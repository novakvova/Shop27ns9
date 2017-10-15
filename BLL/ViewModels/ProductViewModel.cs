using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class AddCategoryProdViewModel
    {
        public string Name { get; set; }
        public bool Published { get; set; }
    }
    public class EditCategoryProdViewModel
    {
        public int Id { get; set; }
        [Display(Name="Назва категорії")]
        [Required(ErrorMessage ="Вкажіть назву категорії")]
        [StringLength(maximumLength: 255, MinimumLength = 2)]
        public string Name { get; set; }
        [Display(Name="Показ на сайті")]
        public bool Published { get; set; }
    }
    public class CategoryItemProdViewModel
    {
        public int Id { get; set; }
        [Display(Name="Назва")]
        public string Name { get; set; }
        [Display(Name = "Показ на сайті")]
        public bool Published { get; set; }
    }
}
