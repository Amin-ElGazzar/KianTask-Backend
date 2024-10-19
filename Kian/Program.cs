

using Kian.Extensions;
using Kian.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependences(builder.Configuration);


#region ADD CORS
var CORS = "_cors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(CORS,
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlerMiddelware>();
app.UseHttpsRedirection();
app.UseCors(CORS);
app.UseAuthorization();

app.MapControllers();

app.Run();
