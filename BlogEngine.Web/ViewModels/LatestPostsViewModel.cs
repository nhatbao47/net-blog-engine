using System.Collections.Generic;

namespace BlogEngine.Web.ViewModels
{
    public class LatestPostsViewModel
    {
        public bool CompactView { get; set; }
        public List<PostViewModel> Posts { get; set; }
    }
}
