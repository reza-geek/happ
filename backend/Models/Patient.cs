namespace backend.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Table("Patient")]
    public class Patient
    {
        //public Patient()
        //{
        //}

        [Key]
        public long Patient_ID { get; set; }
         public string FName { get; set; }
        public string LName { get; set; }
        public string Birthdate { get; set; }
        public string National_Code { get; set; }
        public string ? Phone { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string ? Insert_Date { get; set; }

        [ForeignKey("User")]
        public int  User_ID { get; set; }
        public User ? User { get; set; }
        
        //public ICollection<Reception> Reception { get; set; }
    }
}
