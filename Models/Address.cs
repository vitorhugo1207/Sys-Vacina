using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgramaEstagio.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        [Column("ID")]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Column("Street")]
        [Display(Name = "Rua")]
        [StringLength(100)]
        [Required(ErrorMessage = "Você deve preencher esse campo.")]
        public string Country { get; set; }

        [Column("Complement")]
        [Display(Name = "Complemento")]
        [StringLength(80)]
        public string Complement { get; set; }

        [Column("Distric")]
        [Display(Name = "Bairro")]
        [StringLength(100)]
        [Required(ErrorMessage = "Você deve preencher esse campo.")]
        public string Distric { get; set; }

        [Column("City")]
        [Display(Name = "Cidade")]
        [StringLength(100)]
        [Required(ErrorMessage = "Você deve preencher esse campo.")]
        public string City { get; set; }

        [Column("State")]
        [Display(Name = "Estado")]
        [StringLength(2)]
        [Required(ErrorMessage = "Você deve preencher esse campo.")]
        public string State { get; set; }

        [Column("PersonID")]
        [Display(Name = "Nome do Cliente")]
        [Required(ErrorMessage = "Você deve preencher esse campo.")]
        public int PersonID { get; set; }

        public virtual Person Person{ get; set; }
    }
}
