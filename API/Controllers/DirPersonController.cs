using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DirPersonController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DirPersonController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DirPersonDto>>> Get11()
        {
            var DirPersons = await _unitOfWork.DirPersons.GetAllAsync();
            return _mapper.Map<List<DirPersonDto>>(DirPersons);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DirPersonDto>> Get(int id)
        {
            var DirPerson = await _unitOfWork.DirPersons.GetByIdAsync(id);
            if (DirPerson == null)
                return NotFound(new ApiResponse(404, $"El DirPerson solicitado no existe."));

            return _mapper.Map<DirPersonDto>(DirPerson);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DirPerson>> Post(DirPersonDto DirPersonDto)
        {
            var DirPerson = _mapper.Map<DirPerson>(DirPersonDto);
            _unitOfWork.DirPersons.Add(DirPerson);
            await _unitOfWork.SaveAsync();
            if (DirPerson == null)
                return BadRequest(new ApiResponse(400));

            DirPersonDto.Id = DirPerson.Id;
            return CreatedAtAction(nameof(Post), new { id = DirPersonDto.Id }, DirPersonDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DirPersonDto>> Put(int id, [FromBody] DirPersonDto DirPersonDto)
        {
            if (DirPersonDto == null)
                return NotFound(new ApiResponse(404, $"El DirPerson solicitado no existe."));

            var DirPersonBd = await _unitOfWork.DirPersons.GetByIdAsync(id);
            if (DirPersonBd == null)
                return NotFound(new ApiResponse(404, $"El DirPerson solicitado no existe."));

            var DirPerson = _mapper.Map<DirPerson>(DirPersonDto);
            _unitOfWork.DirPersons.Update(DirPerson);
            await _unitOfWork.SaveAsync();
            return DirPersonDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var DirPerson = await _unitOfWork.DirPersons.GetByIdAsync(id);
            if (DirPerson == null)
                return NotFound(new ApiResponse(404, $"El DirPerson solicitado no existe."));

            _unitOfWork.DirPersons.Remove(DirPerson);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}