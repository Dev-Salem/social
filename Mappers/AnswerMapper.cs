using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using social.Dtos;
using social.Models;

namespace social.Mappers
{
    public class AnswerMapper : Profile
    {
        public AnswerMapper()
        {
            CreateMap<AnswerDTO, Answer>();
            CreateMap<Answer, AnswerDTO>();
            CreateMap<AnswerGetDTO, Answer>();
            CreateMap<Answer, AnswerGetDTO>();
            CreateMap<Answer, PostAnswerDTO>();
        }
    }
}
