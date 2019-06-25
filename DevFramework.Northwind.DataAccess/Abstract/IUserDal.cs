using System.Collections.Generic;
using DevFramework.Core.DataAccess;
using DevFramework.Northwind.Entities.ComplexTypes;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.DataAccess.Abstract
{
    public interface IUserDal: IEntityRepository<User>
    {
        List<UserRoleItem> GetUserRoles(User user);
    }
}