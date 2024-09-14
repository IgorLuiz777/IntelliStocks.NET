namespace INTELLISTOCKS.MODELS.task;

public class Task
{
    private int id { get; set; }
    
    private string title { get; set; }
    
    private string description { get; set; }
    
    private DateTime dueTo { get; set; }
    
    private int priority { get; set; } // 1 - 5
    
    //private List<User> responsiblesUser { get; set; }
    
    private Status status { get; set; }
}