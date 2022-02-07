using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgramaEstagio.Models
{
    [Table("Vaccine")]
    public class Vaccine
    {
        [Key]
        [Column("ID")]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Column("VaccineName")] // Column in table
        [StringLength(100)] // String Length
        [Display(Name = "Nome da Vacina")] // Display
        [Required(ErrorMessage = "Você deve preencher esse campo.")] // Set as obligatory field
        public string VaccineName { get; set; } // Set a variable for column

        [Column("VaccinePrice")]
        [Display(Name = "Preço da Vacina")]
        [StringLength(20)]
        [Required(ErrorMessage = "Você deve preencher esse campo.")]
        public decimal VaccinePrice { get; set; }

        [Column("DataVaccination")]
        [Display(Name = "Data da Vacinação")]
        public DateTime DataVaccination { get; set; }

        [Column("PersonID")]
        [Display(Name = "Nome do Cliente")]
        [StringLength(100)]
        [Required(ErrorMessage = "Você deve preencher esse campo.")]
        public int PersonID { get; set; }

        public virtual Person Person { get; set; }
    }
}
