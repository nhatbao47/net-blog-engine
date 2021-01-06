using System;

namespace BlogEngine.Web.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string ThumbnailImage { get; set; }
        public string PostDate { get; set; }
        public string PostDateUTC { get; set; }
        public string CategoryName { get; set; }
    }
}
