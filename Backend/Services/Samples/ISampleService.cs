using Backend.Models.Sample;

namespace Backend.Services.Samples;

public interface ISampleService
{
    Task<List<Sample>>? GetSamples();
    Task<Sample> CreateSample(Sample sample);
    
    Task<Sample>? UpdateSample(Sample sample, int id);
    Task<Sample>? DeleteSample(int id);
}