using FlarumWebApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlarumWebApp.Core.BaseEntities
{
    public interface IBase
    {
        public int Id { get; set; }

        public DateTime CreateOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Status Status { get; set; }
    }
}
