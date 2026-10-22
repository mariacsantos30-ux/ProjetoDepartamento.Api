using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoDepartamento.Api.Data;
using ProjetoDepartamento.Api.DTOs;
using ProjetoDepartamento.Api.Models;

namespace ProjetoDepartamento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly AppDbContext _Context;
        public FuncionariosController(AppDbContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioDepartamentoDto>>> GetDepartamentos()
        {
            return await _Context.Funcionarios.Include(f => f.Departamento). Select(f => new FuncionarioDepartamentoDto 
            {
                NomeFuncionario = f.Nome, 
                NomeDepartamento = f.Departamento.Nome
            }).ToListAsync();
           
        }
        [HttpGet("info")]
        public async Task<ActionResult<IEnumerable<FuncionarioINFODto>>> GetINFOFuncionarios()
        {
            return await _Context.Funcionarios 
                .Include(f => f.Departamento)
                .Select(f => new FuncionarioINFODto
                {
                    Nome = f.Nome,
                    Salario = f.Salario,
                    NomeDepartamento = f.Departamento.Nome,
                    DepartamentoId = f.DepartamentoId
                })
                .ToListAsync();
           
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarFuncionario(CriarFuncionarioDto funcionarioDto)
        {
            var novoFuncionario = new Funcionario
            {
               Nome = funcionarioDto.Nome,
               CPF = funcionarioDto.CPF,
               Salario = funcionarioDto.Salario,
               DepartamentoId = funcionarioDto.DepartamentoId

            };

            _Context.Funcionarios.Add(novoFuncionario);
            await _Context.SaveChangesAsync();
            return Ok("Funcionario adicionado com sucesso!");
        }
    }
}
