namespace Project.Core.Entities
{
    public class Teacher : BaseEntity
    {
        public string FullName { get; set; }
        public Profession Profession { get; set; }
        public int ProfessionId { get; set; }
        public string ImagePath { get; set; }
    }
}
