using AutoBogus;
using Microsoft.EntityFrameworkCore;    
using SmartPark.Borders.Interfaces.Repositories;
using SmartPark.Borders.Shared.Response;
using SmartPark.Domain.Entities.ParkingLot;
using SmartPark.Infrastructure.Context.ParkingLot;

namespace SmartPark.Infrastructure.Repositories
{
    public class ParkingLotRepository : IParkingLotRepository
    {
        private readonly ParkingLotDbContext _context;

        public ParkingLotRepository(ParkingLotDbContext context)
        {
            _context = context;

            GetParkingLotEntityMockedResult();
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

        public async Task<PostResponse> PostAsync(ParkingLotEntity request)
        {
            await _context.ParkingLots.AddAsync(request);
            await _context.SaveChangesAsync();

            return new PostResponse
            {
                IsCreated = true,
                Id = request.Id
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
