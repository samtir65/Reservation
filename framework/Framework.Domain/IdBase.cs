namespace Framework.Domain
{
    public abstract class IdBase<T> : ValueObjectBase
        {
            public T DbId { get; private set; }

            protected IdBase()
            {
            }

            protected IdBase(T dbId)
            {
                this.DbId = dbId;
            }

            public override int GetHashCode()
            {
                return this.DbId.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                return !(this.GetType() != obj.GetType()) && (obj is IdBase<T> idBase && idBase.DbId.Equals((object)this.DbId));
            }
        }
    }
