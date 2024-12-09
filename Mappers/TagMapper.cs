using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using social.Dtos;
using social.Models;

namespace social.Mappers
{
    public class TagMapper : Profile
    {
        public TagMapper()
        {
            CreateMap<Tag, TagCreateUpdateDTO>();
            CreateMap<TagCreateUpdateDTO, Tag>();
            CreateMap<Tag, TagDTO>();
            CreateMap<TagDTO, Tag>();
            CreateMap<Tag, TagGetDTO>();
        }
    }
}
