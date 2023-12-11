using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ShiftController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShiftController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ShiftDto>>> Get11()
        {
            var Shifts = await _unitOfWork.Shifts.GetAllAsync();
            return _mapper.Map<List<ShiftDto>>(Shifts);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ShiftDto>> Get(int id)
        {
            var Shift = await _unitOfWork.Shifts.GetByIdAsync(id);
            if (Shift == null)
                return NotFound(new ApiResponse(404, $"El Shift solicitado no existe."));

            return _mapper.Map<ShiftDto>(Shift);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Shift>> Post(ShiftDto ShiftDto)
        {
            var Shift = _mapper.Map<Shift>(ShiftDto);
            _unitOfWork.Shifts.Add(Shift);
            await _unitOfWork.SaveAsync();
            if (Shift == null)
                return BadRequest(new ApiResponse(400));

            ShiftDto.Id = Shift.Id;
            return CreatedAtAction(nameof(Post), new { id = ShiftDto.Id }, ShiftDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ShiftDto>> Put(int id, [FromBody] ShiftDto ShiftDto)
        {
            if (ShiftDto == null)
                return NotFound(new ApiResponse(404, $"El Shift solicitado no existe."));

            var ShiftBd = await _unitOfWork.Shifts.GetByIdAsync(id);
            if (ShiftBd == null)
                return NotFound(new ApiResponse(404, $"El Shift solicitado no existe."));

            var Shift = _mapper.Map<Shift>(ShiftDto);
            _unitOfWork.Shifts.Update(Shift);
            await _unitOfWork.SaveAsync();
            return ShiftDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Shift = await _unitOfWork.Shifts.GetByIdAsync(id);
            if (Shift == null)
                return NotFound(new ApiResponse(404, $"El Shift solicitado no existe."));

            _unitOfWork.Shifts.Remove(Shift);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}