namespace VolcanoAPI.APIs
{
    public class VolcanoApis
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/volcanos", Get)
                .Produces<List<Volcano>>(StatusCodes.Status200OK)
                .WithName("GetAllVolcano")
                .WithTags("Getters");

            app.MapGet("/volcanos/{id}", GetById)
                .Produces<Volcano>(StatusCodes.Status200OK)
                .WithName("GetVolcano")
                .WithTags("Getters");

            app.MapPost("/volcanos", Post)
                .Accepts<Volcano>("application/json")
                .Produces<Volcano>(StatusCodes.Status201Created)
                .WithName("CreateVolcano")
                .WithTags("Creators");

            app.MapPut("/volcanos", Put)
                .Accepts<Volcano>("application/json")
                .WithName("UpdateVolcano")
                .WithTags("Updaters");

            app.MapDelete("/volcanos/{id}", Delete)
                .WithName("DeleteVolcano")
                .WithTags("Deleters");
        }

        private async Task<IResult> Get(IVolcanoRepository repository)
        {
            return Results.Ok(await repository.GetVolcanoAsync());
        }

        private async Task<IResult> GetById(int id, IVolcanoRepository repository) =>
            await repository.GetVolcanoAsync(id) is Volcano volcano
        ? Results.Ok(volcano)
        : Results.NotFound();

        private async Task<IResult> Put([FromBody] Volcano volcano, IVolcanoRepository repository)
        {
            await repository.UpdateVolcanoAsync(volcano);
            await repository.SaveAsync();
            return Results.NoContent();
        }

        private async Task<IResult> Post([FromBody] Volcano volcano, IVolcanoRepository repository)
        {
            await repository.InsertVolcanoAsync(volcano);
            await repository.SaveAsync();
            return Results.NoContent();
        }

        private async Task<IResult> Delete(int id, IVolcanoRepository repository)
        {
            await repository.DeleteVolcanoAsync(id);
            await repository.SaveAsync();
            return Results.NoContent();
        }
    }
}
