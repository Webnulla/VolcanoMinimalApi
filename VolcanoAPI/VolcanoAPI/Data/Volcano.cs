namespace VolcanoAPI.Data
{
    public class Volcano
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
