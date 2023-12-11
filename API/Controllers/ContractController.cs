using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ContractController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContractController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ContractDto>>> Get11()
        {
            var Contracts = await _unitOfWork.Contracts.GetAllAsync();
            return _mapper.Map<List<ContractDto>>(Contracts);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContractDto>> Get(int id)
        {
            var Contract = await _unitOfWork.Contracts.GetByIdAsync(id);
            if (Contract == null)
                return NotFound(new ApiResponse(404, $"El Contract solicitado no existe."));

            return _mapper.Map<ContractDto>(Contract);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Contract>> Post(ContractDto ContractDto)
        {
            var Contract = _mapper.Map<Contract>(ContractDto);
            _unitOfWork.Contracts.Add(Contract);
            await _unitOfWork.SaveAsync();
            if (Contract == null)
                return BadRequest(new ApiResponse(400));

            ContractDto.Id = Contract.Id;
            return CreatedAtAction(nameof(Post), new { id = ContractDto.Id }, ContractDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContractDto>> Put(int id, [FromBody] ContractDto ContractDto)
        {
            if (ContractDto == null)
                return NotFound(new ApiResponse(404, $"El Contract solicitado no existe."));

            var ContractBd = await _unitOfWork.Contracts.GetByIdAsync(id);
            if (ContractBd == null)
                return NotFound(new ApiResponse(404, $"El Contract solicitado no existe."));

            var Contract = _mapper.Map<Contract>(ContractDto);
            _unitOfWork.Contracts.Update(Contract);
            await _unitOfWork.SaveAsync();
            return ContractDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Contract = await _unitOfWork.Contracts.GetByIdAsync(id);
            if (Contract == null)
                return NotFound(new ApiResponse(404, $"El Contract solicitado no existe."));

            _unitOfWork.Contracts.Remove(Contract);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}