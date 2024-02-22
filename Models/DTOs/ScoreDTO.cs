
namespace TheChamber.Models.DTOs;

public class ScoreDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public UserProfileDTO UserProfile { get; set; }
    public int Power { get; set; }
    
}