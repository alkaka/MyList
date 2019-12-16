using System.ComponentModel.DataAnnotations;

namespace MyList.Models
{
    public class Customerlist
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer Name is required"), StringLength(25),]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        //Navigation properties,
        public int CountryListId { get; set; }
        public Countrylist Countrylist { get; set; }
    }
}
