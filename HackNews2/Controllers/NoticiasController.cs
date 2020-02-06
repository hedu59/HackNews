using HackNews2.Models;
using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HackNews2.Controllers
{
    public class NoticiasController : Controller
    {
        private Contexto db = new Contexto();


        public ActionResult Index(string titulo)
        {
            var noticias = db.Noticias.ToList();

            if (!String.IsNullOrEmpty(titulo))
            {
                var filtro = noticias.Where(s => s.Titulo.Contains(titulo)).ToList();

                if (filtro != null && filtro.Count >0)
                {
                    noticias = filtro;
                }
                else
                {
                    Response.Write("<script> window.onload = function() { alert('Nenhum titulo encontrado nos filtros selecionados!'); } </script>");
                }
                
            }

           return View(noticias);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Noticia noticia = db.Noticias.Find(id);
            if (noticia == null)
            {
                return HttpNotFound();
            }
            return View(noticia);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,ConteudoNoticia,Data,AutorNoticia")] Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                noticia.Data = DateTime.Now;
                db.Noticias.Add(noticia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(noticia);
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
