using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewPlannerAPI.Domain.Models
{
    public class PlannerHeader:CommonFields
    {
        public PlannerHeader()
        {
            PlannerDetail = new HashSet<PlannerDetail>();
        }
        [Key,Column("Id")]
        public int Id { get; set; }
        [Column("PlannerName")]
        public string? PlannerName { get; set; }

        [ForeignKey("HeaderId")]
        public virtual ICollection<PlannerDetail> PlannerDetail { get; set; }
    }
}
