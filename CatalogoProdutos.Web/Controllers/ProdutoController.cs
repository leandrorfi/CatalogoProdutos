using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CatalogoProdutos.Dominio.Entidades;
using CatalogoProdutos.Dominio.Repositorio;
using PagedList;

namespace CatalogoProdutos.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutoContexto db = new ProdutoContexto();
        private IRepositorio<Produto> _repositorioProduto;

        public ProdutoController()
        {
            _repositorioProduto = new ProdutoRepositorio(new ProdutoContexto());
        }


        public ActionResult Catalogo(int? pagina)
        {
            int tamanhoPagina = 5;
            int numeroPagina = pagina ?? 1;
            return View(_repositorioProduto.GetTodos().ToPagedList(numeroPagina, tamanhoPagina));
        }

        // GET: Produto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoId,SKU,Nome,Descricao,Imagem,ImagemTipo")] Produto produto, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var arqImagem = new Produto
                    {
                        ImagemTipo = upload.ContentType
                    };
                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        arqImagem.Imagem = reader.ReadBytes(upload.ContentLength);
                    }
                    produto.Imagem = arqImagem.Imagem;
                    produto.ImagemTipo = arqImagem.ImagemTipo;
                }

                db.Produtos.Add(produto);
                db.SaveChanges();
                TempData["mensagem"] = string.Format("{0} : foi incluido com sucesso", produto.Nome);
                return RedirectToAction("Catalogo");
            }
            return View(produto);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoId,SKU,Nome,Descricao,Imagem,ImagemTipo")] Produto produto, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var arqImagem = new Produto
                    {
                        ImagemTipo = upload.ContentType
                    };
                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        arqImagem.Imagem = reader.ReadBytes(upload.ContentLength);
                    }
                    produto.Imagem = arqImagem.Imagem;
                    produto.ImagemTipo = arqImagem.ImagemTipo;
                }
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                TempData["mensagem"] = string.Format("{0} : foi atualizado com sucesso", produto.Nome);
                return RedirectToAction("Catalogo");
            }
            return View(produto);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            TempData["mensagem"] = string.Format("{0} : foi excluido com sucesso", produto.Nome);
            return RedirectToAction("Catalogo");
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
