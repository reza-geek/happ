namespace backend.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Table("Doctor")]
    public class Doctor
    {
        [Key]
        [Column("DR_ID")]
        public int Dr_ID { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Dr_Name { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Dr_Family { get; set; }
        public string Dr_NationalCode { get; set; }
        public string Dr_Mobile { get; set; }
        public string Specialty { get; set; }
        //public Nullable<int> User_ID { get; set; }

        public string Insert_date { get; set; }
        public string Other_Center { get; set; }

        //public ICollection<Catheterisation> Catheterisation { get; set; }
        public User? User { get; set; }
    }
}
