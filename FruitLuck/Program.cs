using FruitLuck.Services.FruitLucks;


var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddControllers();
    builder.Services.AddTransient<IFruitLuckService, FruitLuckService>();

}

var app = builder.Build();




{
    // app.UseHttpsRedirection();
    app.Use((ctx, next) =>
    {
        ctx.Response.Headers["Access-Control-Allow-Origin"] = "http://localhost:5173";
        return next();

    });
    app.UseExceptionHandler("/error");
    app.MapControllers();
    app.Run();

}
