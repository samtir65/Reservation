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
                .WithColumn("CreateOn").AsDateTime().NotNullable()
                .WithColumn("CustomerId").AsString(500).NotNullable()
                .WithColumn("ServiceId").AsInt64().NotNullable()
                .WithColumn("PersonelId").AsDateTime().Nullable();
        }
    }
}
