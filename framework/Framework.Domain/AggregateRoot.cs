﻿namespace Framework.Domain
{
    public class AggregateRoot<T> : Entity<T>
    {
        public AggregateRoot(T id) 
            : base(id)
        {
        }
    }
}