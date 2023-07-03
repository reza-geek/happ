namespace backend.Models
{   using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Table("user_tbl")]
    public class User
    {
        [Key]
        public int User_ID { get; set; }
        [Required(ErrorMessage = "Required!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Required!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required!")]
        public string Family { get; set; }
        public string National_Code { get; set; }
        public string Mobile { get; set; }
        public string Create_DateTime { get; set; }


        public Nullable<bool> Is_Active { get; set; }
        public Nullable<int> LoginFailedCount { get; set; }
        public string LastLoginDate { get; set; }

       // public List<Patient> Patients { get; set; }
        //public ICollection<Patient> Patient { get; set; }
        //public ICollection<Doctor> Doctor { get; set; }
    }
}
