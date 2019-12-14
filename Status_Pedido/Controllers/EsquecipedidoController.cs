using Status_Pedido.Models;
using Status_Pedido.Services;
using Status_Pedido.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Status_Pedido.Controllers
{
    public class EsquecipedidoController : Controller
    {
        // GET: Esquecipedido
        public ActionResult Index()
        {
            return View();
        }

        //Método de comunicação da View e Validação do DataAnnotation:
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Nome do Valor Passado Na Action Deve Ter Mesmo Nome Da ViewModel
        public ActionResult Inserir_Documento(string document)
        {
            /*O bloco seguinte valida os estados do DataAnnotation para caso alguém consiga burlar 
             se a pessoa colocar CodigoPedido errado e não passar pela validação, então ela é redirecionada
             para a view Index!*/
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            List<ListaPedidosViewModel> listaPedidos = new List<ListaPedidosViewModel>();

            //PessoaFisica
            if (document.Length == 14)
            {
                object JsonResult = RequisicaoApiMillennium.GetApiResultado_CPF(document);

                //Verifica conexão com porta da API do servidor
                if (JsonResult != null)
                {
                    var resultado = JsonApi.FromJson(JsonResult.ToString());

                    //Verifica se há pedidos
                    if (resultado.OdataCount == 0 && resultado.OdataMetadata != null && resultado.Value != null)
                    {
                        TempData["NoOrderException"] = "Não foram encontrados pedidos no seu CPF.";
                    }
                    //Se encontrado os pedidos, armazena os retornados da Api em uma lista
                    else
                    {
                        foreach (var pv in resultado.Value)
                        {
                            listaPedidos.Add(new ListaPedidosViewModel()
                            {
                                Pedido = pv.Pedido,
                                Status = pv.Status,
                                DataPedido = pv.DataPedido,
                                ValorPedido = pv.ValorPedido,
                                NomeCliente = pv.NomeCliente
                            });
                        }
                    }
                }
                //Se a primeira condição for falsa, avisa sobre o erro de conexão com o servidor
                else
                {
                    TempData["ServerConnException"] = "O servidor está fora do ar no momento, tente novamente mais tarde.";
                }
            }
            //PessoaJuridica
            else if (document.Length == 18)
            {
                object JsonResult = RequisicaoApiMillennium.GetApiResultado_CNPJ(document);
                if (JsonResult != null)
                {
                    var resultado = JsonApi.FromJson(JsonResult.ToString());

                    if (resultado.OdataCount == 0 && resultado.OdataMetadata != null && resultado.Value != null)
                    {
                        TempData["NoOrderException"] = "Não foram encontrados pedidos no seu CNPJ.";
                    }
                    else
                    {
                        foreach (var pv in resultado.Value)
                        {
                            listaPedidos.Add(new ListaPedidosViewModel()
                            {
                                Pedido = pv.Pedido,
                                Status = pv.Status,
                                DataPedido = pv.DataPedido,
                                ValorPedido = pv.ValorPedido,
                                NomeCliente = pv.NomeCliente
                            });
                        }
                    }
                }
                else
                {
                    TempData["ServerConnException"] = "O servidor está fora do ar no momento, tente novamente mais tarde.";
                }
            }
            else
            {
                TempData["DocException"] = "Por alguma razão seu documento não foi digitado corretamente, tente novamente ou entre em contato com o Suporte e comunique o erro!\nErro Cod 1: Tamanho Doc Inválido";
            }

            TempData["ListaPedidos"] = listaPedidos;

            return RedirectToAction("Mostrar_Pedidos", "Pedidoslista");
        }
    }
}