using Zaim.WebApi.Apis;
using Zaim.WebApi.Data;
using Zaim.WebApi.Data.Validators;
using Zaim.WebApi.Models;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<IZaimRepositoty, ZaimRepository>();
builder.Services.AddTransient<IApi, ZaimApi>();
builder.Services.AddTransient<IValidator<DataForCalculDto>, DataForCalculDtoValidator>();

builder.Services.AddCors();

builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});


var app = builder.Build();
//app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowAll");



var apis = app.Services.GetServices<IApi>();
foreach(var api in apis)
{
    if (api is null) throw new InvalidProgramException("Api not found");
    api.Register(app);
}

app.Run();
