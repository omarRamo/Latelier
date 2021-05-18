using AutoMapper;
using CatMash.API.Messages;
using CatMash.API.Models;
using CatMash.DataAccess.Entities;

namespace CatMash.API.Utility
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<TCatPicture, CatPicture>();
            CreateMap<VoteRequest, TVote>();
        }
    }
}
