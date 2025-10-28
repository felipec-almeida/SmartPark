using AutoBogus;
using Microsoft.EntityFrameworkCore;
using SmartPark.Borders.Dtos.ParkingLot;
using SmartPark.Borders.Dtos.ParkingLot.Request;
using SmartPark.Borders.Interfaces.Repositories;
using SmartPark.Borders.Shared.Response;
using SmartPark.Domain.Entities.ParkingLot;
using SmartPark.Infrastructure.Context.ParkingLot;

namespace SmartPark.Infrastructure.Repositories
{
    public class ParkingLotRepository : IParkingLotRepository
    {
        private readonly SmartParkDbContext _context;

        public ParkingLotRepository(SmartParkDbContext context)
        {
            _context = context;

            // GetParkingLotEntityMockedResult();
        }

        public async Task<IEnumerable<ParkingLotEntity>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.ParkingLots
                .AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<ParkingLotEntity?> GetByIdAsync(Guid id)
        {
            return await _context.ParkingLots
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<BasePatchResponse?> PatchAsync((Guid, PatchParkingLotRequest) request)
        {
            var parkingLot = await _context.ParkingLots
                                     .FirstOrDefaultAsync(x => x.Id.Equals(request.Item1));

            if (parkingLot == null)
                return null;

            var entityType = typeof(ParkingLotEntity);

            foreach (var property in request.Item2.GetType().GetProperties())
            {
                var requestValue = property.GetValue(request.Item2);

                if (requestValue is null)
                    continue;

                if (property.Name == nameof(request.Item2.Address))
                {
                    var addressRequest = (ParkingLotAddressDto)requestValue;

                    foreach (var addressProp in addressRequest.GetType().GetProperties())
                    {
                        var addressValue = addressProp.GetValue(addressRequest);

                        if (addressValue != null)
                        {
                            parkingLot.Address
                                .GetType()
                                .GetProperty(addressProp.Name)
                                ?.SetValue(parkingLot.Address, addressValue);
                        }
                    }

                    continue;
                }

                entityType.GetProperty(property.Name)?.SetValue(parkingLot, requestValue);
            }

            await _context.SaveChangesAsync();

            return new BasePatchResponse
            {
                Result = parkingLot,
                IsUpdated = true
            };
        }

        public async Task<BasePostResponse> PostAsync(ParkingLotEntity request)
        {
            await _context.ParkingLots.AddAsync(request);
            await _context.SaveChangesAsync();

            return new BasePostResponse
            {
                Result = request,
                IsCreated = true
            };
        }

        public async Task<BaseDeleteResponse?> DeleteAsync(Guid id)
        {
            var parkingLot = await _context.ParkingLots
                                     .FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (parkingLot == null)
                return null;

            _context.Remove(parkingLot);
            await _context.SaveChangesAsync();

            return new BaseDeleteResponse
            {
                IsDeleted = true
            };
        }

        private async void GetParkingLotEntityMockedResult()
        {
            if (_context.ParkingLots.Any())
                return;

            var mockedParkingLots = AutoFaker.Generate<ParkingLotEntity>(26);

            _context.ParkingLots.AddRange(mockedParkingLots);
            await _context.SaveChangesAsync();
        }
    }
}
