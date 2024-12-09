using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using social.Dtos;
using social.Models;

namespace social.Mappers
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
            CreateMap<PostRequestBody, Post>();
            CreateMap<Post, PostRequestBody>();
        }
    }
}
