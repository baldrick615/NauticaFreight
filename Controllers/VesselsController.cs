using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NauticaFreight.API.Models.Domain;
using NauticaFreight.API.Repositories;

namespace NauticaFreight.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VesselsController : ControllerBase
    {
        private readonly IVesselsRepository _repo;
        private readonly IMapper _mapper;

        public VesselsController(IVesselsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Vessel>> AddVessel(Vessel vessel)
        {
            var newVessel = await _repo.CreateVesselAsync(vessel);
            return Ok(newVessel);
        }


        [HttpGet]
        public async Task<ActionResult<Vessel>> GetVessels()
        {
            var vessels = _repo.GetVessels();
            return Ok();
        }
    }
}
