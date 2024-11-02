using System;
using System.Diagnostics;

namespace Recursividad
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int resultado = Factorial(1000);
            //Console.WriteLine($"Resultado {resultado}");

            int resultadoConFor = FactorialConFor(1000);
            //Console.WriteLine($"Resultado con For {resultadoConFor}");


            //Console.WriteLine(SumarArreglo([1, 2, 3, 4, 5, 6, 7], 7));



            // Fibunacci
            //int n = 10; 

            //Console.WriteLine("Secuencia de Fibonacci:");
            //ContarFibonacci(n, 0); 
            //Console.WriteLine("Ingrese el número de línea para obtener su suma:");
            //int linea = int.Parse(Console.ReadLine());
            //Console.WriteLine($"La suma de la línea {linea} es: {Fibonacci(linea - 1)}");
            



            // rutas y carpetas
            var rutaInicial = Path.Combine("C:", "Carpetas");
            var extension = ".txt";


            // ciclo for
            Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //ExplorarCarpetasIterativo(rutaInicial);
            //stopwatch.Stop();
            //Console.WriteLine($"Tiempo solución iterativa: {stopwatch.ElapsedMilliseconds} ms");


            //recursivo
            //stopwatch.Reset();
            //stopwatch.Start();
            //ExplorarCarpetasRecursivo(rutaInicial);
            //stopwatch.Stop();
            //Console.WriteLine($"Tiempo solución recursiva: {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Reset();
            stopwatch.Start();
            BuscarArchivosPorExtension(rutaInicial, extension);
            stopwatch.Stop();
        }


        static void BuscarArchivosPorExtension(string ruta, string extension)
        {
            if (!Directory.Exists(ruta))
            {
                Console.WriteLine("El directorio no existe.");
                return;
            }

            string[] archivos = Directory.GetFiles(ruta);
            foreach (string archivo in archivos)
            {
                if (Path.GetExtension(archivo).Equals(extension, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Archivo: {archivo}");
                }
            }

            string[] subdirectorios = Directory.GetDirectories(ruta);
            foreach (string subdirectorio in subdirectorios)
            {
                Console.WriteLine($"Explorando subdirectorio: {subdirectorio}");
                BuscarArchivosPorExtension(subdirectorio, extension);
            }
        }


        static void ExplorarCarpetasRecursivo(string ruta)
        {
            try
            {
                string[] archivos = Directory.GetFiles(ruta);
                ProcesarRecursivamente(archivos);

                string[] carpetas = Directory.GetDirectories(ruta);
                ProcesarRecursivamente(carpetas);

            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Acceso denegado a la carpeta : {ruta}");
            }
        }

        static void ProcesarRecursivamente(string[] elementos)
        {
            if (elementos.Length == 0)
                return;

            string elementoActual = elementos[0];
            string[] elementosRestantes = new string[elementos.Length - 1];

            Array.Copy(elementos, 1, elementosRestantes, 0, elementosRestantes.Length);

            if (File.Exists(elementoActual))
            {
                Console.WriteLine($"Archivo: {elementoActual}");
            }
            else if (Directory.Exists(elementoActual))
            {
                Console.WriteLine($"Carpeta: {elementoActual}");
                ExplorarCarpetasRecursivo(elementoActual);
            }

            ProcesarRecursivamente(elementosRestantes);
        }



        static void ExplorarCarpetasIterativo(string ruta)
        {
            try
            {
                string[] archivos = Directory.GetFiles(ruta);
                for (int i = 0; i < archivos.Length; i++)
                {
                    Console.WriteLine($"Archivo: {archivos[i]}");
                }

                string[] carpetas = Directory.GetDirectories(ruta);
                for (int i = 0; i < carpetas.Length; i++)
                {
                    Console.WriteLine($"Archivo: {carpetas[i]}");
                    ExplorarCarpetasIterativo(carpetas[i]);
                }

            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Acceso denegado a la carpeta : {ruta}");
            }
        }




        static void ContarFibonacci(int total, int actual)
        {
            if (actual >= total) return;

            Console.WriteLine($"Línea {actual + 1}: {Fibonacci(actual)}");
            ContarFibonacci(total, actual + 1);
        }

        
        static int Fibonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }


        static int SumarArreglo(int[] arreglo, int logitudArreglo)
        {
            //Caso base
            if (logitudArreglo <= 0) return 0;
            //Llamada recursiva
            return arreglo[logitudArreglo - 1] + SumarArreglo(arreglo, logitudArreglo - 1);
        }

        static int Factorial(int numero)
        {
            if (numero == 0)
                return 1;

            return numero * Factorial(numero - 1);
        }
        static int FactorialConFor(int numero)
        {
            int resultado = 1;

            for (int i = 1; i <= numero; i++)
                resultado = resultado * i;

            return resultado;
        }


    }
}