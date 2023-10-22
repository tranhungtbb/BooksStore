using HDs.BookStore.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace HDs.BookStore;

[DependsOn(
    typeof(BookStoreEntityFrameworkCoreTestModule)
    )]
public class BookStoreDomainTestModule : AbpModule
{

}
