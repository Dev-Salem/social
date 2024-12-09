using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using social.Dtos;
using social.Interfaces;
using social.Models;

namespace social.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController(IMapper mapper, IBaseService<Tag> service) : ControllerBase
    {
        private readonly IBaseService<Tag> _service = service;
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TagCreateUpdateDTO body)
        {
            var tag = await _service.CreateAsync(new Tag() { Name = body.Name });
            return CreatedAtAction(nameof(GetById), new { id = tag!.Id }, tag);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var tag = await _service.DeleteAsync(id);
            return tag == null ? NotFound() : NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tags = await _service.GetAllAsync(null);
            return Ok(_mapper.Map<IEnumerable<TagGetDTO>>(tags));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var tag = await _service.GetByIdAsync(id);
            return tag == null ? NotFound() : Ok(_mapper.Map<TagDTO>(tag));
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] TagCreateUpdateDTO tagDTO
        )
        {
            var tag = await _service.UpdateAsync(id, tagDTO);
            return tag == null ? NotFound() : Ok(tag);
        }
    }
}
