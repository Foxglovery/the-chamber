namespace TheChamber.Models.DTOs;

public class OrderDTO 
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }

    public string? Notes { get; set; }
    public bool Purchased { get; set; }
    public UserProfileDTO UserProfile { get; set; }

}