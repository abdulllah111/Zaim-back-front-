using Zaim.WebApi.Models;

namespace Zaim.WebApi.Data.Validators
{
    public class DataForCalculDtoValidator : IValidator<DataForCalculDto>
    {
        public bool IsValid(DataForCalculDto value)
        {
            if(value == null) return false;
            if (value.MounthsNum.GetType() != typeof(int) ||
                value.Summ.GetType() != typeof(decimal) ||
                value.Bet.GetType() != typeof(double)) return false;
            if(value.MounthsNum <= 0 || value.Summ <=0 || value.Bet <= 0) return false;
            return true;
        }
    }
}
