namespace backend.Models
{   using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Table("Catheterisation")]
    public class Catheterisation
    {
        [Key]
        public long Catheterisation_ID { get; set; }
       // public long Reception_ID { get; set; }
       // public int Dr_ID { get; set; }
        public Nullable<bool> Has_Event { get; set; }
        //public Nullable<int> Event_ID { get; set; }
        public string Event_Desc { get; set; }
        public string Catheterisation_Date { get; set; }
        public Nullable<int> User_ID { get; set; }
       // public Nullable<int> Catheter_ID { get; set; }
        public string Catheterisation_EjectDate { get; set; }
       // public Nullable<int> CatheterEject_ID { get; set; }
        public Nullable<System.DateTime> Catheterisation_DateEn { get; set; }
        public Nullable<System.DateTime> Catheterisation_EjectDateEn { get; set; }
        public CatheterEject? CatheterEject { get; set; }
        [Column("DR_ID")]
        public Doctor Doctor { get; set; }
        public Reception Reception { get; set; }


        //public ICollection<Catheter_event> Catheter_event { get; set; }
    }
}
