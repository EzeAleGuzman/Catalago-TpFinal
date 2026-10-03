
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

        // Método auxiliar para buscar la URL por ID en el árbol
        private string BuscarUrlPorId(ArbolGeneral<ItemCat> arbol,int id, string path)
        {
            string ruta;
            if (path == "")
                ruta = arbol.getDatoRaiz().Nombre;
            else
                ruta = path + "/" + arbol.getDatoRaiz().Nombre;

            if (arbol.getDatoRaiz().Id == id)
                return  "link.com/" + ruta;

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
            List<List<string>> resultado = new List<List<string>>();
			// Verificar si el arbol es nulo
			if (arbol == null) return resultado;
			// Crear una cola para realizar el recorrido por niveles
			Cola<ArbolGeneral<ItemCat>> cola = new Cola<ArbolGeneral<ItemCat>>();
			cola.encolar(arbol);
			// Mientras la cola no este vacia, procesar los nodos por niveles
			while (!cola.esVacia())
			{
    			int cantNiveles = cola.cantidadElementos();
    			List<string> nivelActual = new List<string>();
    			// Procesar todos los nodos del nivel actual
    			for (int i = 0; i < cantNiveles; i++)
    			{
        			ArbolGeneral<ItemCat> nodoActual = cola.desencolar();
        			nivelActual.Add(nodoActual.getDatoRaiz().Nombre);
        			// Encolar los hijos del nodo actual para el siguiente nivel
        			foreach (var hijo in nodoActual.getHijos())
        			{
            			cola.encolar(hijo);
        			}
    			}
    			// Agregar el nivel actual al resultado
    			resultado.Add(nivelActual);
			}
			// Retornar la lista de niveles
			return resultado;
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
            //creo la lista de resultados donde se guardaran los elementos encontrados
			List<ItemCat> resultado = new List<ItemCat>();
            // llamo al metodo auxiliar
            BuscarRecursivo(arbol, elementoABuscar, resultado);
            // devuelvo la lista de resultados
            return resultado;
		}

        // Método auxiliar para realizar la búsqueda recursiva
        private void BuscarRecursivo(ArbolGeneral<ItemCat> arbol, string elementoB, List<ItemCat> resultado)
        {
            // Usamos contains para buscar concidencias parciales
            if (arbol.getDatoRaiz().Nombre.Contains(elementoB))
            {
                // si encuenta una coincidencia, agrega el elemento al resultado
                resultado.Add(arbol.getDatoRaiz());
            }

            // debemos reccorrer los hijos del nodo actual para continuar la búsqueda
            foreach (var hijo in arbol.getHijos())
            {   
                // Llamada recursiva para buscar en los hijos
                BuscarRecursivo(hijo, elementoB, resultado);
            }
        }
            
    }
}
