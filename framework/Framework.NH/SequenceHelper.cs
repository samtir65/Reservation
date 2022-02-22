﻿using NHibernate;

namespace Framework.NH
{
    public static class SequenceHelper
    {
        public static long GetNextSequence(this ISession session, string sequenceName)
        {
            return session.CreateSQLQuery($"SELECT NEXT VALUE FOR {sequenceName}")
                          .UniqueResult<long>();
        }
    }
}
