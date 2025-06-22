using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoodifyCore.Data;
using MoodifyCore.DTO;
using MoodifyCore.Services;

namespace MoodifyCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorDataController : ControllerBase
    {
        private readonly ISensorDataService sensorDataService;
        private readonly IMapper mapper;

        public SensorDataController(ISensorDataService sensorDataService, IMapper mapper)
        {
            this.sensorDataService = sensorDataService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetSensorDataById(int id)
        {
            var entity = sensorDataService.GetSensorDataById(id);
            if (entity == null)
                return NotFound();

            var dto = mapper.Map<SensorDataDto>(entity);
            return Ok(dto);
        }

        [HttpGet("sensorDataByUser/{userId}")]
        public IActionResult GetListOfSensorDataByUser(int userId)
        {
            var entities = sensorDataService.GetListOfSensorDataByUser(userId);
            var dtoList = mapper.Map<List<SensorDataDto>>(entities);
            return Ok(dtoList);
        }

        [HttpPost]
        public IActionResult Create([FromBody] SensorDataCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = mapper.Map<SensorData>(dto);
            sensorDataService.CreateSensorData(entity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            sensorDataService.DeleteSensorData(id);
            return Ok();
        }
    }
}
