using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Newtonsoft.Json;
using System.Diagnostics;
using RestServices.Domain.Supervisor;
using RestServices.Domain.ViewModels;

namespace RestServices.API.Controllers
{
    [Route("api/[controller]")]
    public class AlbumController : Controller
    {
        private readonly IRestServicesSupervisor _restServicesSupervisor;

        public AlbumController(IRestServicesSupervisor restServicesSupervisor)
        {
            _restServicesSupervisor = restServicesSupervisor;
        }

        [HttpGet]
        [Produces(typeof(List<CountryViewModel>))]
        public async Task<ActionResult<List<CountryViewModel>>> Get(CancellationToken ct = default)
        {
            try
            {
                return new ObjectResult(await _restServicesSupervisor.GetAllCountryAsync(ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(CountryViewModel))]
        public async Task<ActionResult<CountryViewModel>> Get(int id, CancellationToken ct = default)
        {
            try
            {
                var country = await _restServicesSupervisor.GetCountryByIdAsync(id, ct);
                if (country == null)
                {
                    return NotFound();
                }

                return Ok(country);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{alpha2}")]
        [Produces(typeof(CountryViewModel))]
        public async Task<ActionResult<CountryViewModel>> Get(string alpha2, CancellationToken ct = default)
        {
            try
            {
                var country = await _restServicesSupervisor.GetCountryByAlpha2Async(alpha2, ct);
                if (country == null)
                {
                    return NotFound();
                }

                return Ok(country);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}