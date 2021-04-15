using System;
using System.ComponentModel.DataAnnotations;

namespace BlogEngine.Web.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        [Required, StringLength(200)]
        public string Name { get; set; }
        [Display(Name = "Email address")]
        [StringLength(254)]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Display(Name = "Comment")]
        [Required, StringLength(1000)]
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public int PostId { get; set; }
    }
}
