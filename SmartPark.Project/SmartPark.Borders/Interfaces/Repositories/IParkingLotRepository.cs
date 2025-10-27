using SmartPark.Borders.Shared.Response;
using SmartPark.Domain.Entities.ParkingLot;

namespace SmartPark.Borders.Interfaces.Repositories
{
    public interface IParkingLotRepository
    {
        Task<IEnumerable<ParkingLotEntity>> GetAllAsync(int pageNumber, int pageSize);

        Task<ParkingLotEntity?> GetByIdAsync(Guid id);

        Task<PostResponse> PostAsync(ParkingLotEntity request);
    }
}
