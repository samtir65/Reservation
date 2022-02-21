using System.Data;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Engine;
using NHibernate.Event;
using NHibernate.Mapping.ByCode;

namespace Framework.NH
{
    public static class SessionFactoryBuilder
    {
        public static ISessionFactory CreateByConnectionString(string connectionString, Assembly mappingAssembly,string sessionName
            , FilterDefinition filterDefinition = null, FilterDefinition isActiveFilterDefinition = null)
        {
            var configuration = new Configuration();
            if (filterDefinition != null)
                configuration.AddFilterDefinition(filterDefinition);
            if (isActiveFilterDefinition != null)
                configuration.AddFilterDefinition(isActiveFilterDefinition);
            configuration.SessionFactoryName(sessionName);
            configuration.DataBaseIntegration(db =>
            {
                db.Dialect<MsSql2012Dialect>();
                db.Driver<SqlClientDriver>();
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                db.IsolationLevel = IsolationLevel.ReadCommitted;
                db.ConnectionString = connectionString;
                db.Timeout = 30;
            });
            configuration.AddAssembly(mappingAssembly);
            var modelMapper = new ModelMapper();
            modelMapper.BeforeMapClass += (mi, t, map) => map.DynamicUpdate(true);
            modelMapper.AddMappings(mappingAssembly.GetExportedTypes());
            var mappingDocument = modelMapper.CompileMappingForAllExplicitlyAddedEntities();
            configuration.AddDeserializedMapping(mappingDocument, sessionName);
            AddDomainEventListeners(configuration);
            return configuration.BuildSessionFactory();
        }

        private static void AddDomainEventListeners(Configuration configuration)
        {
            var listener=new DomainEventListener();
            configuration.SetListeners(ListenerType.PreUpdate, new[] {listener});
            configuration.SetListeners(ListenerType.PreInsert, new[] { listener });
            configuration.SetListeners(ListenerType.PreCollectionRecreate, new[] { listener });
            configuration.SetListeners(ListenerType.PreCollectionUpdate, new[] { listener });

        }
    }
}
