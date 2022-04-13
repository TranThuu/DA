using FlarumWebApp.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlarumWebApp.Core.Entities
{
    public class SavedPost:Base
    {
        public Guid UserId { get; set; }

        public int PostId { get; set; }

        public User User { get; set; }

        public Post Post { get; set; }
    }
}
