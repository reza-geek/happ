namespace backend.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Table("CatheterEject")]
    public class CatheterEject
    {
        [Key]
        public int CatheterEject_ID { get; set; }
        [Required(ErrorMessage = "Required")]
        public string EjectReason { get; set; }

        //public ICollection<Catheterisation> Catheterisation { get; set; }

    }
}
