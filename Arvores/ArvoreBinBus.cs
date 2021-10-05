using System;
using System.Text;

namespace ArvoresBinBus
{
    class Program
    {
        static void Main(string[] args)
        {
            var arvore = new Arvore();

            #region Adicionar Filhos
            Console.WriteLine("Adicionando nó com valor 6");
            arvore.AdicionarFilho(6);
            Console.WriteLine(arvore.Print());
            Console.WriteLine("\n======================================================\n");
            Console.WriteLine("Adicionando nó com valor 4");
            arvore.AdicionarFilho(4);
            Console.WriteLine(arvore.Print());
            Console.WriteLine("\n======================================================\n");
            Console.WriteLine("Adicionando nó com valor 7");
            arvore.AdicionarFilho(7);
            Console.WriteLine(arvore.Print());
            Console.WriteLine("\n======================================================\n");
            Console.WriteLine("Adicionando nó com valor 2");
            arvore.AdicionarFilho(2);
            Console.WriteLine(arvore.Print());
            Console.WriteLine("\n======================================================\n");
            Console.WriteLine("Adicionando nó com valor 1");
            arvore.AdicionarFilho(1);
            Console.WriteLine(arvore.Print());
            Console.WriteLine("\n======================================================\n");
            Console.WriteLine("Adicionando nó com valor 3");
            arvore.AdicionarFilho(3);
            Console.WriteLine(arvore.Print());
            Console.WriteLine("\n======================================================\n");
            Console.WriteLine("Adicionando nó com valor 5");
            arvore.AdicionarFilho(5);
            Console.WriteLine(arvore.Print());
            Console.WriteLine("\n======================================================\n");
            Console.WriteLine("Adicionando nó com valor 8");
            arvore.AdicionarFilho(8);
            Console.WriteLine(arvore.Print());
            Console.WriteLine("\n======================================================\n");
            Console.WriteLine("Adicionando nó com valor 9");
            arvore.AdicionarFilho(9);
            Console.WriteLine(arvore.Print());
            Console.WriteLine("\n======================================================\n");
            #endregion

            #region Buscar Nós
            Console.WriteLine(arvore.Buscar(7).Imprimir());
            Console.WriteLine("\n======================================================\n");
            Console.WriteLine(arvore.Buscar(9).Imprimir());
            Console.WriteLine("\n======================================================\n");
            Console.WriteLine(arvore.Buscar(4).Imprimir());
            Console.WriteLine("\n======================================================\n");
            #endregion

            #region Remover Nós
            Console.WriteLine("Removendo nó com valor 7");
            arvore.Remover(7);
            Console.WriteLine(arvore.Print());
            Console.WriteLine("\n======================================================\n");
            Console.WriteLine("Removendo nó com valor 9");
            arvore.Remover(9);
            Console.WriteLine(arvore.Print());
            Console.WriteLine("\n======================================================\n");
            Console.WriteLine("Removendo nó com valor 4");
            arvore.Remover(4);
            Console.WriteLine(arvore.Print());
            Console.WriteLine("\n======================================================\n");
            #endregion

            #region Imprimir Árvore Invertida
            Console.WriteLine("Imprimindo a árvore invertida");
            Console.WriteLine(arvore.PrintInvertido());
            Console.WriteLine("\n======================================================\n");
            #endregion
        }
    }

    public class No
    {
        public int Valor { get; set; }

        public No Pai { get; set; }

        public No Esquerda { get; set; }

        public No Direita { get; set; }

        public No(int valor)
        {
            Valor = valor;
        }

        public bool ERaiz
        {
            get
            {
                return Pai == null;
            }
        }

        public bool EFolha
        {
            get
            {
                var EFolha = Esquerda == null && Direita == null;
                return EFolha;
            }
        }

        public int Grau
        {
            get
            {
                var grau = 0;
                if (Direita != null) grau++;
                if (Esquerda != null) grau++;
                return grau;
            }
        }

