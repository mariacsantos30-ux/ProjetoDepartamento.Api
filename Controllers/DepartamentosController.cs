using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using ProjetoDepartamento.Api.Data;
using ProjetoDepartamento.Api.Models;
using ProjetoDepartamento.Api.DTOs;

namespace ProjetoDepartamento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly AppDbContext _Context;
        public DepartamentosController(AppDbContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamentos()
        {
            return await _Context.Departamentos.ToListAsync();
        }
        [HttpPost]
        public async  Task<IActionResult> CriarDepartamento(CriarDepartamentoDTO departamentoDto)
        {
            var novoDepartamento = new Departamento
            {
                Nome =  departamentoDto.Nome,
                CodigoAcesso = departamentoDto.CodigoAcesso
            };

            _Context.Departamentos.Add(novoDepartamento);
            await _Context.SaveChangesAsync();
            return Ok("Departamento criado com sucesso!");
        }
    }
         
}
