using MentoriaDevSTi3.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace MentoriaDevSTi3.View.UserControls
{
    /// <summary>
    /// Interaction logic for UcClientes.xaml
    /// </summary>
    /// 

    public partial class UcClientes : UserControl
    {
        private UcClienteViewModel UcClienteVm = new UcClienteViewModel();

        public UcClientes()
        {
            InitializeComponent();

            DataContext = UcClienteVm;
            UcClienteVm.ClientesAdicionados = new ObservableCollection<ClienteViewModel>();
            UcClienteVm.DataNascimento = new System.DateTime(1990, 1, 1);

        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarCliente())
                return;

            if (UcClienteVm.Alteracao)
            {
                //AlterarProduto();
            }
            else
            {
                //AdicionarProduto();
            }

            //LimparCampos();
        }

    private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {

        }

    private bool ValidarCliente()
    {
        if (string.IsNullOrEmpty(UcClienteVm.Nome))
        {
            MessageBox.Show("O campo 'Nome' é obrigatório", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
            return false;
        }

        return true;

        }
    }
 }
