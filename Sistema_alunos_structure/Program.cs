using System;
using System.Collections.Generic;

struct Aluno
{
	public string Nome;
	public int Idade;
	public float Nota;
}

class Program
{
	static List<Aluno> listaAlunos = new List<Aluno>();

	static void AdicionarAluno()
	{
		Aluno novoAluno;
		Console.Write("Nome: ");
		novoAluno.Nome = Console.ReadLine();

		Console.Write("Idade: ");
		while (!int.TryParse(Console.ReadLine(), out novoAluno.Idade))
		{
			Console.Write("Idade inválida. Digite novamente: ");
		}

		Console.Write("Nota: ");
		while (!float.TryParse(Console.ReadLine(), out novoAluno.Nota))
		{
			Console.Write("Nota inválida. Digite novamente: ");
		}

		listaAlunos.Add(novoAluno);
		Console.WriteLine("Aluno adicionado com sucesso!\n");
	}

	static void ListarAlunos()
	{
		if (listaAlunos.Count == 0)
		{
			Console.WriteLine("Nenhum aluno cadastrado.\n");
			return;
		}

		Console.WriteLine("Lista de Alunos:");
		foreach (var aluno in listaAlunos)
		{
			Console.WriteLine($"Nome: {aluno.Nome}, Idade: {aluno.Idade}, Nota: {aluno.Nota:F2}");
		}
		Console.WriteLine();
	}

	static void Main()
	{
		while (true)
		{
			Console.WriteLine("1 - Adicionar Aluno");
			Console.WriteLine("2 - Listar Alunos");
			Console.WriteLine("3 - Sair");
			Console.Write("Escolha uma opção: ");

			string opcao = Console.ReadLine();
			Console.WriteLine();

			switch (opcao)
			{
				case "1":
					AdicionarAluno();
					break;
				case "2":
					ListarAlunos();
					break;
				case "3":
					return;
				default:
					Console.WriteLine("Opção inválida. Tente novamente.\n");
					break;
			}
		}
	}
}
