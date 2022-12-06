namespace backend.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Table("Clearance")]
    public class Clearance
    {
        [Key]
        public int Clearance_ID { get; set; }
        public string Clearance_Type { get; set; }

        //public ICollection<Reception> Reception { get; set; }
    }
}
