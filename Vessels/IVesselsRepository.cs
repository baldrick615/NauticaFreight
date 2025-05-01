namespace NauticaFreight.API.Vessels
{
    public interface IVesselsRepository
    {
        Task<IEnumerable<Vessel>> GetVessels();
        Task<Vessel> GetVesselAsync(Guid id);
        Task<List<Vessel>> GetVesselsByOperatorAsync(string name);
        Task<Vessel> CreateVesselAsync(Vessel vessel);
        Task<Vessel> UpdateVesselAsync(Vessel vessel);
        Task<Vessel> DeleteVesselAsync(Vessel vessel);
    }
}
