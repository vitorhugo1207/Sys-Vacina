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
        [Display(Name = "Nome Completo")] // Display
        [Required(ErrorMessage = "Você deve preencher esse campo.")] // Set as obligatory field
        public string FullName { get; set; } // Set a variable for column

        [Column("BirthDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] // Formating string
        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Você deve preencher esse campo.")]
        public DateTime BirthDate { get; set; }

        [Column("Sex")]
        [StringLength(9)]
        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Você deve preencher esse campo.")]
        public string sex { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Vaccine> Vaccine { get; set; }
    }
}
