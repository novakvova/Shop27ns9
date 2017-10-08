using System.Data.Entity;

namespace DAL.Entities
{
    public class DBInitializer : CreateDatabaseIfNotExists<EFContext> //DropCreateDatabaseAlways<EFContext> //
    {
        protected override void Seed(EFContext context)
        {
            base.Seed(context);
        }
    }
}