using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIv6.Data;
using WebAPIv6.Models;

namespace WebAPIv6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;

        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores!.FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("O professor não foi encontrado");
            return Ok(professor);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var professor = _context.Professores!.FirstOrDefault(a =>
                a.Nome!.ToUpper().Contains(nome.ToUpper()));
            if (professor == null) return BadRequest("O professor não foi encontrado");
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var alu = _context.Professores!.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("O professor não foi encontrado");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var alu = _context.Professores!.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("O professor não foi encontrado");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores!.FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("O professor não foi encontrado");
            _context.Remove(professor);
            _context.SaveChanges();
            return Ok();
        }

    }
}