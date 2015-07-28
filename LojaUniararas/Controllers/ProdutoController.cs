using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaUniararas.DAO;
using LojaUniararas.Models;

namespace LojaUniararas.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            //chamada de regra de negocio
            ProdutoDAO produtoDAO = new ProdutoDAO();
            List<Produto> produtos = produtoDAO.ConsultaProduto();
            ViewBag.Produtos = produtos;
            //chamar a view correspondente
            return View();
        }

        public ActionResult Index2()
        {
            ProdutoDAO produtoDAO = new ProdutoDAO();
            List<Produto> produtos = produtoDAO.ConsultaProduto();
            return View(produtos);
        }

        public ActionResult Form()
        {
            CategoriaProdutoDAO categoriaProdutoDAO = new CategoriaProdutoDAO();
            List<CategoriaProduto> categorias = categoriaProdutoDAO.ConsultaCategoriaProduto();
            ViewBag.Categorias = categorias;
            return View();
        }

        [HttpPost]
        public ActionResult Form(Produto produto)
        {
            ProdutoDAO produtoDAO = new ProdutoDAO();
            produtoDAO.Adiciona(produto);
            return RedirectToAction("Index");
        }

        public ActionResult Inserir()
        {
            CategoriaProdutoDAO categoriaProdutoDAO = new CategoriaProdutoDAO();
            List<CategoriaProduto> categorias = categoriaProdutoDAO.ConsultaCategoriaProduto();
            ViewBag.Categorias = categorias;
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(Produto produto)
        {
            if (ModelState.IsValid)
            {
                if (produto.CategoriaID.Equals(1))
                {
                    if (produto.Preco < 1000)
                    {
                        ModelState.AddModelError("Erro", "O preço mínimo para produtos Portáteis é de R$1.000,00 ");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ProdutoDAO produtoDAO = new ProdutoDAO();
                        produtoDAO.Adiciona(produto);
                    }
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Remover(int id)
        {
            ProdutoDAO produtoDAO = new ProdutoDAO();
            produtoDAO.RemoveProduto(id);
            return RedirectToAction("Index");
        }
    }
}