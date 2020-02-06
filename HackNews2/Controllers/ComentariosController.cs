using HackNews2.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HackNews2.Controllers
{
    public class ComentariosController : Controller
    {
        private Contexto db = new Contexto();


        public ActionResult Lista(int id)
        {
            var comentarios = db.Comentarios
                .Include(c => c.Noticia)
                .Where(x=> x.NoticiaId ==id);

            if(comentarios != null && comentarios.Count() > 0)
            {
                var NoticiaId = comentarios.FirstOrDefault().NoticiaId.ToString();
                ViewBag.Noticia = NoticiaId + "-"+ comentarios.FirstOrDefault().Noticia.Titulo;
                ViewBag.NoticiaId = NoticiaId;
            }

            return View(comentarios.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentarios.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

   
        public ActionResult Create(int? id)
        {
            var noticias = new SelectList(db.Noticias, "Id", "Titulo");

            if (id != null)
            {
                ViewBag.NoticiaId = noticias.Where(x => x.Value == id.ToString());
            }
            else
            {
                ViewBag.NoticiaId = noticias;
            }

            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Comentarios,AutorComentario,Data,NoticiaId")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                comentario.Data = DateTime.Now;
                db.Comentarios.Add(comentario);
                db.SaveChanges();
                return RedirectToAction("Lista","Comentarios", new { id = comentario.NoticiaId });
            }

            ViewBag.NoticiaId = new SelectList(db.Noticias, "Id", "Titulo", comentario.NoticiaId);
            return View(comentario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
