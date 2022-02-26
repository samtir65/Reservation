using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Engine;
using NHibernate.SqlTypes;

namespace Framework.NH
{
    public class StringArrayMapping : ImmutableUserType<List<string>>
    {
        public override SqlType[] SqlTypes => new[] { new SqlType(DbType.String) };

        public override object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            var value = (string)NHibernateUtil.String.NullSafeGet(rs, names[0], session);
            return JsonConvert.DeserializeObject<List<string>>(value);
        }

        public override void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
        {
            var list = (List<string>)value;
            var valueToSave = JsonConvert.SerializeObject(list);
            NHibernateUtil.String.NullSafeSet(cmd, valueToSave , index, session);
        }
    }
}