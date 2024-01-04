using Microsoft.Extensions.FileProviders;
using System.ComponentModel.DataAnnotations;

namespace GMS.Entities.Models
{
    public class Tfa
    {
        [Key]
        public int ID { get; set; }
        public string TwoFKey { get; set; }
    }
}
