using System.Collections.Generic;

namespace BlogEngine.Web.ViewModels
{
    public class LatestPostsViewModel
    {
        public ViewMode View { get; set; }
        public List<PostViewModel> Posts { get; set; }
    }

    public enum ViewMode
    {
        Full = 1,
        Compact,
        Tiny
    }
}
