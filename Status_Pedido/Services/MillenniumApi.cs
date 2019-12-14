using Status_Pedido.ViewModels;
using System.Net.Http;

namespace Status_Pedido.Services
{
    public class MillenniumApi
    {
        public static string BaseUrl
        {
            get
            {
                //Base da Api seguido pelo IP e Porta de conexão do servidor
                return "http://189.113.4.250:888/api/millenium!status_pedidov/pedido_venda/";
            }
        }

        public static object GetApiResultadoPedido(string CodigoPedido)
        {

            //Metodo que faz requisicao a API do Millennium
            string action = string.Format("listaporpedido?cod_pedidov={0}&$format=json", CodigoPedido);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, BaseUrl + action);
            //Tratar response erro de conexão API porta 888
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            var JsonResponse = response.Content.ReadAsStringAsync().Result;
            return JsonResponse;
        }

        public static object GetApiResultado_CPF(string document)
        {

            //Api Request
            string action = string.Format("listarstatuspv_pf?cpf={0}&$format=json", document);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, BaseUrl + action);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            var JsonResponse = response.Content.ReadAsStringAsync().Result;
            return JsonResponse;
        }

        public static object GetApiResultado_CNPJ(string document)
        {

            //Api Request
            string action = string.Format("listarstatuspv_pj?cgc={0}&$format=json", document);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, BaseUrl + action);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            var JsonResponse = response.Content.ReadAsStringAsync().Result;
            return JsonResponse;
        }
    }
}