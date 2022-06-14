namespace DataAccess.Models
{
    public class GroupModel : CreateGroupModel
    {
        public int Id { get; set; } 
    }

    public class CreateGroupModel
    {
        public string? Name { get; set; }
    }
}
