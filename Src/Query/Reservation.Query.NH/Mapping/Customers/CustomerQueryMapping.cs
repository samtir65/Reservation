using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Reservation.Query.Model.Customers;

namespace Reservation.Query.NH.Mapping.Customers
{
    public class CustomerQueryMapping : ClassMapping<CustomerQuery>
    {
        public CustomerQueryMapping()
        {
            Table("Customers");
            Lazy(false);
            Property(x => x.Id);
            Property(x => x.FirstName);
            Property(x => x.LastName);
            Property(x => x.CreateOn);
            IdBag(x => x.CustomerPhones, map =>
            {
                map.Table("CustomersPhones");
                map.Key(x => x.Column("Customer_id"));
                map.Cascade(Cascade.All);
                map.Access(Accessor.Property);
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