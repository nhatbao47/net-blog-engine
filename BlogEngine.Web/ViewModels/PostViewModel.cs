﻿using System;

namespace BlogEngine.Web.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string ThumbnailImage { get; set; }
        public DateTime PostDate { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ViewCount { get; set; }
        public int CommentCount { get; set; }
    }
}
