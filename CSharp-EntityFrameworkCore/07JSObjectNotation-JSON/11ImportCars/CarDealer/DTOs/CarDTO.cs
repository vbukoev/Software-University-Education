using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Newtonsoft.Json;

namespace CarDealer.DTOs
{
    public class CarDTO
    {
        [JsonProperty("make")] public string Make { get; set; } = null!;
        [JsonProperty("model")] public string Model { get; set; } = null!;
        [JsonProperty("traveledDistance")] public long TraveledDistance { get; set; } 
        [JsonProperty("partsId")] public int[] PartsId { get; set; } 
    }
}
