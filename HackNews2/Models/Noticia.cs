using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HackNews2.Models
{
    public class Noticia
    {
        [Key()]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string ConteudoNoticia { get; set; }
        public DateTime Data { get; set; }
        public string AutorNoticia { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}