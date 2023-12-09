using FruitLuck.Services.FruitLucks;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IFruitLuckService, FruitLuckService>();
}

var app = builder.Build();


{
    // app.UseHttpsRedirection();
    app.UseExceptionHandler("/error");
    app.MapControllers();
    app.Run();

}
