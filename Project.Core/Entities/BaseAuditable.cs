namespace Project.Core.Entities
{
    public class BaseAuditable 
    {
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? DeleteAt { get; set; }

    }
}
