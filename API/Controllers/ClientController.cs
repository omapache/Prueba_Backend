using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ClientController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClientDto>>> Get11()
        {
            var Clients = await _unitOfWork.Clients.GetAllAsync();
            return _mapper.Map<List<ClientDto>>(Clients);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClientDto>> Get(int id)
        {
            var Client = await _unitOfWork.Clients.GetByIdAsync(id);
            if (Client == null)
                return NotFound(new ApiResponse(404, $"El Client solicitado no existe."));

            return _mapper.Map<ClientDto>(Client);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Client>> Post(ClientDto ClientDto)
        {
            var Client = _mapper.Map<Client>(ClientDto);
            _unitOfWork.Clients.Add(Client);
            await _unitOfWork.SaveAsync();
            if (Client == null)
                return BadRequest(new ApiResponse(400));

            ClientDto.Id = Client.Id;
            return CreatedAtAction(nameof(Post), new { id = ClientDto.Id }, ClientDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClientDto>> Put(int id, [FromBody] ClientDto ClientDto)
        {
            if (ClientDto == null)
                return NotFound(new ApiResponse(404, $"El Client solicitado no existe."));

            var ClientBd = await _unitOfWork.Clients.GetByIdAsync(id);
            if (ClientBd == null)
                return NotFound(new ApiResponse(404, $"El Client solicitado no existe."));

            var Client = _mapper.Map<Client>(ClientDto);
            _unitOfWork.Clients.Update(Client);
            await _unitOfWork.SaveAsync();
            return ClientDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Client = await _unitOfWork.Clients.GetByIdAsync(id);
            if (Client == null)
                return NotFound(new ApiResponse(404, $"El Client solicitado no existe."));

            _unitOfWork.Clients.Remove(Client);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}