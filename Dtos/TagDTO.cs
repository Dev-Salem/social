using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace social.Dtos
{
    public record TagDTO(int Id, string Name, List<PostRequestBody> Posts) : IBaseDTO;

    public record TagCreateUpdateDTO(string Name) : IBaseDTO;

    public record TagGetDTO(int Id, string Name) : IBaseDTO;
}
