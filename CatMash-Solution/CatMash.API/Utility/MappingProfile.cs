using AutoMapper;
using CatMash.API.DTO;
using CatMash.API.Messages;
using CatMash.API.Models;
using CatMash.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
