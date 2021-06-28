using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MentoriaDevSTi3.View.Acesso
{
    /// <summary>
    /// Interaction logic for AccessWindow.xaml
    /// </summary>
    public partial class AccessWindow : Window
    {

        internal static AccessWindow Main;

        public AccessWindow()
        {
            InitializeComponent();

            Main = this;

            Navegar("");
        }

        public void Navegar(string tela)
        {
            switch (tela)
            {
                case nameof(UcCadastro):
                    ConteudoAcesso.Content = new UcCadastro();
                    break;
                default:
                    ConteudoAcesso.Content = new UcLogin();
                    break;
            }
        }

    }
}
