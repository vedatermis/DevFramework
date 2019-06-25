using System.Data.Entity.ModelConfiguration;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap: EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users", "dbo");
            HasKey(x => x.Id);

            Property(x => x.UserName).HasColumnName("Email");
            Property(x => x.Password).HasColumnName("Password");
            Property(x => x.FirstName).HasColumnName("FirstName");
            Property(x => x.LastName).HasColumnName("LastName");
            Property(x => x.Email).HasColumnName("Email");
        }
    }
}