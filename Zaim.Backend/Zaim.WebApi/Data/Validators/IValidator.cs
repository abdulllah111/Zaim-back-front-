namespace Zaim.WebApi.Data.Validators
{
    public interface IValidator<T>
    {
        bool IsValid(T value);
    }
}