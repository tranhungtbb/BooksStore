using HDs.BookStore.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace HDs.BookStore.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BookStoreController : AbpControllerBase
{
    protected BookStoreController()
    {
        LocalizationResource = typeof(BookStoreResource);
    }
}
