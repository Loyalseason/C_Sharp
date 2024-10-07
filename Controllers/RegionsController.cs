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
        public IActionResult GetAllRegions()
        {
            var regions = _dbContext.Regions.ToList();
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
        public IActionResult GetRegionById([FromRoute] Guid id)
        {
            var region = _dbContext.Regions.Find(id);
            var regionById = _dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (region == null)
            {
                return NotFound($"Region with {id} not Found");
            }
            return Ok(region);
        }


        [HttpPost]
        public IActionResult AddANewRegion([FromBody] AddRegionDto addRegion)
        {
            //Map or convert DTO to domain model
            var region = new Region
            {
                Name = addRegion.Name,
                Code = addRegion.Code,
                RegionImageUrl = addRegion.RegionImageUrl
            };

            //Use Domain Model to create region
            _dbContext.Regions.Add(region);
            _dbContext.SaveChanges();

            var regionDto = MapToRegionDto(region);

            return CreatedAtAction(nameof(GetRegionById), new { id = region.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionDto updateRegion)
        {

            var foundRegion = _dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (foundRegion == null)
            {
                return NotFound("Region Not Found");
            }

            //Mapping Dto to Model
            var region = new Region
            {
                Name = updateRegion.Name,
                Code = updateRegion.Code,
                RegionImageUrl = updateRegion.RegionImageUrl
            };
            _dbContext.SaveChanges();
            // Convert Domain Model to Dto
            var regionDto = MapToRegionDto(region);

            return Ok("Successfully Updated Region");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult deleteRegion([FromRoute] Guid id)
        {
            var foundRegion = _dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (foundRegion == null)
            {
                return NotFound("Region Not Found");
            }

            var deletedRegion = _dbContext.Regions.Remove(foundRegion);
            _dbContext.SaveChanges();

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
