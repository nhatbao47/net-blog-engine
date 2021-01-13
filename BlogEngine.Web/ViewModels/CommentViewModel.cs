using System;

namespace BlogEngine.Web.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
