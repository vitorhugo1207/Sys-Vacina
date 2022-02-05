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

        [Column("VaccinePrice")]
        [Display(Name = "Vaccine Price")]
        [StringLength(10)]
        [Required(ErrorMessage = "You must insert VaccinePrice")]
        public decimal VaccinePrice { get; set; }

        [Column("DataVaccination")]
        [Display(Name = "Data Vaccine")]
        [StringLength(8)]
        [Required(ErrorMessage = "You must insert data Vaccine")]
        public DateTime DataVaccination { get; set; }

        [Column("PersonID")]
        [Display(Name = "Client Name")]
        [StringLength(100)]
        [Required(ErrorMessage = "You must insert the client name.")]
        public int PersonID { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
