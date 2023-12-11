
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StateController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StateController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<StateDto>>> Get11()
        {
            var States = await _unitOfWork.States.GetAllAsync();
            return _mapper.Map<List<StateDto>>(States);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StateDto>> Get(int id)
        {
            var State = await _unitOfWork.States.GetByIdAsync(id);
            if (State == null)
                return NotFound(new ApiResponse(404, $"El State solicitado no existe."));

            return _mapper.Map<StateDto>(State);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<State>> Post(StateDto StateDto)
        {
            var State = _mapper.Map<State>(StateDto);
            _unitOfWork.States.Add(State);
            await _unitOfWork.SaveAsync();
            if (State == null)
                return BadRequest(new ApiResponse(400));

            StateDto.Id = State.Id;
            return CreatedAtAction(nameof(Post), new { id = StateDto.Id }, StateDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<StateDto>> Put(int id, [FromBody] StateDto StateDto)
        {
            if (StateDto == null)
                return NotFound(new ApiResponse(404, $"El State solicitado no existe."));

            var StateBd = await _unitOfWork.States.GetByIdAsync(id);
            if (StateBd == null)
                return NotFound(new ApiResponse(404, $"El State solicitado no existe."));

            var State = _mapper.Map<State>(StateDto);
            _unitOfWork.States.Update(State);
            await _unitOfWork.SaveAsync();
            return StateDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var State = await _unitOfWork.States.GetByIdAsync(id);
            if (State == null)
                return NotFound(new ApiResponse(404, $"El State solicitado no existe."));

            _unitOfWork.States.Remove(State);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}