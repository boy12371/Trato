﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace Trato.Personas
{
    /* https://forums.xamarin.com/discussion/100135/json-response-parsing-in-xamarin-froms
     * EXPLICA EL FORMATO Y COMO DEBEN ESTAR LOS ATRIBUTOS PARA EL JSON
     * 
     * 
     * EN LA TARJETA CON LOS DATOS DE COBRO ENVIAR EL NOMBRE DE LA MEMBRESIA CON STRING
     * Y TAMBIEN ENVIAR  COMO NUMERO EL TIPO DE MEMBRESiA( DE 0 A 2)
         */

    public class C_PerfilGen
    {
        [JsonProperty("nombre")]
        public string v_Nombre { get; set; }
        [JsonProperty("rfc")]
        public string v_Rfc { get; set; }
        [JsonProperty("fechanac")]
        public string v_FecNaci { get; set; }
        [JsonProperty("lugnac")]
        public string v_LugNac { get; set; }
        [JsonProperty("ocu")]
        public string v_Ocup { get; set; }
        [JsonProperty("idsexo")]
        public int v_idsexo { get; set; }
        [JsonProperty("tel")]
        public string v_Tel { get; set; }
        [JsonProperty("cel")]
        public string v_Cel { get; set; }
        [JsonProperty("calle")]
        public string v_Calle { get; set; }
        [JsonProperty("numext")]
        public string v_NumExt { get; set; }
        [JsonProperty("numint")]
        public string v_NumInt { get; set; }
        [JsonProperty("colonia")]
        public string v_Colonia { get; set; }
        [JsonProperty("ciudad")]
        public string v_Ciudad { get; set; }
        [JsonProperty("municipio")]
        public string v_municipio { get; set; }
        [JsonProperty("estado")]
        public string v_Estado { get; set; }
        [JsonProperty("cp")]
        public string v_Cp { get; set; }
        [JsonProperty("correo")]
        public string v_Correo { get; set; }
        [JsonProperty("activado")]
        public string v_activo { get; set; }
        [JsonProperty("fecha_vig")]
        public string v_vig;
        [JsonProperty("total_usuarios")]
        public string v_numEmple { get; set; }


        public C_PerfilGen()
        {
            v_idsexo = -1;
            v_Nombre = "";
            v_Rfc = "";
            v_FecNaci = "";
                v_LugNac = "";
            v_Ocup = "";
            v_Tel = "";
            v_Cel = "";
            v_Calle = "";
            v_NumExt = "";
            v_NumInt = "";
            v_Colonia = "";
            v_Ciudad = "";
            v_municipio = "";
            v_Estado = "";
            v_Cp = "";
            v_Correo= "";
            v_activo = "-23";
            v_vig = "-1241";
        }
        public C_PerfilGen(string _nom, string _rfc, DateTime _fechnac, string _lugnac, string _ocu,int _idsexo,  string _tel, string _cel,
            string _calle, string _numExt, string _numInt, string _col, string _ciud, string _mun, string _est, string _cp, string _corr)
        {
            v_Nombre = _nom;
            v_Rfc = _rfc;
            string _month = "";
            if (_fechnac.Month < 10)
            {
                _month = "0" + _fechnac.Month.ToString();
            }
            else
            {
                _month = _fechnac.Month.ToString();
            }
            string _day = "";
            if (_fechnac.Day < 10)
            {
                _day = "0" + _fechnac.Day.ToString();
            }
            else
            {
                _day = _fechnac.Day.ToString();
            }
            v_FecNaci = _fechnac.Year.ToString() + "-" + _month + "-" + _day;
            v_LugNac = _lugnac;
            v_Ocup = _ocu;
            v_idsexo = _idsexo;
            v_Tel = _tel;
            v_Cel = _cel;
            v_Calle = _calle;
            v_NumExt = _numExt;
            v_NumInt = _numInt;
            v_Colonia = _col;
            v_Ciudad = _ciud;
            v_municipio = _mun;
            v_Estado = _est;
            v_Cp = _cp;
            v_Correo = _corr;
            v_activo = "-23";
        }
        public string Fn_GetDatos()
        {
            string _ret = "";
           _ret= "nombre "+v_Nombre + "  rfc  " + v_Rfc + "  fech nac" + v_FecNaci + " lugnac  " + v_LugNac + " ocu " + v_Ocup + "\n" +
                "id sexo "+ v_idsexo + "  tel " + v_Tel + " cel  " + v_Cel + "  \n" +
                "  calle  "+v_Calle + " numext " + v_NumExt + "  numint " +  v_NumInt + "  " +
                "colonia "+v_Colonia + "ciud  " + v_Ciudad + " muni" + v_municipio + "  esta" + v_Estado + " \n" +
                "cp  "+v_Cp + "  corr " + v_Correo+"   activado  "+ v_activo+"  numemple"+v_numEmple + "vigencia " + v_vig;
            return _ret;
                  
        }
    }
    public class C_PerfilMed
    {
        [JsonProperty("sangre")]
        public string v_sangre { get; set; }
        [JsonProperty("idsexo")]
        public int v_sexo { get; set; }
        [JsonProperty("infoMuj")]
        public string v_infoMujer { get; set; }
        [JsonProperty("alergias")]
        public string v_alergias { get; set; }
        [JsonProperty("operaciones")]
        public string v_operaciones { get; set; }
        [JsonProperty("enfermedades")]
        public string v_enfer { get; set; }
        [JsonProperty("medicamentos")]
        public string v_medica { get; set; }
       
        public C_PerfilMed()
        {
            v_sangre = "";
            v_sexo = -1;
            v_infoMujer = "";
            v_alergias = "";
            v_operaciones = "";
            v_enfer = "";
            v_medica = "";
        }
        public C_PerfilMed(int _idsex)
        {
            v_sangre = "";
            v_sexo = _idsex;
            v_infoMujer = "";
            v_alergias = "";
            v_operaciones = "";
            v_enfer = "";
            v_medica = "";
        }
        public C_PerfilMed(string _sangr, string _sexo, string _aler, string _opera, string _enfer, string _medicam)
        {
            v_sangre = _sangr;
            v_infoMujer = _sexo;
            v_alergias = _aler;
            v_operaciones = _opera;
            v_enfer = _enfer;
            v_medica = _medicam;
        }
        public string Fn_Info()
        {
            string ret = v_sangre + "  ---  " + v_sexo + "  ---  " + v_infoMujer + "---" + v_alergias + "----" + v_operaciones + "---" + v_enfer + "---" + v_medica;
            return ret;
        }
    }
    /// <summary>
    /// el regustro para familiares y empleados
    /// </summary>
    class C_RegistroSec
    {
        #region datos generales
        [JsonProperty("nombre")]
        string v_nombre { get; set; }
        [JsonProperty("sexo")]
        int v_sexo { get; set; }
        [JsonProperty("fecha")]
        string v_fecha { get; set; }
        [JsonProperty("cel")]
        string v_celular { get; set; }
        [JsonProperty("correo")]
        string v_correo { get; set; }
        [JsonProperty("pass")]
        string v_password { get; set; }
        [JsonProperty("idmembre")]
        string v_membre { get; set; }
        [JsonProperty("id")]
        int v_id { get; set; }
        #endregion
        #region Datos de la familiar
        [JsonProperty("parentesco")]
        string v_parentesco { get; set; }
        #endregion
        #region datos especificos de empresarial
        [JsonProperty("empresa")]
        string v_empresa { get; set; }
        [JsonProperty("folio")]
        string v_folio { get; set; }
        #endregion

        public C_RegistroSec ()
        {
            v_sexo = -1;
        }
        public C_RegistroSec(string _nombre,int _sexo, DateTime _fecha, string _cel, string _correo,string _pass,string _membre,  int _id, string _paren)
        {
            v_nombre = _nombre;
            v_sexo = _sexo;
            string _month = "";
            if (_fecha.Month < 10)
            {
                _month = "0" + _fecha.Month.ToString();
            }
            else
            {
                _month = _fecha.Month.ToString();
            }
            string _day = "";
            if (_fecha.Day < 10)
            {
                _day = "0" + _fecha.Day.ToString();
            }
            else
            {
                _day = _fecha.Day.ToString();
            }
            v_fecha = _fecha.Year.ToString() + "-" + _month + "-" + _day;
            v_celular = _cel;
            v_correo = _correo;
            v_password = _pass;
            v_membre = _membre;
            v_id = _id;
            v_parentesco = _paren;
            v_empresa = "";
            v_folio = "";

        }
        public C_RegistroSec(string _nombre, int _sexo, DateTime _fecha, string _cel, string _correo, string _pass, string _membre, int _id,string _empr, string _fol)
        {
            v_nombre = _nombre;
            string _month = "";
            if (_fecha.Month < 10)
            {
                _month = "0" + _fecha.Month.ToString();
            }
            else
            {
                _month = _fecha.Month.ToString();
            }
            string _day = "";
            if (_fecha.Day < 10)
            {
                _day = "0" + _fecha.Day.ToString();
            }
            else
            {
                _day = _fecha.Day.ToString();
            }
            v_fecha = _fecha.Year.ToString() + "-" + _month + "-" + _day;
            v_celular = _cel;
            v_correo = _correo;
            v_password = _pass;
            v_membre = _membre;
            v_id = _id;
            v_parentesco = "";
            v_empresa = _empr;
            v_folio = _fol;
        }

    }
    /// <summary>
    /// registro total del principal, vienen los datos para pagar
    /// </summary>
    class C_RegistroPrinci
    {
        #region DAtos del usuario a registrar
        [JsonProperty("nombre")]
        string v_Nombre { get; set; }
        [JsonProperty("rfc")]
        string v_Rfc { get; set; }
        /// <summary>
        /// Fecha de nacimiento, tiene que ser dia mes año
        /// </summary>
        [JsonProperty("fechanac")]
        string v_FecNaci { get; set; }
        /// <summary>
        /// lugar de nacimiento
        /// </summary>
        [JsonProperty("lugnac")]
        string v_LugNac { get; set; }
        [JsonProperty("ocu")]
        string v_Ocup { get; set; }
        [JsonProperty("tel")]
        string v_Tel { get; set; }
        [JsonProperty("cel")]
        string v_Cel { get; set; }
        [JsonProperty("calle")]
        string v_Calle { get; set; }
        [JsonProperty("numext")]
        string v_NumExt { get; set; }
        [JsonProperty("numint")]
        string v_NumInt { get; set; }
        [JsonProperty("colonia")]
        string v_Colonia { get; set; }
        [JsonProperty("ciudad")]
        string v_Ciudad { get; set; }
        [JsonProperty("municipio")]
        string v_municipio { get; set; }
        [JsonProperty("estado")]
        string v_Estado { get; set; }
        [JsonProperty("cp")]
        string v_Cp { get; set; }
        [JsonProperty("correo")]
        string v_Correo { get; set; }
        /// <summary>
        /// 0 si es fisica, 1 persona moral
        /// </summary>
        [JsonProperty("idpersona")]
        int idPersona = 0;
        #endregion

        #region DAtos de la membresia elegida   
        /// <summary>
        /// el nombre de la membresia, personal, familiar, empresarial
        /// </summary>
        [JsonProperty("nombremembresia")]
        string v_NomMembre { get; set; }
        ////// <summary>
        ////// 0 personal, 1 familiar, 2 empresarial
        ////// </summary>
        [JsonProperty("idmembre")]
        int v_idmembre { get; set; }
        [JsonProperty("costo")]
        string v_Costo { get; set; }
        [JsonProperty("numemple")]
        int v_numEmple { get; set; }

        #endregion

        #region Datos de la tarjeta
        /// <summary>
        /// el token que se genera desde el web view
        /// </summary>
        //[JsonProperty("tokenid")]
        //string v_token { get; set; }
        #endregion



        public C_RegistroPrinci()
        {

        }
        public C_RegistroPrinci(string _nom, string _rfc, DateTime _fechnac, string _lugnac, string _ocu,string _tel, string _cel,
            string _calle,string _numExt, string _numInt, string _col, string _ciud,string _mun, string _est, string _cp, 
            string _corr, int _idPer,string _nomMembre, int _idmembre, string _costo,int _numEmple)//, string _token )
        {
            v_Nombre = _nom;
            v_Rfc = _rfc;
            string _month = "";
            if(_fechnac.Month<10)
            {
                _month = "0" + _fechnac.Month.ToString();
            }
            else
            {
                _month = _fechnac.Month.ToString();
            }
            string _day = "";
            if (_fechnac.Day < 10)
            {
                _day = "0" + _fechnac.Day.ToString();
            }
            else
            {
                _day = _fechnac.Day.ToString();
            }
            v_FecNaci = _fechnac.Year.ToString() + "-" + _month + "-" + _day;
            v_LugNac = _lugnac;
            v_Ocup = _ocu;
            v_Tel = _tel;
            v_Cel = _cel;
            v_Calle = _calle;
            v_NumExt = _numExt;
            v_NumInt = _numInt;
            v_Colonia = _col;
            v_Ciudad = _ciud;
            v_municipio = _mun;
            v_Estado = _est;
            v_Cp = _cp;
            v_Correo = _corr;
            idPersona = _idPer;
            v_NomMembre = _nomMembre;
            v_idmembre = _idmembre;
            v_Costo = _costo;
            v_numEmple = _numEmple;
           // v_token = _token;

        }
    }
    /// <summary>
    /// enviar la info de iniciar sesion
    /// </summary>
    class C_Login
    {
        [JsonProperty("membre")]
        string v_membre { get; set; }
        [JsonProperty("letra")]
        string v_letra { get; set; }
        [JsonProperty("consecutivo")]
        string v_conse { get; set; }
        [JsonProperty("password")]
        string v_pass  { get;set;}
        [JsonProperty("folio")]
        string v_fol { get; set; }



        public C_Login()
        {
            this.v_membre = "";
            this.v_letra = "";
            this.v_conse = "";
            this.v_pass = "";
            this.v_fol = "";
        }
        public C_Login(string _membr,string _letr,string _conse, string _pass,string _fol)
        {
            this.v_membre = _membr;
            this.v_letra =_letr;
            this.v_conse =_conse;
            this.v_pass = _pass;
            this.v_fol = _fol;
        }
    }
    /*
    class C_Ind_Fisica
    {
        [JsonProperty("nombre")]
        string v_Nombre { get; set; }
        [JsonProperty("rfc")]
        string v_Rfc { get; set; }
        /// <summary>
        /// Fecha de nacimiento, tiene que ser dia mes año
        /// </summary>
        [JsonProperty("fechanac")]
        string v_FecNaci { get; set; }
        /// <summary>
        /// lugar de nacimiento
        /// </summary>
        [JsonProperty("lugnac")]
        string v_LugNac { get; set; }
        [JsonProperty("ocu")]
        string v_Ocup { get; set; }
        [JsonProperty("tel")]
        string v_Tel { get; set; }
        [JsonProperty("cel")]
        string v_Cel { get; set; }
        [JsonProperty("calle")]
        string v_Calle { get; set; }
        [JsonProperty("numext")]
        string v_NumExt { get; set; }
        [JsonProperty("numint")]
        string v_NumInt { get; set; }
        [JsonProperty("colonia")]
        string v_Colonia { get; set; }
        [JsonProperty("ciudad")]
        string v_Ciudad { get; set; }
        [JsonProperty("municipio")]
        string v_municipio { get; set; }
        [JsonProperty("estado")]
        string v_Estado { get; set; }
        [JsonProperty("cp")]
        string v_Cp { get; set; }
        [JsonProperty("correo")]
        string v_Correo { get; set; }
        [JsonProperty("membre")]
        int v_membre { get; set; }
        [JsonProperty("id")]
        const int Id = 0;
    public C_Ind_Fisica()
        {

            this.v_Nombre = "";
            this.v_Rfc = "";
            //4-2-2
            //AÑO - MES NUMERO- DIA
            this.v_FecNaci = "0000-00-00";
            this.v_LugNac = "";
            this.v_Ocup = "";
            this.v_Tel = "";
            this.v_Cel = "";
            this.v_Calle = "";
            this.v_NumExt = "";
            this.v_NumInt = "";
            this.v_Colonia = "";
            this.v_Ciudad = "";
            this.v_municipio = "";
            this.v_Estado = "";
            this.v_Cp = "";
            this.v_Correo = "";
        }
        public C_Ind_Fisica(string _nom,string _rfc, DateTime _nac,
           string _lugnac, string _ocu, string _tel, string _cel, string _call,
           string _ext, string _int, string _col, string _ciud, string _muni, string _est, string _cp, string _corr, int _membre)
        {
            this.v_Nombre = _nom;
            this.v_Rfc = _rfc;
            //4-2-2
            //AÑO - MES NUMERO- DIA
            this.v_FecNaci = _nac.Year.ToString() + "-" + _nac.Month.ToString() + "-" + _nac.Day.ToString();
            this.v_LugNac = _lugnac;
            this.v_Ocup = _ocu;
            this.v_Tel = _tel;
            this.v_Cel = _cel;
            this.v_Calle = _call;
            this.v_NumExt = _ext;
            this.v_NumInt = _int;
            this.v_Colonia = _col;
            this.v_Ciudad = _ciud;
            this.v_municipio = _muni;
            this.v_Estado = _est;
            this.v_Cp = _cp;
            this.v_Correo = _corr;
            this.v_membre = _membre;
        }
        
        public string Fn_GetInfo()
        {
            string _mensaje = v_Nombre + " " + v_Rfc + " " + v_FecNaci + " " + v_LugNac + " " + v_Ocup +
                " " + v_Tel + " " + v_Cel + " " + v_Calle + " " + v_NumExt + " " + v_NumInt + " " + v_Colonia + " " +
                v_Ciudad + " " + v_municipio + " " + v_Estado + " " + v_Cp + " " + v_Correo;
            return _mensaje;
        }
    }
    class C_Ind_Moral
    {
        /// <summary>
        /// nombre oi razon social
        /// </summary>
        string v_Nombre;
        [JsonProperty("rfc")]
        string v_Rfc;
        [JsonProperty("ocu")]
        string v_Ocup { get; set; }
        [JsonProperty("tel")]
        string v_Tel { get; set; }
        [JsonProperty("calle")]
        string v_Calle { get; set; }
        [JsonProperty("numext")]
        string v_NumExt { get; set; }
        [JsonProperty("numint")]
        string v_NumInt { get; set; }
        [JsonProperty("colonia")]
        string v_Colonia { get; set; }
        [JsonProperty("ciudad")]
        string v_Ciudad { get; set; }
        [JsonProperty("municipio")]
        string v_municipio { get; set; }
        [JsonProperty("estado")]
        string v_Estado { get; set; }
        [JsonProperty("cp")]
        string v_Cp { get; set; }
        [JsonProperty("correo")]
        string v_Correo { get; set; }
        [JsonProperty("Membre")]
        int v_membre { get; set; }
        [JsonProperty("id")]
        const int Id = 1;


        public C_Ind_Moral()
        {
            this.v_Nombre = "";
            this.v_Rfc = "";
            this.v_Tel = "";
            this.v_Calle = "";
            this.v_NumExt = "";
            this.v_NumInt = "";
            this.v_Colonia = "";
            this.v_Ciudad = "";
            this.v_municipio = "";
            this.v_Estado = "";
            this.v_Cp = "";
            this.v_Ocup = "";
            this.v_Correo = "";
        }
        public C_Ind_Moral(string _nom, string _rfc, string _giro, string _tel, string _call,
           string _ext, string _int, string _col, string _ciud, string _muni, string _est, string _cp, string _corr, int _membre)
        {
            this.v_Nombre = _nom;
            this.v_Rfc = _rfc;
            this.v_Calle = _call;
            this.v_NumExt = _ext;
            this.v_NumInt = _int;
            this.v_Colonia = _col;
            this.v_Ciudad = _ciud;
            this.v_municipio = _muni;
            this.v_Estado = _est;
            this.v_Cp = _cp;
            this.v_Ocup = _giro;
            this.v_Tel = _tel;
            this.v_Correo = _corr;
            this.v_membre = _membre;
        }

        public string Fn_GetInfo()
        {
            string _mensaje = v_Nombre + " " + v_Rfc + " " + v_Calle + " " + v_NumExt + " " + v_NumInt + "  " +
                v_Colonia + " " + v_Ciudad + " " + v_municipio + " " + v_Estado + " " +
                v_Cp + " " + v_Ocup + " " + v_Tel + " " + v_Correo;

            return _mensaje;
        }

    }
    */
    /// <summary>
    /// informacion a mostrar en el buscador, para solicitar citas 
    /// </summary>
    public class C_Medico
    {
        [JsonProperty("Consecutivo")]
        public string v_id { get; set; }
        //get y set para poder que sean binding
        [JsonProperty("titulo")]
        public string v_titulo { get; set; }
        [JsonProperty("nombre")]
        public string v_Nombre { get; set; }
        /// <summary>
        /// lo necesito yo para ordenarlo por orden      
        /// </summary>
        [JsonProperty("ape")]
        public string v_Apellido { get; set; }
        [JsonProperty("espe")]
        public string v_Especialidad { get; set; }
        [JsonProperty("dom")]
        public string v_Domicilio { get; set; }
        [JsonProperty("horario")]
        public string v_horario;
        /// <summary>
        /// este lo necesito yo para el filtro
        /// </summary>
        [JsonProperty("ciudad")]
        public string v_Ciudad { get; set; }
        [JsonProperty("tel")]
        public string v_Tel { get; set; }
        [JsonProperty("correo")]
        public string v_Correo { get; set; }
        [JsonProperty("cedula")]
        public string v_cedula { get; set; }
        [JsonProperty("descrip")]
        public string v_descripcion { get; set; }
        [JsonProperty("idsexo")]
        public int v_idsexo { get; set; }


        public string v_img { get; set; }
        public string v_completo { get; set; }

        public string FN_GetInfo()
        {
            string _ret;
            _ret = "tit " + v_titulo + "nom " + v_Nombre + " ape " + v_Apellido + " espe " + v_Especialidad + " dom " + v_Domicilio + " ciu " + v_Ciudad +
                " tel " + v_Tel + " corr " + v_Correo + " horario" + v_horario + " ced " + v_cedula + " des " + v_descripcion +
                " sexo " + v_idsexo;
            return _ret;
        }
    }
    /// <summary>
    /// lugares, hospitales
    /// </summary>
    public class C_Servicios
    {
        //cambio del nombre de la variable para que en el buscador con el binding no de espacios es blanco
        [JsonProperty("nombre")]
        public string v_completo { get; set; }
        [JsonProperty("espe")]
        public string v_Especialidad { get; set; }
        [JsonProperty("dom")]
        public string v_Domicilio { get; set; }
        [JsonProperty("horario")]
        public string v_horario;
        /// <summary>
        /// este lo necesito yo para el filtro
        /// </summary>
        [JsonProperty("ciudad")]
        public string v_Ciudad { get; set; }
        [JsonProperty("tel")]
        public string v_Tel { get; set; }
        [JsonProperty("correo")]
        public string v_Correo { get; set; }
        [JsonProperty("descrip")]
        public string v_descripcion { get; set; }
        [JsonProperty("sitio")]
        public string v_sitio;
        /// <summary>
        /// imagen para mostrar
        /// </summary>
      
        public string v_img { get; set; }
        
    }
    /// <summary>
    /// lugares diferentes
    /// </summary>
    public class C_ServGenerales
    {
        //cambio del nombre de la variable para que en el buscador con el binding no de espacios es blanco
        [JsonProperty("nombre")]
        public string v_completo { get; set; }
        /// <summary>
        /// la especialidad a lo que se dedica
        /// </summary>
        [JsonProperty("espe")]     
        public string v_Especialidad { get; set; }

        [JsonProperty("descrip")]
        public string v_descripcion { get; set; }

        [JsonProperty("dom")]
        public string v_Domicilio { get; set; }
        /// <summary>
        /// este lo necesito yo para el filtro
        /// </summary>
        [JsonProperty("ciudad")]
        public string v_Ciudad { get; set; }

        [JsonProperty("horario")]
        public string v_horario;

        [JsonProperty("tel")]
        public string v_Tel { get; set; }
        [JsonProperty("correo")]
        public string v_Correo { get; set; }
        [JsonProperty("sitio")]
        public string v_sitio;
        /// <summary>
        /// imagen para mostrar
        /// </summary>
        public string v_img { get; set; }
    }
}
