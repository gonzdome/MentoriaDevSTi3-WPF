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

        }

        private void IncializarOperação()
        {
            DataContext = UcPedidoVm;

            UcPedidoVm.ListaClientes = new ObservableCollection<ClienteViewModel>
            {
                new ClienteViewModel {Nome="1"},
                new ClienteViewModel {Nome="2"}
            };
            UcPedidoVm.ListaProdutos = new ObservableCollection<ProdutoViewModel>
            {
                new ProdutoViewModel {Nome="Produto 1", Valor = 10},
                new ProdutoViewModel {Nome="Produto 2", Valor = 20},

            };
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
                ValorTotalItem = UcPedidoVm.Quantidade * UcPedidoVm.ValorUnit
            };

            UcPedidoVm.ItensAdicionados.Add(itemVm);

            UcPedidoVm.ValorTotalPedido = UcPedidoVm.ItensAdicionados.Sum(i => i.ValorTotalItem);
        }

        private void LimparCampos()
        {
            UcPedidoVm.Quantidade = 0;
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
