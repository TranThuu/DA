using FlarumWebApp.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlarumWebApp.Core.Entities
{
    public class Post:Base
    {
        public string UrlSlug { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public Guid UserId { get; set; }

        public int LikeCount { get; set; }

        public int Dislikecount { get; set; }

        public string Image { get; set; }

        public string ShortDescription { get; set; }

        public int CategoryId { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<SavedPost> SavedPosts { get; set; }

        public User User { get; set; }

        public Category Category { get; set; }

    }
}
