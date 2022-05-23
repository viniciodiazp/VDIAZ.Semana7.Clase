using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

using System.IO;

using VDIAZ.Semana7.Clase.Model;

namespace VDIAZ.Semana7.Clase.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private SQLiteAsyncConnection connection;
        private DBManager dbmanager;
        public LoginPage()
        {
            InitializeComponent();
            this.dbmanager = DependencyService.Get<DBManager>();
            this.connection = dbmanager.GetConnection();
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                SQLiteConnection cnn = new SQLiteConnection(dbPath);
                cnn.CreateTable<Estudiante>();
                IEnumerable<Estudiante> result = SELECT_WHERE(cnn, this.txtUser.Text, this.txtPassword.Text);
                if (result.Count() > 0)
                {
                    Navigation.PushAsync(new ItemListPage());
                }
                else
                {
                    DisplayAlert("Error", "Usuario o contraseña incorrecto", "Aceptar");
                }
            } catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

        private async void btnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection cnn, string user, string password)
        {
            //return cnn.Query<Estudiante>("SELECT * FROM Estudiante WHERE Usuario = ? AND Clave = ?", user, password);
            return cnn.Query<Estudiante>("SELECT * FROM Estudiante");
        }
    }
}