using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain
{
    public abstract class IdBase<T> : ValueObjectBase
        {
            public T DbId { get; private set; }
            protected IdBase();
            protected IdBase(T dbId);
            public override int GetHashCode();
            public override bool Equals(object obj);
        }
}
