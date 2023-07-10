using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgamacionRadEx.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Xamarin.Forms.Shapes;
using System.Diagnostics;
using ProgamacionRadEx.Controllers;

namespace ProgamacionRadEx.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListPersonas : ContentPage
    {
       

        public PageListPersonas()
        {
            InitializeComponent();
            // Registrar el receptor de mensajes
            MessagingCenter.Subscribe<DataBase>(this, "Contacto Eliminado", async (sender) =>
            {
                // Actualizar la lista de personas
                await CargarPersonas();
            });
            async Task CargarPersonas()
            {
                // Obtener la lista de personas de la base de datos
                List<Models.Personas> personas = await App.Database.GetAllPersonas();

                // Actualizar la lista de personas en el ListView
                listapersonas.ItemsSource = personas;
            }



        }



        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                listapersonas.ItemsSource = await App.Database.GetAllPersonas();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }


        private void ToolbarItem_Clicked(object sender, EventArgs e)

        {
            {
                var page = new Views.PagePersonas();
                Navigation.PushAsync(page);
            }



        }



        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            var page = new Views.PageMap();
            Navigation.PushAsync(page);
        }

        private void ToolbarItem_Clicked_2(object sender, EventArgs e)
        {


        }

        private void ToolbarItem_Clicked_3(object sender, EventArgs e)
        {




        }

        async void listapersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)

        {

            Models.Personas personaSelecionada = (Models.Personas)listapersonas.SelectedItem;
            string action = await DisplayActionSheet("Accion: que desea Realizar?", "Actualizar Contacto", "Eliminar Contacto",  "OK");
            Debug.WriteLine("Action: " + action);




            if (action == "Eliminar Contacto")
            {
                try
                {
                    // Eliminar la persona seleccionada de la base de datos
                    int rowsDeleted = await App.Database.DeletePersona(personaSelecionada);

                    if (rowsDeleted > 0)
                    {
                        // Actualizar la lista de personas en la página anterior
                        MessagingCenter.Send(this, "PersonaEliminada");
                        await Navigation.PopAsync();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error: " + ex.Message);
                }
            }
        }





    }







}
    

    



   


    






   

