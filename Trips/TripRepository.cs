using Microsoft.EntityFrameworkCore;
using NauticaFreight.API.Data;

namespace NauticaFreight.API.Trips
{
    public class TripRepository : ITripRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TripRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Trip> CreateTripAsync(Trip trip)
        {
            var newTrip = new Trip
            {
                Id = Guid.NewGuid(),
                VesselId = trip.VesselId,
                DepartureDate = trip.DepartureDate,
                DeparturePortId = trip.DeparturePortId,
                ArrivalPortId = trip.ArrivalPortId,
                EstArrivalDate = trip.EstArrivalDate,
                ActualArrivalDate = trip.ActualArrivalDate,
                CargoType = trip.CargoType,
                CargoWeight = trip.CargoWeight,
                CreateDate = DateTime.UtcNow,
                LastUpdate = DateTime.UtcNow
            };
            await _dbContext.Trips.AddAsync(newTrip);
            await _dbContext.SaveChangesAsync();
            return newTrip;
        }

        public async Task<Trip> DeleteTripAsync(Guid id)
        {
            var trip = await GetTripByIdAsync(id);
            if (trip == null)
            {
                throw new KeyNotFoundException($"Trip with ID {id} not found.");
            }

            _dbContext.Trips.Remove(trip);
            await _dbContext.SaveChangesAsync();
            return trip;
        }

        public async Task<IEnumerable<Trip>> GetAllTripsAsync()
        {
            return await _dbContext.Trips
                .Include(t => t.DeparturePort)
                .Include(t => t.ArrivalPort)
                .Include(t => t.Vessel)
                .ToListAsync();
        }

        public async Task<Trip?> GetTripByIdAsync(Guid id)
        {
            return await _dbContext.Trips
                .Include(t => t.DeparturePort)
                .Include(t => t.ArrivalPort)
                .Include(t => t.Vessel)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Trip?> UpdateTripAsync(Guid id, Trip trip)
        {
            var existingTrip = await _dbContext.Trips.FirstOrDefaultAsync(t => t.Id == id);
            if (existingTrip == null)
            {
                return null;
            }
            existingTrip.DepartureDate = trip.DepartureDate;
            existingTrip.DeparturePortId = trip.DeparturePortId;
            existingTrip.ArrivalPortId = trip.ArrivalPortId;
            existingTrip.EstArrivalDate = trip.EstArrivalDate;
            existingTrip.ActualArrivalDate = trip.ActualArrivalDate;
            existingTrip.CargoType = trip.CargoType;
            existingTrip.CargoWeight = trip.CargoWeight;
            existingTrip.LastUpdate = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
            return existingTrip;
        }
    }
}