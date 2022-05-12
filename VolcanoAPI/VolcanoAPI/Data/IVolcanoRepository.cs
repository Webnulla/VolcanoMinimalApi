namespace VolcanoAPI.Data;

public interface IVolcanoRepository : IDisposable
{
    Task<List<Volcano>> GetVolcanoAsync();
    Task<Volcano> GetVolcanoAsync(int volcanoId);
    Task InsertVolcanoAsync(Volcano volcano);
    Task UpdateVolcanoAsync(Volcano volcano);
    Task DeleteVolcanoAsync(int volcanoId);
    Task SaveAsync();
}