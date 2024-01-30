using AutoMapper;
using WalletApp.Business.Dto;
using WalletApp.Data.Entities;

namespace WalletApp.Business
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CardBalance, CardDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Transaction, TransactionDto>().ReverseMap();
        }
    }
}
