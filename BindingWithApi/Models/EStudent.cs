using System.ComponentModel.DataAnnotations;

namespace BindingWithApi.Models
{
    public class EStudent
    {
        public int id { get; set; }
        [Required]
        public string studentName { get; set; }

        [Required]
        public string studentGender { get; set; }
        [Required]
        public int standard { get; set; }
    }

}
