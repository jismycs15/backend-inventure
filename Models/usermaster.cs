using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inventure.Models
{
    [Table("admusrmsr")]
    public class usermaster
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_name")]
        public string UserName { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("system_role")]
        public string SystemRole { get; set; }


        [Column("location")]
        public string Location { get; set; }

        [Column("phone_number")]
        public string PhoneNumber{ get; set; }
    }
}
