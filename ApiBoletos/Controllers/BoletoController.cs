using Microsoft.AspNetCore.Mvc;
using BoletoAPI.Data;
using BoletoAPI.Models;
using BoletoAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoletoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BoletoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoleto(BoletoDTO boletoDto)
        {
            var boleto = new Boleto
            {
                NomePagador = boletoDto.NomePagador,
                CpfCnpjPagador = boletoDto.CpfCnpjPagador,
                NomeBeneficiario = boletoDto.NomeBeneficiario,
                CpfCnpjBeneficiario = boletoDto.CpfCnpjBeneficiario,
                Valor = boletoDto.Valor,
                DataVencimento = boletoDto.DataVencimento,
                Observacao = boletoDto.Observacao,
                BancoId = boletoDto.BancoId
            };

            _context.Boletos.Add(boleto);
            await _context.SaveChangesAsync();

            return Ok(boleto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoleto(int id)
        {
            var boleto = await _context.Boletos
                .Include(b => b.Banco)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (boleto == null) return NotFound();

            if (boleto.DataVencimento < DateTime.Now)
            {
                boleto.Valor += boleto.Valor * (boleto.Banco?.PercentualJuros / 100 ?? 0);
            }

            var boletoDto = new BoletoDTO
            {
                Id = boleto.Id,
                NomePagador = boleto.NomePagador,
                CpfCnpjPagador = boleto.CpfCnpjPagador,
                NomeBeneficiario = boleto.NomeBeneficiario,
                CpfCnpjBeneficiario = boleto.CpfCnpjBeneficiario,
                Valor = boleto.Valor,
                DataVencimento = boleto.DataVencimento,
                Observacao = boleto.Observacao,
                BancoId = boleto.BancoId
            };

            return Ok(boletoDto);
        }
    }
}