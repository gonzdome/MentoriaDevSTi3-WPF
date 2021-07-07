using MentoriaDevSTi3.Data.Context;
using MentoriaDevSTi3.Data.Entidades;
using MentoriaDevSTi3.View.UserControls;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            Testes();
        }

        private void Testes()
        {

            using var context = new MentoriaDevSTi3Context();

            //context.Database.EnsureCreated();

            //context.Clientes.Add(new Cliente {
            //    Nome = "Gabriel",
            //    Cep = "17211410",
            //    Cidade = "Jaú",
            //    DataNascimento = DateTime.Now,
            //    Endereco = "Rua Antonio Ferreira Dias n°265",

            //});

            var cliente = context.Clientes.First(x => x.Id == 1);

            context.Clientes.Remove(cliente);
            
            context.SaveChanges();
        }

        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            InicializarUc(sender);
        }


        private void InicializarUc(object sender)
        {
            if(sender is Button btn)
            {
                switch (btn.Name)
                {
                    case nameof(BtnProdutos):
                        Conteudo.Content = new UcProdutos();
                        break;
                    case nameof(BtnClientes):
                        Conteudo.Content = new UcClientes();
                        break;
                    case nameof(BtnPedido):
                        Conteudo.Content = new UcPedido();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
