namespace Project.Core.Entities
{
    public class BaseEntity: BaseAuditable
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
