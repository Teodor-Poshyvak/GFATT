using GFAT.Domain.Response;
using GFAT.Domain.ViewModels.Order;

namespace GFAT.Service.Interfaces;

public interface IBasketService
{
    Task<IBaseResponse<IEnumerable<OrderViewModel>>> GetItems(string userName);

    Task<IBaseResponse<OrderViewModel>> GetItem(string userName, long id);
}