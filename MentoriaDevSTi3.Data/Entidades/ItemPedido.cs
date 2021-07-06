namespace MentoriaDevSTi3.Data.Entidades
{
    public class ItemPedido
    {
        public long Id { get; set; }
        public long PedidoId { get; set; }
        public long ProtudoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }

        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }

    }
}
