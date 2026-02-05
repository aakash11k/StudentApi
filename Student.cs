using System.ComponentModel.DataAnnotations;

namespace StudentApi.Models;

public class Student
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
    public required string Email { get; set; }
}