using FlarumWebApp.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlarumWebApp.Core.Entities
{
    public class Comment:Base
    {
        public Guid UserId { get; set; }

        public int? PostId { get; set; }

        public int? ParentCommentId { get; set; }

        public string Content { get; set; }

        public int LikeCount { get; set; }

        public int Dislikecount { get; set; }

        public User User { get; set; }

        public Post Post { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public Comment ParentComment { get; set; }
    }
}
