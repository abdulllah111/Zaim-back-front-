using Zaim.WebApi.Models;

namespace Zaim.WebApi.Data
{
    public interface IZaimRepositoty
    {
        CalculDto GetCalculation(DataForCalculDto data);
    }
}