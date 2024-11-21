
using System;
using System.Collections.Generic;
using tp1;

namespace tpfinal
{

    public class Estrategia
    {
    	
        public String Consulta1(List<Proceso> datos)
        {
        	int cantHojas = 0;
        	int totalNodos = datos.Count;
        	int mitadNodos = datos.Count/2;
         		
        	cantHojas = totalNodos - mitadNodos;
        	
        	string result = ("La cantidad de hojas es: "+cantHojas);
            return result;
        }



        public String Consulta2(List<Proceso> datos)
        {
        	double altura = 0;
        	int n = datos.Count;
        	if (n == 0) {
        		string alt =("La altura del arbol es: " + (altura - 1));
        		return alt;
        	}
        	else
        		altura = Math.Log(n,2);
        	
        	return ("La altura del arbol es: " + Convert.ToInt32(altura));
        }


        public String Consulta3(List<Proceso> datos)
        {
        	int posicion = 1;
        	int nivel = 0;
        	string resultado = " ";
        	
        	Cola<Proceso> c = new Cola<Proceso>();
        	Cola<int> n = new Cola<int>();
        	
        	c.encolar(datos[posicion]);
        	n.encolar(nivel);
        	while (!c.esVacia()) {
        		Proceso p = c.desencolar();
        		int ni = n.desencolar();
        		resultado += "elemento: "+ p.nombre+ " "  +"nivel: " + ni + " ";
        		
        		int hijoIz = 2*posicion;
        		if (hijoIz <= datos.Count && datos[hijoIz] != null) {
        			c.encolar(datos[hijoIz]);
        			n.encolar(nivel+1);
        		}
        		
        		int hijoDer = 2*posicion + 1;
        		if (hijoDer <= datos.Count-1 && datos[hijoDer] != null) {
        			c.encolar(datos[hijoDer]);
        			n.encolar(nivel+1);
        		}
        		nivel++;
        		posicion++;
        	}
        	return resultado;
        }


        public void ShortesJobFirst(List<Proceso> datos, List<Proceso> collected)
        {
        	int posicion = datos.Count-1;
        	
        	foreach (var elem in datos) {
        		collected.Add(elem);
        	}
        	
        	while (posicion > 0) {
        		int posPadre = posicion/2;
        		if (!comparar(collected[posPadre].tiempo, collected[posicion].tiempo)) { break; }
        		
        		if (comparar(collected[posPadre].tiempo, collected[posicion].tiempo)){
        		    	Swap(collected, posPadre, posicion);
        		}
        		
        		posicion--;
        	}
        }


        public void PreemptivePriority(List<Proceso> datos, List<Proceso> collected)
        {
        	int pos = datos.Count-1;
        	
        	foreach (var elem in datos) {
        		collected.Add(elem);
        	}
        	
        	while (pos > 0) { 
        		int posPadre = pos/2;
        		
        		if(comparar(collected[posPadre].prioridad, collected[pos].prioridad)) {	break; }
        		
        		if (!comparar(collected[posPadre].prioridad, collected[pos].prioridad)) {
        			Swap(collected, posPadre, pos);
        		}
        		
        		pos--;
        	}
        }
		
        public bool comparar(int a, int b)
        {	return a > b;  }

        public void Swap(List<Proceso> datos, int a, int b)
        { 
        	Proceso swap = datos[a];
        	datos[a] = datos[b];
        	datos[b] = swap;
        }
    }
}