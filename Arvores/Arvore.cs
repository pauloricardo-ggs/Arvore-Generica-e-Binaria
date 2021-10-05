using System;
using System.Collections.Generic;

namespace Arvores
{
    class Program
    {
        static void Main(string[] args)
        {
            var HyperX = new Arvore<string>("Hyperx");

            var Teclados = new Arvore<string>("Teclados");
            var Mouses = new Arvore<string>("Mouses");
            var Headsets = new Arvore<string>("Headsets");

            var Mars = new Arvore<string>("Mars");
            var AloyRGB = new Arvore<string>("AloyRGB");

            var Pulsefire = new Arvore<string>("Pulsefire");
            var PulsefireSurge = new Arvore<string>("PulsefireSurge");
            var PulsefirePro = new Arvore<string>("PulsefirePro");

            var CloudStinger = new Arvore<string>("CloudStinger");
            var CloudFlight = new Arvore<string>("CloudFlight");
            var CloudRevolver = new Arvore<string>("CloudRevolver");

            HyperX.AdicionarSubarvore(Teclados);
            HyperX.AdicionarSubarvore(Mouses);
            HyperX.AdicionarSubarvore(Headsets);

            Teclados.AdicionarSubarvore(Mars);
            Teclados.AdicionarSubarvore(AloyRGB);

            Mouses.AdicionarSubarvore(Pulsefire);
            Mouses.AdicionarSubarvore(PulsefireSurge);
            Mouses.AdicionarSubarvore(PulsefirePro);

            Headsets.AdicionarSubarvore(CloudStinger);
            Headsets.AdicionarSubarvore(CloudFlight);
            Headsets.AdicionarSubarvore(CloudRevolver);

            ImprimirSubarvores(HyperX);
            Console.WriteLine();
            ImprimirSubarvores(Teclados);
            Console.WriteLine();
            ImprimirSubarvores(Mouses);

            static void ImprimirSubarvores(Arvore<string> arvore)
            {
                Console.Write(arvore.Elemento);
                if (!arvore.EFolha)
                {
                    Console.Write("(");
                    var contador = 0;
                    foreach (var subarvore in arvore.Subarvores)
                    {
                        contador++;
                        ImprimirSubarvores(subarvore);
                        if (contador < arvore.Subarvores.Count)
                        {
                            Console.Write(", ");
                        }
                    }
                    Console.Write(")");
                }
            }

            Console.ReadLine();
        }
    }

    public class Arvore<T>
    {
        public T Elemento { get; set; }

        public Arvore<T> Pai { get; set; }

        public List<Arvore<T>> Subarvores { get; set; }

        public bool ERaiz 
        {
            get { return Pai == null; } 
        }

        public bool EFolha 
        {
            get { return Subarvores.Count == 0; } 
        }

        public int Grau
        {
            get { return Subarvores.Count; }
        }

        public int Altura
        {
            get
            {
                if (EFolha) return 0;

                var altura = 0;
                foreach (var subarvore in Subarvores) 
                {
                    if (subarvore.Altura >= altura)
                    {
                        altura++;
                    }
                }
                return altura;
            }
        }

        public int Profundidade
        {
            get 
            {
                if (ERaiz) return 0;
                return Pai.Nivel + 1;
            }
        }

        public int Nivel
        {
            get 
            {
                if (ERaiz) return 0;
                return Pai.Nivel + 1;
            }
        }

        public Arvore(T elemento)
        {
            Elemento = elemento;
            Subarvores = new List<Arvore<T>>();
        }

        public void AdicionarSubarvore(Arvore<T> subarvore)
        {
            subarvore.Pai = this;
            Subarvores.Add(subarvore);
        }
    }
}
