using Backend.Data;
using Backend.Models.Sample;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Samples;

public class SampleService : ISampleService
{
    private DataContext _context;

    public SampleService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Sample>> GetSamples()
    {
        return await _context.Samples.ToListAsync();
    }

    public async Task<Sample> CreateSample(Sample sample)
    {
        _context.Samples.Add(sample);
        await _context.SaveChangesAsync();
        return sample;
    }

    public async Task<Sample>? UpdateSample(Sample sample, int id)
    {
        var sampleToUpdate = await _context.Samples.FindAsync(id);
        if (sampleToUpdate == null)
        {
            return null;
        }

        sampleToUpdate.receiving_party = sample.receiving_party;
        sampleToUpdate.client_name = sample.client_name;
        sampleToUpdate.date = sample.date;
        sampleToUpdate.description = sample.description;
        sampleToUpdate.qutaity = sample.qutaity;
        sampleToUpdate.extra = sample.extra;
        sampleToUpdate.price = sample.price;
        sampleToUpdate.status = sample.status;
        
        await _context.SaveChangesAsync();
        return sampleToUpdate;
    }


    public async Task<Sample>? DeleteSample(int id)
    {
        var sampleToDelete = await _context.Samples.FindAsync(id);
        if (sampleToDelete == null)
        {
            return null;
        }

        _context.Samples.Remove(sampleToDelete);
        await _context.SaveChangesAsync();
        return sampleToDelete;
    }
}