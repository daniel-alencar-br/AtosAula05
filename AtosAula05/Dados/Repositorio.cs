using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AtosAula05.Models;
using System.Data.Entity;
    
namespace AtosAula05.Dados
{
    public class Repositorio
    {
        // metodo para incluir um cliente
        public static void NovoCliente(Clientes Novo)
        {
            using (var ctx = new CursoAspEntities())
            {
                ctx.Clientes.Add(Novo);
                ctx.SaveChanges();
            }
        }

        // buscar um cliente por codigo (pesquisar)
        public static Clientes PesquisarCliente(int Codigo)
        {
            using (var ctx = new CursoAspEntities())
            {
                return ctx.Clientes.FirstOrDefault(p =>
                           p.Cod.Equals(Codigo));
            }
        }

        // trazer todos os clientes
        public static IEnumerable<Clientes> ListarClientes()
        {
            using (var ctx = new CursoAspEntities())
            {
                return ctx.Clientes.ToList();
            }
        }

        // metodo para alterar o cliente
        public static void AlterarCliente(Clientes Alterado)
        {
            using (var ctx = new CursoAspEntities())
            {
                ctx.Entry<Clientes>(Alterado).State = 
                       EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        // metodo para Apagar o cliente
        public static void ApagarCliente(Clientes Apagado)
        {
            using (var ctx = new CursoAspEntities())
            {
                ctx.Entry<Clientes>(Apagado).State =
                       EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

    }
}