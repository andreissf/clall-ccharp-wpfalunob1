using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EscolaManager.Utils;

namespace EscolaManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ManagerPessoa manager;
        private Pessoa pessoa;

        public MainWindow()
        {
            manager = new Utils.ManagerPessoa();            
            InitializeComponent();
            btnDelete.Visibility = Visibility.Hidden;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtIdade.Text) || string.IsNullOrEmpty(txtTurma.Text))
            {
                MessageBox.Show("Preencher todos os campos.");
                return;
            }

            btnDelete.Visibility = Visibility.Hidden;

            if (btnSalvar.Content.ToString().Equals("Editar"))
            {
                manager.Update(listPessoas.SelectedIndex, txtNome.Text, Convert.ToInt32(txtIdade.Text), txtTurma.Text);
                listPessoas.SelectedIndex = -1;
                btnSalvar.Content = "Salvar";
            }
            else
            {
                manager.Add(txtNome.Text, Convert.ToInt32(txtIdade.Text), txtTurma.Text);
            }

            Limpar();

            listPessoas.ItemsSource = manager.GetList();            
        }

        private void listPessoas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDelete.Visibility = Visibility.Hidden;
            pessoa = (Pessoa) listPessoas.SelectedItem;
            if (pessoa != null)
            {
                btnDelete.Visibility = Visibility.Visible;
                txtNome.Text = pessoa.Name;
                txtIdade.Text = pessoa.Idade.ToString();
                txtTurma.Text = pessoa.Turma;

                btnSalvar.Content = "Editar";
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            btnDelete.Visibility = Visibility.Hidden;
            manager.RemovePessoa(listPessoas.SelectedIndex);
            listPessoas.SelectedIndex = -1;
            Limpar();
            listPessoas.ItemsSource = manager.GetList();
        }

        private void Limpar()
        {
            txtNome.Text = string.Empty;
            txtIdade.Text = string.Empty;
            txtTurma.Text = string.Empty;
        }
    }
}
