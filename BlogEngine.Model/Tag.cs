namespace BlogEngine.Model
{
    public class Tag : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
