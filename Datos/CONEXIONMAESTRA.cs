using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using appKaraoke.Datos;
using System.Data;

namespace appKaraoke.Datos
{
    internal static class CONEXIONMAESTRA
    {
        public static SqlConnection conexion = new SqlConnection(@"Data source=DESKTOP-VLIVP2S\SQLEXPRESS; Initial Catalog=karaoke_db; Integrated Security=true");
        public static void abrir()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
        }
        public static void cerrar()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
