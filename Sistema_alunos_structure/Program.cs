using System;
using System.Collections.Generic;

struct Livro
{
    public string Titulo;
    public string Autor;
    public int AnoPublicacao;
}

class Program
{
    static List<Livro> biblioteca = new List<Livro>();

    static void AdicionarLivro()
    {
        Livro novoLivro;
        Console.Write("Titulo: ");
        novoLivro.Titulo = Console.ReadLine();
        Console.Write("Autor: ");
        novoLivro.Autor = Console.ReadLine();
        Console.Write("Ano de publicação: ");
        if (!int.TryParse(Console.ReadLine(), out novoLivro.AnoPublicacao))
        {
            Console.WriteLine("Ano inválido. O livro não foi adicionado.");
            return;
        }

        biblioteca.Add(novoLivro);
        Console.WriteLine("Livro adicionado com sucesso!\n");
    }

    static void ListarLivros()
    {
        Console.WriteLine("\nLista de Livros:");
        for (int i = 0; i < biblioteca.Count; i++)
        {
            Console.WriteLine($"{i + 1} - Titulo: {biblioteca[i].Titulo}, Autor: {biblioteca[i].Autor}, Ano: {biblioteca[i].AnoPublicacao}");
        }
        Console.WriteLine();
    }

    static void BuscarLivro()
    {
        Console.Write("Digite o título do livro para buscar: ");
        string busca = Console.ReadLine().ToLower();

        foreach (var livro in biblioteca)
        {
            if (livro.Titulo.ToLower().Contains(busca))
            {
                Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}, Ano: {livro.AnoPublicacao}");
                return;
            }
        }
        Console.WriteLine("Livro não encontrado. \n");
    }

    static void EditarLivro()
    {
        Console.Write("Digite o título do livro que deseja editar: ");
        string busca = Console.ReadLine().ToLower();

        for (int i = 0; i < biblioteca.Count; i++)
        {
            if (biblioteca[i].Titulo.ToLower().Contains(busca))
            {
                Console.Write("Novo título (ou pressione Enter para manter o mesmo): ");
                string novoTitulo = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoTitulo))
                {
                    biblioteca[i] = new Livro { Titulo = novoTitulo, Autor = biblioteca[i].Autor, AnoPublicacao = biblioteca[i].AnoPublicacao };
                }

                Console.Write("Novo autor (ou pressione Enter para manter o mesmo): ");
                string novoAutor = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoAutor))
                {
                    biblioteca[i] = new Livro { Titulo = biblioteca[i].Titulo, Autor = novoAutor, AnoPublicacao = biblioteca[i].AnoPublicacao };
                }

                Console.Write("Novo ano de publicação (ou pressione Enter para manter o mesmo): ");
                string novoAno = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoAno) && int.TryParse(novoAno, out int anoPublicacao))
                {
                    biblioteca[i] = new Livro { Titulo = biblioteca[i].Titulo, Autor = biblioteca[i].Autor, AnoPublicacao = anoPublicacao };
                }

                Console.WriteLine("Livro editado com sucesso!\n");
                return;
            }
        }
        Console.WriteLine("Livro não encontrado para edição.\n");
    }

    static void Main()
    {
        int opcao;
        do
        {
            Console.WriteLine("1 - Adicionar livro");
            Console.WriteLine("2 - Listar livros");
            Console.WriteLine("3 - Buscar livro");
            Console.WriteLine("4 - Editar livro");
            Console.WriteLine("5 - Sair");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida!");
                continue;
            }

            switch (opcao)
            {
                case 1: AdicionarLivro(); break;
                case 2: ListarLivros(); break;
                case 3: BuscarLivro(); break;
                case 4: EditarLivro(); break;
                case 5: Console.WriteLine("Encerrando..."); break;
                default: Console.WriteLine("Opção inválida!"); break;
            }

        } while (opcao != 5);
    }
}
