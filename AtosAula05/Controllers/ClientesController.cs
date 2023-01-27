using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using AtosAula05.Dados;
using AtosAula05.Models;

namespace AtosAula05.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {
            try
            {
                return View(Repositorio.ListarClientes());
            }
            catch (Exception ex)
            {
                ViewBag.MensagemErro = ex.Message;
                return View("_Erro");
            }
        }

        [HttpGet]
        public ActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(Clientes Novo)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                Repositorio.NovoCliente(Novo);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                ViewBag.MensagemErro = ex.Message;
                return View("_Erro");
            }
        }

        private ActionResult BuscarCliente(int Codigo, string Operacao)
        {
            try
            {
                var InfoCli = Repositorio.PesquisarCliente(Codigo);
                return View(Operacao, InfoCli);
            }
            catch (Exception erro)
            {
                ViewBag.MensagemErro = erro.Message;
                return View("_Erro");
            }
        }

        public ActionResult Detalhes(int Codigo)
        {
            return BuscarCliente(Codigo, "Pesquisar");
        }

        [HttpGet]
        public ActionResult Alterar(int Codigo)
        {
            return BuscarCliente(Codigo, "Alterar");
        }

        [HttpPost]
        public ActionResult Alterar(Clientes Alt)
        { 
            try
            {
                Repositorio.AlterarCliente(Alt);
                return RedirectToAction("Listar");
            }
            catch (Exception erro)
            {
                ViewBag.MensagemErro = erro.Message;
                return View("_Erro");
            }
        }

        [HttpGet]
        public ActionResult Apagar(int Codigo)
        {
            return BuscarCliente(Codigo, "Apagar");
        }

        [HttpPost]
        public ActionResult Apagar(Clientes Tchau)
        {
            try
            {
                Repositorio.ApagarCliente(Tchau);
                return RedirectToAction("Listar");
            }
            catch (Exception erro)
            {
                ViewBag.MensagemErro = erro.Message;
                return View("_Erro");
            }
        }
    }
}