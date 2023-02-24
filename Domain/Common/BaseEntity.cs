using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public bool IsDeleted { get; private set; }

        public void Delete()
        {
            this.IsDeleted = true;
        }
    }
}
