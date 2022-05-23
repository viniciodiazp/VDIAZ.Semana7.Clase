using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using VDIAZ.Semana7.Clase.Model;
using SQLite;

namespace VDIAZ.Semana7.Clase.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        private SQLiteAsyncConnection cnn;
        public RegisterPage()
        {
            InitializeComponent();
            this.cnn = DependencyService.Get<DBManager>().GetConnection();
        }

        private void btnRegister_Clicked(object sender, EventArgs e)
        {
            Estudiante student = new Estudiante() 
                { Usuario = txtUser.Text, Clave = txtPassword.Text, Nombre = txtName.Text };

            this.cnn.InsertAsync(student);
            Clear();
            DisplayAlert("Estudiantes", "Registro almacenado", "Aceptar");
        }

        private void Clear()
        {
            this.txtName.Text = string.Empty;
            this.txtUser.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
        }
    }
}