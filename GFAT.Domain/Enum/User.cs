
using System.ComponentModel.DataAnnotations;

namespace GFAT.Domain.Enum;

    public enum Role
    {
        [Display(Name = "Пользователь")]
        User = 0,
        [Display(Name = "Кур'єр")]
        Moderator = 1,
        [Display(Name = "Админ")]
        Admin = 2,
    }
