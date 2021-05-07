using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NRDCL.Site.Service.Dtos;
using NRDCL.Site.Service.Extensions;
using NRDCL.Site.Service.Entities;
using MassTransit;
using NRDCL.Site.Service.Repositories;
using NRDCL.Common.Dtos.Site;

namespace NRDCL.Site.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SiteController : ControllerBase
    {
        private readonly ISiteRepository _siteRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPublishEndpoint _publishEndpoint;

        public SiteController(ISiteRepository siteRepository, ICustomerRepository customerRepository,
            IPublishEndpoint publishEndpoint)
        {
            _siteRepository = siteRepository;
            _customerRepository = customerRepository;
            _publishEndpoint = publishEndpoint;
        }

        //GET /items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SiteDto>>> GetAsync()
        {
            var customers = await _customerRepository.GetAsync();
            var sites = (await _siteRepository.GetAsync()).Select(site =>
           {
               var customer = customers.Single(customer => customer.CustomerCID == site.CustomerCID);
               return site.AsDto(customer.CustomerName);
           });

            return Ok(sites);
        }

        //GET /items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SiteDto>> GetByIDAsync(int id)
        {
            var site = await _siteRepository.GetByIDAsync(id);
            return site != null ? site.AsDto() : NotFound();
        }

        //POST /items
        [HttpPost]
        public async Task<ActionResult<SiteDto>> PostAsync(CreateSiteDto createSiteDto)
        {
            var site = new SiteEntity
            {
                SiteID = createSiteDto.SiteID,
                CustomerCID = createSiteDto.CustomerCID,
                SiteName = createSiteDto.SiteName,
                Distance = createSiteDto.Distance
            };

            await _siteRepository.CreateAsync(site);
            await _publishEndpoint.Publish(new SiteCreated(site.SiteID, site.CustomerCID, site.SiteName, site.Distance));
            return CreatedAtAction(nameof(GetByIDAsync), new { id = site.SiteID }, site);
        }

        //PUT /items/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, UpdateSiteDto updateSiteDto)
        {
            var existingSite = await _siteRepository.GetByIDAsync(id);

            if (existingSite == null)
                return NotFound();

            existingSite.CustomerCID = updateSiteDto.CustomerCID;
            existingSite.SiteName = updateSiteDto.SiteName;
            existingSite.Distance = updateSiteDto.Distance;

            await _siteRepository.UpdateAsync(existingSite);
            await _publishEndpoint.Publish(new SiteUpdated(
                existingSite.SiteID, existingSite.CustomerCID, existingSite.SiteName, existingSite.Distance
            ));
            return NoContent();
        }

        //DELETE /items/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var site = await _siteRepository.GetByIDAsync(id);

            if (site == null)
                return NotFound();

            await _siteRepository.DeleteAsync(site);
            await _publishEndpoint.Publish(new SiteDeleted(site.SiteID));
            return NoContent();
        }
    }
}
