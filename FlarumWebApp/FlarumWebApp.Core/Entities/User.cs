using FlarumWebApp.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlarumWebApp.Core.Entities
{
    public class User:IdentityUser<Guid>
    {
        public string FullName { get; set; }

        public string UrlSlug { get; set; }

        public string Introduce { get; set; }

        public Status Status { get; set; }

        public string AvatarImage { get; set; }

        public string BackgroundImage { get; set; }

        public Gender Gender { get; set; }

        public ICollection<Post> Posts { get; set; }

        public ICollection<LogActive> LogActiveActors { get; set; }
        public ICollection<LogActive> LogActiveVictims { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<SavedPost> SavedPosts { get; set; }

    }
}
