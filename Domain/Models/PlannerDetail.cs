

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewPlannerAPI.Domain.Models
{
    public class PlannerDetail:CommonFields
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("HeaderId")]
        public int HeaderId {  get; set; }
        [Column("Name")]
        public string? Name {  get; set; }
        [Column("Scheduling_Lead_time")]
        public int? SchedulingLeadtime{get; set; }
        [Column("Attendant_Sheet")]
        public int? AttendantSheet {  get; set; }
        [Column("Stretchers")]
        public int? Stretchers {  get; set; }
        [Column("Acuity")]
        public string? Acuity {  get; set; }
        [Column("IsMultiLoad")]
        public string? IsMultiLoad { get; set; }
        [Column("Serviced_By")]
        public string? ServicedBy {  get; set; }
        [Column("IsParalllelPickup")]
        public int IsParalllelPickup {  get; set; }
        [Column("Sequence")]
        public int? Sequence {  get; set; }


    }
}
