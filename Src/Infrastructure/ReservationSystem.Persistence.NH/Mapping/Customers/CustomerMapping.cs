using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using ReservationSystem.Domain.Models.Customers;

namespace ReservationSystem.Persistence.NH.Mapping.Customers
{
    public class CustomerMapping : ClassMapping<Customer>
    {
        public CustomerMapping()
        {
            Table("Customers");
            Lazy(false);
            ComponentAsId(x => x.Id, map =>
            {
                map.Property(x => x.DbId, z => z.Column("Id"));
            });
            Property(x => x.CreateOn);
            Property(x => x.FirstName);
            Property(x => x.LastName);
            Property(x => x.CreatorUserId, x => x.Column("CreatorUser_Id"));

            IdBag(x => x.CustomerPhones, map =>
            {
                map.Table("CustomersPhones");
                map.Key(x => x.Column("Customer_Id"));
                map.Cascade(Cascade.All);
                map.Access(Accessor.Field);
                map.Id(x =>
                {
                    x.Column("Id");
                    x.Generator(Generators.Identity);
                });
            }, relation => relation.Component(mapper =>
            {
                mapper.Property(x => x.Area);
                mapper.Property(x => x.Number);
            }));
        }

    }
}