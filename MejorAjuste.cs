using System;
using CodeSO;

namespace CodeSO{
    class MejorAjuste : Ajustes{

        //Constructor
        public MejorAjuste(string[] id, int[] tiempoLlegada,int[] ejecucion, int[] peso):base(id, tiempoLlegada, ejecucion,peso){

        }

        //Métodos
        public override void MostrarInformacion(){
            //string[] proceso = base.Id;
            Console.WriteLine($"**********************************\n"+
            $"Información del Mejor Ajuste: ");
            
            Console.Write("Procesos: ");
            for(int i = 0 ; i < 9 ; i++){
                Console.Write(","+base.Id[i]);
            }
            Console.WriteLine();

            Console.Write("Tiempo de Llegada: ");
            for(int i = 0 ; i < 9 ; i++){
                Console.Write(",t"+base.TiempoLlegada[i]);
            }
            Console.WriteLine();

            Console.Write("Duración: ");
            for(int i = 0 ; i < 9 ; i++){
                Console.Write(","+base.Ejecucion[i]);
            }
            Console.WriteLine();
            
            Console.Write("Duración: ");
            for(int i = 0 ; i < 9 ; i++){
                Console.Write(","+base.Peso[i]+"kb");
            }
            Console.WriteLine("\n****************************************************************************");
            
        }

        public void Tabla(){
            int[,] matriz = new int[10, 10];
            
            int[] t1 = base.ObtenerMemoria;
            int[] t2 = base.ObtenerMemoria;
            int[] t3 = base.ObtenerMemoria;
            int[] t4 = base.ObtenerMemoria;
            int[] t5 = base.ObtenerMemoria;
            int[] t6 = base.ObtenerMemoria;
            int[] t7 = base.ObtenerMemoria;
            int[] t8 = base.ObtenerMemoria;
            int[] t9 = base.ObtenerMemoria;

            int[] tiempos = {10,10,10,10,10,10,10,10,10};

            int[] pesos = {base.Peso[0],base.Peso[1],base.Peso[2],base.Peso[3],base.Peso[4],base.Peso[5],base.Peso[6],base.Peso[7],base.Peso[8]};
            
            int[] procesosLlegada = {base.TiempoLlegada[0],base.TiempoLlegada[1],base.TiempoLlegada[2],base.TiempoLlegada[3],base.TiempoLlegada[4],base.TiempoLlegada[5],base.TiempoLlegada[6],base.TiempoLlegada[7],base.TiempoLlegada[8]};

            //----------------------llenar vector de "tn" con 1 dependiendo del peso del proceso-----------------------------------
            //TIEMPO 1 --- PESO 1
            int aux = 0;
            int var = 0;
            //la idea es modificar los vectores t0,t1,...tn haciendo 1 cuando se ocupe esa posición.
            //for(int i = 0 ; i < 1 ; i++){ // la idea es ir avanzando con los procesos....

                var = (base.Peso[0])/10; //guardamos el valor del "base.Peso[i]" en var ya que tiene los valores en unidad.
                
                //identificamos la cantidad de 0 que contiene el vector para así saber si se puede agregar un proceso en este tiempo
                for(int k = 0 ; k < 9 ; k++){
                    if(t1[k] == 0 ){//recorremos el vector t1 para saber cuantos ceros tiene.
                        aux += k; //la variable "aux" se utilizará para guardar la cantidad de ceros que tiene para así saber la cantidad de memoria que tiene disponible.
                    }
                }
                //aquí mostramos los valores del vector dependiendo del valor de var en donde este contiene el peso en unidad.
                Console.Write("Tiempo 1 : ");
                for(int m = 0 ; m < 9 ; m++){
                    if(m < var){  
                        t1[m] = 1;
                    }if(m >= var){
                        t1[m] = 0;
                    }
                    Console.Write(t1[m]);
                }
                Console.WriteLine("\n****************************************************************************");
            //}
            //----------------------------------------------------------------------------------------------------------------------
            // TIEMPO 2 ------ PESO 2
            int aux1 = 0;
            //int uno = 0;
            int var1 = (base.Peso[1])/10; //guardamos el valor del "base.Peso[i]" en var ya que tiene los valores en unidad.
            Console.WriteLine("peso del proceso 2 : "+ var1);
            //identificamos la cantidad de 0 que contiene el vector para así saber si se puede agregar un proceso en este tiempo
            for(int k = 0 ; k < 9 ; k++){
                if(t1[k] == 1 ){//recorremos el vector t1 para saber cuantos ceros tiene.
                    aux1 += 1; //la variable "aux" se utilizará para guardar la cantidad de ceros que tiene para así saber la cantidad de memoria que tiene disponible.
                    Console.Write("aux: "+aux1+", ");
                }if(t1[k] > var && t1[k] == 0){
                    t1[k] = 2;
                }
            }
            Console.WriteLine();
            Console.Write("Tiempo 2 : ");
            //aquí mostramos los valores del vector dependiendo del valor de var en donde este contiene el peso en unidad.
            for(int m = var ; m < 9 ; m++){
                if(m < var1){  
                    t2[m] = 2;
                }
                Console.Write(t2[m]);
            }
            Console.WriteLine("\n****************************************************************************");
            //----------------------------------------------------------------------------------------------------------------------

            //Console.WriteLine();// funciona bien el guardar los pesos en los procesos 
            
            //----------------------LLENAR MATRIZ CON VALORES-----------------------------------------------------------------------
            // Llenar la matriz con valores
            for (int i = 0; i < 10; i++){ //i es la columna (recorre para abajo)

                //TIEMPO 1
                //agregar el vector t1 a la fila 1.
                for (int j = 0; j < 1; j++){ // j es la fila (recorre para la derecha)
                    //matriz[i, j] = 0 ;
                    matriz[i, j] = t1[i] ; // Puedes modificar esta línea para asignar los valores que desees.
                } // en t1[i] irá agregando 
                
                //TIEMPO 2
                //agregar el vector t1 a la fila 1.
                for (int j = 1; j < 2; j++){ // j es la fila (recorre para la derecha)
                    matriz[i, j] = t2[i] ; // Puedes modificar esta línea para asignar los valores que desees.
                } // en t1[i] irá agregando 

                //rellenar de ceros.
                for (int j = 2; j < 10; j++){
                    matriz[i, j] = 0 ; // Puedes modificar esta línea para asignar los valores que desees.
                }
            }
            //----------------------MOSTRAR MATRIZ CON VALORES-----------------------------------------------------------------------

            // Mostrar la matriz en la consola
            for (int i = 0; i < 10; i++){
                for (int j = 0; j < 10; j++){
                    Console.Write(matriz[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("****************************************************************************");
            //----------------------------------------------------------------------------------------------------------------------
        }
    }
}
