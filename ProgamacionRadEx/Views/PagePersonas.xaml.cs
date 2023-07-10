using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms.Maps;
using ProgamacionRadEx.Models;

namespace ProgamacionRadEx.Views
{


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePersonas : ContentPage

    {

        // Variable que guardara la foto 
        Plugin.Media.Abstractions.MediaFile photo = null;
        private object personaSeleccionado;

        public PagePersonas()
        {
            InitializeComponent();


        }

        public PagePersonas(object personaSeleccionado)
        {
            this.personaSeleccionado = personaSeleccionado;
        }

        public byte[] GetImageToBytes()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] bytes = memory.ToArray();

                    return bytes;
                }
            }

            return null;
        }




        private async void btSalvarContacto_Clicked(object sender, EventArgs e)
        {
            if (txtNombre == null || string.IsNullOrEmpty(txtNombre.Text))
            {
                await DisplayAlert("Error", "Ingresa el nombre", "ok");
            }
            else if (txtApellido == null || string.IsNullOrEmpty(txtApellido.Text))
            {
                await DisplayAlert("Error", "Ingrese sus apellidos", "ok");
            }
            else if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                await DisplayAlert("Error", "Debe de escribir su telefono", "ok");
            }
            else if (string.IsNullOrEmpty(txtEdad.Text))
            {
                await DisplayAlert("Error", "Debe de escribir su edad", "ok");
            }
            else if (string.IsNullOrEmpty(txtNota.Text))
            {
                await DisplayAlert("Error", "Debe de escribir su nota", "ok");
            }


            

            var person = new Models.Personas
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text,
                Edad = txtEdad.Text,
                Nota = txtNota.Text,
                

                foto = GetImageToBytes()
            };

            if (await App.Database.AddPersona(person) > 0)
            {
                await DisplayAlert("Aviso", "Persona ingresada con exito", "OK");
            }
            else
            {
                await DisplayAlert("Aviso", "No se pudo ingresar", "OK");
            }
        }


    

        

        private async void btnfoto_Clicked(object sender, EventArgs e)
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "APP",
                Name = "foto.jpg",
                SaveToAlbum = true
            });

            if (photo != null)
            {
                foto.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }
        }

        private  async  void btVercontactos_Clicked(object sender, EventArgs e)
        {
            var persona = new Models.Personas

            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
              
                foto= GetImageToBytes()
                
            };

            Views.PageListPersonas page = new Views.PageListPersonas();
            page.BindingContext = persona;
            await Navigation.PushAsync(page);
        }

        private void Pais_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}

      
    
