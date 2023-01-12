using GFAT.Domain.Models;
using GFAT.Domain.Response;
using GFAT.Domain.ViewModels.Order;

namespace GFAT.Service.Interfaces;

public interface IOrderService
{
    Task<IBaseResponse<Order>> Create(CreateOrderViewModel model);

    Task<IBaseResponse<bool>> Delete(long id);
}