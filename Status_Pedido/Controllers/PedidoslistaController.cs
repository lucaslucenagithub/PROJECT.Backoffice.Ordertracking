using Status_Pedido.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Status_Pedido.Controllers
{
    public class PedidoslistaController : Controller
    {
        // GET: Pedidoslista
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Mostrar_Pedidos()
        {
            //Pega os dados da lista do Controller de origem registrados no TempData.
            List<ListaPedidosViewModel> listaPedidos = (List<ListaPedidosViewModel>)TempData["ListaPedidos"];

            return View("Index", listaPedidos);
        }
    }
}