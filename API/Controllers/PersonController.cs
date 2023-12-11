using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PersonController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonDto>>> Get11()
        {
            var Persons = await _unitOfWork.Persons.GetAllAsync();
            return _mapper.Map<List<PersonDto>>(Persons);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonDto>> Get(int id)
        {
            var Person = await _unitOfWork.Persons.GetByIdAsync(id);
            if (Person == null)
                return NotFound(new ApiResponse(404, $"El Person solicitado no existe."));

            return _mapper.Map<PersonDto>(Person);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Person>> Post(PersonDto PersonDto)
        {
            var Person = _mapper.Map<Person>(PersonDto);
            _unitOfWork.Persons.Add(Person);
            await _unitOfWork.SaveAsync();
            if (Person == null)
                return BadRequest(new ApiResponse(400));

            PersonDto.Id = Person.Id;
            return CreatedAtAction(nameof(Post), new { id = PersonDto.Id }, PersonDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonDto>> Put(int id, [FromBody] PersonDto PersonDto)
        {
            if (PersonDto == null)
                return NotFound(new ApiResponse(404, $"El Person solicitado no existe."));

            var PersonBd = await _unitOfWork.Persons.GetByIdAsync(id);
            if (PersonBd == null)
                return NotFound(new ApiResponse(404, $"El Person solicitado no existe."));

            var Person = _mapper.Map<Person>(PersonDto);
            _unitOfWork.Persons.Update(Person);
            await _unitOfWork.SaveAsync();
            return PersonDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Person = await _unitOfWork.Persons.GetByIdAsync(id);
            if (Person == null)
                return NotFound(new ApiResponse(404, $"El Person solicitado no existe."));

            _unitOfWork.Persons.Remove(Person);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}