using System.ComponentModel.DataAnnotations;

namespace DiaryApp.Models
{
    public class DiaryEntry
    {
        //create property to match the DB column names
        public int Id { get; set; }

        //add annotations for client side validation error messages
        [Required(ErrorMessage ="Please enter a title!")]
        [StringLength(100,MinimumLength =3,ErrorMessage ="Title must be between 3 to 100 characters.")]
        public string Title { get; set; }=string.Empty;//set default value for required props or set it as non-nullable with string?

        [Required(ErrorMessage ="Please enter a content for diary entry!")]
        [StringLength(300,MinimumLength =3,ErrorMessage ="Content must be between 3 to 300 characters.")]
        public string Content { get; set; }=string.Empty;

        [Required(ErrorMessage ="Please select a date for dairy entry!")]
        public DateTime Created { get; set; }=DateTime.Now;
    }
}
