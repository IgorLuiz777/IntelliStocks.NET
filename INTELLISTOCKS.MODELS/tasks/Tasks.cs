namespace INTELLISTOCKS.MODELS.task;


public class Tasks // Usei o nome no plural para diferenciar com a palavra reservada Task
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public DateTime DueTo { get; set; }
    
    public Priority Priority { get; set; }
    
    //public List<User> ResponsiblesUser { get; set; }
    
    public Status Status { get; set; }
}