using Microsoft.AspNetCore.Mvc;
using BoletoAPI.Data;
using BoletoAPI.Models;
using BoletoAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoletoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BancoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanco(BancoDTO bancoDto)
        {
            var banco = new Banco
            {
                NomeBanco = bancoDto.NomeBanco,
                CodigoBanco = bancoDto.CodigoBanco,
                PercentualJuros = bancoDto.PercentualJuros
            };

            _context.Bancos.Add(banco);
            await _context.SaveChangesAsync();

            return Ok(banco);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBancos()
        {
            var bancos = await _context.Bancos.ToListAsync();

            var bancosDto = bancos.Select(b => new BancoDTO
            {
                Id = b.Id,
                NomeBanco = b.NomeBanco,
                CodigoBanco = b.CodigoBanco,
                PercentualJuros = b.PercentualJuros
            }).ToList();

            return Ok(bancosDto);
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetBancoByCodigo(int codigo)
        {
            var banco = await _context.Bancos
                .FirstOrDefaultAsync(b => b.CodigoBanco == codigo);

            if (banco == null) return NotFound();

            var bancoDto = new BancoDTO
            {
                Id = banco.Id,
                NomeBanco = banco.NomeBanco,
                CodigoBanco = banco.CodigoBanco,
                PercentualJuros = banco.PercentualJuros
            };

            return Ok(bancoDto);
        }
    }
}