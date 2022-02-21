using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain
{
    public abstract class ValueObjectBase
    {
        public override bool Equals(object obj);
        public override int GetHashCode();
    }
}
