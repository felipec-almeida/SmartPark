namespace SmartPark.Domain.Entities.ParkingRecord
{
    public record CustomerEntity
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Cpf { get; init; }
    }
}
