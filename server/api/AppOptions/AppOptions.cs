using System.ComponentModel.DataAnnotations;

namespace api.AppOptions;

public class AppOptions
{
    [MinLength(1)]
    public string DbConnectionString { get; set; }
    [MinLength(1)]
    public string JwtSecret { get; set; }
}