using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ContactPersonController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactPersonController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ContactPersonDto>>> Get11()
        {
            var ContactPersons = await _unitOfWork.ContactPersons.GetAllAsync();
            return _mapper.Map<List<ContactPersonDto>>(ContactPersons);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactPersonDto>> Get(int id)
        {
            var ContactPerson = await _unitOfWork.ContactPersons.GetByIdAsync(id);
            if (ContactPerson == null)
                return NotFound(new ApiResponse(404, $"El ContactPerson solicitado no existe."));

            return _mapper.Map<ContactPersonDto>(ContactPerson);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactPerson>> Post(ContactPersonDto ContactPersonDto)
        {
            var ContactPerson = _mapper.Map<ContactPerson>(ContactPersonDto);
            _unitOfWork.ContactPersons.Add(ContactPerson);
            await _unitOfWork.SaveAsync();
            if (ContactPerson == null)
                return BadRequest(new ApiResponse(400));

            ContactPersonDto.Id = ContactPerson.Id;
            return CreatedAtAction(nameof(Post), new { id = ContactPersonDto.Id }, ContactPersonDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactPersonDto>> Put(int id, [FromBody] ContactPersonDto ContactPersonDto)
        {
            if (ContactPersonDto == null)
                return NotFound(new ApiResponse(404, $"El ContactPerson solicitado no existe."));

            var ContactPersonBd = await _unitOfWork.ContactPersons.GetByIdAsync(id);
            if (ContactPersonBd == null)
                return NotFound(new ApiResponse(404, $"El ContactPerson solicitado no existe."));

            var ContactPerson = _mapper.Map<ContactPerson>(ContactPersonDto);
            _unitOfWork.ContactPersons.Update(ContactPerson);
            await _unitOfWork.SaveAsync();
            return ContactPersonDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var ContactPerson = await _unitOfWork.ContactPersons.GetByIdAsync(id);
            if (ContactPerson == null)
                return NotFound(new ApiResponse(404, $"El ContactPerson solicitado no existe."));

            _unitOfWork.ContactPersons.Remove(ContactPerson);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}