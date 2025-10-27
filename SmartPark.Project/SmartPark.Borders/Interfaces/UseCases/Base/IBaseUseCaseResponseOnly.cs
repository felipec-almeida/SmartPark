namespace SmartPark.Borders.Interfaces.UseCases.Base
{
    public interface IBaseUseCaseResponseOnly<TResponse>
    {
        Task<TResponse> Execute();
    }
}
