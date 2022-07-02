using System.ComponentModel.DataAnnotations;

public class Monster
{
    [Key]
    public int ID {get; set;}
    public string? Title {get; set;}
    public string? Creator {get; set;}
    public int BirthYear {get; set;}

    public string ImageURL {get; set;}
}