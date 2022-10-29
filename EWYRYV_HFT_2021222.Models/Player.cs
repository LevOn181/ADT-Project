
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EWYRYV_HFT_202223.Models
{
    [Table("player")]
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerId { get; set; }

        [Range(1, 99)]
        public int? KitNumber { get; set; }

        [Required]
        [Range(1, 12)]
        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }

        [Required]
        [StringLength(240)]
        public string Name { get; set; }

        public int? RoleId { get; set; }
        public string? BirthDate { get; set; }
        public int? Value { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Team Team { get; set; }

        public Player()
        {

        }

        public Player(string line)
        {
            string[] split = line.Split('#');
            PlayerId = int.Parse(split[0]);
            KitNumber = int.Parse(split[1]);
            TeamId = int.Parse(split[2]);
            RoleId = int.Parse(split[3]);
            Name = split[4];
            BirthDate = split[5];
            Value = int.Parse(split[6]);
        }
    }
}
