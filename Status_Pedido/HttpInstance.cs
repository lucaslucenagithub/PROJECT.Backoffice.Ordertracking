using System.Net.Http;

namespace Status_Pedido
{
    public class HttpInstance
    {
        private static HttpClient httpClientInstance;

        private HttpInstance()
        {
        }

        public static HttpClient GetHttpClientInstance()
        {
            if (httpClientInstance == null)
            {
                //Chama apenas uma instancia do HttpClient, pois nao é muito aconselhável ter várias por ai pelo seu código!
                httpClientInstance = new HttpClient();
                //Chama a autenticacao no método!
                httpClientInstance.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "BasicAuthGenerateKey");
                //Mantém o 'Keep Alive' online!
                httpClientInstance.DefaultRequestHeaders.ConnectionClose = false;
            }
            return httpClientInstance;
        }
    }
}