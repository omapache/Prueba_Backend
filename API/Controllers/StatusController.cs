using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StatusController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StatusController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<StatusDto>>> Get11()
        {
            var Statuss = await _unitOfWork.Statuses.GetAllAsync();
            return _mapper.Map<List<StatusDto>>(Statuss);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StatusDto>> Get(int id)
        {
            var Status = await _unitOfWork.Statuses.GetByIdAsync(id);
            if (Status == null)
                return NotFound(new ApiResponse(404, $"El Status solicitado no existe."));

            return _mapper.Map<StatusDto>(Status);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Status>> Post(StatusDto StatusDto)
        {
            var Status = _mapper.Map<Status>(StatusDto);
            _unitOfWork.Statuses.Add(Status);
            await _unitOfWork.SaveAsync();
            if (Status == null)
                return BadRequest(new ApiResponse(400));

            StatusDto.Id = Status.Id;
            return CreatedAtAction(nameof(Post), new { id = StatusDto.Id }, StatusDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<StatusDto>> Put(int id, [FromBody] StatusDto StatusDto)
        {
            if (StatusDto == null)
                return NotFound(new ApiResponse(404, $"El Status solicitado no existe."));

            var StatusBd = await _unitOfWork.Statuses.GetByIdAsync(id);
            if (StatusBd == null)
                return NotFound(new ApiResponse(404, $"El Status solicitado no existe."));

            var Status = _mapper.Map<Status>(StatusDto);
            _unitOfWork.Statuses.Update(Status);
            await _unitOfWork.SaveAsync();
            return StatusDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Status = await _unitOfWork.Statuses.GetByIdAsync(id);
            if (Status == null)
                return NotFound(new ApiResponse(404, $"El Status solicitado no existe."));

            _unitOfWork.Statuses.Remove(Status);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}