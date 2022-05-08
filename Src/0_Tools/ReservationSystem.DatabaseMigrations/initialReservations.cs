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
                .WithColumn("PersonnelId").AsInt64().NotNullable()
                .WithColumn("CreatorUserId").AsInt64().NotNullable();

            Create.Table("Personels")
                .WithColumn("Id").AsInt64().PrimaryKey().NotNullable()
                .WithColumn("FirstName").AsString().NotNullable()
                .WithColumn("LastName").AsString().NotNullable()
                .WithColumn("CreatorUserId").AsInt64().NotNullable();

            Create.Table("Customers")
                .WithColumn("Id").AsInt64().PrimaryKey().NotNullable()
                .WithColumn("FirstName").AsString().NotNullable()
                .WithColumn("LastName").AsString().NotNullable()
                .WithColumn("CreateOn").AsDateTime2().NotNullable()
                .WithColumn("CreatorUser_Id").AsInt64().NotNullable();

            Create.Table("CustomersPhones")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity().NotNullable()
                .WithColumn("Area").AsString(10)
                .WithColumn("Number").AsString(255).NotNullable()
                .WithColumn("Customer_Id").AsInt64().ForeignKey("Customers", "Id").NotNullable();

            Create.Table("Skills")
                .WithColumn("Id").AsInt64().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(255).NotNullable();

            Create.Table("AssignedSkills")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity().NotNullable()
                .WithColumn("SkillId").AsInt64().ForeignKey("Skills", "Id").NotNullable()
                .WithColumn("PersonnelId").AsInt64().ForeignKey("Personels", "Id").NotNullable()
                .WithColumn("Amount").AsString().NotNullable();

            Create.Table("RequiredSkills")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity().NotNullable()
                .WithColumn("SkillId").AsInt64().ForeignKey("Skills", "Id").NotNullable()
                .WithColumn("ReservationId").AsInt64().ForeignKey("Reservations", "Id").NotNullable();

            Create.Sequence("SequenceReservation").Cache(20).IncrementBy(1).StartWith(1);
            Create.Sequence("SequenceCustomer").Cache(20).IncrementBy(1).StartWith(1);
        }
    }
}
