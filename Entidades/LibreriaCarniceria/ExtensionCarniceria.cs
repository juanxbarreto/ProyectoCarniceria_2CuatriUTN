using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCarniceria
{
    public static class ExtensionCarniceria
    {
        public static bool ValidarTexto(this string texto)
        {
            return texto.Length <= 50;
        }

        public static string FormatearFecha(this DateTime fecha)
        {
            fecha = DateTime.Now;
            string fechaStr = fecha.ToString("HH:mm:ss");
            return fechaStr;
        }

    }
}
