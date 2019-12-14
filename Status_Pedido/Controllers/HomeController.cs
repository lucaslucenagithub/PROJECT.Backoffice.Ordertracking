using Status_Pedido.Models;
using Status_Pedido.Services;
using Status_Pedido.ViewModels;
using System.Web.Mvc;

namespace Status_Pedido.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        //Método de comunicação da View e Validação do DataAnnotation:
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Nome do Valor Passado Na Action Deve Ter Mesmo Nome Da ViewModel
        public ActionResult Inserir_Pedido(string CodigoPedido)
        {
            /*O bloco seguinte valida os estados do DataAnnotation para caso alguém consiga burlar 
             se a pessoa colocar CodigoPedido errado e não passar pela validação, então ela é redirecionada
             para a view Index!*/
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            object ResultadoApiJson = RequisicaoApiMillennium.GetApiResultadoPedido(CodigoPedido);

            //Verifica conexão com porta da API do servidor
            if (ResultadoApiJson != null)
            {
                var resultado = JsonApi.FromJson(ResultadoApiJson.ToString());

                //Verifica conexão com porta da API do servidor
                if (resultado.OdataCount > 1)
                {
                    //Valida se o código do pedido fornecido só retornou um pedido mesmo
                    TempData["JsonDataCountException"] = "Ocorreu um erro, entre em contato com o suporte e descreva o seguinte ocorrido: CodErro 0: O array de pedidos retornou num diferente de '1'";
                }
                //Se tudo der certo, Armazena os pedidos retornados da Api em uma lista
                else
                {
                    foreach (var item in resultado.Value)
                    {
                        PedidoViewModel Pedido = new PedidoViewModel(item.Pedido, item.Status, item.DataPedido, item.DataAtualizacao, item.ValorPedido, item.NomeCliente);

                        TempData["Pedido"] = Pedido;
                    }

                }

            }
            //Se a primeira condição for falsa, avisa sobre o erro com a porta de conexão do Server API!
            else
            {
                //Apenas TempDatas sao permitidas passar entre controllers
                TempData["ServerConnException"] = "O servidor está fora do ar no momento, tente novamente mais tarde.";
            }
            return RedirectToAction("Mostrar_Status_Home", "Statuspedido");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}