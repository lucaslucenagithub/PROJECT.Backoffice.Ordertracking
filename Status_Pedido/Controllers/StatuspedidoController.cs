using Status_Pedido.ViewModels;
using System.Web.Mvc;

namespace Status_Pedido.Controllers
{
    public class StatuspedidoController : Controller
    {
        // GET: Statuspedido
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Mostrar_Status_Home()
        {
            //Pega os dados da lista do Controller de origem registrados no TempData de lá.
            var pedido = (PedidoViewModel)TempData["Pedido"];
            return View("Mostrar_Status_Home", pedido);

        }

        public ActionResult Mostrar_Status_PedidoLista(string CodigoPedido, string Status, string DataPedido, string DataAtualizacao, string ValorPedido, string NomeCliente)
        {

            PedidoViewModel pedido = new PedidoViewModel()
            {
                Pedido = CodigoPedido,
                Status = Status,
                DataPedido = DataPedido,
                DataAtualizacao = DataAtualizacao,
                ValorPedido = ValorPedido,
                NomeCliente = NomeCliente

            };

            return View("Mostrar_Status_PedidoLista", pedido);

        }
    }
}