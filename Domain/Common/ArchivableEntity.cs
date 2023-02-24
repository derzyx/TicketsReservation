using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class ArchivableEntity : BaseEntity
    {
        public bool IsArchived { get; private set; }

        public void Archive()
        {
            this.IsArchived = true;
        }
    }
}
