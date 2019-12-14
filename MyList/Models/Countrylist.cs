using System.ComponentModel.DataAnnotations;

namespace MyList.Models
{
    public class Countrylist
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Country name is required"), StringLength(20),]
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }
    }
}
