using System.Windows;
using System.Windows.Controls;

namespace MentoriaDevSTi3.View.Acesso
{
    /// <summary>
    /// Interaction logic for UcLogin.xaml
    /// </summary>
    public partial class UcLogin : UserControl
    {
        public UcLogin()
        {
            InitializeComponent();
        }

        protected void BtnEntrar_Click(object sender, RoutedEventArgs e)
        {
            var Login = "teste";
            var Senha = "teste";


            if (login.Text == Login && senha.Password == Senha)
            {

                Window PrincipalWindow = new Principal();
                PrincipalWindow.ShowDialog();

            }
            else
            {
                MessageBox.Show("Nome ou senha inválidos!", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

            private void BtnRegistrarConta_Click(object sender, RoutedEventArgs e)
            {
                AccessWindow.Main.Navegar(nameof(UcCadastro));
            }
        }
    }
