namespace Status_Pedido.ViewModels
{
    public class PedidoViewModel
    {

        public PedidoViewModel()
        {

        }

        public PedidoViewModel(string Pedido, string Status, string DataPedido, string DataAtualizacao, string ValorPedido, string NomeCliente)
        {
            this.Pedido = Pedido;
            this.Status = Status;
            this.DataPedido = DataPedido;
            this.DataAtualizacao = DataAtualizacao;
            this.ValorPedido = ValorPedido;
            this.NomeCliente = NomeCliente;

        }

        public string Pedido { get; set; }

        public string Status { get; set; }

        public string DataPedido { get; set; }

        public string DataAtualizacao { get; set; }

        public string ValorPedido { get; set; }

        public string NomeCliente { get; set; }
    }
}