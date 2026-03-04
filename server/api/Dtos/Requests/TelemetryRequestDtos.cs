using System.ComponentModel.DataAnnotations;

namespace server.Dtos.Requests;

public record CreateTelemetryRequestDto
{
    [Required] [MinLength(1)]
    public string TurbineId { get; set; }
    [Required] [MinLength(1)]
    public string FarmId { get; set; }
    [MinLength(1)]
    public float WindSpeed { get; set; }
    [MinLength(1)]
    public float WindDirection { get; set; }  
    [MinLength(1)]
    public float AmbientTemperature { get; set; }  
    [MinLength(1)]
    public float RotorSpeed { get; set; }  
    [MinLength(1)]
    public float PowerOutput { get; set; }  
    [MinLength(1)]
    public float NacelleDirection { get; set; }  
    [MinLength(1)]
    public float BladePitch { get; set; }  
    [MinLength(1)]
    public float GeneratorTemp { get; set; } 
    [MinLength(1)]
    public float GearboxTemp { get; set; }  
    [MinLength(1)]
    public float Vibration { get; set; } 
    [MinLength(1)]
    public string Status { get; set; }
}

public record UpdateTelemetryRequestDto
{
    [Required] [MinLength(1)]
    public string TelemetryId { get; set; }
    [Required] [MinLength(1)]
    public string TurbineId { get; set; }
    [Required] [MinLength(1)]
    public string FarmId { get; set; }
    [MinLength(1)]
    public float WindSpeed { get; set; }
    [MinLength(1)]
    public float WindDirection { get; set; }  
    [MinLength(1)]
    public float AmbientTemperature { get; set; }  
    [MinLength(1)]
    public float RotorSpeed { get; set; }  
    [MinLength(1)]
    public float PowerOutput { get; set; }  
    [MinLength(1)]
    public float NacelleDirection { get; set; }  
    [MinLength(1)]
    public float BladePitch { get; set; }  
    [MinLength(1)]
    public float GeneratorTemp { get; set; } 
    [MinLength(1)]
    public float GearboxTemp { get; set; }  
    [MinLength(1)]
    public float Vibration { get; set; } 
    [MinLength(1)]
    public string Status { get; set; } 
}