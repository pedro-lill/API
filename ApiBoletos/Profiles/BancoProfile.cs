using AutoMapper;
using BoletoAPI.Models;
using BoletoAPI.DTOs;

namespace BoletoAPI.Profiles
{
    public class BancoProfile : Profile
    {
        public BancoProfile()
        {
            CreateMap<Banco, BancoDTO>();
            CreateMap<BancoDTO, Banco>();
        }
    }
}