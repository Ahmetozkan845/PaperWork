using Microsoft.AspNetCore.Mvc;
using PaperWork.Api.Entitty;
using PaperWork.Api.Services;

namespace PaperWork.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaperWorkController : ControllerBase
    {
        private readonly IPaperWorkService _service;
        public PaperWorkController(IPaperWorkService service) => _service = service;

 
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? pwId, CancellationToken ct)
        {
            if (!string.IsNullOrWhiteSpace(pwId))
            {
                var item = await _service.GetAsync(pwId, ct);
                return item is null ? NotFound() : Ok(item);
            }

            var list = await _service.ListAsync(ct);
            return Ok(list);
        }

    
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PaperWorkEntity body, CancellationToken ct)
        {
            var (ok, error, created) = await _service.CreateAsync(body, ct);
            if (!ok) return Conflict(error);
            return CreatedAtAction(nameof(Get), new { pwId = created!.PWId }, created);
        }

        [HttpPut("{pwId}")]
        public async Task<IActionResult> Update([FromRoute] string pwId, [FromBody] PaperWorkEntity body, CancellationToken ct)
        {
            var (ok, error, updated) = await _service.UpdateAsync(pwId, body, ct);
            if (!ok) return NotFound(error);
            return Ok(updated);
        }
    }
}
