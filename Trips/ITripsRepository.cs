namespace NauticaFreight.API.Trips
{
    public interface ITripsRepository
    {
        Task<IEnumerable<Trip>> GetAllTripsAsync();
        Task<IEnumerable<LimitedTripsDto>> GetLimitedTripsInfoAsync();
        Task<LimitedTripsDto?> GetLimitedTripInfoAsync(Guid id);
        Task<Trip?> GetTripByIdAsync(Guid id);
        Task<Trip> CreateTripAsync(Trip trip);
        Task<Trip?> UpdateTripAsync(Guid id, Trip trip);
        Task<Trip> DeleteTripAsync(Guid id);        
    }
}
