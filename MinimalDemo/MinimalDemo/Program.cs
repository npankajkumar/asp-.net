var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(option => {
    option.AllowAnyOrigin();
    option.AllowAnyMethod();
    option.AllowAnyHeader();
});
app.MapGet("/product", () =>
{
    return "Product with get called";
});
 
//app.Use((context, next) =>
//{
//    next();
//    return context.Response.WriteAsync("Hello, world!");
//});
//app.Use((context, next) =>
//{
//    next();
//    return context.Response.WriteAsync("Actalent");
//});
//middleware function
app.Run();

 
