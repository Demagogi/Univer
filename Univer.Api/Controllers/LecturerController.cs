using MediatR;
using Microsoft.AspNetCore.Mvc;
using Univer.Application.Dtos;
using Univer.Application.Lecturers.Commands;
using Univer.Application.Lecturers.Queries;

namespace Univer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerController : ControllerBase
    {
        private readonly ISender _mediator;
        public LecturerController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LecturerDto>>> GetLecturersAsync()
        {
            var lecturersDtos = await _mediator.Send(new GetLecturersQuery());

            return Ok(lecturersDtos);
        }

        [HttpGet("{id}", Name = nameof(GetLecturerAsync))]
        public async Task<ActionResult<LecturerDto>> GetLecturerAsync(Guid id)
        {
            return Ok(await _mediator.Send(new GetLecturerQuery(id)));
        }

        [HttpPost(Name = nameof(Create))]
        public async Task<ActionResult> Create([FromBody] CreateLecturerCommand command)
        {
            var newLecturerId = await _mediator.Send(command);

            return Ok(newLecturerId);
        }

        [HttpPut(Name = nameof(Update))]
        public async Task<ActionResult> Update([FromBody] UpdateLecturerCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = nameof(Delete))]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteLecturerCommand(id));

            return NoContent();
        }
    }
}
