using MentoriaDevSTi3.Business;
using MentoriaDevSTi3.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace MentoriaDevSTi3.View.UserControls
{
    /// <summary>
    /// Interaction logic for UcPedido.xaml
    /// </summary>
    public partial class UcPedido : UserControl
    {
        private UcPedidoViewModel UcPedidoVm = new UcPedidoViewModel();

        public UcPedido()
        {
            InitializeComponent();

            IncializarOperação();
        }

        private void CmbProduto_DropDownClosed(object sender, EventArgs e)
        {
            if (sender is ComboBox cmb && cmb.SelectedItem is ProdutoViewModel produto)
            {
                UcPedidoVm.ValorUnit = produto.Valor;
            }
        }        

        private void BtnAdicionarItem_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarPedido())
                return;
            else
            {
                AdicionarItem();
            }

            LimparCampos();
        }

        private void BtnFinalizarPedido_Click(object sender, RoutedEventArgs e)
        {
            FinalizarPedido();
        }

        private void IncializarOperação()
        {
            DataContext = UcPedidoVm;

            UcPedidoVm.ListaClientes = new ObservableCollection<ClienteViewModel>(new ClienteBusiness().Listar());

            UcPedidoVm.ListaProdutos = new ObservableCollection<ProdutoViewModel>(new ProdutoBusiness().Listar());

            UcPedidoVm.ListaPagamentos = new ObservableCollection<string>
            {
                "Dinheiro",
                "Boleto",
                "Cartão de Crédito",
                "Cartão de Débito",
                "PIX",
            };

            UcPedidoVm.ItensAdicionados = new ObservableCollection<UcPedidoItemViewModel>();

        }

        private void AdicionarItem()
        {
            var produtoSelecionado = CmbProduto.SelectedItem as ProdutoViewModel;

            var itemVm = new UcPedidoItemViewModel
            {
                Nome = produtoSelecionado.Nome,
                Quantidade = UcPedidoVm.Quantidade,
                ValorUnit = UcPedidoVm.ValorUnit,
                ValorTotalItem = UcPedidoVm.Quantidade * UcPedidoVm.ValorUnit,
                ProdutoId = produtoSelecionado.Id

            };

            UcPedidoVm.ItensAdicionados.Add(itemVm);

            UcPedidoVm.ValorTotalPedido = UcPedidoVm.ItensAdicionados.Sum(i => i.ValorTotalItem);

            LimparCampos();
        }

        private void FinalizarPedido()
        {
            var clienteSelecionado = CampoCliente.SelectedItem as ClienteViewModel;
            var formaPagamentoSelecionada = CampoPagamento.SelectedItem as string;

            var pedidoViewModel = new PedidoViewModel
            {
                ClienteId = clienteSelecionado.Id,
                FormaPagamento = formaPagamentoSelecionada,
                Valor = UcPedidoVm.ValorTotalPedido,
                ItensPedido = UcPedidoVm.ItensAdicionados.Select(s => new ItensPedidoViewModel
                {
                    ProdutoId = s.ProdutoId,
                    Quantidade = s.Quantidade,
                    Valor = s.ValorTotalItem
                }).ToList()
            };

            new PedidoBusiness().Adicionar(pedidoViewModel);

            MessageBox.Show("Pedido realizado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);

            LimparTodosCampos();

        }

        private void LimparCampos()
        {
            UcPedidoVm.Quantidade = 1;
            CmbProduto.SelectedItem = null;
            UcPedidoVm.ValorUnit = 0;
        }

        private void LimparTodosCampos()
        {
            UcPedidoVm.ItensAdicionados = new ObservableCollection<UcPedidoItemViewModel>();
            UcPedidoVm.ValorTotalPedido = 0;
            CampoCliente.SelectedItem = null;
            CampoPagamento.SelectedItem = null;

            LimparCampos();
        }

        private bool ValidarPedido()
        {
            if (CampoCliente.SelectedItem is null)
                {
                MessageBox.Show("Selecione um cliente!", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (CampoPagamento.SelectedItem is null)
            {
                MessageBox.Show("Selecione um método de pagamento!", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (CmbProduto.SelectedItem is null)
            {
                MessageBox.Show("Selecione um produto!", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (CampoQuantidade.Text is "0")
            {
                MessageBox.Show("A quantidade de produtos não pode ser '0'!", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }


            return true;

        }

        private void CampoQuantidade_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
