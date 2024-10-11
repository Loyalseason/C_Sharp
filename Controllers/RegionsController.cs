using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstrestFulApi.Data;
using MyFirstrestFulApi.Models.Domain;
using MyFirstrestFulApi.Models.DTOs;

namespace MyFirstrestFulApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _dbContext;
        public RegionsController(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private RegionDto MapToRegionDto(Region region)
        {
            return new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _dbContext.Regions.ToListAsync();

            if (regions.Count == 0)
            {
                return NotFound("No Regions Found");
            }

            //  var regionsDto = new List<RegionDto>();
            //  foreach (var region in regions)
            //  {
            //     regionsDto.Add(
            //         new RegionDto(){
            //             Id = region.Id,
            //             Code =  region.Code,
            //             Name = region.Name,
            //             RegionImageUrl = region.RegionImageUrl
            //     });
            //  }

            var regionsDto = regions.Select(MapToRegionDto).ToList();
            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
            var region = await _dbContext.Regions.FindAsync(id);
            // var regionById = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
            {
                return NotFound($"Region with {id} not Found");
            }
            return Ok(region);
        }


        [HttpPost]
        public async Task<IActionResult> AddANewRegion([FromBody] AddRegionDto addRegion)
        {
            //Map or convert DTO to domain model
            var region = new Region
            {
                Name = addRegion.Name,
                Code = addRegion.Code,
                RegionImageUrl = addRegion.RegionImageUrl
            };

            //Use Domain Model to create region
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();

            var regionDto = MapToRegionDto(region);

            return CreatedAtAction(nameof(GetRegionById), new { id = region.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionDto updateRegion)
        {

            var foundRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (foundRegion == null)
            {
                return NotFound("Region Not Found");
            }

            //Mapping Dto to Model

            foundRegion.Name = updateRegion.Name;
            foundRegion.Code = updateRegion.Code;
            foundRegion.RegionImageUrl = updateRegion.RegionImageUrl;

            await _dbContext.SaveChangesAsync();
            // Convert Domain Model to Dto
            var regionDto = MapToRegionDto(foundRegion);

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var foundRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (foundRegion == null)
            {
                return NotFound("Region Not Found");
            }

            var deletedRegion = _dbContext.Regions.Remove(foundRegion);
            await _dbContext.SaveChangesAsync();

            // var RegionDto = new RegionDto
            // {
            //     Id = foundRegion.Id,
            //     Code = foundRegion.Code,
            //     Name = foundRegion.Name,
            //     RegionImageUrl = foundRegion.Code
            // };

            var regionDto = MapToRegionDto(foundRegion);

            return Ok(regionDto);
        }
    }
}
