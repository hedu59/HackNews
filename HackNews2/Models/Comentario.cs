using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HackNews2.Models
{
    public class Comentario
    {
        [Key()]
        public int Id { get; set; }
        public string Comentarios { get; set; }
        public string AutorComentario { get; set; }
        public DateTime Data { get; set; }

        [ForeignKey("Noticia")]
        public int NoticiaId { get; set; }
        public virtual Noticia Noticia { get; set; }
    }
}