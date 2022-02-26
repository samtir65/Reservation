// Decompiled with JetBrains decompiler
// Type: Respect.NH.SessionFactoryBuilder
// Assembly: Respect.NH, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: DA4DCF3D-5563-415D-B353-FC11CFB50050
// Assembly location: C:\Users\admin\.nuget\packages\respect.nh\1.0.1\lib\net5.0\Respect.NH.dll

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.Loquacious;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Engine;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Impl;

namespace Framework.NH
{
    public static class SessionFactoryBuilder
    {
        public static ISessionFactory CreateByConnectionString(
          string connectionString,
          Assembly mappingAssembly,
          string sessionName,
          FilterDefinition filterDefinition = null,
          FilterDefinition isActiveFilterDefinition = null)
        {
            Configuration configuration = new Configuration();
            if (filterDefinition != null)
                configuration.AddFilterDefinition(filterDefinition);
            if (isActiveFilterDefinition != null)
                configuration.AddFilterDefinition(isActiveFilterDefinition);
            configuration.SessionFactoryName(sessionName);
            configuration.DataBaseIntegration((Action<DbIntegrationConfigurationProperties>)(db =>
            {
                db.Dialect<MsSql2012Dialect>();
                db.Driver<SqlClientDriver>();
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                db.IsolationLevel = IsolationLevel.ReadCommitted;
                db.ConnectionString = connectionString;
                db.Timeout = (byte)30;
            }));
            configuration.AddAssembly(mappingAssembly);
            ModelMapper modelMapper = new ModelMapper();
            modelMapper.BeforeMapClass += (RootClassMappingHandler)((mi, t, map) => map.DynamicUpdate(true));
            modelMapper.AddMappings((IEnumerable<Type>)mappingAssembly.GetExportedTypes());
            HbmMapping mappingDocument = modelMapper.CompileMappingForAllExplicitlyAddedEntities();
            configuration.AddDeserializedMapping(mappingDocument, sessionName);
            return configuration.BuildSessionFactory();
        }
    }
}
