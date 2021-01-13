using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEngine.Model
{
    public class Comment : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }
    }
}
