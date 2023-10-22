using System.Threading.Tasks;

namespace HDs.BookStore.Data;

public interface IBookStoreDbSchemaMigrator
{
    Task MigrateAsync();
}
