namespace INTELLISTOCKS.MODELS.note;

public class Note
{
    
    public int ID  { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now; 
    //public user CreatedBy { get; set; }
    
}