namespace backend.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Table("Catheter")]
    public class Catheter
    {
        [Key]
        [Column("Catheter_ID")]
        public int Catheter_ID { get; set; }
        [Required(ErrorMessage = "Required!")]
        public string Catheter_Name { get; set; }

       // public ICollection<Catheterisation> Catheterisation { get; set; }
    }
}
