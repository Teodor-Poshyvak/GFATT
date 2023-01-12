using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace GFAT.Domain.ViewModels.Food;

public class FoodViewModel
{
    public long Id { get; set; }
	
    [Display(Name = "Название")]
    [Required(ErrorMessage = "Введите имя")]
    [MinLength(2, ErrorMessage = "Минимальная длина должна быть больше двух символов")]
    public string Name { get; set; }
	
    [Display(Name = "Описание")]
    [MinLength(50, ErrorMessage = "Минимальная длина должна быть больше 50 символов")]
    public string Description { get; set; }
	
    
    [Display(Name = "Стоимость")]
    [Required(ErrorMessage = "Укажите стоимость")]
    public decimal Price { get; set; }
    
	
    [Display(Name = "Тип автомобиля")]
    [Required(ErrorMessage = "Выберите тип")]
    public string CatagoryFood { get; set; }
	
    public IFormFile Avatar { get; set; }
	
    public byte[]? Image { get; set; }
}

