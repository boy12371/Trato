﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Trato.Personas;
using System.Collections.ObjectModel;//listas observa
using System.Collections;//para el sorte list
using System.Net.Http;
using Newtonsoft.Json;
using Trato.Varios;
namespace Trato.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class V_Buscador : ContentPage
    {
        /// <summary>
        /// la pantalla con los filtro esta visible
        /// </summary>
        bool v_filtro = false;
        /// <summary>
        /// Lista que el usuario elige cada  vez que le pica
        /// </summary>
        List<string> _filEspec = new List<string>();
        /// <summary>
        /// Lista que el usuario elige cada  vez que le pica
        /// </summary>
        List<string> _filCiud = new List<string>();
        /// <summary>
        /// textos que se agregan a la lista visible
        /// </summary>
        ObservableCollection<Filtro> _especialidades = new ObservableCollection<Filtro>();
        /// <summary>
        /// textos que se agregan a la lista visible
        /// </summary>
        ObservableCollection<Filtro> _ciudades = new ObservableCollection<Filtro>();
        /// <summary>
        /// 0 MEDICOS,   1 SERVICIOS MEDICOS,    2 SERVICIOS GENERALES
        /// </summary>
        int v_tipo = -1;
        public V_Buscador()
        {
            InitializeComponent();
            overlay.IsVisible = v_filtro;
        }
        public V_Buscador(int _valor)
        {
            InitializeComponent();
            overlay.IsVisible = v_filtro;
            if (Device.RuntimePlatform == Device.Android)//para que solo en ios se vea la barra de arriba y el buscador completo
            {
                ToolbarItems.Clear();
                Grid_Busqueda.BackgroundColor = Color.Transparent;
            }//en prueba
            else if(Device.RuntimePlatform== Device.iOS)
            {
                Grid.SetColumnSpan(v_Search, 4);
                B_Filtrar.IsVisible = false;
                v_Search.BackgroundColor = Color.Transparent;                
                Grid_Busqueda.BackgroundColor = Color.Transparent;
            }
            if (_valor==0)
            {
                v_tipo = _valor;
                Orden();
                v_lista.ItemsSource = App.v_medicos;
            }
            else if(_valor==1)
            {
                v_tipo = _valor;
                Orden();
                v_lista.ItemsSource = App.v_servicios;
            }
            else if(_valor==2)
            {
                v_tipo = _valor;
                Orden();
                v_lista.ItemsSource = App.v_generales;
            }
            Buscador.IsVisible = false;
            Fn_CargarDAtos();
        }
        public async void Fn_CrearCiud()
        {
           if(v_tipo==0)
            {
                _ciudades.Clear();
                List<string> _tempCont = new List<string>();
                for (int i=0;i<App.v_medicos.Count; i++)
                {
                    if (!_tempCont.Contains(App.v_medicos[i].v_Ciudad))
                    {
                        _tempCont.Add(App.v_medicos[i].v_Ciudad);
                        if (_filCiud.Contains(App.v_medicos[i].v_Ciudad))
                        {
                            _ciudades.Add(new Filtro(App.v_medicos[i].v_Ciudad, true));
                        }
                        else
                        {
                            _ciudades.Add(new Filtro(App.v_medicos[i].v_Ciudad, false));
                        }
                    }
                }
            }
            else if(v_tipo==1)
            {
                _ciudades.Clear();
                List<string> _tempCont = new List<string>();
                for (int i = 0; i < App.v_servicios.Count; i++)
                {
                    if (!_tempCont.Contains(App.v_servicios[i].v_Ciudad))
                    {
                        _tempCont.Add(App.v_servicios[i].v_Ciudad);
                        if (_filCiud.Contains(App.v_servicios[i].v_Ciudad))
                        {
                            _ciudades.Add(new Filtro(App.v_servicios[i].v_Ciudad, true));
                        }
                        else
                        {
                            _ciudades.Add(new Filtro(App.v_servicios[i].v_Ciudad, false));
                        }
                    }
                }
            }
           else if(v_tipo==2)
            {
                _ciudades.Clear();
                List<string> _tempCont = new List<string>();
                for (int i = 0; i < App.v_generales.Count; i++)
                {
                    if (!_tempCont.Contains(App.v_generales[i].v_Ciudad))
                    {
                        _tempCont.Add(App.v_generales[i].v_Ciudad);
                        if (_filCiud.Contains(App.v_generales[i].v_Ciudad))
                        {
                            _ciudades.Add(new Filtro(App.v_generales[i].v_Ciudad, true));
                        }
                        else
                        {
                            _ciudades.Add(new Filtro(App.v_generales[i].v_Ciudad, false));
                        }
                    }
                }
            }
            IEnumerable<Filtro> _temp = _ciudades.OrderBy(x => x.v_texto);
            _ciudades = new ObservableCollection<Filtro>(_temp);
            filCiudad.ItemsSource = _ciudades;
           await  Task.Delay(100);
        }
        public async void Fn_CrearEspec()
        {
            if(v_tipo==0)
            {
                _especialidades.Clear();
                List<string> _tempCont = new List<string>();
                for (int i = 0; i < App.v_medicos.Count; i++)//recorre todos los medicos
                {
                    for (int j = 0; j < App.v_medicos[i].v_ListaEsp.Count; j++)
                    {
                        if ((!string.IsNullOrEmpty(App.v_medicos[i].v_ListaEsp[j].v_nombreEspec) && !string.IsNullOrWhiteSpace(App.v_medicos[i].v_ListaEsp[j].v_nombreEspec))
                            && (!_tempCont.Contains(App.v_medicos[i].v_ListaEsp[j].v_nombreEspec)))
                        {
                            _tempCont.Add(App.v_medicos[i].v_ListaEsp[j].v_nombreEspec);
                            if (_filEspec.Contains(App.v_medicos[i].v_ListaEsp[j].v_nombreEspec))
                            {
                                _especialidades.Add(new Filtro(App.v_medicos[i].v_ListaEsp[j].v_nombreEspec, true));
                            }
                            else
                            {
                                _especialidades.Add(new Filtro(App.v_medicos[i].v_ListaEsp[j].v_nombreEspec, false));
                            }
                        }
                    }
                }
            }
            else if(v_tipo==1)
            {
                _especialidades.Clear();
                List<string> _tempCont = new List<string>();
                for (int i = 0; i < App.v_servicios.Count; i++)
                {
                    if (!_tempCont.Contains(App.v_servicios[i].v_Especialidad))
                    {
                        _tempCont.Add(App.v_servicios[i].v_Especialidad);
                        if (_filEspec.Contains(App.v_servicios[i].v_Especialidad))
                        {
                            _especialidades.Add(new Filtro(App.v_servicios[i].v_Especialidad, true));
                        }
                        else
                        {
                            _especialidades.Add(new Filtro(App.v_servicios[i].v_Especialidad, false));
                        }
                    }
                }
            }
            else if(v_tipo==2)
            {
                _especialidades.Clear();
                List<string> _tempCont = new List<string>();
                for (int i = 0; i < App.v_generales.Count; i++)
                {
                    if (!_tempCont.Contains(App.v_generales[i].v_Especialidad))
                    {
                        _tempCont.Add(App.v_generales[i].v_Especialidad);
                        if (_filEspec.Contains(App.v_generales[i].v_Especialidad))
                        {
                            _especialidades.Add(new Filtro(App.v_generales[i].v_Especialidad, true));
                        }
                        else
                        {
                            _especialidades.Add(new Filtro(App.v_generales[i].v_Especialidad, false));
                        }
                    }
                }
            }
            IEnumerable<Filtro> _temp = _especialidades.OrderBy(x => x.v_texto);
            _especialidades = new ObservableCollection<Filtro>(_temp);
            filEspc.ItemsSource = _especialidades;
            await Task.Delay(100);
        }
        //public void Fn_Cancelar(object sender, EventArgs _Args)
        //{
        //    //no limpiar la lista que el usuario le pica
        //    //_filCiud.Clear();
        //    //_filEspec.Clear();

        //    //filEspc.ItemsSource = null;
        //    //for(int i=0; i<_especialidades.Count;i++)
        //    //{
        //    //    _especialidades[i].v_color = Color.Blue;
        //    //}
        //    //filEspc.ItemsSource = _especialidades;

        //    //filCiudad.ItemsSource = null;
        //    //for (int i = 0; i < _ciudades.Count; i++)
        //    //{
        //    //    _ciudades[i].v_color = Color.Blue;
        //    //}
        //    //filCiudad.ItemsSource = _ciudades;


        //    if (v_tipo == 0)
        //    {
        //        v_lista.ItemsSource = App.v_medicos;
        //    }
        //    else if (v_tipo == 1)
        //    {
        //        v_lista.ItemsSource = App.v_servicios;
        //    }
        //    else if (v_tipo == 2)
        //    {
        //        v_lista.ItemsSource = App.v_generales;
        //    }
        //    Fn_Filtro(sender, _Args);
        //}
        public void Fn_BorrarFiltro(object sender, EventArgs _args)
        {
            filEspc.ItemsSource = null;
            for(int i=0; i<_especialidades.Count; i++)//quita las imagenes del filtro
            {
                if(_especialidades[i].v_visible==true)
                {
                _especialidades[i].v_visible = false;
                }
            }
            filEspc.ItemsSource = _especialidades;//reinicia losvalores
            filCiudad.ItemsSource =null;
            for (int i = 0; i < _ciudades.Count; i++)//quita las imagenes del filtro
            {
                if (_ciudades[i].v_visible == true)
                {
                    _ciudades[i].v_visible = false;
                }
            }
            filCiudad.ItemsSource = _ciudades;
            _filEspec.Clear();//limpia lo que el usuario eligio antes
            _filCiud.Clear();
            if (v_tipo==0)//regresa todo a lo inicial
            {
                v_lista.ItemsSource = App.v_medicos;
            }
            else if(v_tipo==1)
            {
                v_lista.ItemsSource = App.v_servicios;
            }
            else if(v_tipo==2)
            {
                v_lista.ItemsSource = App.v_generales;
            }
            Fn_Filtro(sender, _args);
        }
        public async void Fn_Aceptar(object sender, EventArgs _args)
        {
            v_lista.ItemsSource = null;
            if (v_tipo == 0)
            {
                ObservableCollection<C_Medico> _filtrada = new ObservableCollection<C_Medico>();
                if (_filCiud.Count > 0 && _filEspec.Count > 0)
                {
                    //recorre toda la lista de medicos
                    for (int i = 0; i < App.v_medicos.Count; i++)
                    {
                        //recorre lista de ciudad a filtrar
                        for (int j = 0; j < _filCiud.Count; j++)
                        {//recorre lista de especialidad a filtrar
                            for (int k = 0; k < _filEspec.Count; k++)
                            {
                                //falta recorrer la lista de cada medico por si tiene mas especialidades
                                for (int e = 0; e < App.v_medicos[i].v_ListaEsp.Count; e++)
                                {
                                    if ((App.v_medicos[i].v_Ciudad == _filCiud[j] 
                                         && App.v_medicos[i].v_ListaEsp[e].v_nombreEspec == _filEspec[k]) 
                                        && !_filtrada.Contains(App.v_medicos[i]))
                                    {
                                        _filtrada.Add(App.v_medicos[i]);
                                    }
                                }

                                /*if ((App.v_medicos[i].v_Ciudad == _filCiud[j] && App.v_medicos[i].v_Especialidad == _filEspec[k]) && !_filtrada.Contains(App.v_medicos[i]))
                                {
                                    _filtrada.Add(App.v_medicos[i]);
                                }*/
                            }
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < _filCiud.Count; j++)
                    {//recorre toda la lista de medicos
                        for (int i = 0; i < App.v_medicos.Count; i++)
                        { //recorre lista de ciudad a filtrar

                            if (App.v_medicos[i].v_Ciudad == _filCiud[j] && !_filtrada.Contains(App.v_medicos[i]))
                            {
                                _filtrada.Add(App.v_medicos[i]);
                            }
                        }
                    }
                    //recorre lista de especialidad a filtrar
                    for (int j = 0; j < _filEspec.Count; j++)
                    {
                        //recorre toda la lista de medicos
                        for (int i = 0; i < App.v_medicos.Count; i++)
                        {
                            //falta recorrer la lista de cada medico por si tiene mas especialidades
                            for  (int e = 0; e < App.v_medicos[i].v_ListaEsp.Count; e++)
                            {
                                if (App.v_medicos[i].v_ListaEsp[e].v_nombreEspec == _filEspec[j] && !_filtrada.Contains(App.v_medicos[i]))
                                {
                                    _filtrada.Add(App.v_medicos[i]);
                                }
                                /* if (App.v_medicos[i].v_Especialidad == _filEspec[j] && !_filtrada.Contains(App.v_medicos[i]))
                                 {
                                     _filtrada.Add(App.v_medicos[i]);
                                 }*/
                            }
                        }
                    }
                }
                IEnumerable<C_Medico> _temp = _filtrada.OrderBy(x => x.v_Apellido);
                _filtrada = new ObservableCollection<C_Medico>(_temp);

                await Task.Delay(100);
                if (_filtrada.Count > 0)
                {
                    v_lista.ItemsSource = _filtrada;
                }
                else
                {
                    await DisplayAlert("Filtro vacio", "No se encontraron resultados", "Aceptar");
                    v_lista.ItemsSource = App.v_medicos;
                }
            }
            else if (v_tipo == 1)
            {
                ObservableCollection<C_Servicios> _filtrada = new ObservableCollection<C_Servicios>();
                if (_filCiud.Count > 0 && _filEspec.Count > 0)
                {
                    //recorre toda la lista de medicos
                    for (int i = 0; i < App.v_servicios.Count; i++)
                    {
                        //recorre lista de ciudad a filtrar
                        for (int j = 0; j < _filCiud.Count; j++)
                        {//recorre lista de especialidad a filtrar
                            for (int k = 0; k < _filEspec.Count; k++)
                            {
                                if ((App.v_servicios[i].v_Ciudad == _filCiud[j] && App.v_servicios[i].v_Especialidad == _filEspec[k]) && !_filtrada.Contains(App.v_servicios[i]))
                                {
                                    _filtrada.Add(App.v_servicios[i]);
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < _filCiud.Count; j++)
                    {//recorre toda la lista de medicos
                        for (int i = 0; i < App.v_servicios.Count; i++)
                        { //recorre lista de ciudad a filtrar
                            if (App.v_servicios[i].v_Ciudad == _filCiud[j] && !_filtrada.Contains(App.v_servicios[i]))
                            {
                                _filtrada.Add(App.v_servicios[i]);
                            }
                        }
                    }
                    //recorre lista de especialidad a filtrar
                    for (int j = 0; j < _filEspec.Count; j++)
                    {
                        //recorre toda la lista de medicos
                        for (int i = 0; i < App.v_servicios.Count; i++)
                        {
                            if (App.v_servicios[i].v_Especialidad == _filEspec[j] && !_filtrada.Contains(App.v_servicios[i]))
                            {
                                _filtrada.Add(App.v_servicios[i]);
                            }
                        }
                    }
                }
                IEnumerable<C_Servicios> _temp = _filtrada.OrderBy(x => x.v_completo);
                _filtrada = new ObservableCollection<C_Servicios>(_temp);
                if (_filtrada.Count > 0)
                {
                    v_lista.ItemsSource = _filtrada;
                }
                else
                {
                    await DisplayAlert("Filtro vacio", "No se encontraron resultados", "Aceptar");
                    v_lista.ItemsSource = App.v_servicios;
                }
            }
            else if (v_tipo == 2)
            {
                ObservableCollection<C_ServGenerales> _filtrada = new ObservableCollection<C_ServGenerales>();
                if (_filCiud.Count > 0 && _filEspec.Count > 0)
                {
                    //recorre toda la lista de medicos
                    for (int i = 0; i < App.v_generales.Count; i++)
                    {
                        //recorre lista de ciudad a filtrar
                        for (int j = 0; j < _filCiud.Count; j++)
                        {//recorre lista de especialidad a filtrar
                            for (int k = 0; k < _filEspec.Count; k++)
                            {
                                if ((App.v_generales[i].v_Ciudad == _filCiud[j] && App.v_generales[i].v_Especialidad == _filEspec[k]) && !_filtrada.Contains(App.v_generales[i]))
                                {
                                    _filtrada.Add(App.v_generales[i]);
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < _filCiud.Count; j++)
                    {//recorre toda la lista de medicos
                        for (int i = 0; i < App.v_generales.Count; i++)
                        { //recorre lista de ciudad a filtrar
                            if (App.v_generales[i].v_Ciudad == _filCiud[j] && !_filtrada.Contains(App.v_generales[i]))
                            {
                                _filtrada.Add(App.v_generales[i]);
                            }
                        }
                    }

                    //recorre lista de especialidad a filtrar
                    for (int j = 0; j < _filEspec.Count; j++)
                    {
                        //recorre toda la lista de medicos
                        for (int i = 0; i < App.v_generales.Count; i++)
                        {
                            if (App.v_generales[i].v_Especialidad == _filEspec[j] && !_filtrada.Contains(App.v_generales[i]))
                            {
                                _filtrada.Add(App.v_generales[i]);
                            }
                        }
                    }
                }
                IEnumerable < C_ServGenerales> _temp = _filtrada.OrderBy(x => x.v_completo);
                _filtrada = new ObservableCollection<C_ServGenerales>(_temp);

                if (_filtrada.Count > 0)
                {
                    v_lista.ItemsSource = _filtrada;
                }
                else
                {
                    await DisplayAlert("Filtro vacio", "No se encontraron resultados", "Aceptar");
                    v_lista.ItemsSource = App.v_generales;
                }
            }
            Fn_Filtro(sender, _args);
        }
        /// <summary>
        /// activar/Desactivar la pantalla de los filtros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="_Args"></param>
        public void Fn_Filtro(object sender, EventArgs _Args)
        {
            v_filtro = !v_filtro;
            overlay.IsVisible = v_filtro;
        }
        /// <summary>
        /// ordenar la lista por alfabetico
        /// </summary>
        async void Orden()
        {
            if(v_tipo==0)
            {
                for (int i = 0; i < App.v_medicos.Count; i++)
                {
                    App.v_medicos[i].Fn_SetEspec();
                }
                IEnumerable<C_Medico> _temp=      App.v_medicos.OrderBy(x => x.v_Apellido);
                App.v_medicos = new ObservableCollection<C_Medico>(_temp);  
                await Task.Delay(100);
            }
            else if(v_tipo==1)
            {
                IEnumerable<C_Servicios> _temp = App.v_servicios.OrderBy(x => x.v_completo);
                App.v_servicios =new ObservableCollection<C_Servicios>( _temp);
                await Task.Delay(100);                
            }
            else if(v_tipo==2)
            {
                IEnumerable<C_ServGenerales> _temp = App.v_generales.OrderBy(x => x.v_completo);
                App.v_generales = new ObservableCollection<C_ServGenerales>(_temp);
                await Task.Delay(100);
            }
        }
        /// <summary>
        /// seleccionas un elemento de la lista para expandir su informacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        async void Fn_Select(object sender, SelectedItemChangedEventArgs args)
        {
            if(v_tipo==0)
            {
                C_Medico item = args.SelectedItem as C_Medico;
                if (item == null)
                    return;

                await Navigation.PushAsync(new V_MedicoVista(item) { Title = item.v_titulo+" " +item.v_Nombre });
                v_lista.SelectedItem = null;
            }
            else if(v_tipo==1)
            {
                C_Servicios item = args.SelectedItem as C_Servicios;
                if (item == null)
                    return;

                await Navigation.PushAsync(new V_MedicoVista(item) { Title =  item.v_completo });
                v_lista.SelectedItem = null;
            }
            else if(v_tipo==2)
            {
                C_ServGenerales item = args.SelectedItem as C_ServGenerales;
                if (item == null)
                    return;

                await Navigation.PushAsync(new V_MedicoVista(item) { Title =  item.v_completo });
                v_lista.SelectedItem = null;
            }
        }        
        /// <summary>
        /// agregar o quitar del filtro de especialidad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="_Args"></param>
         void Fn_TapEspec(object sender, ItemTappedEventArgs _Args)
        {
            //para mostrar un cambio en la lista la estoy haciendo null y despues volviendo a llenar
            var list = (ListView)sender;
            list.ItemsSource = null;
            var _valor =  _Args.Item as Filtro;
            for (int i = 0; i < _especialidades.Count; i++)
            {
                if (_especialidades[i].v_texto == _valor.v_texto)
                {
                    _especialidades[i].v_visible = !_especialidades[i].v_visible;
                }
            }
            if (!_filEspec.Contains(_valor.v_texto))
            {
                _filEspec.Add(_valor.v_texto);
            }
            else
            {
                _filEspec.Remove(_valor.v_texto);
            }
            list.ItemsSource = _especialidades;
            //if (!_filEspec.Contains(_valor.v_texto))
            //{
            //    for(int i=0; i<_especialidades.Count; i++)
            //    {
            //        if(_especialidades[i].v_texto==_valor.v_texto)
            //        {
            //            // _especialidades[i].v_color=Color.Red;
            //            _especialidades[i].v_visible = !_especialidades[i].v_visible;
            //        }
            //    }
            //   _filEspec.Add(_valor.v_texto);
            //    list.ItemsSource = _especialidades;
            //}
            //else
            //{
            //    for (int i = 0; i < _especialidades.Count; i++)
            //    {
            //        if (_especialidades[i].v_texto == _valor.v_texto)
            //        {
            //            // _especialidades[i].v_color = new Color(.15686274509, 0.58823529411, 0.81960784313);
            //            _especialidades[i].v_visible = !_especialidades[i].v_visible;
            //        }
            //    }
            //    _filEspec.Remove(_valor.v_texto);
            //    list.ItemsSource = _especialidades;
            //}   
        }
        /// <summary>
        /// agregar o quitar del filtro de especialidad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="_Args"></param>
        void Fn_TapCiu(object sender, ItemTappedEventArgs _Args)
        {
            //para mostrar un cambio en la lista la estoy haciendo null y despues volviendo a llenar
            var list = (ListView)sender;
            list.ItemsSource = null;
            var _valor = _Args.Item as Filtro;//cast al template que ya esta preparado 
            if (!_filCiud.Contains(_valor.v_texto))
            {
                for (int i = 0; i < _ciudades.Count; i++)
                {
                    if (_ciudades[i].v_texto == _valor.v_texto)
                    {
                        _ciudades[i].v_visible = !_ciudades[i].v_visible;
                    }
                }
                _filCiud.Add(_valor.v_texto);
                list.ItemsSource = _ciudades;
            }
            else
            {
                for (int i = 0; i < _ciudades.Count; i++)
                {
                    if (_ciudades[i].v_texto == _valor.v_texto)
                    {
                        //_ciudades[i].v_color = Color.Blue;
                        _ciudades[i].v_visible = !_ciudades[i].v_visible;
                    }
                }
                _filCiud.Remove(_valor.v_texto);
                list.ItemsSource = _ciudades;
            }
        }
        /// <summary>
        /// buscar la informacionde la base de datos para los medicos y servicios
        /// </summary>
        public async void Fn_CargarDAtos()
        {
            string url = "";
            if(v_tipo==0)
            {
                HttpClient _cliente = new HttpClient();
                L_Error.IsVisible = true;
                L_Error.Text = "Procesando Informacion";
                try
                {
                    url = "http://tratoespecial.com/prueba_json.php";
                    HttpResponseMessage _respuestphp = await _cliente.PostAsync(url, null);
                    string _respu = await _respuestphp.Content.ReadAsStringAsync();
                  //  Console.Write("json nedicos \n" + _respu);
                    ObservableCollection<C_Medico> _med = JsonConvert.DeserializeObject<ObservableCollection<C_Medico>>(_respu);
                    L_Error.IsVisible = false;
                    B_Filtrar.IsEnabled = true;
                    App.v_medicos = _med;
                    Orden();
                    App.Fn_ImgSexo();
                    v_lista.ItemsSource = App.v_medicos;
                    App.Fn_GuardarRed(App.v_medicos);
                }
                catch
                {
                    if (Application.Current.Properties.ContainsKey(NombresAux.v_redmedica2))
                    {
                        string _json = App.Current.Properties[NombresAux.v_redmedica2] as string;
                        App.v_medicos = JsonConvert.DeserializeObject<ObservableCollection<C_Medico>>(_json);
                        Orden();
                        App.Fn_ImgSexo();
                        if(App.v_medicos.Count>0)
                        {
                            L_Error.IsVisible = false;
                            B_Filtrar.IsEnabled = true;
                        }
                        else
                        {
                            L_Error.Text = "Error de Conexion";
                            L_Error.IsVisible = true;
                            B_Filtrar.IsEnabled = false;
                        }
                        v_lista.ItemsSource = App.v_medicos;
                    }
                    else
                    {
                        L_Error.Text = "Error de Conexion";
                        L_Error.IsVisible = true;
                        B_Filtrar.IsEnabled = false;
                        v_lista.ItemsSource = null;
                    }
                }
            }
            else if(v_tipo==1)
            {
                url = "http://tratoespecial.com/query_servicios_medicos.php";
                HttpClient _cliente = new HttpClient();
                L_Error.IsVisible = true;
                L_Error.Text = "Procesando Informacion";
                try
                {
                    HttpResponseMessage _respuestphp = await _cliente.PostAsync(url, null);
                    string _respu = await _respuestphp.Content.ReadAsStringAsync();
                    ObservableCollection<C_Servicios> _med = JsonConvert.DeserializeObject<ObservableCollection<C_Servicios>>(_respu);
                    if(_med.Count<1)
                    {
                        L_Error.Text = "Llega vacio";
                    }
                    else
                    {
                        L_Error.IsVisible = false;
                        B_Filtrar.IsEnabled = true;
                    }
                    App.v_servicios = _med;
                    App.Fn_GuardarServcios(App.v_servicios);
                    Orden();
                   // App.Fn_ImgSexo();
                    v_lista.ItemsSource = App.v_servicios;
                }
                catch 
                {
                    if (Application.Current.Properties.ContainsKey("servicios"))
                    {
                        string _json = App.Current.Properties["servicios"] as string;
                        App.v_servicios = JsonConvert.DeserializeObject<ObservableCollection<C_Servicios>>(_json);
                        Orden();
                        //App.Fn_ImgSexo(v_tipo);
                        if (App.v_servicios.Count > 0)
                        {
                            L_Error.IsVisible = false;
                            B_Filtrar.IsEnabled = true;
                        }
                        else
                        {
                            L_Error.Text = "Error de Conexion";
                            L_Error.IsVisible = true;
                            B_Filtrar.IsEnabled = false;
                        }
                        v_lista.ItemsSource = App.v_servicios;
                    }
                    else
                    {
                        L_Error.Text = "Error de Conexion";
                        L_Error.IsVisible = true;
                        B_Filtrar.IsEnabled = false;
                        v_lista.ItemsSource = null;
                    }
                }
            }
            else if(v_tipo==2)
            { 
                HttpClient _cliente = new HttpClient();
                url = "http://tratoespecial.com/query_servicios_generales.php";
                L_Error.IsVisible = true;
                L_Error.Text = "Procesando Informacion";
                try
                {
                    HttpResponseMessage _respuestphp = await _cliente.PostAsync(url, null);
                    string _respu = await _respuestphp.Content.ReadAsStringAsync();
                    ObservableCollection<C_ServGenerales> _med = JsonConvert.DeserializeObject<ObservableCollection<C_ServGenerales>>(_respu);
                    if (_med.Count < 1)
                    {
                        L_Error.Text = "Llega vacio";
                    }
                    else
                    {
                        L_Error.IsVisible = false;
                        B_Filtrar.IsEnabled = true;
                    }
                    App.v_generales = _med;
                    App.Fn_GuardarGenerales(App.v_generales);
                    Orden();
                   // App.Fn_ImgSexo();
                    v_lista.ItemsSource = App.v_generales;
                }
                catch
                {
                    if (Application.Current.Properties.ContainsKey("generales"))
                    {
                        string _json = App.Current.Properties["generales"] as string;
                        App.v_generales = JsonConvert.DeserializeObject<ObservableCollection<C_ServGenerales>>(_json);
                        Orden();
                      //  App.Fn_ImgSexo();
                        if (App.v_generales.Count > 0)
                        {
                            L_Error.IsVisible = false;
                            B_Filtrar.IsEnabled = true;
                        }
                        else
                        {
                            L_Error.Text = "Error de Conexion";
                            L_Error.IsVisible = true;
                            B_Filtrar.IsEnabled = false;
                        }
                        v_lista.ItemsSource = App.v_generales;
                    }
                    else
                    {
                        L_Error.Text = "Error de Conexion";
                        L_Error.IsVisible = true;
                        B_Filtrar.IsEnabled = false;
                        v_lista.ItemsSource = null;
                    }
                }
            }
            Fn_CrearCiud();
            Fn_CrearEspec();
        }
        /// <summary>
        /// refresh de la lista principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Fn_Refresh(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            Fn_CargarDAtos();
            v_Search.Text = "";
            await Task.Delay(100);
            list.IsRefreshing = false;//cancelar la actualizacion
        }
        /// <summary>
        /// la barra de busqueda mientras escribes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Fn_Buscar(object sender, TextChangedEventArgs e)
        {
            SearchBar _search = (SearchBar)sender;
            if (_search != null)
            {
                string _abuscar = _search.Text;//.StartsWith()
                if (string.IsNullOrEmpty(_abuscar) || string.IsNullOrWhiteSpace(_abuscar))
                {
                    v_lista.IsVisible = false;
                    Buscador.ItemsSource = null;
                    Buscador.IsVisible = false;
                    v_lista.IsVisible = true;
                    if (v_tipo == 0)
                    {
                        v_lista.ItemsSource = App.v_medicos;
                    }
                    else if (v_tipo == 1)
                    {
                        v_lista.ItemsSource = App.v_servicios;
                    }
                    else if (v_tipo == 2)
                    {
                        v_lista.ItemsSource = App.v_generales;
                    }
                }
                else
                {
                    _abuscar = _abuscar.ToLower();
                    v_lista.IsVisible = false;
                    Buscador.ItemsSource = null;
                    Buscador.IsVisible = true;
                    ObservableCollection<string> _lista = new ObservableCollection<string>();
                    if (v_tipo == 0)//recorre solo los  medicos, para ver su nombre y apellido
                    {
                        for (int i = 0; i < App.v_medicos.Count; i++)//hacer cambios para cuando tienen  2 nombre apellidoos
                        {
                            if (App.v_medicos[i].v_Nombre.ToLower().StartsWith(_abuscar) && !_lista.Contains(App.v_medicos[i].v_Nombre))
                            {
                                _lista.Add(App.v_medicos[i].v_Nombre);
                            }
                            else if (App.v_medicos[i].v_Apellido.ToLower().StartsWith(_abuscar) && !_lista.Contains(App.v_medicos[i].v_Apellido))
                            {
                                _lista.Add(App.v_medicos[i].v_Apellido);
                            }
                        }
                    }
                    else if (v_tipo == 1)
                    {
                        for (int i = 0; i < App.v_servicios.Count; i++)
                        {
                            if (App.v_servicios[i].v_completo.ToLower().StartsWith(_abuscar) && !_lista.Contains(App.v_servicios[i].v_completo))
                            {
                                _lista.Add(App.v_servicios[i].v_completo);
                            }
                        }
                    }
                    else if (v_tipo == 2)
                    {
                        for (int i = 0; i < App.v_generales.Count; i++)
                        {
                            if (App.v_generales[i].v_completo.ToLower().StartsWith(_abuscar) && !_lista.Contains(App.v_generales[i].v_completo))
                            {
                                _lista.Add(App.v_generales[i].v_completo);
                            }
                        }
                    }
                    //recorre solamente las especialidades que ya se guardaron antes
                    for (int i = 0; i < _especialidades.Count; i++)
                    {
                        if (_especialidades[i].v_texto.ToLower().StartsWith(_abuscar))
                        {
                            _lista.Add(_especialidades[i].v_texto);
                        }
                    }
                    if (_lista.Count > 0)
                    {
                        ObservableCollection<PrefFil> _pref = new ObservableCollection<PrefFil>();
                        for (int i = 0; i < _lista.Count; i++)
                        {
                            _pref.Add(new PrefFil { v_texto = _lista[i] });
                        }
                        Buscador.ItemsSource = _pref;
                        Buscador.IsVisible = true;
                    }
                    else
                    {
                        Buscador.IsVisible = false;
                    }
                }
            }
        }
        /// <summary>
        /// lista que esta abajop de la barra de busqueda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="_args"></param>
        public void Fn_TapFiltro(object sender, ItemTappedEventArgs _args)
        {
            PrefFil _nuevoFiltro =_args.Item as PrefFil;
            v_Search.Text = _nuevoFiltro.v_texto;
            if(v_tipo==0)
            {
                ObservableCollection<C_Medico> _medicosTemp = new ObservableCollection<C_Medico>();
                for(int i=0; i<App.v_medicos.Count; i++)
                {
                    for (int e = 0; e < App.v_medicos[i].v_ListaEsp.Count; e++)
                    {
                        if (((App.v_medicos[i].v_Nombre == _nuevoFiltro.v_texto) ||
                            (App.v_medicos[i].v_Apellido == _nuevoFiltro.v_texto) || 
                            (App.v_medicos[i].v_ListaEsp[e].v_nombreEspec == _nuevoFiltro.v_texto)
                            )&& !_medicosTemp.Contains(App.v_medicos[i]) )
                        {
                            _medicosTemp.Add(App.v_medicos[i]);
                        }
                    }
                }
                v_lista.ItemsSource = _medicosTemp;
            }
            else if(v_tipo==1)
            {
                ObservableCollection<C_Servicios> _serTemp = new ObservableCollection<C_Servicios>();
                for (int i = 0; i < App.v_servicios.Count; i++)
                {
                    if (( (App.v_servicios[i].v_completo == _nuevoFiltro.v_texto) ||
                        (App.v_servicios[i].v_Especialidad == _nuevoFiltro.v_texto))&& !_serTemp.Contains(App.v_servicios[i]) )
                    {
                        _serTemp.Add(App.v_servicios[i]);
                    }
                }
                v_lista.ItemsSource = _serTemp;
            }
            else if(v_tipo==2)
            {
                ObservableCollection<C_ServGenerales> _serTemp = new ObservableCollection<C_ServGenerales>();
                for (int i = 0; i < App.v_generales.Count; i++)
                {
                    if (((App.v_generales[i].v_completo == _nuevoFiltro.v_texto) ||
                        (App.v_generales[i].v_Especialidad == _nuevoFiltro.v_texto) ) && !_serTemp.Contains(App.v_generales[i]))
                    {
                        _serTemp.Add(App.v_generales[i]);
                    }
                }
                v_lista.ItemsSource = _serTemp;
            }
            v_lista.IsVisible = true;
            Buscador.IsVisible = false;
        }
    }
}