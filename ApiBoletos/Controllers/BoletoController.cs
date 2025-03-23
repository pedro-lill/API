
using Microsoft.AspNetCore.Mvc;
using BoletoAPI.Data;
using BoletoAPI.DTOs;
using BoletoAPI.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BoletoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BoletoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoleto(BoletoDTO boletoDto)
        {
            var boleto = _mapper.Map<Boleto>(boletoDto);

            _context.Boletos.Add(boleto);
            await _context.SaveChangesAsync();

            var boletoDtoResult = _mapper.Map<BoletoDTO>(boleto);

            return Ok(boletoDtoResult);
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

            var boletoDto = _mapper.Map<BoletoDTO>(boleto);

            return Ok(boletoDto);
        }
    }
}
