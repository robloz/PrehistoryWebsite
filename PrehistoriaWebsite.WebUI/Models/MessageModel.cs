using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrehistoryWebsite.Models
{
    public class MessageModel
    {
        [Required(ErrorMessage = "Inserta el correo")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Inserta un correo válido")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Inserta el asunto")]
        public String Asunto { get; set; }
        [Required(ErrorMessage = "Inserta el mensaje")]
        public String Message { get; set; }

        public String CheckSpam { get; set; } // if it's not equal to "", it's a span
    }
}