using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CityController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CityDto>>> Get11()
        {
            var Citys = await _unitOfWork.Cities.GetAllAsync();
            return _mapper.Map<List<CityDto>>(Citys);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CityDto>> Get(int id)
        {
            var City = await _unitOfWork.Cities.GetByIdAsync(id);
            if (City == null)
                return NotFound(new ApiResponse(404, $"El City solicitado no existe."));

            return _mapper.Map<CityDto>(City);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<City>> Post(CityDto CityDto)
        {
            var City = _mapper.Map<City>(CityDto);
            _unitOfWork.Cities.Add(City);
            await _unitOfWork.SaveAsync();
            if (City == null)
                return BadRequest(new ApiResponse(400));

            CityDto.Id = City.Id;
            return CreatedAtAction(nameof(Post), new { id = CityDto.Id }, CityDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CityDto>> Put(int id, [FromBody] CityDto CityDto)
        {
            if (CityDto == null)
                return NotFound(new ApiResponse(404, $"El City solicitado no existe."));

            var CityBd = await _unitOfWork.Cities.GetByIdAsync(id);
            if (CityBd == null)
                return NotFound(new ApiResponse(404, $"El City solicitado no existe."));

            var City = _mapper.Map<City>(CityDto);
            _unitOfWork.Cities.Update(City);
            await _unitOfWork.SaveAsync();
            return CityDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var City = await _unitOfWork.Cities.GetByIdAsync(id);
            if (City == null)
                return NotFound(new ApiResponse(404, $"El City solicitado no existe."));

            _unitOfWork.Cities.Remove(City);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}