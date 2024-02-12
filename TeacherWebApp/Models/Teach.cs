using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeacherWebApp.Models
{
    [Table("Students")]
    public class Teach
    {
        [Key]
        public int SId { get; set; }
        public string? SName { get; set; }
        public string? Subject { get; set; }

        public double Marks { get; set; }

    }
}
