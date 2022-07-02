using System.ComponentModel.DataAnnotations;

public class Movie
{
    [Key]
    public int Id {get; set;}
    public string? Title {get; set;}
    public string? Director {get; set;}
    public int YearReleased {get; set;}
    public string? ImageURL {get; set;}
}