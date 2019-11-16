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
using System.Windows.Shapes;
using CRUDSQLite.Clases;
using SQLite;

namespace CRUDSQLite
{
    /// <summary>
    /// Lógica de interacción para VentanaGestoraDeRegistros.xaml
    /// </summary>
    public partial class VentanaGestoraDeRegistros : Window
    {
        List<Contactos> contactos;

        public VentanaGestoraDeRegistros()
        {
            InitializeComponent();
            contactos = new List<Contactos>();
            LeerBaseDatos();

        }
        void LeerBaseDatos()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contactos>();
                contactos = (conn.Table<Contactos>().ToList()).OrderBy(c => c.Nombre).ToList();
            }
            if (contactos != null)
            {
                lvContactos.ItemsSource = contactos;
            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            CRUDSQLite.MainWindow form = new CRUDSQLite.MainWindow();
            form.ShowDialog();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            CRUDSQLite.Matar form = new CRUDSQLite.Matar();
            form.ShowDialog();
        }

        private void btnActulizar_Click(object sender, RoutedEventArgs e)
        {
            

        }   
    }
}
