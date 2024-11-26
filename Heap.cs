using System;
using System.Collections;
using System.Collections.Generic;

namespace tpfinal
{
	public class Heap
	{
		private List<Proceso> c;
		
		public Heap(){ c = new List<Proceso>(); }
		
		public void agregarElemento(Proceso elem, bool h)
		{	
			c.Add(elem);
			int posPadre = (c.Count-1)/2;
			
			if (h == true) {
				while (posPadre >= 0) {
				
					int posHijoIzq = posPadre*2+1;
					int posHijoDer = posPadre*2+2;
		
					if (posHijoIzq < c.Count && !comparar(c[posPadre].tiempo, c[posHijoIzq].tiempo)){
						Swap(posPadre, posHijoIzq);
					}
					
					if (posHijoDer < c.Count && !comparar(c[posPadre].tiempo, c[posHijoDer].tiempo)) {
						Swap(posPadre, posHijoDer);
					}
				
					posPadre--;
				}
			}
			else
				while (posPadre >= 0) {
				
				int posHijoIzq = posPadre*2+1;
				int posHijoDer = posPadre*2+2;
		
				if (posHijoIzq < c.Count && comparar(c[posPadre].prioridad, c[posHijoIzq].prioridad)){
					Swap(posPadre, posHijoIzq);
				}
					
				if (posHijoDer < c.Count && comparar(c[posPadre].prioridad, c[posHijoDer].prioridad)) {
					Swap(posPadre, posHijoDer);
				}
				
				posPadre--;
			}
		}
		
		public bool comparar(int a, int b)
		{	return a < b;  }

        public void Swap(int a, int b)
        { 
        	Proceso swap = c[a];
        	c[a] = c[b];
        	c[b] = swap;
        }
        
        public void copiarLista(List<Proceso> l)
        {
			foreach (var elem in c) {
        		l.Add(elem);
			}	
        }
	}
}
