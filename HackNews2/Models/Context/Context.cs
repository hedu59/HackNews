using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HackNews2.Models
{
    public class Contexto : DbContext
    {
        public Contexto() : base("PgNews")
        {
            Database.Log = c => System.Diagnostics.Debug.WriteLine(c);
        }

        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }


    }
}