        public int Altura
        {
            get
            {
                if (EFolha) return 0;

                var altura = 0;
                if (Direita != null)
                {
                    if (Direita.Altura >= altura) altura = Direita.Altura + 1;
                }
                if (Esquerda != null)
                {
                    if (Esquerda.Altura >= altura) altura = Esquerda.Altura + 1;
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

        public int QuantidadeNos
        {
            get
            {
                if (EFolha) return 1;
                if (Grau == 1)
                {
                    if (Esquerda != null) return Esquerda.QuantidadeNos + 1;
                    if (Direita != null) return Direita.QuantidadeNos + 1;
                }
                return Esquerda.QuantidadeNos + Direita.QuantidadeNos + 1;
            }
        }

        public string Imprimir()
        {
            var pai = "null";
            var esquerda = "null";
            var direita = "null";

            if (Pai != null) pai = Pai.Valor.ToString();
            if (Esquerda != null) esquerda = Esquerda.Valor.ToString();
            if (Direita != null) direita = Direita.Valor.ToString();

            return $"Aqui está o que encontrei do nó com elemento {this.Valor}:\n" +
                   $"   - É raiz: {ERaiz}\n" +
                   $"   - É folha: {EFolha}\n" +
                   $"   - Grau: {Grau}\n" +
                   $"   - Altura: {Altura}\n" +
                   $"   - Profundidade: {Profundidade}\n" +
                   $"   - Nível: {Nivel}\n" +
                   $"   - Pai: {pai}\n" +
                   $"   - Filho Esquerdo: {esquerda}\n" +
                   $"   - Filho Direito: {direita}\n" +
                   $"   - Quantidade de nós da subárvore: {QuantidadeNos}";
        }
    }

    public class Arvore
    {
        public No Raiz { get; set; }

        public Arvore()
        {
            Raiz = null;
        }

        public bool AdicionarFilho(int valor)
        {
            No novo = new No(valor);
            No atual = Raiz;

            if (atual == null)
            {
                Raiz = novo;
                return true;
            }

            while(atual != null)
            {
                novo.Pai = atual;
                if (valor < atual.Valor)
                    atual = atual.Esquerda;
                else if (valor > atual.Valor)
                    atual = atual.Direita;
                else
                    return false;
            }

            if (valor < novo.Pai.Valor)
                novo.Pai.Esquerda = novo;
            else
                novo.Pai.Direita = novo;

            return true;
        }

        public No Buscar(int valor)
        {
            return Buscar(valor, Raiz);
        }

        private No Buscar(int valor, No pai)
        {
            if (pai != null)
            {
                if (valor == pai.Valor) return pai;
                if (valor < pai.Valor)
                    return Buscar(valor, pai.Esquerda);
                else
                    return Buscar(valor, pai.Direita);
            }

            return null;
        }

        public bool Remover(int valor)
        {
            No remover = Buscar(valor);
            return Remover(Raiz, remover);
        }

        private bool Remover(No atual, No remover)
        {
            No pai = remover.Pai;

            if (remover.EFolha)
            {
                if (remover == Raiz) 
                { 
                    Raiz = null;
                    return true;
                }

                remover.Pai = null;
                if(remover == pai.Esquerda) pai.Esquerda = null;
                else if (remover == pai.Direita) pai.Direita = null;

                return true;
            }

            else if(remover.Grau == 1)
            {
                No noFilho = null;
                if (remover.Direita != null)
                {
                    noFilho = remover.Direita;
                    remover.Direita = null;
                }
                else if (remover.Esquerda != null)
                {
                    noFilho = remover.Esquerda;
                    remover.Esquerda = null;
                }

                if (remover == Raiz)
                {
                    noFilho.Pai = null;
                    Raiz = noFilho;
                    return true;
                }
                else
                {
                    noFilho.Pai = pai;
                    remover.Pai = null;

                    if (remover == pai.Esquerda)
                    {
                        pai.Esquerda = noFilho;
                    }
                    else if (remover == pai.Direita)
                    {
                        pai.Direita = noFilho;
                    }
                }
            }

            else if(remover.Grau == 2)
            {
                No noFilhoEsquerda = remover.Esquerda;
                No noFilhoDireita = remover.Direita;

                remover.Esquerda = null;
                remover.Direita = null;
                remover.Pai = null;

                No maior = noFilhoEsquerda;

                while (maior.Direita != null)
                {
                    maior = maior.Direita;
                }

                No substituto = new No(maior.Valor);

                substituto.Esquerda = noFilhoEsquerda;
                substituto.Direita = noFilhoDireita;
                noFilhoEsquerda.Pai = substituto;
                noFilhoDireita.Pai = substituto;

                if (pai != null)
                {
                    substituto.Pai = pai;
                    if (remover == pai.Esquerda) pai.Esquerda = substituto;
                    else if (remover == pai.Direita) pai.Direita = substituto;
                }

                Remover(Raiz, maior);

                return true;
            }

            return false;
        }

        public string Print()
        {
            var builder = new StringBuilder();
            Print(Raiz, 4, builder);
            builder.Append(Caminhos(Raiz));
            return builder.ToString();
        }

        private void Print(No no, int padding, StringBuilder builder)
        {
            if (no != null)
            {
                if (no.Direita != null)
                {
                    Print(no.Direita, padding + 4, builder);
                }
                if (padding > 0)
                {
                    builder.Append(" ".PadLeft(padding));
                }
                if (no.Direita != null)
                {
                    builder.Append("/\n");
                    builder.Append(" ".PadLeft(padding));
                }
                builder.Append(no.Valor.ToString() + "\n ");
                if (no.Esquerda != null)
                {
                    builder.Append(" ".PadLeft(padding) + "\\\n");
                    Print(no.Esquerda, padding + 4, builder);
                }
            }
        }

        public string PrintInvertido()
        {
            var builder = new StringBuilder();
            PrintInvertido(Raiz, 4, builder);
            builder.Append(Caminhos(Raiz));
            return builder.ToString();
        }

        private void PrintInvertido(No no, int padding, StringBuilder builder)
        {
            if (no != null)
            {
                if (no.Esquerda != null)
                {
                    PrintInvertido(no.Esquerda, padding + 4, builder);
                }
                if (padding > 0)
                {
                    builder.Append(" ".PadLeft(padding));
                }
                if (no.Esquerda != null)
                {
                    builder.Append("/\n");
                    builder.Append(" ".PadLeft(padding));
                }
                builder.Append(no.Valor.ToString() + "\n ");
                if (no.Direita != null)
                {
                    builder.Append(" ".PadLeft(padding) + "\\\n");
                    PrintInvertido(no.Direita, padding + 4, builder);
                }
            }
        }

        public string Caminhos(No no)
        {
            var builder = new StringBuilder();

            builder.Append("\nPré Ordem: ");
            PreOrdem(no, builder);
            builder.Append("\nIn Ordem: ");
            InOrdem(no, builder);
            builder.Append("\nPós Ordem: ");
            PosOrdem(no, builder);

            return builder.ToString();
        }

        public void PreOrdem(No pai, StringBuilder builder)
        {
            if (pai == null) return;

            builder.Append($"{pai.Valor} ");
            PreOrdem(pai.Esquerda, builder);
            PreOrdem(pai.Direita, builder);
        }

        public void InOrdem(No pai, StringBuilder builder)
        {
            if (pai == null) return;

            InOrdem(pai.Esquerda, builder);
            builder.Append($"{pai.Valor} ");
            InOrdem(pai.Direita, builder);
        }

        public void PosOrdem(No pai, StringBuilder builder)
        {
            if (pai == null) return;

            PosOrdem(pai.Esquerda, builder);           
            PosOrdem(pai.Direita, builder);
            builder.Append($"{pai.Valor} ");
        }       
    }
}
