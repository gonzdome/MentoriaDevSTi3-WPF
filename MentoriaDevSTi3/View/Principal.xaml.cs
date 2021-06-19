﻿using MentoriaDevSTi3.View.UserControls;
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

namespace MentoriaDevSTi3.View
{
    /// <summary>
    /// Interaction logic for Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void BtnProdutos_Click(object sender, RoutedEventArgs e)
        {
            Conteudo.Content = new UcProdutos();
        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            Conteudo.Content = new UcClientes();

        }

        private void BtnPedido_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
