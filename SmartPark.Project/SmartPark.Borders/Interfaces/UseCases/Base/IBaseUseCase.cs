namespace SmartPark.Borders.Interfaces.UseCases.Base
{
    public interface IBaseUseCase<TRequest, TResponse>
    {
        Task<TResponse> Execute(TRequest request);
    }
}
