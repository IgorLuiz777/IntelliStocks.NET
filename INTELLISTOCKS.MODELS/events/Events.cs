namespace INTELLISTOCKS.MODELS.events;

public class Events
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Location { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public string Description { get; set; }
    
    //public User CreatedBy { get; set; }
    //public User Participants { get; set; }
}