using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Murach_Guitar.Models
{
    public class Product
    {
        #region properties
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please enter a product code.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please enter a product Name.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please enter a product price.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        #endregion

        #region calculated properties
        public decimal DiscountPercent => 0.20M; //20%

        public decimal DiscountAmount => Price * DiscountPercent;

        public decimal DiscountPrice => Price - DiscountAmount;

        public string Slug { get { return Name == null ? "" : Name.Replace(' ', '-'); } }
        #endregion

        #region foreign peoperties
        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryID { get; set; }

        public Category Category { get; set; }
        #endregion

    }
}
