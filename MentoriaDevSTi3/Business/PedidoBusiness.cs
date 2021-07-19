﻿using MentoriaDevSTi3.Data.Context;
using MentoriaDevSTi3.Data.Entidades;
using MentoriaDevSTi3.ViewModel;
using System.Linq;

namespace MentoriaDevSTi3.Business
{
    public class PedidoBusiness
    {

        private readonly MentoriaDevSTi3Context _context;

        public PedidoBusiness()
        {
            _context = new MentoriaDevSTi3Context();
        }

        public void Adicionar(PedidoViewModel pedidoViewModel)
        {
            _context.Pedidos.Add(new Pedido
            {
                ClienteId = pedidoViewModel.ClienteId,
                FormaPagamento = pedidoViewModel.FormaPagamento,
                Valor = pedidoViewModel.Valor,
                ItensPedido = pedidoViewModel.ItensPedido.Select(s => new ItemPedido
                {
                    ProtudoId = s.ProdutoId,
                    Quantidade = s.Quantidade,
                    Valor = s.Valor
                }).ToList()
            });

            _context.SaveChanges();
        }
    }
}
