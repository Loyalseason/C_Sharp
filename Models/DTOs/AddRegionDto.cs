using System;

namespace MyFirstrestFulApi.Models.DTOs;

public class AddRegionDto
{
         public required string Code { get; set; }

        public required string Name { get; set; }

        public string? RegionImageUrl { get; set; } 
}
