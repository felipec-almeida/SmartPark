using SmartPark.Borders.Dtos.ParkingLot.Request;
using SmartPark.Borders.Shared.Response;
using SmartPark.Domain.Entities.ParkingLot;

namespace SmartPark.Borders.Interfaces.Repositories
{
    public interface IParkingLotRepository
    {
        Task<IEnumerable<ParkingLotEntity>> GetAllAsync(int pageNumber, int pageSize);

        Task<ParkingLotEntity?> GetByIdAsync(Guid id);

        Task<BasePostResponse> PostAsync(ParkingLotEntity request);

        Task<BasePatchResponse?> PatchAsync((Guid, PatchParkingLotRequest) request);

        Task<BaseDeleteResponse?> DeleteAsync(Guid id);
    }
}
