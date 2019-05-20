using DevFramework.Core.DataAccess.NHibernate;
using NHibernate;

namespace DevFramework.Northwind.DataAccess.NHibernate.Helpers
{
    public class SqlServerHelper: NHibernateHelper
    {
        protected override ISessionFactory InitializeFactory()
        {
            throw new System.NotImplementedException();
        }
    }
}