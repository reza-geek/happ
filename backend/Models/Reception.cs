namespace backend.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Reception")]
    public class Reception
    {
        //public Reception()
        //{ }
        [Key]
        public long Reception_ID { get; set; }
       // public long Patient_ID { get; set; }
        public string Rec_DateTime { get; set; }
        public string Recognization { get; set; }
       // public int Part_ID { get; set; }
        public string? Clearance_DESC { get; set; }
        //public Nullable<int> Clearance_ID { get; set; }
        public string? Clearance_DateTime { get; set; }
        // public int User_ID { get; set; }
        //[ForeignKey("User")]
       // public int User_ID { get; set; }
        public User User { get; set; }
        //public ICollection<Catheterisation> Catheterisation { get; set; }
        public Part Part { get; set; }
        public Clearance? Clearance { get; set; }
        public Patient Patient { get; set; }
    }
}
