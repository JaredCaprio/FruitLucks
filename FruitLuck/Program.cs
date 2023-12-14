using FruitLuck.Services.FruitLucks;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddControllers();
    builder.Services.AddTransient<IFruitLuckService, FruitLuckService>();
}

var app = builder.Build();


{
    // app.UseHttpsRedirection();
    app.UseExceptionHandler("/error");
    app.MapControllers();
    app.Run();

}
