using Backend.Models.Sample;
using Backend.Services.Samples;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Samples;

[ApiController]
[Route("api/sample")]
public class SampleController : ControllerBase
{
    private readonly ISampleService _sampleService;

    public SampleController(ISampleService sampleService)
    {
        _sampleService = sampleService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sample>>> GetSamples()
    {
        var data = await _sampleService.GetSamples();
        if (data == null || !data.Any())
        {
            return NotFound("No clients found");
        }

        return Ok(data);
    }

    [HttpPost]
    public async Task<ActionResult<Sample>> CreateSample(Sample sample)
    {
        var data = await _sampleService.CreateSample(sample);
        if (data == null)
        {
            return BadRequest("Failed to create sample");
        }

        return Ok(data);
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<Sample>> UpdateSample(Sample sample, int id)
    {
        var data = await _sampleService.UpdateSample(sample, id);
        if (data == null)
        {
            return NotFound("no Client with this id");
        }

        return Ok(data);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Sample>> DeleteSample(int id)
    {
        var result = await _sampleService.DeleteSample(id);
        if (result is null)
        {
            return NotFound("Client not found");
        }

        return Ok("Client Deleted");
    }
}