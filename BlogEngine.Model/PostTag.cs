using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEngine.Model
{
    public class PostTag : IEntityBase
    {
        public int Id { set; get; }
        public int PostId { set; get; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }
        public int TagId { set; get; }
        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}
