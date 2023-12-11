using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllAsync()
        {
            var Employees = await _unitOfWork.Employees.GetAllAsync();
            return _mapper.Map<List<EmployeeDto>>(Employees);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeDto>> Get(int id)
        {
            var Employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (Employee == null)
                return NotFound(new ApiResponse(404, $"El Employee solicitado no existe."));

            return _mapper.Map<EmployeeDto>(Employee);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee>> Post(EmployeeDto EmployeeDto)
        {
            var Employee = _mapper.Map<Employee>(EmployeeDto);
            _unitOfWork.Employees.Add(Employee);
            await _unitOfWork.SaveAsync();
            if (Employee == null)
                return BadRequest(new ApiResponse(400));

            EmployeeDto.Id = Employee.Id;
            return CreatedAtAction(nameof(Post), new { id = EmployeeDto.Id }, EmployeeDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmployeeDto>> Put(int id, [FromBody] EmployeeDto EmployeeDto)
        {
            if (EmployeeDto == null)
                return NotFound(new ApiResponse(404, $"El Employee solicitado no existe."));

            var EmployeeBd = await _unitOfWork.Employees.GetByIdAsync(id);
            if (EmployeeBd == null)
                return NotFound(new ApiResponse(404, $"El Employee solicitado no existe."));

            var Employee = _mapper.Map<Employee>(EmployeeDto);
            _unitOfWork.Employees.Update(Employee);
            await _unitOfWork.SaveAsync();
            return EmployeeDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (Employee == null)
                return NotFound(new ApiResponse(404, $"El Employee solicitado no existe."));

            _unitOfWork.Employees.Remove(Employee);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}