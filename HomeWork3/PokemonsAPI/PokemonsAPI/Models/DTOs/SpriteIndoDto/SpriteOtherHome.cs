﻿using Newtonsoft.Json;

namespace PokemonsAPI.Models.DTOs.SpriteIndoDto;

/// <summary>
/// 
/// </summary>
public class SpriteOtherHome
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "Front_Default")]
    public string Front_Default { get; set; } = "";
}