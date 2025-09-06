using Application.Features.Mediator.Commands.ReviewCommands;
using Application.Features.Mediator.Queries.ReviewQueries;
using Application.Validators.ReviewValidators;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewByCarId(int id)
        {
            var values =await _mediator.Send(new GetReviewByCarIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddReview(CreateReviewCommand createReviewCommand)
        {
            CreateReviewValidator validator = new CreateReviewValidator();
            var validationResult = validator.Validate(createReviewCommand);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _mediator.Send(createReviewCommand);
            return Ok("Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand updateReviewCommand)
        {
            await _mediator.Send(updateReviewCommand);
            return Ok("Güncellendi");
        }
    }
}
