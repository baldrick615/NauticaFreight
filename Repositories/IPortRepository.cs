﻿using NauticaFreight.API.Models.Domain;
using NauticaFreight.API.Models.Dtos;

namespace NauticaFreight.API.Repositories
{
    public interface IPortRepository
    {
        Task<List<Port>> GetPorts();
        Task<Port?> GetPortById(int id);
        Task<Port> CreateAsync(Port port);
        Task<Port?> UpdateAsync(int id, Port port);
        Task<Port> DeleteAsync(int id);
    }
}
