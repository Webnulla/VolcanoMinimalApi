namespace VolcanoAPI.Data;

public class VolcanoRepository : IVolcanoRepository
{
    private readonly VolcanoDb _context;

    public VolcanoRepository(VolcanoDb context)
    {
        _context = context;
    }

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        _disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public Task<List<Volcano>> GetVolcanoAsync() => _context.Volcanos.ToListAsync();

    public async Task<Volcano> GetVolcanoAsync(int volcanoId) => await _context.Volcanos.FindAsync(new object[] {volcanoId});

    public async Task InsertVolcanoAsync(Volcano volcano) => await _context.Volcanos.AddAsync(volcano);

    public async Task UpdateVolcanoAsync(Volcano volcano)
    {
        var volcanoFromDb = await _context.Volcanos.FindAsync(new object[] {volcano.Id});
        if (volcanoFromDb == null)
        {
            return;
        }

        volcanoFromDb.Latitude = volcano.Latitude;
        volcanoFromDb.Longitude = volcano.Longitude;
        volcanoFromDb.Name = volcano.Name;
    }

    public async Task DeleteVolcanoAsync(int volcanoId)
    {
        var volcanoFromDb = await _context.Volcanos.FindAsync(new object[] {volcanoId});
        if (volcanoFromDb == null)
        {
            return;
        }

        _context.Volcanos.Remove(volcanoFromDb);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}