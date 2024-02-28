using System.ComponentModel.DataAnnotations.Schema;

namespace NewPlannerAPI.Domain.Models
{
    public class CommonFields
    {
        [Column("CreatedBy")]
        public int? CreatedBy { get; set; }
        [Column("Created_Datetime")]
        public DateTime? CreatedDatetime { get; set; }
        [Column("ModifiedBy")]
        public int? ModifiedBy { get; set; }
        [Column("Modeified_Datetime")]
        public DateTime? ModifiedDatetime{get; set; }
        [Column("DeletedBy")]
        public int? DeletedBy { get; set; }
        [Column("Deleted_Datetime")]
        public DateTime? DeletedDatetime { get; set; }
    }
}
