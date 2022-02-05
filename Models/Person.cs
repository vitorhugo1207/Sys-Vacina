using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgramaEstagio.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        [Column("ID")]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Column("Name")] // Column in table
        [StringLength(100)] // String Length
        [Display(Name = "Full Name")] // Display
        [Required(ErrorMessage = "The field full name is required.")] // Set as obligatory field
        public string FullName { get; set; } // Set a variable for column

        [Column("BirthDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] // Formating string
        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "The field birth date is required.")]
        public DateTime BirthDate { get; set; }

        [Column("Sex")]
        [StringLength(4)]
        [Display(Name = "Sex")]
        [Required(ErrorMessage = "The field sex if required.")]
        public string sex { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Vaccine> Vaccines { get; set; }
    }
}
