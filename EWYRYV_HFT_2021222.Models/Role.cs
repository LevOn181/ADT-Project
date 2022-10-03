using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWYRYV_HFT_202223.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        [StringLength(240)]
        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; }


        public Role()
        {

        }

        public Role(string line)
        {
            string[] split = line.Split("#");
            RoleId = int.Parse(split[0]);
            Name = split[1];
        }
    }
}
