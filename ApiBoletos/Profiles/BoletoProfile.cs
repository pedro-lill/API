using AutoMapper;
using BoletoAPI.Models;
using BoletoAPI.DTOs;

namespace BoletoAPI.Profiles
{
    public class BoletoProfile : Profile
    {
        public BoletoProfile()
        {
            CreateMap<Boleto, BoletoDTO>();
            CreateMap<BoletoDTO, Boleto>();
        }
    }
}