using VolcanoAPI.APIs;var builder = WebApplication.CreateBuilder(args);

RegisterService(builder.Services);

var app = builder.Build();

Configure(app);

new VolcanoApis().Register(app);

app.Run();

void RegisterService(IServiceCollection service)
{
    service.AddEndpointsApiExplorer();

    service.AddSwaggerGen();

    service.AddDbContext<VolcanoDb>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
    });
    service.AddScoped<IVolcanoRepository, VolcanoRepository>();
}

void Configure(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<VolcanoDb>();
        db.Database.EnsureCreated();
    }

    app.UseHttpsRedirection();
}

