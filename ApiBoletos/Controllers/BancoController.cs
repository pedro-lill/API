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
    public class BancoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BancoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanco(BancoDTO bancoDto)
        {
            var banco = _mapper.Map<Banco>(bancoDto);

            _context.Bancos.Add(banco);
            await _context.SaveChangesAsync();

            var bancoDtoResult = _mapper.Map<BancoDTO>(banco);

            return Ok(bancoDtoResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBancos()
        {
            var bancos = await _context.Bancos.ToListAsync();

            var bancosDto = _mapper.Map<List<BancoDTO>>(bancos);

            return Ok(bancosDto);
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetBancoByCodigo(int codigo)
        {
            var banco = await _context.Bancos
                .FirstOrDefaultAsync(b => b.CodigoBanco == codigo);

            if (banco == null) return NotFound();

            var bancoDto = _mapper.Map<BancoDTO>(banco);

            return Ok(bancoDto);
        }
    }
}
