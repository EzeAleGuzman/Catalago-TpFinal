
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using tp1;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace tpfinal
{

	public class Estrategia
	{
		
		public string GetUrlSeoPorId(ArbolGeneral<ItemCat> arbol, int id)
        {
            string url = BuscarUrlPorId(arbol, id, "");
            if (url == "")
                {
                    return "URL no encontrada";
                }
            return url;
        }

        private string BuscarUrlPorId(ArbolGeneral<ItemCat> arbol,int id, string path)
        {
            string ruta;
            if (path == "")
                ruta = arbol.getDatoRaiz().Nombre;
            else
                ruta = path + "/" + arbol.getDatoRaiz().Nombre;

            if (arbol.getDatoRaiz().Id == id)
                return "tienda.com/" + ruta;

            foreach (var hijo in arbol.getHijos())
            {
                string resultado = BuscarUrlPorId(hijo, id, ruta);
                if (resultado != "") return resultado;
            }

            return "";
        }


		
		

        public List<string> GetURLsSEO(ArbolGeneral<ItemCat> arbol)
		{
			return ["Implementar"];
		}
        

              

        public List<List<string>> ConsultaNiveles(ArbolGeneral<ItemCat> arbol)
		{
            return [["Implementar"]];
        }


        public List<ItemCat> Todos(ArbolGeneral<ItemCat> arbol)
        {
            return  [];
        }

        public void Agregar(ArbolGeneral<ItemCat> arbol, ItemCat dato, string rutaAlPadre)
		{
            //implementar
        }

        public List<ItemCat> Buscar(ArbolGeneral<ItemCat> arbol, string elementoABuscar)
		{
			return [];
		}
            
    }
}
