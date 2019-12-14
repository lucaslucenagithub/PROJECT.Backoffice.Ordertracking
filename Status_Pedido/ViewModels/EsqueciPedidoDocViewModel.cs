using System.ComponentModel.DataAnnotations;

namespace Status_Pedido.ViewModels
{
    public class EsqueciPedidoDocViewModel
    {

        [Required(ErrorMessage = "Campo obrigatório")]
        //Obra de Deus: verifica as espressões RegExp junto com a máscara jquery da view do Esquecipedido
        [RegularExpression("^[0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2}|[0-9]{2}.[0-9]{3}.[0-9]{3}/[0-9]{4}-[0-9]{2}$",
            ErrorMessage = "Verifique este campo")]
        public string Document { get; set; }
    }
}