using System.ComponentModel.DataAnnotations;

namespace GFAT.Domain.Enum;

public enum CatagoryFood
{
     [Display(Name = "Piz")]
     Pizza = 0,
     
     [Display(Name = "Sus")]
     Sushi = 1,

     [Display(Name = "Huic")]
     Juice = 2,

     [Display(Name = "Tea")]
     Tea = 3
     
}