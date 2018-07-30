﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Trato.Personas;
using System.Net.Http;
using Newtonsoft.Json;

namespace Trato.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class V_Login : ContentPage
    {
        protected override void OnAppearing()
        {
            NavigationPage.SetHasNavigationBar(this, false);
        }
        public V_Login()
        {
            InitializeComponent();
        }
        public async void Fn_Registro(object sender, EventArgs _Args)
        {
            await App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new V_Registro(true)) );
        }
        public async void Fn_Login(object sender, EventArgs _args)
        {
            if (Fn_Condiciones())
            {
                StackMen.IsVisible = true;
                Mensajes_over.Text = " Comprobando informacion\n";
                ;
                string prime = usu.Text.Split('-')[0];

                string _membre = "";
                for(int i=0; i<prime.Length-1; i++)
                {
                    _membre += prime[i];
                }


                string letra = prime[prime.Length - 1].ToString();
                    string _conse = usu.Text.Split('-')[1];

                C_Login _login = new C_Login(_membre,letra,_conse, pass.Text,fol.Text);
                //crear el json
                string _jsonLog = JsonConvert.SerializeObject(_login, Formatting.Indented);
                //mostrar la pantalla con mensajes
                mensajes.Text = _jsonLog;
                Mensajes_over.Text +=_jsonLog ;
                //crear el cliente
                HttpClient _client = new HttpClient();
                string _DirEnviar = "https://useller.com.mx/trato_especial/login.php";
                StringContent _content = new StringContent(_jsonLog, Encoding.UTF8, "application/json");
                //mandar el json con el post
                HttpResponseMessage _respuestaphp = await _client.PostAsync(_DirEnviar, _content);
                string _respuesta = await _respuestaphp.Content.ReadAsStringAsync();
                if (_respuesta == "0")
                {
                    Mensajes_over.Text += "\n Error en los datos";
                    Reinten.IsVisible = true;
                }
                else if (_respuesta == "1")
                {
                    //cambiar a logeado
                    StackMen.IsVisible = false;
                    App.v_logeado = true;
                    //cargar la nueva pagina de perfil
                    Application.Current.MainPage = new NavigationPage(new V_Master() { Title = "Bienvenido" });
                }



                //revisar el status code
                //if(_respuestaphp.StatusCode == System.Net.HttpStatusCode.OK)
                //{
                //}
                //else
                //{
                //    Mensajes_over.Text += "\n Error de conexion";
                //    Reinten.IsVisible = true;
                //}
            }
        }
        /// <summary>
        /// apagar el panel de mensajes para reintentar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="_args"></param>
        public void Fn_Reintento(object sender, EventArgs _args)
        {
            StackMen.IsVisible = false; 
            Mensajes_over.Text="";
            Reinten.IsVisible = false;
        }
        /// <summary>
        /// si es false, hay algun dato mal y no puedes continuar
        /// </summary>
        /// <returns></returns>
        bool Fn_Condiciones()
        {
            int _conta = 0;
            if (string.IsNullOrEmpty(usu.Text) || string.IsNullOrWhiteSpace(usu.Text))
            {
                usu.BackgroundColor = Color.Red; 
                _conta++;
            }
            else
            {
                usu.BackgroundColor = Color.Transparent;
            }
            if (string.IsNullOrEmpty(pass.Text) || string.IsNullOrWhiteSpace(pass.Text))
            {
                pass.BackgroundColor = Color.Red;
                _conta++;
            }
            else
            {
                pass.BackgroundColor = Color.Transparent;
            }

            if (_conta > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}