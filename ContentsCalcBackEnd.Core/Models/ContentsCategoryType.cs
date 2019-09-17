using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContentsCalcBackEnd.Core.Models
{
    /// <summary>
    /// The Contents Category Type Class
    /// </summary>
    public class ContentsCategoryType: BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
