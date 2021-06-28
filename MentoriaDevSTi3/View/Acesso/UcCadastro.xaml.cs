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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MentoriaDevSTi3.View.Acesso
{
    /// <summary>
    /// Interaction logic for UcCadastro.xaml
    /// </summary>
    public partial class UcCadastro : UserControl
    {
        public UcCadastro()
        {
            InitializeComponent();
        }

        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            AccessWindow.Main.Navegar(nameof(UcLogin));
        }
    }
}
