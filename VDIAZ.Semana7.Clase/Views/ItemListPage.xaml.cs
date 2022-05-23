using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
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
    public partial class ItemListPage : ContentPage
    {
        private SQLiteAsyncConnection cnn;
        private ObservableCollection<Estudiante> studentCollection;
        public ItemListPage()
        {
            InitializeComponent();
            this.cnn = DependencyService.Get<DBManager>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);

        }

        private void lsUsers_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Estudiante student = (Estudiante) e.SelectedItem;
            int id = student.Id;

            try
            {
                Navigation.PushAsync(new ItemPage(id));
            } catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Aceptar");
                throw;
            }
        }

        protected async override void OnAppearing()
        {
            List<Estudiante> students = await this.cnn.Table<Estudiante>().ToListAsync();
            studentCollection = new ObservableCollection<Estudiante>(students);
            lsUsers.ItemsSource = studentCollection;
            base.OnAppearing();
        }
    }
}