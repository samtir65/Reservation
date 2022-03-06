// Decompiled with JetBrains decompiler
// Type: Respect.NH.SqlCommandFactory
// Assembly: Respect.NH, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: DA4DCF3D-5563-415D-B353-FC11CFB50050
// Assembly location: C:\Users\admin\.nuget\packages\respect.nh\1.0.1\lib\net5.0\Respect.NH.dll

using System.Data.SqlClient;
using Framework.Domain;
using Newtonsoft.Json;

namespace Framework.NH
{
    public class SqlCommandFactory
    {
        public static SqlCommand FromEvent(DomainEvent targetEvent)
        {
            string cmdText = " INSERT INTO [DomainEvents] ([EventId],[EventType],[SerializedContent],[PublishDateTime],[SentOnBus]) Values(@EventId,@EventType,@SerializedContent,@DateTimePublish,@SentOnBus)";
            string str = JsonConvert.SerializeObject((object)targetEvent);
            SqlCommand sqlCommand = new SqlCommand(cmdText);
            sqlCommand.Parameters.AddWithValue("@EventId", (object)targetEvent.EventId);
            sqlCommand.Parameters.AddWithValue("@EventType", (object)targetEvent.GetType().AssemblyQualifiedName);
            sqlCommand.Parameters.AddWithValue("@SerializedContent", (object)str);
            sqlCommand.Parameters.AddWithValue("@DateTimePublish", (object)targetEvent.DateTimePublish);
            sqlCommand.Parameters.AddWithValue("@SentOnBus", (object)false);
            return sqlCommand;
        }
    }
}