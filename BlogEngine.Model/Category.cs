using System;
using System.Collections.Generic;

namespace BlogEngine.Model
{
    public class Category: IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
