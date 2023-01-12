using GFAT.DALL.Interface;
using GFAT.Domain.Enum;
using GFAT.Domain.Extensions;
using GFAT.Domain.Models;
using GFAT.Domain.Response;
using GFAT.Domain.ViewModels.Order;
using GFAT.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GFAT.Service.Implementations;

public class BasketService : IBasketService
{
    private readonly IBaseRepository<User> _userRepository;
    private readonly IBaseRepository<Food> _carRepository;

    public BasketService(IBaseRepository<User> userRepository, IBaseRepository<Food> foodRepository)
    {
        _userRepository = userRepository;
        _carRepository = foodRepository;
    }

    public async Task<IBaseResponse<IEnumerable<OrderViewModel>>> GetItems(string userName)
    {
        try
        {
            var user = await _userRepository.GetAll()
                .Include(x => x.Basket)
                .ThenInclude(x => x.Orders)
                .FirstOrDefaultAsync(x => x.Name == userName);

            if (user == null)
            {
                return new BaseResponse<IEnumerable<OrderViewModel>>()
                {
                    Description = "Пользователь не найден",
                    StatusCode = StatusCode.UserNotFound
                };
            }

            var orders = user.Basket?.Orders;
            var response = from p in orders
                join c in _carRepository.GetAll() on p.FoodId equals c.id
                select new OrderViewModel()
                {
                    id = p.id,
                    FoodName = c.name,
                    CataforyFood = c.CatagoryFood.GetDisplayName(),
               
                };

            return new BaseResponse<IEnumerable<OrderViewModel>>()
            {
                Data = response,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<IEnumerable<OrderViewModel>>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<OrderViewModel>> GetItem(string userName, long id)
    {
        try
        {
            var user = await _userRepository.GetAll()
                .Include(x => x.Basket)
                .ThenInclude(x => x.Orders)
                .FirstOrDefaultAsync(x => x.Name == userName);

            if (user == null)
            {
                return new BaseResponse<OrderViewModel>()
                {
                    Description = "Пользователь не найден",
                    StatusCode = StatusCode.UserNotFound
                };
            }

            var orders = user.Basket?.Orders.Where(x => x.id == id).ToList();
            if (orders == null || orders.Count == 0)
            {
                return new BaseResponse<OrderViewModel>()
                {
                    Description = "Заказов нет",
                    StatusCode = StatusCode.OrderNotFound
                };
            }

            var response = (from p in orders
                join c in _carRepository.GetAll() on p.FoodId equals c.id
                select new OrderViewModel()
                {
                    id = p.id,
                    FoodName = c.name,
                    CataforyFood= c.CatagoryFood.GetDisplayName(),
                    Address = p.Address,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    MiddleName = p.MiddleName,
               
                }).FirstOrDefault();

            return new BaseResponse<OrderViewModel>()
            {
                Data = response,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<OrderViewModel>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}