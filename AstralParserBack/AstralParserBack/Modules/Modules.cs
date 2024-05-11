using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AstralParserBack.Modules
{
    public class developer
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(255)]
        public string nickname { get; set; }

        [Required]
        [MaxLength(255)]
        public string passwd { get; set; }

        [Required]
        [MaxLength(255)]
        public string firstname { get; set; }

        [Required]
        [MaxLength(255)]
        public string surename { get; set; }

        [MaxLength(255)]
        public string fathername { get; set; }

        [Required]
        public bool havepermission { get; set; }
    }

    public class admin
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(255)]
        public string nickname { get; set; }

        [Required]
        [MaxLength(255)]
        public string passwd { get; set; }

        [Required]
        [MaxLength(255)]
        public string firstname { get; set; }

        [Required]
        [MaxLength(255)]
        public string surename { get; set; }

        [MaxLength(255)]
        public string fathername { get; set; }
    }

    public class history
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int developerid { get; set; }

        [JsonIgnore]
        public developer developer { get; set; }

        [Required]
        public DateTime buildtime { get; set; }

        [Required]
        public int jobid { get; set; }

        public job job { get; set; }

        [Required]
        public int statusid { get; set; }

        public status status { get; set; }
    }

    public class job
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(255)]
        public string jobname { get; set; }

        // Navigation property
        public ICollection<history> history { get; set; }
    }

    public class status
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(255)]
        public string name { get; set; }

        // Navigation property
        public ICollection<history> history { get; set; }
    }
}
