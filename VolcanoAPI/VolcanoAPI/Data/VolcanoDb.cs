namespace VolcanoAPI.Data
{
    public class VolcanoDb : DbContext
    {
        public VolcanoDb(DbContextOptions<VolcanoDb> options) : base(options) { }
        public DbSet<Volcano> Volcanos => Set<Volcano>();
    }
}
