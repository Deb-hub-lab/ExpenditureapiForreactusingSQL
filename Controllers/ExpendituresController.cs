using AutoMapper;
//using MyExpenditure.Models.dt;
using MyExpenditure.Interfaces;
//using MyExpenditure.Models;
using Microsoft.AspNetCore.Mvc;
//using MyExpenditure.Interfaces;
using MyExpenditure.Model;

namespace MyExpenditure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpendituresController : ControllerBase
    {
        private readonly IExpenditureRepository _repository;
        private readonly IMapper _mapper;

        public ExpendituresController(IExpenditureRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Expenditures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenditureDto>>> GetExpenditures()
        {
            var expenditures = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ExpenditureDto>>(expenditures));
        }

        // GET: api/Expenditures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenditureDto>> GetExpenditure(int id)
        {
            var expenditure = await _repository.GetByIdAsync(id);
            if (expenditure == null)
            {
                return NotFound();
            }
            return _mapper.Map<ExpenditureDto>(expenditure);
        }

        // POST: api/Expenditures
        [HttpPost]
        public async Task<ActionResult<ExpenditureDto>> PostExpenditure(ExpenditureCreateDto expenditureCreateDto)
        {
            var expenditure = _mapper.Map<Expenditure>(expenditureCreateDto);
            await _repository.AddAsync(expenditure);
            var expenditureDto = _mapper.Map<ExpenditureDto>(expenditure);
            return CreatedAtAction(nameof(GetExpenditure), new { id = expenditureDto.Id }, expenditureDto);
        }

        // PUT: api/Expenditures/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpenditure(int id, ExpenditureUpdateDto expenditureUpdateDto)
        {
            if (!await _repository.ExistsAsync(id))
            {
                return NotFound();
            }

            var expenditure = _mapper.Map<Expenditure>(expenditureUpdateDto);
            expenditure.Id = id;

            await _repository.UpdateAsync(expenditure);
            return NoContent();
        }

        // DELETE: api/Expenditures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpenditure(int id)
        {
            var expenditure = await _repository.GetByIdAsync(id);
            if (expenditure == null)
            {
                return NotFound();
            }
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }

   
}