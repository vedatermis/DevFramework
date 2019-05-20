using System.Linq;
using DevFramework.Core.Entities;

namespace DevFramework.Core.DataAccess.NHibernate
{
    public class NhQueryableRepository<T>: IQueryableRepository<T> where T: class, IEntity, new()
    {
        private NHibernateHelper _nHibernateHelper;
        private IQueryable<T> _entities;

        public NhQueryableRepository(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public IQueryable<T> Table => this.Entities;

        public virtual IQueryable<T> Entities => _entities ?? _nHibernateHelper.OpenSession().Query<T>();
    }
}