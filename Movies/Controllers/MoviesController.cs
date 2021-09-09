using System.Threading.Tasks;
using Kafka;
using Microsoft.AspNetCore.Mvc;
using Movies.DTOs;

namespace Movies.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MoviesController : ControllerBase
    {
        public MoviesController()
        {
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] MovieDTO movieDTO)
        {
            var producer = new Dispatcher<LogDTO>();
            var log = new LogDTO() { Action = $"{movieDTO.Name} criado" };

            await producer.Send("LOG_CREATED", log);

            return CreatedAtAction(nameof(Create), new { Id = 1 }, movieDTO);
        }
    }
}
