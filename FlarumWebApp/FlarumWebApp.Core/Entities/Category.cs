using FlarumWebApp.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlarumWebApp.Core.Entities
{
    public class Category:Base
    {
        public string CategoryName { get; set; }

        public string Image { get; set; }

        public bool IsHotCategory { get; set; }

        public int NumberOrder { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
