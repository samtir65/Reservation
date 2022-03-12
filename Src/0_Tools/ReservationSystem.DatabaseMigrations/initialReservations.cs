﻿using FluentMigrator;

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

            Create.Sequence("SequenceReservation").Cache(20).IncrementBy(1).StartWith(1);
            Create.Sequence("SequenceCustomer").Cache(20).IncrementBy(1).StartWith(1);
        }
    }
}
