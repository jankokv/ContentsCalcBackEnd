using System.ComponentModel.DataAnnotations;

namespace ContentsCalcBackEnd.Core.Models
{
   public class ContentsCalculatorItem : BaseEntity
    {
        public int Id { get; set; }

        [StringLength(250)]
        [Required]
        public string Name { get; set; }

        public int ContentsCategoryTypeId { get; set; }
        public ContentsCategoryType ContentsCategoryType { get; set; }

        [Required]
        public double Value { get; set; }
    }
}
