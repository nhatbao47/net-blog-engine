namespace BlogEngine.Web.ViewModels
{
    public class PostListViewModel
    {
        public PaginatedList<PostViewModel> Posts { get; set; }
        public int CurrentPage { get; set; }
        public int PagingCount { get; set; }
        public string Slug { get; set; }
        public string PageName { get; set; }
    }
}
