namespace NauticaFreight.API.Trips
{
    public interface ITripRepository
    {
        Task<IEnumerable<Trip>> GetAllTripsAsync();
        Task<Trip?> GetTripByIdAsync(Guid id);
        Task<Trip> CreateTripAsync(Trip trip);
        Task<Trip?> UpdateTripAsync(Guid id, Trip trip);
        Task<Trip> DeleteTripAsync(Guid id);        
    }
}
