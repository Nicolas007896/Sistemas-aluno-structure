using System;
using System.Collections.Generic;
using System.IO.Pipes;

struct Livro
{
	public string Titulo;
	public string Autor;
	public int AnoPublicacao;
}
class program
{
	static List<Livro> biblioteca = new List<Livro>();

	static void Adicionarlivro()
	{
		Livro novoLivro;
		Console.Write("Titulo: ");
		novoLivro.Titulo = Console.ReadLine();
		Console.WriteLine("Auto: ");
		novoLivro.Autor = Console.ReadLine();
		Console.Write("Ano de publicação: ");
		novoLivro.AnoPublicacao = int.Parse(Console.ReadLine());

		biblioteca.Add(novoLivro);
		Console.WriteLine("Livro adicionado com sucesso!");
	}

	static void ListarLivros()
	{
		Console.WriteLine("Lista de Livros: " );
		for (int i = 0; i < biblioteca.Count; i++)
		{
			Console.WriteLine($"{i + 1}. Titulo: {biblioteca[i].Titulo}, Autor: {biblioteca[i].Autor}, Ano de publicação: {biblioteca[i].AnoPublicacao}");
		}
		Console.WriteLine();
	}

	static void BuscarLivro()
	{
		Console.Write("Digite o titulo do livro para buscar: ");
		string busca = Console.ReadLine();

		foreach (var livro in biblioteca)
		{
			if (livro.Titulo.ToLower().Contains(busca.ToLower()))
			{
				Console.WriteLine($"Titulo: {livro.Titulo}, Autor: {livro.Autor}, Ano: {livro.AnoPublicacao}");
				return;
			}
		}
		Console.WriteLine("Livro não encontrado.");
	}

	static void EditarLivro()
	{
		Console.WriteLine("Digite o titulo do livro que deseja editar: ");
		string busca = Console.ReadLine();

		for (int i = 0; i < biblioteca.Count; i++ )
		{
			if (biblioteca[i].Titulo.ToLower().Contains(busca.ToLower()))
			{
				Console.WriteLine($"Editando: {biblioteca[i].Titulo}, Autor: {biblioteca[i].Autor}, Ano: {biblioteca[i].AnoPublicacao} ");

				Console.Write("Novo titulo (ou pressione enter para manter o mesmo): ");
				string novoTitulo = Console.ReadLine();
				if (!string.IsNullOrWhiteSpace(novoTitulo))
				{
					biblioteca[i] = new Livro { Titulo = novoTitulo, Autor = biblioteca[i].Autor, AnoPublicacao = biblioteca[i].AnoPublicacao };
				}

				Console.Write("Novo Autor (ou pressione enter para manter o mesmo: ");
				string novoAutor = Console.ReadLine();
				if (!string.IsNullOrWhiteSpace(novoAutor))
				{
					biblioteca[i] = new Livro { Titulo = biblioteca[i].Titulo, Autor = novoAutor, AnoPublicacao = biblioteca[i].AnoPublicacao };
				}

				Console.Write("Novo Ano de publicação (ou pressione enter para manter o mesmo: ");
				string novoAno = Console.ReadLine(); 
				if (!string.IsNullOrWhiteSpace(novoAno) && int.TryParse(novoAno, out int AnoPublicacao))
				{
					biblioteca[i] = new Livro { Titulo = biblioteca[i].Titulo, Autor = biblioteca[i].Autor, AnoPublicacao = AnoPublicacao};
				}

				Console.WriteLine("Livro atualizaado com sucesso!");
				return;

			}
		}
		Console.WriteLine("Livro não encontrado para edição.");
	}

	static void Main()
	{
		int opcao;
		do
		{
			Console.WriteLine("1 - Adicionar Livro");
			Console.WriteLine("2 - Listar Livros");
			Console.WriteLine("3 - Buscar Livros");
			Console.WriteLine("4 - Editar Livro");
			Console.WriteLine("5 - Sair");
			Console.Write("Escolha uma opção: ");
			opcao = int.Parse(Console.ReadLine());

			switch (opcao)
			{
				case 1: Adicionarlivro(); break;
				case 2: ListarLivros(); break;
				case 3: BuscarLivro(); break;
				case 4: EditarLivro(); break;
				case 5: Console.WriteLine("Encerrando... ."); break;
				default: Console.WriteLine("Opção invalida: "); break;

			}

		} while (opcao != 5);
	}
}