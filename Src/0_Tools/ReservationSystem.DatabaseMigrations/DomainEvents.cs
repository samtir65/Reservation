using FluentMigrator;

namespace ReservationSystem.DatabaseMigrations
{
    [Migration(2)]
    public class DomainEvents : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("DomainEvents")
                .WithColumn("Id").AsInt64().Identity().PrimaryKey()
                .WithColumn("EventType").AsString(int.MaxValue).NotNullable()
                .WithColumn("SerializedContent").AsString(int.MaxValue).NotNullable()
                .WithColumn("PublishDateTime").AsDateTime().NotNullable()
                .WithColumn("SentOnBus").AsBoolean().WithDefaultValue(false).NotNullable()
                .WithColumn("EventId").AsGuid().Unique();
        }
    }
}
