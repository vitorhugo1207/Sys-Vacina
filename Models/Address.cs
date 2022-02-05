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
        [Display(Name = "Street")]
        [StringLength(100)]
        [Required(ErrorMessage = "You must insert the street")]
        public string Country { get; set; }

        [Column("Complement")]
        [Display(Name = "Complement")]
        [StringLength(80)]
        [Required(ErrorMessage = "You must insert the complement.")]
        public string Complement { get; set; }

        [Column("Distric")]
        [Display(Name = "Distric")]
        [StringLength(100)]
        [Required(ErrorMessage = "You must insert the distric.")]
        public string Distric { get; set; }

        [Column("City")]
        [Display(Name = "City")]
        [StringLength(100)]
        [Required(ErrorMessage = "You must insert the city.")]
        public string City { get; set; }

        [Column("State")]
        [Display(Name = "State")]
        [StringLength(2)]
        [Required(ErrorMessage = "You must insert the state.")]
        public string State { get; set; }

        [Column("PersonID")]
        [Display(Name = "Name client")]
        [Required(ErrorMessage = "You must insert the name.")]
        public int PersonID { get; set; }

        public virtual Person Person{ get; set; }
    }
}
