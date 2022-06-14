namespace DataAccess.Models
{
    public class BadgeModel : CreateBadgeModel
    {
        public int Id { get; set; }
    }

    public class CreateBadgeModel
    {
        public int UserId { get; set; }
        public string? NFCTag { get; set; }
    }
}
