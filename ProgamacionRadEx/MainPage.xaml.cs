using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Media;

namespace ProgamacionRadEx
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }



        private  void btPaises_Clicked(object sender, EventArgs e)
        {




        }
        private void btSalvarContacto_Clicked(object sender, EventArgs e)

        {



            if (txtNombre == null)
            {
                DisplayAlert("Error", "Ingresa el nombre", "ok");
            }
            else if (string.IsNullOrEmpty(txtNombre.Text))
            {
                DisplayAlert("Error", "Debe escribir su nombre", "ok");

            }

            else if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                DisplayAlert("Error", "Debe de escribir su telefono", "ok");
            }

            else if (string.IsNullOrEmpty(txtEdad.Text))
            {
                DisplayAlert("Error", "Debe de escribir su edad", "ok");
            }

            else if (string.IsNullOrEmpty(txtNota.Text))
            {
                DisplayAlert("Error", "Debe de escribir su nota", "ok");
            }



            
        }

        private  async void btVerAgenda_Clicked(object sender, EventArgs e)
        {


            var persona = new Models.Personas

            {
                Nombre = txtNombre.Text,
                Edad = txtEdad.Text,    
                Telefono = txtTelefono.Text,    
                Nota = txtNota.Text,

            };
                
            Views.PageResultado page = new Views.PageResultado();
            page.BindingContext = persona;
            await Navigation.PushAsync(page);
        }

        private void btnfoto_Clicked(object sender, EventArgs e)
        {

        }
    }
}
