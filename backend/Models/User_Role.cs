namespace backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User_Role
    {
        [Key]
        public int User_Role_ID { get; set; }
        [Required(ErrorMessage ="Role Name is required")]
        public string Role_Name { get; set; }
    }
}
