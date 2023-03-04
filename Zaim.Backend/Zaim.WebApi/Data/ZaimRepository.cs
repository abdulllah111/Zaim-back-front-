using Zaim.WebApi.Models;
using System;
using Zaim.WebApi.Data.Validators;

namespace Zaim.WebApi.Data
{
    public class ZaimRepository : IZaimRepositoty
    {
        private readonly IValidator<DataForCalculDto> _validator;
        public ZaimRepository(IValidator<DataForCalculDto> validator) => _validator = validator;

        public CalculDto GetCalculation(DataForCalculDto data)
        {
            decimal A;
            decimal K;
            decimal S = data.Summ;
            double I = data.Bet / 12;
            decimal P;
            var calculDto = new CalculDto() { CalculItems = new List<CalculItem>() };
            var date = DateOnly.FromDateTime(DateTime.Now);
            for(int n = 1; n <= data.MounthsNum; n++)
            {
                K = (decimal)((I * Math.Pow((1+I), data.MounthsNum))/(Math.Pow((1+I), data.MounthsNum) - 1));
                A = K * data.Summ;
                P = S * (decimal)I;
                S = S - (A - P);
                date = date.AddMonths(n);
                calculDto.CalculItems.Add(new CalculItem()
                {
                    Id = n,
                    DatePay = date,
                    Pay = A,
                    MainPay = A - P,
                    ProcentPay = P,
                    CreditBalance = S
                });
            }
            A = 0;K = 0;S=0;I=0;P=0;

            return calculDto;
        }
    }
}