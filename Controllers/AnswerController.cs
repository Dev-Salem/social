using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using social.Dtos;
using social.Interfaces;
using social.Models;

namespace social.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController(IMapper mapper, IBaseService<Answer> service) : ControllerBase
    {
        private readonly IBaseService<Answer> _service = service;
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        [Route("{postId:int}")]
        public async Task<IActionResult> Create([FromRoute] int postId, [FromBody] AnswerDTO body)
        {
            var answer = await _service.CreateAsync(
                new Answer() { PostId = postId, Content = body.Content }
            );
            if (answer == null)
                return NotFound();
            return CreatedAtAction(
                nameof(GetById),
                new { id = answer.Id },
                _mapper.Map<AnswerGetDTO>(answer)
            );
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var answer = await _service.DeleteAsync(id);
            return answer == null ? NotFound() : NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var answers = await _service.GetAllAsync(null);
            return Ok(answers);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var answer = await _service.GetByIdAsync(id);
            return answer == null ? NotFound() : Ok(_mapper.Map<AnswerGetDTO>(answer));
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AnswerDTO answerDTO)
        {
            var answer = await _service.UpdateAsync(id, answerDTO);
            return answer == null ? NotFound() : Ok(answer);
        }
    }
}
