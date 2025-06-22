using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoodifyCore.Data;
using MoodifyCore.DTO;
using MoodifyCore.Services;

namespace MoodifyCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService feedbackService;
        private readonly IMapper mapper;

        public FeedbackController(IFeedbackService feedbackService, IMapper mapper)
        {
            this.feedbackService = feedbackService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = feedbackService.GetById(id);
            if (entity == null)
                return NotFound();

            var dto = mapper.Map<FeedbackDto>(entity);
            return Ok(dto);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetByUser(int userId)
        {
            var feedbacks = feedbackService.GetFeedbacksByUser(userId);
            if (feedbacks == null)
                return NotFound();

            var dtoList = mapper.Map<List<FeedbackDto>>(feedbacks);
            return Ok(dtoList);
        }

        [HttpPost]
        public IActionResult Add([FromBody] FeedbackCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = mapper.Map<Feedback>(dto);
            feedbackService.AddFeedback(entity);

            var resultDto = mapper.Map<FeedbackDto>(entity);
            return Ok(resultDto);
        }
    }
} 