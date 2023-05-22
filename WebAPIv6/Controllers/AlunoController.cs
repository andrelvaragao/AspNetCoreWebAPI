using Microsoft.AspNetCore.Mvc;
using WebAPIv6.Models;
using WebAPIv6.Data;
using Microsoft.EntityFrameworkCore;

namespace WebAPIv6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private IRepository _repo { get; set; }

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("O aluno não foi encontrado");
            return Ok(aluno);
        }

        // [HttpGet("ByName")]
        // public IActionResult GetByName(string nome, string Sobrenome)
        // {
        //     var aluno = _context.Alunos!.FirstOrDefault(a =>
        //         a.Nome!.ToUpper().Contains(nome.ToUpper()) && a.Sobrenome!.ToUpper().Contains(Sobrenome.ToUpper())
        //     );
        //     if (aluno == null) return BadRequest("O aluno não foi encontrado");
        //     return Ok(aluno);
        // }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("O aluno não foi encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não atualizado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("O aluno não foi encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("O aluno não foi encontrado");
 
             _repo.Delete(alu);
            if (_repo.SaveChanges())
            {
                return Ok("Aluno excluído");
            }

            return BadRequest("Aluno não excluído");
       }

    }
}