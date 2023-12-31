﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P520233_MaryelCastro.Globales
{
    public static class ObjetosGlobales
    {
        //Definir un objeto global para el form principal
        public static Form MiFormularioPrincipal = new Formularios.FrmPrincipal();

        public static Formularios.FrmUsuariosGestion 
            MiFormularioDeGestionDeUsuarios = new Formularios.FrmUsuariosGestion();




        //FORMULARIO DE GESTION DE PRODUCTO
        public static Formularios.FrmProductosGestion
            MiFormularioDeGestionDeProductos = new Formularios.FrmProductosGestion();






        //Este sera el usuario validado en el login, tendra un scopre global
        //en toda la aplicacion

        public static Logica.Models.Usuario MiUsuarioGlobal = new Logica.Models.Usuario();

        //Crear el formulario de movimientos
        public static Formularios.FrmMovimientosInventario
            MiFormularioMovimientos = new Formularios.FrmMovimientosInventario();



    }
}
