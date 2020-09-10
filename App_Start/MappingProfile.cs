using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vid.Dtos;
using Vid.Models;

namespace Vid.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore()).ForMember(c => c.DateAdded, opt => opt.Ignore());
        }
    }
}