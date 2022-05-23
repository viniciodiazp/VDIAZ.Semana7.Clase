using SQLite;
using System;
using System.Collections.Generic;
using VDIAZ.Semana7.Clase.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace VDIAZ.Semana7.Clase.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemPage : ContentPage
    {
        public int selectedId;
        private SQLiteAsyncConnection asyncCnn;
        private IEnumerable<Estudiante> updateResult;
        private IEnumerable<Estudiante> deleteResult;
        private SQLiteConnection cnn;
        public ItemPage(int id)
        {
            InitializeComponent();
            this.selectedId = id;
            this.asyncCnn = DependencyService.Get<DBManager>().GetConnection();
            string dbPath = Path.Combine(System.Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            this.cnn = new SQLiteConnection(dbPath);
        }

        private void btnUpdate_Clicked(object sender, EventArgs e)
        {
            try
            {
                Estudiante student = new Estudiante() { Nombre = txtName.Text, Usuario = txtUser.Text, Clave = txtPassword.Text };
                this.updateResult = Update(this.cnn, student);
                DisplayAlert("Estudiante", "Registro actualizado", "Aceptar");
            } catch (Exception ex)
            {
                DisplayAlert("Estudiante", ex.Message, "Aceptar");
            }
        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {
            try
            {
                this.deleteResult = Delete(this.cnn, this.selectedId);
                DisplayAlert("Estudiante", "Registro eliminado", "Aceptar");
            }
            catch (Exception ex)
            {
                DisplayAlert("Estudiante", ex.Message, "Aceptar");
            }
        }

        public static IEnumerable<Estudiante> Delete(SQLiteConnection cnn, int id)
        {
            return cnn.Query<Estudiante>("DELETE FROM Estudiante WHERE Id = ?", id);
        }

        public static IEnumerable<Estudiante> Update(SQLiteConnection cnn, Estudiante student)
        {
            return cnn.Query<Estudiante>("UPDATE Estudiante SET Nombre = ?, Usuario = ?, Clave = ? WHERE Id = ? ",
                student.Nombre, student.Usuario, student.Clave, student.Id);
        }
    }
}