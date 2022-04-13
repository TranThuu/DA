using FlarumWebApp.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlarumWebApp.Core.Entities
{
    public  class LogActive:Base
    {
        public Guid UserActorId { get; set; }

        public Guid UserVictimId { get; set; }
        public string Content { get; set; }

        public User UserActor { get; set; }

        public User UserVictim { get; set; }
    }
}
