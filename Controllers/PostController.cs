using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using social.Dtos;
using social.Helpers;
using social.Interfaces;
using social.Models;
using social.Services;

namespace social.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController(IMapper mapper, IBaseService<Post> service) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBaseService<Post> _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PostQueryObject query)
        {
            var posts = await _service.GetAllAsync(query);
            return Ok(_mapper.Map<IEnumerable<PostDto>>(posts));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var post = await _service.GetByIdAsync(id);
            return post == null ? NotFound() : Ok(_mapper.Map<PostDto>(post));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostRequestBody body)
        {
            var post = await ((PostService)_service).CreatePostWithTagsAsync(body);
            if (post == null)
                return NotFound();
            return CreatedAtAction(
                nameof(GetById),
                new { id = post.Id },
                _mapper.Map<PostDto>(post)
            );
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PostRequestBody body)
        {
            var post = await _service.UpdateAsync(id, body);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PostDto>(post));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var post = await _service.DeleteAsync(id);
            return post == null ? NotFound() : NoContent();
        }
    }
}
