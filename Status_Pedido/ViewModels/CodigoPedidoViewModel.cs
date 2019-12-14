using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Status_Pedido.ViewModels
{
    public class CodigoPedidoViewModel
    {
        [Required(ErrorMessage = "Digite o número do Pedido")]
        [MinLength(4, ErrorMessage = "Deve ser maior que 4 caracteres")]
        [MaxLength(20, ErrorMessage = "Não ultrapassar 20 caracteres")]
        public string CodigoPedido { get; set; }
    }
}