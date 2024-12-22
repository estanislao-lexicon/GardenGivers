using AutoMapper;
using API.Dto;
using API.Models;

namespace API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Offer, OfferDto>();
            CreateMap<OfferDto, Offer>();
            CreateMap<Produce, ProduceDto>();
            CreateMap<ProduceDto, Produce>();
            CreateMap<Request, RequestDto>();
            CreateMap<RequestDto, Request>();
            CreateMap<Transaction, TransactionDto>();
            CreateMap<TransactionDto, Transaction>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
