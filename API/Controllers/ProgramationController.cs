using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProgramationController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProgramationController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProgramationDto>>> Get11()
        {
            var Programations = await _unitOfWork.Programations.GetAllAsync();
            return _mapper.Map<List<ProgramationDto>>(Programations);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProgramationDto>> Get(int id)
        {
            var Programation = await _unitOfWork.Programations.GetByIdAsync(id);
            if (Programation == null)
                return NotFound(new ApiResponse(404, $"El Programation solicitado no existe."));

            return _mapper.Map<ProgramationDto>(Programation);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Programation>> Post(ProgramationDto ProgramationDto)
        {
            var Programation = _mapper.Map<Programation>(ProgramationDto);
            _unitOfWork.Programations.Add(Programation);
            await _unitOfWork.SaveAsync();
            if (Programation == null)
                return BadRequest(new ApiResponse(400));

            ProgramationDto.Id = Programation.Id;
            return CreatedAtAction(nameof(Post), new { id = ProgramationDto.Id }, ProgramationDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProgramationDto>> Put(int id, [FromBody] ProgramationDto ProgramationDto)
        {
            if (ProgramationDto == null)
                return NotFound(new ApiResponse(404, $"El Programation solicitado no existe."));

            var ProgramationBd = await _unitOfWork.Programations.GetByIdAsync(id);
            if (ProgramationBd == null)
                return NotFound(new ApiResponse(404, $"El Programation solicitado no existe."));

            var Programation = _mapper.Map<Programation>(ProgramationDto);
            _unitOfWork.Programations.Update(Programation);
            await _unitOfWork.SaveAsync();
            return ProgramationDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Programation = await _unitOfWork.Programations.GetByIdAsync(id);
            if (Programation == null)
                return NotFound(new ApiResponse(404, $"El Programation solicitado no existe."));

            _unitOfWork.Programations.Remove(Programation);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}