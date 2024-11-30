using System.ComponentModel.DataAnnotations;

namespace DiaryApp.Models
{
    public class DiaryEntry
    {
        //create property to match the DB column names
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }=string.Empty;//set default value for required props or set it as non-nullable with string?

        [Required]
        public string Content { get; set; }=string.Empty;

        [Required]
        public DateTime Created { get; set; }=DateTime.Now;
    }
}
