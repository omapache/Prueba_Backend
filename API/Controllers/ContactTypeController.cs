using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ContactTypeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ContactTypeDto>>> Get11()
        {
            var ContactTypes = await _unitOfWork.ContactTypes.GetAllAsync();
            return _mapper.Map<List<ContactTypeDto>>(ContactTypes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactTypeDto>> Get(int id)
        {
            var ContactType = await _unitOfWork.ContactTypes.GetByIdAsync(id);
            if (ContactType == null)
                return NotFound(new ApiResponse(404, $"El ContactType solicitado no existe."));

            return _mapper.Map<ContactTypeDto>(ContactType);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactType>> Post(ContactTypeDto ContactTypeDto)
        {
            var ContactType = _mapper.Map<ContactType>(ContactTypeDto);
            _unitOfWork.ContactTypes.Add(ContactType);
            await _unitOfWork.SaveAsync();
            if (ContactType == null)
                return BadRequest(new ApiResponse(400));

            ContactTypeDto.Id = ContactType.Id;
            return CreatedAtAction(nameof(Post), new { id = ContactTypeDto.Id }, ContactTypeDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactTypeDto>> Put(int id, [FromBody] ContactTypeDto ContactTypeDto)
        {
            if (ContactTypeDto == null)
                return NotFound(new ApiResponse(404, $"El ContactType solicitado no existe."));

            var ContactTypeBd = await _unitOfWork.ContactTypes.GetByIdAsync(id);
            if (ContactTypeBd == null)
                return NotFound(new ApiResponse(404, $"El ContactType solicitado no existe."));

            var ContactType = _mapper.Map<ContactType>(ContactTypeDto);
            _unitOfWork.ContactTypes.Update(ContactType);
            await _unitOfWork.SaveAsync();
            return ContactTypeDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var ContactType = await _unitOfWork.ContactTypes.GetByIdAsync(id);
            if (ContactType == null)
                return NotFound(new ApiResponse(404, $"El ContactType solicitado no existe."));

            _unitOfWork.ContactTypes.Remove(ContactType);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}