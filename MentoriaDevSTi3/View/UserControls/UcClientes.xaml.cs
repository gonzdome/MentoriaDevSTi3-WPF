using MentoriaDevSTi3.ViewModel;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
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
                AlterarCliente();
            }
            else
            {
                AdicionarCliente();
            }

            LimparCampos();
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            var cliente = (sender as Button).Tag as ClienteViewModel;

            PreencherCampos(cliente);
        }
        private void CampoNome_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z ]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TxtCep_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CampoCidade_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z ]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void PreencherCampos(ClienteViewModel cliente)
        {
            UcClienteVm.Nome = cliente.Nome;
            UcClienteVm.DataNascimento = cliente.DataNascimento;
            UcClienteVm.Cep = cliente.Cep;
            UcClienteVm.Endereco = cliente.Endereco;
            UcClienteVm.Cidade = cliente.Cidade;

            UcClienteVm.Alteracao = true;
        }

        private void AdicionarCliente()
        {
            var novoCliente = new ClienteViewModel
            {
                Nome = UcClienteVm.Nome,
                DataNascimento = UcClienteVm.DataNascimento,
                Cep = UcClienteVm.Cep,
                Endereco = UcClienteVm.Endereco,
                Cidade = UcClienteVm.Cidade
            };

            UcClienteVm.ClientesAdicionados.Add(novoCliente);
        }

        private void AlterarCliente()
        {
            //desenvolvido no banco de dados
        }

        private void LimparCampos()
        {
            UcClienteVm.Nome = "";
            UcClienteVm.DataNascimento = new System.DateTime(1990, 1, 1);
            UcClienteVm.Cep = 0;
            UcClienteVm.Endereco = "";
            UcClienteVm.Cidade = "";
            UcClienteVm.Alteracao = false;
        }
        private bool ValidarCliente()
        {

        if (string.IsNullOrEmpty(UcClienteVm.Nome))
        {
            MessageBox.Show("O campo 'Nome' é obrigatório!", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
            return false;

        }
        if (UcClienteVm.Cep is 0)
        {
            MessageBox.Show("O campo 'Cep' é obrigatório!", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
            return false;

        }     
        if (string.IsNullOrEmpty(UcClienteVm.Endereco))
        {
            MessageBox.Show("O campo 'Endereço' é obrigatório!", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
            return false;

        }  
        if (string.IsNullOrEmpty(UcClienteVm.Cidade))
        {
            MessageBox.Show("O campo 'Cidade' é obrigatório!", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
            return false;

        }
        return true;

        }
    }
 }
