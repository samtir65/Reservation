using FluentMigrator;

namespace ReservationSystem.DatabaseMigrations
{
    [Migration(1)]
    public class InitialReservations : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Reservations")
                .WithColumn("Id").AsInt64().PrimaryKey().NotNullable()
                .WithColumn("CreateOn").AsDateTime2().NotNullable()
                .WithColumn("CustomerId").AsInt64().NotNullable()
                .WithColumn("ServiceId").AsInt64().NotNullable()
                .WithColumn("personnelId").AsInt64().NotNullable()
                .WithColumn("CreatorUserId").AsInt64().NotNullable();

            Create.Sequence("SequenceReservation").Cache(20).IncrementBy(1).StartWith(1);
        }
    }
}
