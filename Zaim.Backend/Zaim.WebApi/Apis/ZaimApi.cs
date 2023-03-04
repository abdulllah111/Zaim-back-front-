using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Zaim.WebApi.Data;
using Zaim.WebApi.Data.Validators;
using Zaim.WebApi.Models;

namespace Zaim.WebApi.Apis
{
    public class ZaimApi : IApi
    {
        private readonly IValidator<DataForCalculDto> _validator;
        public ZaimApi(IValidator<DataForCalculDto> validator) => _validator = validator;
        public void Register(WebApplication app)
        {
            app.MapPost("/calculate", Calcul);
            app.MapGet("/", () => "Hello World!");
        }

        private async Task<IResult> Calcul([FromBody] DataForCalculDto data, IZaimRepositoty repo) => _validator.IsValid(data) ?
            repo.GetCalculation(data)
            is CalculDto calculDto
            ? Results.Ok(calculDto)
            : Results.NotFound()
            : Results.NotFound(data);
    }
}