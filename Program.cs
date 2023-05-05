using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace Arboles_Clase
{
    class Node
    {
        public int Dato { get; set; }
        public Node Izquierda { get; set; }
        public Node Derecha { get; set; }
        public Node Padre { get; set; }
    }
    class Tree
    {
        public Node Raiz { get; set; }

        public Tree()
        {
            this.Raiz = null;
        }

        public void Insertar(Node nodo, Node nuevo)
        {
            if (nuevo.Dato < nodo.Dato)
                if (nodo.Izquierda == null)
                {
                    nodo.Izquierda = nuevo;
                }
                else
                    Insertar(nodo.Izquierda, nuevo);
            else
                if (nuevo.Dato > nodo.Dato)
                if (nodo.Derecha == null)
                    nodo.Derecha = nuevo;
                else
                    Insertar(nodo.Derecha, nuevo);
            else
                Console.WriteLine("El número " + nuevo.Dato + " ya se encuentra ingresado.");
        }
        private void MenorValor(Node nodo)
        {
            Node iterador=nodo;
            while (iterador.Izquierda != null)
            {
                if (iterador.Dato < nodo.Dato)
                {
                    MenorValor(iterador);
                }
            }

            Console.WriteLine(iterador.Dato);
        }
        public void MenorValor(int nivel)
        {
            MenorValor(Raiz);
        }
        private void buscar(Node raiz, int valor)
        {
            if (raiz == null)
            {
                Console.WriteLine(raiz.Dato);
            }
            else
            {
                if (valor == raiz.Dato)
                {
                    Console.WriteLine(raiz.Dato);
                }
                else
                {
                    if (valor < raiz.Dato)
                    {
                        Console.WriteLine(raiz.Dato);
                        buscar(raiz.Izquierda, valor);
                    }
                    else
                    {
                        Console.WriteLine(raiz.Dato);
                        buscar(raiz.Derecha, valor);
                    }
                }
            }
        }
        public void buscar(int valor)
        {
            buscar(Raiz, valor);
        }
        private int Longitud(Node raiz, int valor)
        {
            int contador=0;
            if (raiz == null)
            {
                contador = 0;
            }
            else
            {
                if (valor == raiz.Dato)
                {
                    contador = contador++;
                    return contador;
                }
                else
                {
                    if (valor < raiz.Dato)
                    {
                        contador++;
                        buscar(raiz.Izquierda, valor);
                        return contador;
                    }
                    else
                    {
                        contador++;
                        buscar(raiz.Derecha, valor);
                        return contador;
                    }
                }
            }
            return contador;
        }
        public int Longitud(int valor)
        {
            return Longitud(Raiz, valor);
        }

        private void mostrarArbol(Node raiz, int nivel)
        {
            if (raiz != null)
            {
                mostrarArbol(raiz.Derecha, nivel + 1);
                for (int i = 1; i <= nivel; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(raiz.Dato);
                mostrarArbol(raiz.Izquierda, nivel + 1);
            }
        }
        public void mostrarArbol(int nivel)
        {
            mostrarArbol(Raiz, nivel);
        }

        public static Node eliminarNodo(Node arbol, int valor)
        {
            if (arbol == null)
            {
                return arbol;
            }
            else
            {
                if (valor == arbol.Dato)
                {
                    if (arbol.Izquierda != null && arbol.Derecha != null)
                    {
                        arbol = eliminarDosHijos(arbol);
                    }
                    else if (arbol.Izquierda != null || arbol.Derecha != null)
                    {
                        arbol = eliminarUnHijo(arbol);
                    }
                    else
                    {
                        arbol = eliminarHoja(arbol);
                    }
                }
                else
                {
                    if (valor < arbol.Dato)
                    {
                        arbol.Izquierda = eliminarNodo(arbol.Izquierda, valor);
                    }
                    else
                    {
                        arbol.Derecha = eliminarNodo(arbol.Derecha, valor);
                    }
                }
                return arbol;
            }
        }
        public static Node Eliminarysumar(Node arbol)
        {
            Node aux = arbol;
            return arbol;
        }
        public static Node eliminarHoja(Node arbol)
        {
            arbol = null;
            return arbol;
        }

        public static Node eliminarUnHijo(Node arbol)
        {
            Node aux = arbol;
            if (arbol.Izquierda != null)
            {
                arbol.Izquierda.Dato = arbol.Dato + arbol.Izquierda.Dato;
                if(arbol.Izquierda.Dato > arbol.Dato)
                {
                    arbol = arbol.Izquierda;
                }
                else
                {
                    arbol = null;
                }
            }
            else
            {
                arbol.Derecha.Dato = arbol.Dato + arbol.Derecha.Dato;
                if (arbol.Derecha.Dato > arbol.Dato)
                {
                    arbol = arbol.Derecha;
                }
                else
                {
                    arbol = null;
                }
            }
            aux = null;
            return arbol;
        }

        public static Node eliminarDosHijos(Node arbol)
        {
            int menor;
            Node nodoMenor = arbol.Derecha;
            while (nodoMenor.Izquierda != null)
            {
                nodoMenor = nodoMenor.Izquierda;
            }
            menor = nodoMenor.Dato;

            arbol = eliminarNodo(arbol, nodoMenor.Dato);
            arbol.Dato = menor;
            return arbol;
        }
        public void eliminarNodo(int valor)
        {
            eliminarNodo(Raiz, valor);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Tree arbol = new Tree();
            Node nuevo;
            int n, valor;

            Console.Write("Ingrese la cantidad de nodos a ingresar: ");
            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write("Ingrese un número: ");
                valor = int.Parse(Console.ReadLine());

                nuevo = new Node();
                nuevo.Dato = valor;

                if (arbol.Raiz != null)
                    arbol.Insertar(arbol.Raiz, nuevo);
                else
                    arbol.Raiz = nuevo;
            }

            Console.WriteLine("Arbol ingresado:");
            arbol.mostrarArbol(0);
            //Console.WriteLine("Indique el valor a buscar: ");
            //int buscar = int.Parse(Console.ReadLine());
            //arbol.buscar(buscar);
            //Console.WriteLine();
            //Console.WriteLine("Ingrese el valor a buscar: ");
            //buscar = int.Parse(Console.ReadLine());
            //Console.WriteLine("El numero de elementos recorridos es de: ");
            //Console.WriteLine(arbol.Longitud(buscar));
            Console.WriteLine("------------------------------------------");
            Console.Write("Ingrese el valor que desea eliminar: ");
            int eliminar = int.Parse(Console.ReadLine());
            arbol.eliminarNodo(eliminar);
            Console.WriteLine("El dato fue eliminado");
            arbol.mostrarArbol(0);
        }
    }
}