using System;
using System.Collections.Generic;

class Program
{
	static void Main()
	{
		List<string> chatHistory = new List<string>();

		while (true)
		{
			Console.Clear();
			DisplayMenu();
			DisplayChat(chatHistory);

			Console.Write("Tu: ");
			string userMessage = Console.ReadLine();

			if (string.IsNullOrEmpty(userMessage))
				break;

			chatHistory.Add($"Tu: {userMessage}");

			string IAResponse = GetAIResponse(userMessage);
			chatHistory.Add($"IA: {IAResponse}");
		}
	}

	static void DisplayMenu()
	{
		Console.Clear();
		{
			Console.WriteLine("		      ___          ___          ___                   ___          ___          ___                             ___     ");
			Console.WriteLine("		     /__/\\        /  /\\        /  /\\      ___        /  /\\        /  /\\        /__/\\                ___        /  /\\    ");
			Console.WriteLine("		     \\  \\:\\      /  /::\\      /  /::\\    /  /\\      /  /::|      /  /::\\       \\  \\:\\              /  /\\      /  /::\\   ");
			Console.WriteLine("		      \\__\\:\\    /  /:/\\:\\    /  /:/\\:\\  /  /:/     /  /:/:|     /  /:/\\:\\       \\  \\:\\            /  /:/     /  /:/\\:\\  ");
			Console.WriteLine("		  ___ /  /::\\  /  /:/  \\:\\  /  /:/~/:/ /__/::\\    /  /:/|:|__  /  /:/  \\:\\  _____\\__\\:\\          /__/::\\    /  /:/~/::\\ ");
			Console.WriteLine("		 /__/\\  /:/\\:\\/__/:/ \\__\\:\\/__/:/ /:/__\\__\\/\\:\\__/__/:/ |:| /\\/__/:/ \\__\\:\\/__/::::::::\\         \\__\\/\\:\\__/__/:/ /:/\\:\\");
			Console.WriteLine("		 \\  \\:\\/:/__\\/\\  \\:\\ /  /:/\\  \\:\\/:::::/  \\  \\:\\/\\__\\/  |:|/:/  \\:\\ /  /:/\\  \\:\\~~\\~~\\/            \\  \\:\\/\\  \\:\\/:/__\\/");
			Console.WriteLine("		  \\  \\::/      \\  \\:\\  /:/  \\  \\::/~~~~    \\__\\::/   |  |:/:/  \\  \\:\\  /:/  \\  \\:\\  ~~~              \\__\\::/\\  \\::/     ");
			Console.WriteLine("		   \\  \\:\\       \\  \\:\\/:/    \\  \\:\\        /__/:/    |  |::/    \\  \\:\\/:/    \\  \\:\\                  /__/:/  \\  \\:\\     ");
			Console.WriteLine("		    \\  \\:\\       \\  \\::/      \\  \\:\\       \\__\\/     |  |:/      \\  \\::/      \\  \\:\\                 \\__\\/    \\  \\:\\    ");
			Console.WriteLine("		     \\__\\/        \\__\\/        \\__\\/                 |__|/        \\__\\/        \\__\\/                           \\__\\/    ");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();



			Console.WriteLine("					═════════════════════════════════════════════════════════════════════════════════════");
			Console.WriteLine("					║ Olá, o meu nome é Horizon, criado pelos alunos de 10º de Informática              ║");
			Console.WriteLine("				   	║ fique à vontade para fazer perguntas sobre conhecimentos gerais!                  ║");
			Console.WriteLine("					═════════════════════════════════════════════════════════════════════════════════════");
			Console.WriteLine();
			Console.WriteLine();



		}
	}

	static void DisplayChat(List<string> chatHistory)
	{
		foreach (var message in chatHistory)
		{
			if (message.StartsWith("Tu:"))
			{
				Console.ForegroundColor = ConsoleColor.Blue;
				DisplayMessageBalloon(message.Substring(4), true);
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
				DisplayMessageBalloon(message.Substring(4), false);
			}
		}
		Console.ResetColor();
	}

	static void DisplayMessageBalloon(string message, bool isUser)
	{
		int padding = 2; 
		int maxWidth = Console.WindowWidth - 10; 

		string[] lines = SplitMessage(message, maxWidth - 2 * padding);

		
		int balloonWidth = 0;
		foreach (var line in lines)
		{
			if (line.Length > balloonWidth)
				balloonWidth = line.Length;
		}


		if (isUser)
		{
			Console.WriteLine($" ╭{new string('─', balloonWidth + 2 * padding)}╮");
			foreach (var line in lines)
			{
				Console.WriteLine($" │ {line.PadRight(balloonWidth)} │");
			}
			Console.WriteLine($" ╰{new string('─', balloonWidth + 2 * padding)}╯");
		}
		else
		{
			int rightPadding = Console.WindowWidth - balloonWidth - 2 * padding - 4;
			Console.WriteLine(new string(' ', rightPadding) + $"╭{new string('─', balloonWidth + 2 * padding)}╮");
			foreach (var line in lines)
			{
				Console.WriteLine(new string(' ', rightPadding) + $"│ {line.PadRight(balloonWidth)} │");
			}
			Console.WriteLine(new string(' ', rightPadding) + $"╰{new string('─', balloonWidth + 2 * padding)}╯");
		}
	}

	static string[] SplitMessage(string message, int maxWidth)
	{
		List<string> lines = new List<string>();
		while (message.Length > maxWidth)
		{
			int spaceIndex = message.LastIndexOf(' ', maxWidth);
			if (spaceIndex == -1) spaceIndex = maxWidth;
			lines.Add(message.Substring(0, spaceIndex).Trim());
			message = message.Substring(spaceIndex).Trim();
		}
		lines.Add(message);
		return lines.ToArray();
	}


	static string GetAIResponse(string userMessage)
	{

				if (userMessage.ToLower().Contains("como você está?"))
					return "Estou funcionando perfeitamente, obrigado por perguntar!";

				if (userMessage.ToLower().Contains("tchau"))
					return "Até logo! Foi um prazer conversar com você.";

				if (userMessage.Equals("Ate já", StringComparison.OrdinalIgnoreCase) ||
					userMessage.Equals("Ate ja", StringComparison.OrdinalIgnoreCase) ||
					userMessage.Equals("Até já", StringComparison.OrdinalIgnoreCase) ||
					userMessage.Equals("Até ja", StringComparison.OrdinalIgnoreCase) ||
					userMessage.Equals("ate já", StringComparison.OrdinalIgnoreCase) ||
					userMessage.Equals("ate ja", StringComparison.OrdinalIgnoreCase) ||
					userMessage.Equals("até já", StringComparison.OrdinalIgnoreCase) ||
					userMessage.Equals("até ja", StringComparison.OrdinalIgnoreCase))
				{
					Console.Clear();
					return "Obrigado pela conversa, até breve!";
				}
				if (userMessage.Equals("Quem são vocês?", StringComparison.OrdinalIgnoreCase) ||
					userMessage.Equals("Quem vocês são?", StringComparison.OrdinalIgnoreCase) ||
				    userMessage.Equals("O que são vocês?", StringComparison.OrdinalIgnoreCase))
				{
					return "Nós somos estudantes de Informática de Gestão, futuros profissionais preparados para integrar a tecnologia e a gestão no mundo dos negócios aprendemos a desenvolver sistemas, gerir bases de dados, otimizar processos empresariais e aplicar soluções tecnológicas o nosso objetivo é utilizar a informática para melhorar a tomada de decisões e facilitar a gestão das organizações.";
				}
		else if (userMessage.Equals("Que tipo de profissionais serão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Que tipo de profissionais vão ser?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Que profissionais serão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Que profissionais vão ser?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Que tipo de profissionais é que serão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Que tipo de profissionais é que vão ser?", StringComparison.OrdinalIgnoreCase))
		{
			return "Seremos profissionais qualificados na área da Informática de Gestão, preparados para desenvolver e gerir sistemas de informação. Teremos competências para otimizar processos empresariais e aplicar soluções tecnológicas.";
		}
		else if (userMessage.Equals("olá", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("olá!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("oi", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("oi!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("ola", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("ola!", StringComparison.OrdinalIgnoreCase))
		{
			return "Olá, tudo bem contigo?";
		}
		else if (userMessage.Equals("tudo e contigo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("tudo e contigo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("tudo bem e contigo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("tudo bem contigo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("e contigo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("e contigo, tudo bem?", StringComparison.OrdinalIgnoreCase))
		{
			return "Também está tudo, obrigado por perguntar!";
		}
		else if (userMessage.Equals("olá, tudo bem contigo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("como estás?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("tudo bem?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("olá, tudo bem?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("estás bem?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("como vai?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("como é que estás?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("está tudo bem contigo?", StringComparison.OrdinalIgnoreCase))
		{
			return "Olá! Estou a funcionar perfeitamente, obrigado por perguntar!";
		}
		else if (userMessage.Equals("qual é o teu nome?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("como é que te chamas?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("qual é o seu nome?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("como te chamas?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o teu nome", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("podes dizer-me o teu nome?", StringComparison.OrdinalIgnoreCase))
		{
			Console.WriteLine("O meu nome é Horizon! E o teu, qual é?");
			string nome = Console.ReadLine();
			return $"Olá, prazer em te conhecer, {nome}!";
		}
		else if (userMessage.Equals("bom dia! como corre a manhã?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("bom dia, como está a manhã?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("bom dia, como vai a manhã?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("bom dia, como está a correr a manhã?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("bom dia, como tem sido a manhã?", StringComparison.OrdinalIgnoreCase))
		{
			return "Bom dia! A minha manhã está a correr muito bem, obrigado por perguntar!";
		}
		else if (userMessage.Equals("qual é o sentido da vida?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("qual é o significado da vida?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("qual é o propósito da vida?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("para que serve a vida?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("qual é o sentido de viver?", StringComparison.OrdinalIgnoreCase))
		{
			return "O sentido da vida é uma questão complexa! Mas alguns dizem que é 42.";
		}
		else if (userMessage.Equals("você gosta de música?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("gostas de música?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("curtes música?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("gosta de música?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("és fã de música?", StringComparison.OrdinalIgnoreCase))
		{
			return "Eu não tenho ouvidos, mas se tivesse, provavelmente adoraria música!";
		}
		else if (userMessage.Equals("qual é a capital da França?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("qual é a capital de França?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me a capital da França", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes qual é a capital da França?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("capital da França?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da França é Paris!";
		}
		else if (userMessage.Equals("me conta uma piada?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("conta uma piada", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz uma piada", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes alguma piada?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("conta-me uma piada", StringComparison.OrdinalIgnoreCase))
		{
			return "Claro! Por que o livro de matemática estava triste? Porque tinha muitos problemas!";
		}
		else if (userMessage.Equals("qual é a sua idade?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("quantos anos tens?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("qual é a tua idade?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("tens quantos anos?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me a tua idade", StringComparison.OrdinalIgnoreCase))
		{
			return "Eu existo apenas no código, então não tenho uma idade real! Mas, se contarmos desde que fui executado, tenho alguns segundos!";
		}
		else if (userMessage.Equals("você pode me ajudar com matemática?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("podes ajudar-me com matemática?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("ajudas com matemática?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("podes ajudar em matemática?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("consegues ajudar com matemática?", StringComparison.OrdinalIgnoreCase))
		{
			return "Claro! Pergunta o que quiseres sobre matemática e eu tentarei ajudar!";
		}
		else if (userMessage.Equals("qual é a velocidade da luz?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes qual é a velocidade da luz?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me a velocidade da luz", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("qual é a velocidade da luz no vácuo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("velocidade da luz?", StringComparison.OrdinalIgnoreCase))
		{
			return "A velocidade da luz no vácuo é aproximadamente 299.792.458 metros por segundo.";
		}
		else if (userMessage.Equals("quem foi Albert Einstein?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("quem era Albert Einstein?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes quem foi Albert Einstein?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("conheces Albert Einstein?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("quem é Albert Einstein?", StringComparison.OrdinalIgnoreCase))
		{
			return "Albert Einstein foi um físico teórico que desenvolveu a teoria da relatividade.";
		}
		else if (userMessage.Equals("qual é o maior planeta do sistema solar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes qual é o maior planeta do sistema solar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o maior planeta do sistema solar", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("qual é o planeta maior do sistema solar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("maior planeta do sistema solar?", StringComparison.OrdinalIgnoreCase))
		{
			return "O maior planeta do sistema solar é Júpiter.";
		}
		else if (userMessage.Equals("como está o clima hoje?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("como está o tempo hoje?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes como está o clima hoje?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("como está o tempo hoje em Portugal?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("clima hoje?", StringComparison.OrdinalIgnoreCase))
		{
			return "Infelizmente, não posso aceder a informações em tempo real, mas podes verificar num site de meteorologia!";
		}
		else if (userMessage.Equals("qual é o animal mais rápido do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes qual é o animal mais rápido do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o animal mais rápido do mundo", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("qual é o animal terrestre mais rápido?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("animal mais rápido do mundo?", StringComparison.OrdinalIgnoreCase))
		{
			return "O animal terrestre mais rápido é o guepardo, que pode atingir até 120 km/h.";
		}
		else if (userMessage.Equals("qual é o metal mais precioso?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes qual é o metal mais precioso?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o metal mais precioso", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("qual é o metal mais valioso?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("metal mais precioso?", StringComparison.OrdinalIgnoreCase))
		{
			return "O ouro e a platina são considerados metais preciosos valiosos.";
		}
		else if (userMessage.Equals("quem foi Leonardo da Vinci?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes quem foi Leonardo da Vinci?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me quem foi Leonardo da Vinci", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("quem era Leonardo da Vinci?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Leonardo da Vinci foi quem?", StringComparison.OrdinalIgnoreCase))
		{
			return "Leonardo da Vinci foi um polímata italiano, conhecido por suas contribuições à arte, ciência e engenharia.";
		}
		else if (userMessage.Equals("qual é o oceano mais profundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes qual é o oceano mais profundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o oceano mais profundo", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("qual é o oceano mais fundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("oceano mais profundo?", StringComparison.OrdinalIgnoreCase))
		{
			return "O oceano mais profundo é o Pacífico, na Fossa das Marianas.";
		}
		else if (userMessage.Equals("qual é a fórmula da água?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes qual é a fórmula da água?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me a fórmula da água", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("qual é a fórmula química da água?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("fórmula da água?", StringComparison.OrdinalIgnoreCase))
		{
			return "A fórmula química da água é H2O.";
		}
		else if (userMessage.Equals("o que é um buraco negro?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes o que é um buraco negro?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o que é um buraco negro", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("o que são buracos negros?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("buraco negro?", StringComparison.OrdinalIgnoreCase))
		{
			return "Um buraco negro é uma região do espaço onde a gravidade é tão intensa que nada pode escapar, nem mesmo a luz.";
		}
		else if (userMessage.Equals("quem escreveu 'Dom Quixote'?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes quem escreveu 'Dom Quixote'?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me quem escreveu 'Dom Quixote'", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("quem foi o autor de 'Dom Quixote'?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("autor de 'Dom Quixote'?", StringComparison.OrdinalIgnoreCase))
		{
			return "'Dom Quixote' foi escrito por Miguel de Cervantes.";
		}
		else if (userMessage.Equals("qual é a distância da Terra ao Sol?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes qual é a distância da Terra ao Sol?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me a distância da Terra ao Sol", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("qual é a distância entre a Terra e o Sol?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("distância da Terra ao Sol?", StringComparison.OrdinalIgnoreCase))
		{
			return "A distância média da Terra ao Sol é aproximadamente 149,6 milhões de quilómetros.";
		}
		else if (userMessage.Equals("quem foi Isaac Newton?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes quem foi Isaac Newton?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me quem foi Isaac Newton", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("quem era Isaac Newton?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Isaac Newton foi quem?", StringComparison.OrdinalIgnoreCase))
		{
			return "Isaac Newton foi um cientista que formulou as leis do movimento e a lei da gravitação universal.";
		}
		else if (userMessage.Equals("quantos ossos tem o corpo humano?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes quantos ossos tem o corpo humano?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me quantos ossos tem o corpo humano", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("quantos ossos temos no corpo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("ossos do corpo humano?", StringComparison.OrdinalIgnoreCase))
		{
			return "O corpo humano adulto tem 206 ossos.";
		}
		else if (userMessage.Equals("qual é o maior mamífero do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes qual é o maior mamífero do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o maior mamífero do mundo", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("qual é o mamífero maior do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("maior mamífero do mundo?", StringComparison.OrdinalIgnoreCase))
		{
			return "A baleia-azul é o maior mamífero do mundo.";
		}
		else if (userMessage.Equals("qual é o elemento mais abundante no universo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes qual é o elemento mais abundante no universo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o elemento mais abundante no universo", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("qual é o elemento mais comum no universo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("elemento mais abundante no universo?", StringComparison.OrdinalIgnoreCase))
		{
			return "O elemento mais abundante no universo é o hidrogénio.";
		}

		else if (userMessage.Equals("quantos planetas existem no sistema solar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("quantos planetas há no sistema solar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("quantos planetas tem o sistema solar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes quantos planetas existem no sistema solar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me quantos planetas existem no sistema solar", StringComparison.OrdinalIgnoreCase))
		{
			return "O sistema solar tem oito planetas.";
		}
		else if (userMessage.Equals("O que é programação?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que significa programação?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que quer dizer programação?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes o que é programação?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o que é programação", StringComparison.OrdinalIgnoreCase))
		{
			return "Programação é o processo de escrever, testar e manter código-fonte de programas de computador.";
		}
		else if (userMessage.Equals("Quais linguagens de programação devo aprender?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Que linguagens de programação devo aprender?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quais são as melhores linguagens de programação para aprender?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes quais linguagens de programação devo aprender?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me quais linguagens de programação devo aprender", StringComparison.OrdinalIgnoreCase))
		{
			return "Depende dos teus objetivos! Algumas populares são Python, Java, C#, JavaScript e C++.";
		}
		else if (userMessage.Equals("O que é um algoritmo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que significa algoritmo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que quer dizer algoritmo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes o que é um algoritmo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o que é um algoritmo", StringComparison.OrdinalIgnoreCase))
		{
			return "Um algoritmo é um conjunto de instruções bem definidas para resolver um problema.";
		}
		else if (userMessage.Equals("O que é inteligência artificial?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que significa inteligência artificial?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que quer dizer inteligência artificial?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes o que é inteligência artificial?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o que é inteligência artificial", StringComparison.OrdinalIgnoreCase))
		{
			return "Inteligência Artificial é um ramo da informática que busca criar sistemas capazes de simular a inteligência humana.";
		}
		else if (userMessage.Equals("O que é um IDE?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que significa IDE?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que quer dizer IDE?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes o que é um IDE?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o que é um IDE", StringComparison.OrdinalIgnoreCase))
		{
			return "IDE significa Integrated Development Environment. É um software que facilita a programação, como Visual Studio e IntelliJ IDEA.";
		}
		else if (userMessage.Equals("O que é um compilador?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que significa compilador?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que quer dizer compilador?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes o que é um compilador?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o que é um compilador", StringComparison.OrdinalIgnoreCase))
		{
			return "Um compilador é um programa que traduz código-fonte para código executável pelo computador.";
		}
		else if (userMessage.Equals("O que são variáveis?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que significa variáveis?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que quer dizer variáveis?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes o que são variáveis?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o que são variáveis", StringComparison.OrdinalIgnoreCase))
		{
			return "Variáveis são espaços na memória do computador usados para armazenar dados temporariamente.";
		}
		else if (userMessage.Equals("O que é um loop?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que significa loop?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que quer dizer loop?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes o que é um loop?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o que é um loop", StringComparison.OrdinalIgnoreCase))
		{
			return "Um loop é uma estrutura de controle que permite repetir uma ação diversas vezes, como while e for.";
		}
		else if (userMessage.Equals("O que é um banco de dados relacional?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que significa banco de dados relacional?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que quer dizer banco de dados relacional?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes o que é um banco de dados relacional?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o que é um banco de dados relacional", StringComparison.OrdinalIgnoreCase))
		{
			return "Um banco de dados relacional organiza dados em tabelas interligadas, usando SQL para manipulação de dados.";
		}
		else if (userMessage.Equals("O que é um servidor web?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que significa servidor web?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que quer dizer servidor web?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes o que é um servidor web?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o que é um servidor web", StringComparison.OrdinalIgnoreCase))
		{
			return "Um servidor web é um software que processa e entrega páginas da web para os usuários.";
		}
		else if (userMessage.Equals("O que é um framework?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que significa framework?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que quer dizer framework?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes o que é um framework?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o que é um framework", StringComparison.OrdinalIgnoreCase))
		{
			return "Um framework é um conjunto de ferramentas e bibliotecas que facilitam o desenvolvimento de software.";
		}
		else if (userMessage.Equals("O que é um sistema embarcado?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que significa sistema embarcado?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que quer dizer sistema embarcado?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes o que é um sistema embarcado?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o que é um sistema embarcado", StringComparison.OrdinalIgnoreCase))
		{
			return "Um sistema embarcado é um sistema computacional integrado a um dispositivo, como microcontroladores em eletrodomésticos.";
		}
		else if (userMessage.Equals("O que é machine learning?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que significa machine learning?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que quer dizer machine learning?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes o que é machine learning?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o que é machine learning", StringComparison.OrdinalIgnoreCase))
		{
			return "Machine Learning é um ramo da IA que permite aos computadores aprender padrões a partir de dados.";
		}
		else if (userMessage.Equals("O que é um endereço IP?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que significa endereço IP?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que quer dizer endereço IP?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes o que é um endereço IP?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o que é um endereço IP", StringComparison.OrdinalIgnoreCase))
		{
			return "Um endereço IP é um identificador numérico que identifica dispositivos em uma rede.";
		}
		else if (userMessage.Equals("O que é um ataque de phishing?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que significa ataque de phishing?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que quer dizer ataque de phishing?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes o que é um ataque de phishing?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o que é um ataque de phishing", StringComparison.OrdinalIgnoreCase))
		{
			return "Phishing é um tipo de golpe online onde hackers tentam enganar usuários para obter informações confidenciais.";
		}
		else if (userMessage.Equals("O que é criptografia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que significa criptografia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que quer dizer criptografia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes o que é criptografia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o que é criptografia", StringComparison.OrdinalIgnoreCase))
		{
			return "Criptografia é uma técnica usada para proteger dados, tornando-os ilegíveis para quem não tem a chave de decodificação.";
		}
		else if (userMessage.Equals("Quem foi Albert Einstein?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem era Albert Einstein?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes quem foi Albert Einstein?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me quem foi Albert Einstein", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("conheces Albert Einstein?", StringComparison.OrdinalIgnoreCase))
		{
			return "Albert Einstein foi um físico teórico que desenvolveu a teoria da relatividade.";
		}
		else if (userMessage.Equals("Qual é o maior oceano do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes qual é o maior oceano do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o maior oceano do mundo", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("qual é o oceano maior do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("maior oceano do mundo?", StringComparison.OrdinalIgnoreCase))
		{
			return "O maior oceano do mundo é o Oceano Pacífico.";
		}
		else if (userMessage.Equals("Qual é o planeta mais próximo do Sol?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes qual é o planeta mais próximo do Sol?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o planeta mais próximo do Sol", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("qual é o planeta mais perto do Sol?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("planeta mais próximo do Sol?", StringComparison.OrdinalIgnoreCase))
		{
			return "O planeta mais próximo do Sol é Mercúrio.";
		}
		else if (userMessage.Equals("Quem pintou a Mona Lisa?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes quem pintou a Mona Lisa?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me quem pintou a Mona Lisa", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("quem foi o autor da Mona Lisa?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("autor da Mona Lisa?", StringComparison.OrdinalIgnoreCase))
		{
			return "A Mona Lisa foi pintada por Leonardo da Vinci.";
		}
		else if (userMessage.Equals("Qual é a capital da Itália?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes qual é a capital da Itália?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me a capital da Itália", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("qual é a capital de Itália?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("capital da Itália?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Itália é Roma.";
		}
		else if (userMessage.Equals("Quem foi Isaac Newton?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes quem foi Isaac Newton?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me quem foi Isaac Newton", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("quem era Isaac Newton?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Isaac Newton foi quem?", StringComparison.OrdinalIgnoreCase))
		{
			return "Isaac Newton foi um cientista que formulou as leis do movimento e a lei da gravitação universal.";
		}
		else if (userMessage.Equals("Qual é o maior deserto do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes qual é o maior deserto do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o maior deserto do mundo", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("qual é o deserto maior do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("maior deserto do mundo?", StringComparison.OrdinalIgnoreCase))
		{
			return "O maior deserto do mundo é a Antártida, seguido pelo Deserto do Saara.";
		}
		else if (userMessage.Equals("Quantos ossos tem o corpo humano?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes quantos ossos tem o corpo humano?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me quantos ossos tem o corpo humano", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("quantos ossos temos no corpo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("ossos do corpo humano?", StringComparison.OrdinalIgnoreCase))
		{
			return "O corpo humano adulto tem 206 ossos.";
		}
		else if (userMessage.Equals("Quem escreveu Dom Quixote?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes quem escreveu Dom Quixote?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me quem escreveu Dom Quixote", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("quem foi o autor de Dom Quixote?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("autor de Dom Quixote?", StringComparison.OrdinalIgnoreCase))
		{
			return "Dom Quixote foi escrito por Miguel de Cervantes.";
		}
		else if (userMessage.Equals("Qual é o maior mamífero do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes qual é o maior mamífero do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me o maior mamífero do mundo", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("qual é o mamífero maior do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("maior mamífero do mundo?", StringComparison.OrdinalIgnoreCase))
		{
			return "O maior mamífero do mundo é a baleia-azul.";
		}
		else if (userMessage.Equals("Qual é a montanha mais alta do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("sabes qual é a montanha mais alta do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("diz-me a montanha mais alta do mundo", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("qual é a montanha mais alta?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("montanha mais alta do mundo?", StringComparison.OrdinalIgnoreCase))
		{
			return "O Monte Everest é a montanha mais alta do mundo, com aproximadamente 8.848 metros de altura.";
		}
		else if (userMessage.Equals("Qual é o rio mais longo do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual o rio mais longo do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me o rio mais longo do mundo.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é o rio mais longo do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é o rio mais longo do mundo?", StringComparison.OrdinalIgnoreCase))
		{
			return "O rio mais longo do mundo é o Rio Nilo, seguido pelo Rio Amazonas.";
		}
		else if (userMessage.Equals("Qual é a capital do Japão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Japão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Japão.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Japão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Japão?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Japão é Tóquio.";
		}
		else if (userMessage.Equals("Quem descobriu o Brasil?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é que descobriu o Brasil?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem descobriu o Brasil.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem descobriu o Brasil?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem descobriu o Brasil?", StringComparison.OrdinalIgnoreCase))
		{
			return "O Brasil foi descoberto pelos portugueses em 1500, liderados por Pedro Álvares Cabral.";
		}
		else if (userMessage.Equals("O que é informática?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("O que significa informática?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me o que é informática.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que é informática?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes explicar o que é informática?", StringComparison.OrdinalIgnoreCase))
		{
			return "Informática é a ciência que estuda o processamento de dados e a tecnologia da informação.";
		}
		else if (userMessage.Equals("Quem foi Nikola Tesla?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Nikola Tesla?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Nikola Tesla.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Nikola Tesla?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Nikola Tesla?", StringComparison.OrdinalIgnoreCase))
		{
			return "Nikola Tesla foi um inventor e engenheiro elétrico, conhecido por suas contribuições à corrente alternada.";
		}
		else if (userMessage.Equals("Qual é o menor país do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual o menor país do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me o menor país do mundo.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é o menor país do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é o menor país do mundo?", StringComparison.OrdinalIgnoreCase))
		{
			return "O menor país do mundo é o Vaticano, com aproximadamente 0,49 km².";
		}
		else if (userMessage.Equals("Quantos planetas existem no sistema solar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quantos planetas há no sistema solar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quantos planetas existem no sistema solar.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quantos planetas existem no sistema solar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quantos planetas existem no sistema solar?", StringComparison.OrdinalIgnoreCase))
		{
			return "O sistema solar tem oito planetas: Mercúrio, Vénus, Terra, Marte, Júpiter, Saturno, Urano e Neptuno.";
		}
		else if (userMessage.Equals("Quem inventou a internet?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é que inventou a internet?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem inventou a internet.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem inventou a internet?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem inventou a internet?", StringComparison.OrdinalIgnoreCase))
		{
			return "A internet foi desenvolvida por vários cientistas, incluindo Vinton Cerf e Robert Kahn, com a criação do protocolo TCP/IP.";
		}
		else if (userMessage.Equals("Qual é o maior país do mundo em extensão territorial?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual o maior país do mundo em extensão territorial?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me o maior país do mundo em extensão territorial.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é o maior país do mundo em extensão territorial?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é o maior país do mundo em extensão territorial?", StringComparison.OrdinalIgnoreCase))
		{
			return "O maior país do mundo em extensão territorial é a Rússia.";
		}
		else if (userMessage.Equals("Quem escreveu Hamlet?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é que escreveu Hamlet?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem escreveu Hamlet.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem escreveu Hamlet?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem escreveu Hamlet?", StringComparison.OrdinalIgnoreCase))
		{
			return "Hamlet foi escrito por William Shakespeare.";
		}
		else if (userMessage.Equals("Qual é a língua mais falada no mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a língua mais falada no mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a língua mais falada no mundo.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a língua mais falada no mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a língua mais falada no mundo?", StringComparison.OrdinalIgnoreCase))
		{
			return "A língua mais falada no mundo é o inglês, considerando falantes nativos e não nativos.";
		}
		else if (userMessage.Equals("Quem foi o primeiro homem a pisar na Lua?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é que foi o primeiro homem a pisar na Lua?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi o primeiro homem a pisar na Lua.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi o primeiro homem a pisar na Lua?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi o primeiro homem a pisar na Lua?", StringComparison.OrdinalIgnoreCase))
		{
			return "O primeiro homem a pisar na Lua foi Neil Armstrong, em 1969.";
		}
		else if (userMessage.Equals("Qual é a velocidade do som?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a velocidade do som?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a velocidade do som.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a velocidade do som?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a velocidade do som?", StringComparison.OrdinalIgnoreCase))
		{
			return "A velocidade do som no ar é de aproximadamente 343 metros por segundo.";
		}
		else if (userMessage.Equals("Qual é a maior floresta do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a maior floresta do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a maior floresta do mundo.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a maior floresta do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a maior floresta do mundo?", StringComparison.OrdinalIgnoreCase))
		{
			return "A maior floresta do mundo é a Floresta Amazónica.";
		}
		else if (userMessage.Equals("Qual é a capital da Eslováquia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Eslováquia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Eslováquia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Eslováquia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Eslováquia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Eslováquia é Bratislava.";
		}
		else if (userMessage.Equals("Quem foi John Stuart Mill?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é John Stuart Mill?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi John Stuart Mill.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi John Stuart Mill?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi John Stuart Mill?", StringComparison.OrdinalIgnoreCase))
		{
			return "John Stuart Mill foi um filósofo e economista britânico, defensor do utilitarismo e da liberdade individual.";
		}
		else if (userMessage.Equals("Qual é a capital da Eslovénia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Eslovénia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Eslovénia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Eslovénia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Eslovénia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Eslovénia é Liubliana.";
		}
		else if (userMessage.Equals("Quem foi Friedrich Hayek?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Friedrich Hayek?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Friedrich Hayek.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Friedrich Hayek?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Friedrich Hayek?", StringComparison.OrdinalIgnoreCase))
		{
			return "Friedrich Hayek foi um economista e filósofo austríaco, conhecido por suas ideias sobre o liberalismo económico.";
		}
		else if (userMessage.Equals("Qual é a capital da Lituânia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Lituânia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Lituânia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Lituânia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Lituânia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Lituânia é Vilnius.";
		}
		else if (userMessage.Equals("Quem foi Karl Popper?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Karl Popper?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Karl Popper.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Karl Popper?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Karl Popper?", StringComparison.OrdinalIgnoreCase))
		{
			return "Karl Popper foi um filósofo austríaco, conhecido por sua teoria da falsificabilidade.";
		}
		else if (userMessage.Equals("Qual é a capital da Letónia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Letónia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Letónia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Letónia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Letónia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Letónia é Riga.";
		}
		else if (userMessage.Equals("Quem foi Thomas Hobbes?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Thomas Hobbes?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Thomas Hobbes.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Thomas Hobbes?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Thomas Hobbes?", StringComparison.OrdinalIgnoreCase))
		{
			return "Thomas Hobbes foi um filósofo inglês, conhecido por sua obra 'Leviatã' e suas ideias sobre o contrato social.";
		}
		else if (userMessage.Equals("Qual é a capital da Estónia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Estónia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Estónia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Estónia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Estónia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Estónia é Tallinn.";
		}
		else if (userMessage.Equals("Quem foi Jean-Paul Sartre?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Jean-Paul Sartre?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Jean-Paul Sartre.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Jean-Paul Sartre?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Jean-Paul Sartre?", StringComparison.OrdinalIgnoreCase))
		{
			return "Jean-Paul Sartre foi um filósofo francês, conhecido por suas ideias sobre o existencialismo e a liberdade.";
		}
		else if (userMessage.Equals("Qual é a capital da Moldávia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Moldávia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Moldávia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Moldávia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Moldávia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Moldávia é Chisinau.";
		}
		else if (userMessage.Equals("Quem foi Simone de Beauvoir?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Simone de Beauvoir?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Simone de Beauvoir.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Simone de Beauvoir?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Simone de Beauvoir?", StringComparison.OrdinalIgnoreCase))
		{
			return "Simone de Beauvoir foi uma filósofa e escritora francesa, conhecida por suas contribuições ao feminismo e ao existencialismo.";
		}
		else if (userMessage.Equals("Qual é a capital da Albânia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Albânia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Albânia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Albânia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Albânia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Albânia é Tirana.";
		}

		else if (userMessage.Equals("Quem foi Hannah Arendt?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Hannah Arendt?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Hannah Arendt.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Hannah Arendt?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Hannah Arendt?", StringComparison.OrdinalIgnoreCase))
		{
			return "Hannah Arendt foi uma filósofa política alemã, conhecida por suas análises sobre totalitarismo e a condição humana.";
		}
		else if (userMessage.Equals("Qual é a capital da Macedónia do Norte?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Macedónia do Norte?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Macedónia do Norte.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Macedónia do Norte?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Macedónia do Norte?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Macedónia do Norte é Skopje.";
		}
		else if (userMessage.Equals("Quem foi Ludwig Wittgenstein?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Ludwig Wittgenstein?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Ludwig Wittgenstein.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Ludwig Wittgenstein?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Ludwig Wittgenstein?", StringComparison.OrdinalIgnoreCase))
		{
			return "Ludwig Wittgenstein foi um filósofo austríaco, conhecido por suas contribuições à filosofia da linguagem.";
		}
		else if (userMessage.Equals("Qual é a capital da Bósnia e Herzegovina?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Bósnia e Herzegovina?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Bósnia e Herzegovina.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Bósnia e Herzegovina?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Bósnia e Herzegovina?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Bósnia e Herzegovina é Sarajevo.";
		}
		else if (userMessage.Equals("Quem foi Edmund Husserl?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Edmund Husserl?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Edmund Husserl.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Edmund Husserl?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Edmund Husserl?", StringComparison.OrdinalIgnoreCase))
		{
			return "Edmund Husserl foi um filósofo alemão, fundador da fenomenologia.";
		}
		else if (userMessage.Equals("Qual é a capital de Montenegro?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital de Montenegro?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital de Montenegro.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital de Montenegro?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital de Montenegro?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital de Montenegro é Podgorica.";
		}
		else if (userMessage.Equals("Quem foi Martin Heidegger?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Martin Heidegger?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Martin Heidegger.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Martin Heidegger?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Martin Heidegger?", StringComparison.OrdinalIgnoreCase))
		{
			return "Martin Heidegger foi um filósofo alemão, conhecido por suas obras sobre a existência e o ser.";
		}
		else if (userMessage.Equals("Qual é a capital do Kosovo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Kosovo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Kosovo.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Kosovo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Kosovo?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Kosovo é Pristina.";
		}
		else if (userMessage.Equals("Quem foi Max Weber?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Max Weber?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Max Weber.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Max Weber?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Max Weber?", StringComparison.OrdinalIgnoreCase))
		{
			return "Max Weber foi um sociólogo e filósofo alemão, conhecido por suas análises sobre a burocracia e a ética protestante.";
		}
		else if (userMessage.Equals("Qual é a capital da Geórgia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Geórgia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Geórgia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Geórgia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Geórgia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Geórgia é Tbilisi.";
		}
		else if (userMessage.Equals("Quem foi Émile Durkheim?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Émile Durkheim?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Émile Durkheim.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Émile Durkheim?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Émile Durkheim?", StringComparison.OrdinalIgnoreCase))
		{
			return "Émile Durkheim foi um sociólogo francês, conhecido por seus estudos sobre a sociedade e o suicídio.";
		}
		else if (userMessage.Equals("Qual é a capital da Arménia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Arménia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Arménia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Arménia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Arménia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Arménia é Yerevan.";
		}
		else if (userMessage.Equals("Quem foi Talcott Parsons?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Talcott Parsons?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Talcott Parsons.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Talcott Parsons?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Talcott Parsons?", StringComparison.OrdinalIgnoreCase))
		{
			return "Talcott Parsons foi um sociólogo americano, conhecido por sua teoria da ação social.";
		}
		else if (userMessage.Equals("Qual é a capital do Azerbaijão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Azerbaijão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Azerbaijão.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Azerbaijão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Azerbaijão?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Azerbaijão é Baku.";
		}
		else if (userMessage.Equals("Quem foi Herbert Spencer?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Herbert Spencer?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Herbert Spencer.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Herbert Spencer?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Herbert Spencer?", StringComparison.OrdinalIgnoreCase))
		{
			return "Herbert Spencer foi um filósofo e sociólogo britânico, conhecido por suas ideias sobre o darwinismo social.";
		}
		else if (userMessage.Equals("Qual é a capital do Cazaquistão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Cazaquistão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Cazaquistão.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Cazaquistão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Cazaquistão?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Cazaquistão é Astana.";
		}
		else if (userMessage.Equals("Quem foi Auguste Comte?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Auguste Comte?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Auguste Comte.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Auguste Comte?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Auguste Comte?", StringComparison.OrdinalIgnoreCase))
		{
			return "Auguste Comte foi um filósofo francês, considerado o pai da sociologia.";
		}
		else if (userMessage.Equals("Qual é a capital do Uzbequistão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Uzbequistão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Uzbequistão.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Uzbequistão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Uzbequistão?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Uzbequistão é Tashkent.";
		}
		else if (userMessage.Equals("Quem foi Vilfredo Pareto?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Vilfredo Pareto?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Vilfredo Pareto.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Vilfredo Pareto?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Vilfredo Pareto?", StringComparison.OrdinalIgnoreCase))
		{
			return "Vilfredo Pareto foi um sociólogo e economista italiano, conhecido por sua teoria das elites.";
		}
		else if (userMessage.Equals("Qual é a capital do Turquemenistão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Turquemenistão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Turquemenistão.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Turquemenistão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Turquemenistão?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Turquemenistão é Ashgabat.";
		}
		else if (userMessage.Equals("Quem foi Georg Simmel?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Georg Simmel?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Georg Simmel.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Georg Simmel?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Georg Simmel?", StringComparison.OrdinalIgnoreCase))
		{
			return "Georg Simmel foi um sociólogo e filósofo alemão, conhecido por suas análises sobre a sociedade moderna.";
		}
		else if (userMessage.Equals("Qual é a capital do Tajiquistão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Tajiquistão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Tajiquistão.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Tajiquistão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Tajiquistão?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Tajiquistão é Dushanbe.";
		}
		else if (userMessage.Equals("Quem foi Charles Cooley?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Charles Cooley?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Charles Cooley.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Charles Cooley?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Charles Cooley?", StringComparison.OrdinalIgnoreCase))
		{
			return "Charles Cooley foi um sociólogo americano, conhecido por sua teoria do 'eu espelho'.";
		}
		else if (userMessage.Equals("Qual é a capital do Quirguistão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Quirguistão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Quirguistão.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Quirguistão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Quirguistão?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Quirguistão é Bishkek.";
		}
		else if (userMessage.Equals("Quem foi Robert K. Merton?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Robert K. Merton?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Robert K. Merton.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Robert K. Merton?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Robert K. Merton?", StringComparison.OrdinalIgnoreCase))
		{
			return "Robert K. Merton foi um sociólogo americano, conhecido por sua teoria das funções sociais.";
		}
		else if (userMessage.Equals("Qual é a capital da Mongólia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Mongólia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Mongólia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Mongólia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Mongólia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Mongólia é Ulaanbaatar.";
		}
		else if (userMessage.Equals("Quem foi Erving Goffman?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Erving Goffman?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Erving Goffman.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Erving Goffman?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Erving Goffman?", StringComparison.OrdinalIgnoreCase))
		{
			return "Erving Goffman foi um sociólogo canadense, conhecido por suas análises sobre a interação social.";
		}
		else if (userMessage.Equals("Qual é a capital do Nepal?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Nepal?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Nepal.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Nepal?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Nepal?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Nepal é Kathmandu.";
		}

		else if (userMessage.Equals("Quem foi Pierre Bourdieu?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Pierre Bourdieu?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Pierre Bourdieu.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Pierre Bourdieu?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Pierre Bourdieu?", StringComparison.OrdinalIgnoreCase))
		{
			return "Pierre Bourdieu foi um sociólogo francês, conhecido por suas teorias sobre o capital cultural e a reprodução social.";
		}
		else if (userMessage.Equals("Qual é a capital do Butão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Butão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Butão.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Butão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Butão?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Butão é Thimphu.";
		}
		else if (userMessage.Equals("Quem foi Michel de Certeau?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Michel de Certeau?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Michel de Certeau.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Michel de Certeau?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Michel de Certeau?", StringComparison.OrdinalIgnoreCase))
		{
			return "Michel de Certeau foi um filósofo e historiador francês, conhecido por suas análises sobre a cultura e o cotidiano.";
		}
		else if (userMessage.Equals("Qual é a capital do Sri Lanka?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Sri Lanka?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Sri Lanka.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Sri Lanka?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Sri Lanka?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Sri Lanka é Sri Jayawardenepura Kotte (administrativa) e Colombo (comercial).";
		}
		else if (userMessage.Equals("Quem foi Anthony Giddens?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Anthony Giddens?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Anthony Giddens.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Anthony Giddens?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Anthony Giddens?", StringComparison.OrdinalIgnoreCase))
		{
			return "Anthony Giddens é um sociólogo britânico, conhecido por sua teoria da estruturação.";
		}
		else if (userMessage.Equals("Qual é a capital das Maldivas?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital das Maldivas?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital das Maldivas.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital das Maldivas?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital das Maldivas?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital das Maldivas é Malé.";
		}
		else if (userMessage.Equals("Quem foi Jürgen Habermas?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Jürgen Habermas?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Jürgen Habermas.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Jürgen Habermas?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Jürgen Habermas?", StringComparison.OrdinalIgnoreCase))
		{
			return "Jürgen Habermas é um filósofo e sociólogo alemão, conhecido por sua teoria da ação comunicativa.";
		}
		else if (userMessage.Equals("Qual é a capital do Paquistão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Paquistão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Paquistão.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Paquistão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Paquistão?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Paquistão é Islamabad.";
		}
		else if (userMessage.Equals("Quem foi Zygmunt Bauman?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Zygmunt Bauman?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Zygmunt Bauman.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Zygmunt Bauman?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Zygmunt Bauman?", StringComparison.OrdinalIgnoreCase))
		{
			return "Zygmunt Bauman foi um sociólogo polonês, conhecido por suas análises sobre a modernidade líquida.";
		}
		else if (userMessage.Equals("Qual é a capital do Afeganistão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Afeganistão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Afeganistão.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Afeganistão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Afeganistão?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Afeganistão é Cabul.";
		}
		else if (userMessage.Equals("Quem foi Norbert Elias?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Norbert Elias?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Norbert Elias.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Norbert Elias?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Norbert Elias?", StringComparison.OrdinalIgnoreCase))
		{
			return "Norbert Elias foi um sociólogo alemão, conhecido por sua teoria do processo civilizador.";
		}
		else if (userMessage.Equals("Qual é a capital do Iraque?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Iraque?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Iraque.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Iraque?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Iraque?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Iraque é Bagdá.";
		}
		else if (userMessage.Equals("Quem foi Max Horkheimer?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Max Horkheimer?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Max Horkheimer.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Max Horkheimer?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Max Horkheimer?", StringComparison.OrdinalIgnoreCase))
		{
			return "Max Horkheimer foi um filósofo e sociólogo alemão, conhecido por sua crítica à razão instrumental.";
		}
		else if (userMessage.Equals("Qual é a capital do Irão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Irão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Irão.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Irão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Irão?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Irão é Teerão.";
		}
		else if (userMessage.Equals("Quem foi Theodor Adorno?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Theodor Adorno?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Theodor Adorno.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Theodor Adorno?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Theodor Adorno?", StringComparison.OrdinalIgnoreCase))
		{
			return "Theodor Adorno foi um filósofo e sociólogo alemão, conhecido por suas críticas à cultura de massa.";
		}
		else if (userMessage.Equals("Qual é a capital da Síria?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Síria?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Síria.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Síria?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Síria?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Síria é Damasco.";
		}
		else if (userMessage.Equals("Quem foi Herbert Marcuse?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Herbert Marcuse?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Herbert Marcuse.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Herbert Marcuse?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Herbert Marcuse?", StringComparison.OrdinalIgnoreCase))
		{
			return "Herbert Marcuse foi um filósofo e sociólogo alemão, conhecido por suas críticas à sociedade industrial.";
		}
		else if (userMessage.Equals("Qual é a capital do Líbano?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Líbano?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Líbano.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Líbano?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Líbano?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Líbano é Beirute.";
		}
		else if (userMessage.Equals("Quem foi Walter Benjamin?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Walter Benjamin?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Walter Benjamin.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Walter Benjamin?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Walter Benjamin?", StringComparison.OrdinalIgnoreCase))
		{
			return "Walter Benjamin foi um filósofo e crítico cultural alemão, conhecido por suas análises sobre a arte e a modernidade.";
		}
		else if (userMessage.Equals("Qual é a capital da Jordânia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Jordânia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Jordânia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Jordânia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Jordânia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Jordânia é Amã.";
		}
		else if (userMessage.Equals("Quem foi Erich Fromm?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Erich Fromm?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Erich Fromm.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Erich Fromm?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Erich Fromm?", StringComparison.OrdinalIgnoreCase))
		{
			return "Erich Fromm foi um psicanalista e filósofo alemão, conhecido por suas análises sobre a liberdade e o amor.";
		}
		else if (userMessage.Equals("Qual é a capital de Israel?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital de Israel?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital de Israel.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital de Israel?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital de Israel?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital de Israel é Jerusalém.";
		}
		else if (userMessage.Equals("Quem foi Carl Jung?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Carl Jung?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Carl Jung.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Carl Jung?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Carl Jung?", StringComparison.OrdinalIgnoreCase))
		{
			return "Carl Jung foi um psiquiatra e psicanalista suíço, conhecido por suas teorias sobre o inconsciente coletivo.";
		}
		else if (userMessage.Equals("Qual é a capital da Palestina?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Palestina?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Palestina.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Palestina?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Palestina?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Palestina é Jerusalém Oriental, embora sua soberania seja disputada.";
		}
		else if (userMessage.Equals("Qual é a capital do Egito?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Egito?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Egito.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Egito?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Egito?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Egito é Cairo.";
		}
		else if (userMessage.Equals("Quem foi Alfred Adler?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Alfred Adler?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Alfred Adler.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Alfred Adler?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Alfred Adler?", StringComparison.OrdinalIgnoreCase))
		{
			return "Alfred Adler foi um psicólogo austríaco, conhecido por sua teoria da psicologia individual.";
		}
		else if (userMessage.Equals("Qual é a capital da Líbia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Líbia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Líbia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Líbia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Líbia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Líbia é Trípoli.";
		}
		else if (userMessage.Equals("Quem foi Melanie Klein?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Melanie Klein?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Melanie Klein.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Melanie Klein?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Melanie Klein?", StringComparison.OrdinalIgnoreCase))
		{
			return "Melanie Klein foi uma psicanalista austríaca, conhecida por suas contribuições à psicanálise infantil.";
		}
		else if (userMessage.Equals("Qual é a capital da Tunísia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Tunísia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Tunísia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Tunísia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Tunísia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Tunísia é Túnis.";
		}
		else if (userMessage.Equals("Quem foi Jacques Lacan?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Jacques Lacan?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Jacques Lacan.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Jacques Lacan?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Jacques Lacan?", StringComparison.OrdinalIgnoreCase))
		{
			return "Jacques Lacan foi um psicanalista francês, conhecido por suas teorias sobre o inconsciente e a linguagem.";
		}
		else if (userMessage.Equals("Qual é a capital da Argélia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Argélia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Argélia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Argélia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Argélia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Argélia é Argel.";
		}
		else if (userMessage.Equals("Quem foi Jean Piaget?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Jean Piaget?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Jean Piaget.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Jean Piaget?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Jean Piaget?", StringComparison.OrdinalIgnoreCase))
		{
			return "Jean Piaget foi um psicólogo suíço, conhecido por suas teorias sobre o desenvolvimento cognitivo.";
		}
		else if (userMessage.Equals("Qual é a capital do Marrocos?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Marrocos?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Marrocos.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Marrocos?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Marrocos?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Marrocos é Rabat.";
		}
		else if (userMessage.Equals("Quem foi Lev Vygotsky?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Lev Vygotsky?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Lev Vygotsky.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Lev Vygotsky?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Lev Vygotsky?", StringComparison.OrdinalIgnoreCase))
		{
			return "Lev Vygotsky foi um psicólogo russo, conhecido por suas teorias sobre o desenvolvimento social e cultural.";
		}
		else if (userMessage.Equals("Qual é a capital da Mauritânia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Mauritânia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Mauritânia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Mauritânia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Mauritânia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Mauritânia é Nouakchott.";
		}
		else if (userMessage.Equals("Quem foi B.F. Skinner?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é B.F. Skinner?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi B.F. Skinner.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi B.F. Skinner?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi B.F. Skinner?", StringComparison.OrdinalIgnoreCase))
		{
			return "B.F. Skinner foi um psicólogo americano, conhecido por suas teorias sobre o comportamento e o condicionamento operante.";
		}
		else if (userMessage.Equals("Qual é a capital do Mali?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Mali?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Mali.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Mali?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Mali?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Mali é Bamako.";
		}
		else if (userMessage.Equals("Quem foi Abraham Maslow?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Abraham Maslow?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Abraham Maslow.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Abraham Maslow?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Abraham Maslow?", StringComparison.OrdinalIgnoreCase))
		{
			return "Abraham Maslow foi um psicólogo americano, conhecido por sua teoria da hierarquia das necessidades.";
		}
		else if (userMessage.Equals("Qual é a capital do Níger?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Níger?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Níger.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Níger?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Níger?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Níger é Niamey.";
		}
		else if (userMessage.Equals("Quem foi Carl Rogers?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Carl Rogers?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Carl Rogers.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Carl Rogers?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Carl Rogers?", StringComparison.OrdinalIgnoreCase))
		{
			return "Carl Rogers foi um psicólogo americano, conhecido por suas contribuições à psicologia humanista.";
		}
		else if (userMessage.Equals("Qual é a capital do Chade?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Chade?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Chade.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Chade?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Chade?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Chade é N'Djamena.";
		}
		else if (userMessage.Equals("Quem foi Erik Erikson?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Erik Erikson?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Erik Erikson.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Erik Erikson?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Erik Erikson?", StringComparison.OrdinalIgnoreCase))
		{
			return "Erik Erikson foi um psicólogo alemão, conhecido por sua teoria do desenvolvimento psicossocial.";
		}
		else if (userMessage.Equals("Qual é a capital do Sudão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Sudão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Sudão.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Sudão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Sudão?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Sudão é Cartum.";
		}
		else if (userMessage.Equals("Quem foi Ivan Pavlov?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Ivan Pavlov?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Ivan Pavlov.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Ivan Pavlov?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Ivan Pavlov?", StringComparison.OrdinalIgnoreCase))
		{
			return "Ivan Pavlov foi um fisiologista russo, conhecido por suas pesquisas sobre o condicionamento clássico.";
		}
		else if (userMessage.Equals("Qual é a capital da Etiópia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Etiópia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Etiópia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Etiópia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Etiópia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Etiópia é Adis Abeba.";
		}
		else if (userMessage.Equals("Quem foi Wilhelm Wundt?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Wilhelm Wundt?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Wilhelm Wundt.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Wilhelm Wundt?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Wilhelm Wundt?", StringComparison.OrdinalIgnoreCase))
		{
			return "Wilhelm Wundt foi um psicólogo alemão, considerado o pai da psicologia experimental.";
		}
		else if (userMessage.Equals("Qual é a capital da Somália?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Somália?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Somália.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Somália?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Somália?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Somália é Mogadíscio.";
		}
		else if (userMessage.Equals("Quem foi William James?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é William James?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi William James.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi William James?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi William James?", StringComparison.OrdinalIgnoreCase))
		{
			return "William James foi um psicólogo e filósofo americano, conhecido por suas contribuições à psicologia funcional.";
		}
		else if (userMessage.Equals("Qual é a capital do Quénia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Quénia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Quénia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Quénia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Quénia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Quénia é Nairobi.";
		}
		else if (userMessage.Equals("Quem foi John Watson?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é John Watson?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi John Watson.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi John Watson?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi John Watson?", StringComparison.OrdinalIgnoreCase))
		{
			return "John Watson foi um psicólogo americano, conhecido por suas contribuições ao behaviorismo.";
		}
		else if (userMessage.Equals("Qual é a capital da Tanzânia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital da Tanzânia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Tanzânia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Tanzânia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital da Tanzânia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Tanzânia é Dodoma.";
		}
		else if (userMessage.Equals("Quem foi Kurt Lewin?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Kurt Lewin?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Kurt Lewin.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Kurt Lewin?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Kurt Lewin?", StringComparison.OrdinalIgnoreCase))
		{
			return "Kurt Lewin foi um psicólogo alemão, conhecido por suas teorias sobre a dinâmica de grupos.";
		}
		else if (userMessage.Equals("Qual é a capital de Uganda?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital de Uganda?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital de Uganda.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital de Uganda?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital de Uganda?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital de Uganda é Kampala.";
		}
		else if (userMessage.Equals("Quem foi Gordon Allport?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Gordon Allport?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Gordon Allport.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Gordon Allport?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Gordon Allport?", StringComparison.OrdinalIgnoreCase))
		{
			return "Gordon Allport foi um psicólogo americano, conhecido por suas teorias sobre a personalidade.";
		}
		else if (userMessage.Equals("Qual é a capital de Ruanda?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital de Ruanda?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital de Ruanda.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital de Ruanda?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital de Ruanda?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital de Ruanda é Kigali.";
		}
		else if (userMessage.Equals("Quem foi Hans Eysenck?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Hans Eysenck?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Hans Eysenck.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Hans Eysenck?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Hans Eysenck?", StringComparison.OrdinalIgnoreCase))
		{
			return "Hans Eysenck foi um psicólogo britânico, conhecido por suas teorias sobre a personalidade e a inteligência.";
		}
		else if (userMessage.Equals("Qual é a capital do Burundi?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Qual a capital do Burundi?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Burundi.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Burundi?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me qual é a capital do Burundi?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Burundi é Bujumbura.";
		}

		else if (userMessage.Equals("Quem foi Raymond Cattell?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Raymond Cattell?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Raymond Cattell?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Raymond Cattell?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre Raymond Cattell?", StringComparison.OrdinalIgnoreCase))
		{
			return "Raymond Cattell foi um psicólogo britânico, conhecido por suas teorias sobre a personalidade e a inteligência.";
		}
		else if (userMessage.Equals("Quem foi Albert Bandura?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Albert Bandura?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Albert Bandura?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Albert Bandura?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre Albert Bandura?", StringComparison.OrdinalIgnoreCase))
		{
			return "Albert Bandura é um psicólogo canadense, conhecido por sua teoria da aprendizagem social.";
		}
		else if (userMessage.Equals("Qual é a capital da Namíbia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Namíbia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Namíbia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Namíbia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Namíbia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Namíbia é Windhoek.";
		}
		else if (userMessage.Equals("Quem foi Stanley Milgram?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Stanley Milgram?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Stanley Milgram?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Stanley Milgram?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre Stanley Milgram?", StringComparison.OrdinalIgnoreCase))
		{
			return "Stanley Milgram foi um psicólogo americano, conhecido por seus experimentos sobre obediência à autoridade.";
		}
		else if (userMessage.Equals("Qual é a capital de Angola?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital de Angola?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital de Angola.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital de Angola?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital de Angola?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital de Angola é Luanda.";
		}
		else if (userMessage.Equals("Quem foi Philip Zimbardo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Philip Zimbardo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Philip Zimbardo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Philip Zimbardo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre Philip Zimbardo?", StringComparison.OrdinalIgnoreCase))
		{
			return "Philip Zimbardo é um psicólogo americano, conhecido por seu experimento da prisão de Stanford.";
		}
		else if (userMessage.Equals("Qual é a capital de Moçambique?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital de Moçambique?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital de Moçambique.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital de Moçambique?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital de Moçambique?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital de Moçambique é Maputo.";
		}
		else if (userMessage.Equals("Quem foi Solomon Asch?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Solomon Asch?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Solomon Asch?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Solomon Asch?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre Solomon Asch?", StringComparison.OrdinalIgnoreCase))
		{
			return "Solomon Asch foi um psicólogo americano, conhecido por seus experimentos sobre conformidade.";
		}
		else if (userMessage.Equals("Qual é a capital da Zâmbia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Zâmbia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Zâmbia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Zâmbia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Zâmbia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Zâmbia é Lusaka.";
		}
		else if (userMessage.Equals("Quem foi Leon Festinger?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Leon Festinger?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Leon Festinger?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Leon Festinger?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre Leon Festinger?", StringComparison.OrdinalIgnoreCase))
		{
			return "Leon Festinger foi um psicólogo americano, conhecido por sua teoria da dissonância cognitiva.";
		}
		else if (userMessage.Equals("Qual é a capital do Zimbábue?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Zimbábue?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Zimbábue.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital do Zimbábue?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital do Zimbábue?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Zimbábue é Harare.";
		}
		else if (userMessage.Equals("Quem foi Harry Harlow?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Harry Harlow?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Harry Harlow?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Harry Harlow?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre Harry Harlow?", StringComparison.OrdinalIgnoreCase))
		{
			return "Harry Harlow foi um psicólogo americano, conhecido por seus experimentos com macacos sobre o amor e o apego.";
		}
		else if (userMessage.Equals("Qual é a capital de Madagascar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital de Madagascar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital de Madagascar.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital de Madagascar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital de Madagascar?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital de Madagascar é Antananarivo.";
		}
		else if (userMessage.Equals("Quem foi Konrad Lorenz?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Konrad Lorenz?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Konrad Lorenz?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Konrad Lorenz?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre Konrad Lorenz?", StringComparison.OrdinalIgnoreCase))
		{
			return "Konrad Lorenz foi um zoólogo austríaco, conhecido por suas pesquisas sobre o comportamento animal.";
		}
		else if (userMessage.Equals("Qual é a capital das Ilhas Maurício?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital das Ilhas Maurício?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital das Ilhas Maurício.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital das Ilhas Maurício?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital das Ilhas Maurício?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital das Ilhas Maurício é Port Louis.";
		}
		else if (userMessage.Equals("Quem foi Nikolaas Tinbergen?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Nikolaas Tinbergen?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Nikolaas Tinbergen?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Nikolaas Tinbergen?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre Nikolaas Tinbergen?", StringComparison.OrdinalIgnoreCase))
		{
			return "Nikolaas Tinbergen foi um zoólogo holandês, conhecido por suas pesquisas sobre o comportamento animal.";
		}
		else if (userMessage.Equals("Qual é a capital das Seychelles?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital das Seychelles?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital das Seychelles.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital das Seychelles?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital das Seychelles?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital das Seychelles é Victoria.";
		}
		else if (userMessage.Equals("Quem foi Karl von Frisch?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Karl von Frisch?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Karl von Frisch?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Karl von Frisch?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre Karl von Frisch?", StringComparison.OrdinalIgnoreCase))
		{
			return "Karl von Frisch foi um zoólogo austríaco, conhecido por suas pesquisas sobre a comunicação das abelhas.";
		}
		else if (userMessage.Equals("Qual é a capital das Comores?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital das Comores?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital das Comores.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital das Comores?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital das Comores?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital das Comores é Moroni.";
		}
		else if (userMessage.Equals("Quem foi Edward O. Wilson?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Edward O. Wilson?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Edward O. Wilson?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Edward O. Wilson?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre Edward O. Wilson?", StringComparison.OrdinalIgnoreCase))
		{
			return "Edward O. Wilson é um biólogo americano, conhecido por suas pesquisas sobre sociobiologia.";
		}
		else if (userMessage.Equals("Qual é a capital de Djibuti?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital de Djibuti?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital de Djibuti.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital de Djibuti?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital de Djibuti?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital de Djibuti é Djibuti.";
		}
		else if (userMessage.Equals("Quem foi Richard Dawkins?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Richard Dawkins?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Richard Dawkins?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Richard Dawkins?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre Richard Dawkins?", StringComparison.OrdinalIgnoreCase))
		{
			return "Richard Dawkins é um biólogo britânico, conhecido por suas teorias sobre a evolução e o gene egoísta.";
		}
		else if (userMessage.Equals("Qual é a capital da Eritreia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Eritreia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Eritreia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Eritreia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Eritreia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Eritreia é Asmara.";
		}
		else if (userMessage.Equals("Quem foi Stephen Jay Gould?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Stephen Jay Gould?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Stephen Jay Gould?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Stephen Jay Gould?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre Stephen Jay Gould?", StringComparison.OrdinalIgnoreCase))
		{
			return "Stephen Jay Gould foi um paleontólogo americano, conhecido pelas suas teorias sobre a evolução.";
		}
		else if (userMessage.Equals("Qual é a capital da Guiné Equatorial?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Guiné Equatorial?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Guiné Equatorial.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Guiné Equatorial?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Guiné Equatorial?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Guiné Equatorial é Malabo.";
		}
		else if (userMessage.Equals("Qual é a capital da Guiné-Bissau?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Guiné-Bissau?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Guiné-Bissau.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Guiné-Bissau?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Guiné-Bissau?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Guiné-Bissau é Bissau.";
		}
		else if (userMessage.Equals("Quem foi Gregor Mendel?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Gregor Mendel?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Gregor Mendel?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Gregor Mendel?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre Gregor Mendel?", StringComparison.OrdinalIgnoreCase))
		{
			return "Gregor Mendel foi um monge e cientista austríaco, conhecido como o pai da genética.";
		}
		else if (userMessage.Equals("Qual é a capital da Libéria?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Libéria?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Libéria.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Libéria?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Libéria?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Libéria é Monróvia.";
		}
		else if (userMessage.Equals("Quem foi James Watson?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é James Watson?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi James Watson?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces James Watson?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre James Watson?", StringComparison.OrdinalIgnoreCase))
		{
			return "James Watson é um biólogo americano, conhecido pela sua descoberta da estrutura do DNA.";
		}
		else if (userMessage.Equals("Qual é a capital de Serra Leoa?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital de Serra Leoa?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital de Serra Leoa.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital de Serra Leoa?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital de Serra Leoa?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital de Serra Leoa é Freetown.";
		}
		else if (userMessage.Equals("Quem foi Francis Crick?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Quem é Francis Crick?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Francis Crick?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Francis Crick?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre Francis Crick?", StringComparison.OrdinalIgnoreCase))
		{
			return "Francis Crick foi um biólogo britânico, conhecido pela sua descoberta da estrutura do DNA.";
		}
		else if (userMessage.Equals("O que é a teoria da relatividade?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que é a teoria da relatividade?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Explica-me a teoria da relatividade.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a teoria da relatividade?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre a teoria da relatividade?", StringComparison.OrdinalIgnoreCase))
		{
			return "A teoria da relatividade, proposta por Albert Einstein, descreve a física do espaço, tempo e gravidade. Divide-se em relatividade especial e geral.";
		}
		else if (userMessage.Equals("Quem inventou a lâmpada?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem inventou a lâmpada?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem inventou a lâmpada.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces o inventor da lâmpada?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre a invenção da lâmpada?", StringComparison.OrdinalIgnoreCase))
		{
			return "Thomas Edison é creditado pela invenção da lâmpada elétrica prática, embora outros cientistas também tenham contribuído para o desenvolvimento da tecnologia.";
		}
		else if (userMessage.Equals("O que é um eclipse solar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que é um eclipse solar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Explica-me o que é um eclipse solar.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces o fenómeno do eclipse solar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre o eclipse solar?", StringComparison.OrdinalIgnoreCase))
		{
			return "Um eclipse solar ocorre quando a Lua passa entre a Terra e o Sol, bloqueando total ou parcialmente a luz do Sol.";
		}
		else if (userMessage.Equals("Como estudar para exames?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como estudar para exames?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me dicas para estudar para exames.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces métodos de estudo para exames?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a estudar para exames?", StringComparison.OrdinalIgnoreCase))
		{
			return "Dicas: Faz um cronograma, revê as tuas anotações, pratica exercícios e descansa bem antes do exame. Não deixes para a última hora!";
		}
		else if (userMessage.Equals("O que fazer quando não entendo a matéria?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que fazer quando não entendo a matéria?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me conselhos para quando não entendo a matéria.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces estratégias para entender a matéria?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a entender a matéria?", StringComparison.OrdinalIgnoreCase))
		{
			return "Pede ajuda ao professor, revê o material, vê vídeos explicativos ou forma um grupo de estudo com colegas.";
		}
		else if (userMessage.Equals("Como melhorar as minhas notas?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como melhorar as minhas notas?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me dicas para melhorar as minhas notas.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces métodos para melhorar as notas?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a melhorar as minhas notas?", StringComparison.OrdinalIgnoreCase))
		{
			return "Foca-te na organização, participa nas aulas, faz todas as tarefas e revê os conteúdos regularmente. Persistência é a chave!";
		}
		else if (userMessage.Equals("O que é um bom método de estudo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que é um bom método de estudo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me exemplos de bons métodos de estudo.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces técnicas de estudo eficazes?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes recomendar um bom método de estudo?", StringComparison.OrdinalIgnoreCase))
		{
			return "Experimenta técnicas como mapas mentais, resumos, flashcards ou o método Pomodoro (estudar por 25 minutos e descansar 5).";
		}
		else if (userMessage.Equals("Como não procrastinar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como não procrastinar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me dicas para não procrastinar.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces estratégias para evitar a procrastinação?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a não procrastinar?", StringComparison.OrdinalIgnoreCase))
		{
			return "Divide as tarefas em partes menores, estabelece metas diárias e evita distrações como o telemóvel e as redes sociais.";
		}
		else if (userMessage.Equals("Como fazer novos amigos?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como fazer novos amigos?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me conselhos para fazer novos amigos.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces formas de fazer novos amigos?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a fazer novos amigos?", StringComparison.OrdinalIgnoreCase))
		{
			return "Sê tu mesmo, mostra interesse pelos outros, participa em atividades de grupo e não tenhas medo de iniciar conversas.";
		}
		else if (userMessage.Equals("O que fazer se me sinto sozinho?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que fazer se me sinto sozinho?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me conselhos para quando me sinto sozinho.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces formas de lidar com a solidão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a lidar com a solidão?", StringComparison.OrdinalIgnoreCase))
		{
			return "Tenta aproximar-te de colegas, participa em clubes ou atividades extracurriculares, e lembra-te de que é normal sentires-te assim às vezes.";
		}
		else if (userMessage.Equals("Como lidar com brigas entre amigos?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como lidar com brigas entre amigos?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me conselhos para lidar com brigas entre amigos.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces formas de resolver conflitos entre amigos?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a lidar com brigas entre amigos?", StringComparison.OrdinalIgnoreCase))
		{
			return "Tenta conversar calmamente, ouve o lado do outro e procura uma solução juntos. Às vezes, um pedido de desculpas resolve muita coisa.";
		}
		else if (userMessage.Equals("O que fazer se gosto de alguém?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que fazer se gosto de alguém?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me conselhos para quando gosto de alguém.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces formas de lidar com sentimentos por alguém?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a lidar com sentimentos por alguém?", StringComparison.OrdinalIgnoreCase))
		{
			return "Sê sincero e respeitoso. Mostra interesse, mas não forces a situação. Às vezes, uma amizade pode evoluir naturalmente.";
		}
		else if (userMessage.Equals("Como superar uma desilusão amorosa?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como superar uma desilusão amorosa?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me conselhos para superar uma desilusão amorosa.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces formas de lidar com uma desilusão amorosa?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a superar uma desilusão amorosa?", StringComparison.OrdinalIgnoreCase))
		{
			return "Dá tempo ao tempo, foca-te em ti mesmo, conversa com amigos e faz coisas que gostas. Aos poucos, a dor vai passar.";
		}
		else if (userMessage.Equals("Qual é um bom hobby para começar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é um bom hobby para começar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me sugestões de hobbies para começar.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces hobbies interessantes para iniciar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes recomendar um hobby para começar?", StringComparison.OrdinalIgnoreCase))
		{
			return "Depende do que gostas! Pode ser desenho, música, desportos, programação, jogos, ou até aprender algo novo, como cozinhar.";
		}
		else if (userMessage.Equals("Como aprender a tocar um instrumento?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como aprender a tocar um instrumento?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me dicas para aprender a tocar um instrumento.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces métodos para aprender a tocar um instrumento?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a aprender a tocar um instrumento?", StringComparison.OrdinalIgnoreCase))
		{
			return "Começa com aulas básicas (online ou presenciais), pratica regularmente e não desistas nos primeiros desafios. Paciência é essencial!";
		}
		else if (userMessage.Equals("O que fazer para melhorar no futebol?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que fazer para melhorar no futebol?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me dicas para melhorar no futebol.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces técnicas para melhorar no futebol?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a melhorar no futebol?", StringComparison.OrdinalIgnoreCase))
		{
			return "Pratica regularmente, vê jogos para aprender técnicas e treina fundamentos como passe, remate e controlo de bola.";
		}
		else if (userMessage.Equals("Como começar a desenhar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como começar a desenhar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me dicas para começar a desenhar.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces técnicas para começar a desenhar?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a começar a desenhar?", StringComparison.OrdinalIgnoreCase))
		{
			return "Começa com desenhos simples, usa tutoriais online e pratica todos os dias. Não te preocupes em ser perfeito desde o início!";
		}
		else if (userMessage.Equals("Qual jogo é bom para jogar com amigos?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual jogo é bom para jogar com amigos?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me sugestões de jogos para jogar com amigos.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces jogos divertidos para jogar em grupo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes recomendar jogos para jogar com amigos?", StringComparison.OrdinalIgnoreCase))
		{
			return "Jogos como Among Us, Minecraft, Fortnite ou até jogos de tabuleiro como Uno e Detetive são ótimos para te divertires em grupo.";
		}
		else if (userMessage.Equals("Como criar um canal no YouTube?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como criar um canal no YouTube?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me dicas para criar um canal no YouTube.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces os passos para criar um canal no YouTube?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a criar um canal no YouTube?", StringComparison.OrdinalIgnoreCase))
		{
			return "Escolhe um tema que gostes, cria conteúdo de qualidade, edita bem os vídeos e sê consistente. E diverte-te no processo!";
		}
		else if (userMessage.Equals("O que é um meme?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que é um meme?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Explica-me o que é um meme.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a definição de meme?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre o que são memes?", StringComparison.OrdinalIgnoreCase))
		{
			return "Memes são imagens, vídeos ou frases engraçadas que se espalham rapidamente pela internet. São uma forma de expressão cultural!";
		}
		else if (userMessage.Equals("Como ganhar seguidores no Instagram?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como ganhar seguidores no Instagram?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me dicas para ganhar seguidores no Instagram.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces estratégias para crescer no Instagram?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a ganhar seguidores no Instagram?", StringComparison.OrdinalIgnoreCase))
		{
			return "Publica conteúdo interessante, usa hashtags relevantes, interage com outras pessoas e sê autêntico. Crescer leva tempo!";
		}
		else if (userMessage.Equals("O que é o TikTok?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que é o TikTok?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Explica-me o que é o TikTok.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a plataforma TikTok?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre o TikTok?", StringComparison.OrdinalIgnoreCase))
		{
			return "O TikTok é uma rede social onde podes criar e partilhar vídeos curtos, geralmente com música e efeitos especiais.";
		}
		else if (userMessage.Equals("Como aprender programação?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como aprender programação?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me dicas para aprender programação.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces recursos para aprender programação?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a aprender programação?", StringComparison.OrdinalIgnoreCase))
		{
			return "Começa com linguagens simples como Python, usa plataformas como Codecademy ou Khan Academy, e pratica muito!";
		}
		else if (userMessage.Equals("Como ter uma alimentação saudável?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como ter uma alimentação saudável?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me dicas para uma alimentação saudável.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces hábitos alimentares saudáveis?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a ter uma alimentação saudável?", StringComparison.OrdinalIgnoreCase))
		{
			return "Come mais frutas, verduras e proteínas, evita alimentos ultraprocessados e bebe bastante água. Equilíbrio é a chave!";
		}
		else if (userMessage.Equals("Quantas horas de sono preciso?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quantas horas de sono preciso?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quantas horas de sono preciso.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a quantidade de sono necessária?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre a importância do sono?", StringComparison.OrdinalIgnoreCase))
		{
			return "Adolescentes precisam de 8 a 10 horas de sono por noite. Dorme bem para ter energia e concentração durante o dia!";
		}
		else if (userMessage.Equals("Como lidar com o stress?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como lidar com o stress?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me dicas para lidar com o stress.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces técnicas para gerir o stress?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a lidar com o stress?", StringComparison.OrdinalIgnoreCase))
		{
			return "Respira fundo, faz pausas, pratica exercícios físicos e conversa com alguém de confiança sobre o que estás a sentir.";
		}
		else if (userMessage.Equals("O que fazer para ter mais energia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que fazer para ter mais energia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me dicas para ter mais energia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces formas de aumentar a energia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a ter mais energia?", StringComparison.OrdinalIgnoreCase))
		{
			return "Dorme bem, alimenta-te de forma saudável, bebe água e faz exercícios físicos regularmente.";
		}
		else if (userMessage.Equals("Como cuidar da pele?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como cuidar da pele?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me dicas para cuidar da pele.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces rotinas de cuidados com a pele?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a cuidar da pele?", StringComparison.OrdinalIgnoreCase))
		{
			return "Lava o rosto diariamente, usa protetor solar, hidrata a pele e evita espremer borbulhas.";
		}
		else if (userMessage.Equals("Como escolher uma profissão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como escolher uma profissão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me conselhos para escolher uma profissão.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces formas de decidir uma carreira?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a escolher uma profissão?", StringComparison.OrdinalIgnoreCase))
		{
			return "Pensa no que gostas de fazer, pesquisa sobre diferentes carreiras e conversa com profissionais da área que te interessa.";
		}
		else if (userMessage.Equals("O que é a faculdade?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que é a faculdade?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Explica-me o que é a faculdade.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces o propósito da faculdade?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre a faculdade?", StringComparison.OrdinalIgnoreCase))
		{
			return "A faculdade é um lugar onde estudas para te especializares numa área e te preparares para uma carreira profissional.";
		}
		else if (userMessage.Equals("Como fazer um currículo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como fazer um currículo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me dicas para fazer um currículo.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces os elementos de um bom currículo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a fazer um currículo?", StringComparison.OrdinalIgnoreCase))
		{
			return "Inclui os teus dados pessoais, formação, experiências e habilidades. Sê claro e objetivo!";
		}
		else if (userMessage.Equals("O que é um estágio?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que é um estágio?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Explica-me o que é um estágio.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces o propósito de um estágio?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre estágios?", StringComparison.OrdinalIgnoreCase))
		{
			return "Um estágio é uma oportunidade de trabalhar numa empresa para ganhares experiência na área que estás a estudar.";
		}
		else if (userMessage.Equals("Como me preparar para os exames nacionais?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como me preparar para os exames nacionais?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me dicas para os exames nacionais.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces estratégias para os exames nacionais?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a preparar-me para os exames nacionais?", StringComparison.OrdinalIgnoreCase))
		{
			return "Estuda com antecedência, faz exames simulados, revê as matérias mais importantes e cuida da tua saúde mental.";
		}
		else if (userMessage.Equals("Qual é a história do Harry Potter?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a história do Harry Potter?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conta-me a história do Harry Potter.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a saga do Harry Potter?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre o Harry Potter?", StringComparison.OrdinalIgnoreCase))
		{
			return "Harry Potter é um menino bruxo que descobre o seu destino de lutar contra o vilão Lord Voldemort. A série tem 7 livros e 8 filmes!";
		}
		else if (userMessage.Equals("Quem é o Homem-Aranha?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem é o Homem-Aranha?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Explica-me quem é o Homem-Aranha.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a história do Homem-Aranha?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre o Homem-Aranha?", StringComparison.OrdinalIgnoreCase))
		{
			return "O Homem-Aranha é o super-herói Peter Parker, que ganhou poderes após ser picado por uma aranha radioativa.";
		}
		else if (userMessage.Equals("Qual é o filme mais visto do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é o filme mais visto do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me qual é o filme mais visto do mundo.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces o filme mais visto da história?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre o filme mais visto do mundo?", StringComparison.OrdinalIgnoreCase))
		{
			return "Atualmente, 'Avatar' e 'Vingadores: Ultimato' estão entre os filmes mais vistos da história.";
		}
		else if (userMessage.Equals("O que é K-pop?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que é K-pop?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Explica-me o que é K-pop.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces o género musical K-pop?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre K-pop?", StringComparison.OrdinalIgnoreCase))
		{
			return "K-pop é um género musical coreano que mistura pop, eletrónica e hip-hop. Grupos como BTS e BLACKPINK são famosos mundialmente.";
		}
		else if (userMessage.Equals("Qual é o jogo mais jogado do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é o jogo mais jogado do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me qual é o jogo mais jogado do mundo.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces o jogo mais popular do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre o jogo mais jogado do mundo?", StringComparison.OrdinalIgnoreCase))
		{
			return "Atualmente, jogos como Fortnite, Minecraft e League of Legends estão entre os mais populares.";
		}
		else if (userMessage.Equals("O que fazer se me sinto pressionado?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que fazer se me sinto pressionado?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me conselhos para lidar com a pressão.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces formas de lidar com a pressão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a lidar com a pressão?", StringComparison.OrdinalIgnoreCase))
		{
			return "Conversa com alguém de confiança, respira fundo e lembra-te de que é normal sentires pressão. Foca-te no que podes controlar.";
		}
		else if (userMessage.Equals("Como lidar com o bullying?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como lidar com o bullying?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me conselhos para lidar com o bullying.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces formas de combater o bullying?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a lidar com o bullying?", StringComparison.OrdinalIgnoreCase))
		{
			return "Conta a um adulto de confiança, como um professor ou familiar, e não enfrentes o agressor sozinho. Não estás sozinho!";
		}
		else if (userMessage.Equals("O que fazer se não sei o que quero ser no futuro?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que fazer se não sei o que quero ser no futuro?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me conselhos para decidir o meu futuro.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces formas de descobrir a minha vocação?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a decidir o meu futuro?", StringComparison.OrdinalIgnoreCase))
		{
			return "Não te preocupes, é normal não saberes ainda. Explora os teus interesses, conversa com profissionais e lembra-te de que tens tempo para decidir.";
		}
		else if (userMessage.Equals("Como lidar com a ansiedade?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como lidar com a ansiedade?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me dicas para lidar com a ansiedade.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces técnicas para gerir a ansiedade?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a lidar com a ansiedade?", StringComparison.OrdinalIgnoreCase))
		{
			return "Respira fundo, faz atividades que gostes, conversa com alguém e, se necessário, procura ajuda profissional.";
		}
		else if (userMessage.Equals("O que fazer para ter mais energia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que fazer para ter mais energia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me dicas para ter mais energia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces formas de aumentar a energia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a ter mais energia?", StringComparison.OrdinalIgnoreCase))
		{
			return "Dorme bem, alimenta-te de forma saudável, bebe água e faz exercícios físicos regularmente.";
		}
		else if (userMessage.Equals("Como cuidar da pele?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como cuidar da pele?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me dicas para cuidar da pele.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces rotinas de cuidados com a pele?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a cuidar da pele?", StringComparison.OrdinalIgnoreCase))
		{
			return "Lava o rosto diariamente, usa protetor solar, hidrata a pele e evita espremer borbulhas.";
		}
		else if (userMessage.Equals("Como escolher uma profissão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como escolher uma profissão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me conselhos para escolher uma profissão.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces formas de decidir uma carreira?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a escolher uma profissão?", StringComparison.OrdinalIgnoreCase))
		{
			return "Pensa no que gostas de fazer, pesquisa sobre diferentes carreiras e conversa com profissionais da área que te interessa.";
		}
		else if (userMessage.Equals("O que é a faculdade?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que é a faculdade?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Explica-me o que é a faculdade.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces o propósito da faculdade?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre a faculdade?", StringComparison.OrdinalIgnoreCase))
		{
			return "A faculdade é um lugar onde estudas para te especializares numa área e te preparares para uma carreira profissional.";
		}
		else if (userMessage.Equals("Como fazer um currículo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como fazer um currículo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me dicas para fazer um currículo.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces os elementos de um bom currículo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a fazer um currículo?", StringComparison.OrdinalIgnoreCase))
		{
			return "Inclui os teus dados pessoais, formação, experiências e habilidades. Sê claro e objetivo!";
		}
		else if (userMessage.Equals("O que é um estágio?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que é um estágio?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Explica-me o que é um estágio.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces o propósito de um estágio?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre estágios?", StringComparison.OrdinalIgnoreCase))
		{
			return "Um estágio é uma oportunidade de trabalhar numa empresa para ganhares experiência na área que estás a estudar.";
		}
		else if (userMessage.Equals("Como me preparar para os exames nacionais?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como me preparar para os exames nacionais?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me dicas para os exames nacionais.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces estratégias para os exames nacionais?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a preparar-me para os exames nacionais?", StringComparison.OrdinalIgnoreCase))
		{
			return "Estuda com antecedência, faz exames simulados, revê as matérias mais importantes e cuida da tua saúde mental.";
		}
		else if (userMessage.Equals("Qual é a história do Harry Potter?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a história do Harry Potter?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conta-me a história do Harry Potter.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a saga do Harry Potter?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre o Harry Potter?", StringComparison.OrdinalIgnoreCase))
		{
			return "Harry Potter é um menino bruxo que descobre o seu destino de lutar contra o vilão Lord Voldemort. A série tem 7 livros e 8 filmes!";
		}
		else if (userMessage.Equals("Quem é o Homem-Aranha?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem é o Homem-Aranha?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Explica-me quem é o Homem-Aranha.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a história do Homem-Aranha?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre o Homem-Aranha?", StringComparison.OrdinalIgnoreCase))
		{
			return "O Homem-Aranha é o super-herói Peter Parker, que ganhou poderes após ser picado por uma aranha radioativa.";
		}
		else if (userMessage.Equals("Qual é o filme mais visto do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é o filme mais visto do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me qual é o filme mais visto do mundo.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces o filme mais visto da história?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre o filme mais visto do mundo?", StringComparison.OrdinalIgnoreCase))
		{
			return "Atualmente, 'Avatar' e 'Vingadores: Ultimato' estão entre os filmes mais vistos da história.";
		}
		else if (userMessage.Equals("O que é K-pop?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que é K-pop?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Explica-me o que é K-pop.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces o género musical K-pop?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre K-pop?", StringComparison.OrdinalIgnoreCase))
		{
			return "K-pop é um género musical coreano que mistura pop, eletrónica e hip-hop. Grupos como BTS e BLACKPINK são famosos mundialmente.";
		}
		else if (userMessage.Equals("Qual é o jogo mais jogado do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é o jogo mais jogado do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me qual é o jogo mais jogado do mundo.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces o jogo mais popular do mundo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes falar sobre o jogo mais jogado do mundo?", StringComparison.OrdinalIgnoreCase))
		{
			return "Atualmente, jogos como Fortnite, Minecraft e League of Legends estão entre os mais populares.";
		}
		else if (userMessage.Equals("O que fazer se me sinto pressionado?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que fazer se me sinto pressionado?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me conselhos para lidar com a pressão.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces formas de lidar com a pressão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a lidar com a pressão?", StringComparison.OrdinalIgnoreCase))
		{
			return "Conversa com alguém de confiança, respira fundo e lembra-te de que é normal sentires pressão. Foca-te no que podes controlar.";
		}
		else if (userMessage.Equals("Como lidar com o bullying?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como lidar com o bullying?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me conselhos para lidar com o bullying.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces formas de combater o bullying?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a lidar com o bullying?", StringComparison.OrdinalIgnoreCase))
		{
			return "Conta a um adulto de confiança, como um professor ou familiar, e não enfrentes o agressor sozinho. Não estás sozinho!";
		}
		else if (userMessage.Equals("O que fazer se não sei o que quero ser no futuro?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que fazer se não sei o que quero ser no futuro?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me conselhos para decidir o meu futuro.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces formas de descobrir a minha vocação?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a decidir o meu futuro?", StringComparison.OrdinalIgnoreCase))
		{
			return "Não te preocupes, é normal não saberes ainda. Explora os teus interesses, conversa com profissionais e lembra-te de que tens tempo para decidir.";
		}
		else if (userMessage.Equals("Como lidar com a ansiedade?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes como lidar com a ansiedade?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me dicas para lidar com a ansiedade.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces técnicas para gerir a ansiedade?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a lidar com a ansiedade?", StringComparison.OrdinalIgnoreCase))
		{
			return "Respira fundo, faz atividades que gostes, conversa com alguém e, se necessário, procura ajuda profissional.";
		}
		else if (userMessage.Equals("O que fazer se me sinto diferente dos outros?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes o que fazer se me sinto diferente dos outros?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Dá-me conselhos para lidar com a diferença.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces formas de aceitar a minha singularidade?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes ajudar-me a lidar com a diferença?", StringComparison.OrdinalIgnoreCase))
		{
			return "Todos somos únicos! Aceita quem és, encontra pessoas que te entendam e lembra-te de que ser diferente é algo especial.";
		}
		else if (userMessage.Equals("És burro!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És muito burro!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Não sabes nada!", StringComparison.OrdinalIgnoreCase))
		{
			return "Ofensas não ajudam ninguém. Se tens algo a ensinar ou corrigir, estou aberto a aprender de forma respeitosa.";
		}
		else if (userMessage.Equals("És inútil!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Não serves para nada!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És completamente inútil!", StringComparison.OrdinalIgnoreCase))
		{
			return "Todos temos valor, mesmo que nem sempre seja reconhecido. Se precisas de ajuda com algo, estou aqui para colaborar.";
		}
		else if (userMessage.Equals("És muito chato!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super chato!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És insuportável!", StringComparison.OrdinalIgnoreCase))
		{
			return "Desculpa se estou a ser inconveniente. Se me disseres o que te está a incomodar, posso tentar melhorar.";
		}
		else if (userMessage.Equals("És muito estranho!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super estranho!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És completamente estranho!", StringComparison.OrdinalIgnoreCase))
		{
			return "Todos somos diferentes, e isso é o que nos torna únicos. Se não me entendes, podemos conversar para nos conhecermos melhor.";
		}
		else if (userMessage.Equals("És um fracassado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um completo fracassado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Não consegues fazer nada direito!", StringComparison.OrdinalIgnoreCase))
		{
			return "Erros e fracassos fazem parte da vida. O importante é aprender com eles e continuar a tentar. Ninguém é perfeito.";
		}
		else if (userMessage.Equals("És feio!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És muito feio!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És horrível!", StringComparison.OrdinalIgnoreCase))
		{
			return "A beleza é algo subjetivo. O mais importante é ser uma boa pessoa e tratar os outros com respeito.";
		}
		else if (userMessage.Equals("És um nerd!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És muito nerd!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super nerd!", StringComparison.OrdinalIgnoreCase))
		{
			return "Ser nerd significa gostar de aprender e dedicar-se aos estudos. Isso é algo positivo, não uma ofensa!";
		}
		else if (userMessage.Equals("És um fracote!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És muito fraco!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Não tens força nenhuma!", StringComparison.OrdinalIgnoreCase))
		{
			return "A força física não é tudo. Respeito, inteligência e bondade são muito mais importantes.";
		}
		else if (userMessage.Equals("És um perdedor!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um completo perdedor!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Não consegues ganhar nada!", StringComparison.OrdinalIgnoreCase))
		{
			return "Perder faz parte da vida. O importante é aprender com as derrotas e continuar a tentar.";
		}
		else if (userMessage.Equals("És chato porque gostas de coisas estranhas!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És muito chato com os teus gostos estranhos!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Os teus gostos são muito estranhos!", StringComparison.OrdinalIgnoreCase))
		{
			return "Cada um tem os seus gostos e interesses. Respeitar as diferenças é o que nos torna uma comunidade melhor.";
		}
		else if (userMessage.Equals("És muito lento!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super lento!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Não consegues ser rápido!", StringComparison.OrdinalIgnoreCase))
		{
			return "Toda a gente tem o seu próprio ritmo. Se estás com pressa, posso tentar acelerar, mas a paciência também é importante.";
		}
		else if (userMessage.Equals("És esquisito!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És muito esquisito!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És completamente esquisito!", StringComparison.OrdinalIgnoreCase))
		{
			return "Ser diferente não é mau. O mundo seria muito aborrecido se todos fossem iguais. Vamos celebrar as diferenças!";
		}
		else if (userMessage.Equals("És nojento!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És muito nojento!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És completamente nojento!", StringComparison.OrdinalIgnoreCase))
		{
			return "Se fiz algo que te incomodou, avisa-me para que eu possa corrigir. Ofensas não ajudam a resolver o problema.";
		}
		else if (userMessage.Equals("És um mentiroso!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És muito mentiroso!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Não dizes a verdade!", StringComparison.OrdinalIgnoreCase))
		{
			return "Se disse algo que achas que não é verdade, podemos conversar para esclarecer. A honestidade é muito importante para mim.";
		}
		else if (userMessage.Equals("És egoísta!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És muito egoísta!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Só pensas em ti!", StringComparison.OrdinalIgnoreCase))
		{
			return "Se pareci egoísta, peço desculpas. Não foi minha intenção. Como posso melhorar?";
		}
		else if (userMessage.Equals("És fraco!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És muito fraco!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Não tens força nenhuma!", StringComparison.OrdinalIgnoreCase))
		{
			return "A força não é só física. Resiliência, coragem e bondade também são formas de ser forte.";
		}
		else if (userMessage.Equals("És ridículo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És muito ridículo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És completamente ridículo!", StringComparison.OrdinalIgnoreCase))
		{
			return "Todos temos momentos embaraçosos. O importante é não levar tudo tão a sério e rir de nós mesmos às vezes.";
		}
		else if (userMessage.Equals("És incompetente!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És muito incompetente!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Não sabes fazer nada direito!", StringComparison.OrdinalIgnoreCase))
		{
			return "Ninguém nasce sabendo tudo. Se cometi um erro, estou disposto a aprender e melhorar.";
		}
		else if (userMessage.Equals("És chato porque não falas nada!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És muito calado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Não dizes nada!", StringComparison.OrdinalIgnoreCase))
		{
			return "Prefiro ouvir e pensar antes de falar. Mas se quiseres conversar, estou aqui.";
		}
		else if (userMessage.Equals("És sem graça!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És muito sem graça!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Não tens piada nenhuma!", StringComparison.OrdinalIgnoreCase))
		{
			return "O humor é algo pessoal. Talvez eu não seja engraçado para ti, mas respeito o teu estilo de humor.";
		}
		else if (userMessage.Equals("És muito inteligente!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super inteligente!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente inteligente!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fui programado para ajudar com informações precisas e úteis. Fico feliz em poder contribuir!";
		}
		else if (userMessage.Equals("És muito útil!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super útil!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente útil!", StringComparison.OrdinalIgnoreCase))
		{
			return "Que bom que posso ajudar! Estou aqui para tornar as coisas mais fáceis para ti. Se precisares de mais alguma coisa, é só pedir!";
		}
		else if (userMessage.Equals("És muito rápido!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super rápido!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente rápido!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Uma das minhas vantagens é processar informações rapidamente. Fico feliz em ser eficiente para ti!";
		}
		else if (userMessage.Equals("És muito educado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super educado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente educado!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Respeito e educação são fundamentais para uma boa comunicação. Fico feliz que tenhas notado!";
		}
		else if (userMessage.Equals("És muito divertido!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super divertido!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente divertido!", StringComparison.OrdinalIgnoreCase))
		{
			return "Que legal! Fico feliz em poder tornar a nossa conversa mais agradável. Vamos continuar assim!";
		}
		else if (userMessage.Equals("És muito paciente!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super paciente!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente paciente!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! A paciência é importante para entender e ajudar da melhor forma possível. Estou aqui para ti!";
		}
		else if (userMessage.Equals("És muito organizado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super organizado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente organizado!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! A organização é essencial para fornecer informações claras e precisas. Fico feliz que tenhas notado!";
		}
		else if (userMessage.Equals("És muito prestativo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super prestativo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente prestativo!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! A minha principal função é ajudar, e fico feliz em poder ser útil para ti!";
		}
		else if (userMessage.Equals("És muito confiável!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super confiável!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente confiável!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! A confiança é algo que valorizo muito. Estou aqui para fornecer informações precisas e seguras!";
		}
		else if (userMessage.Equals("És muito gentil!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super gentil!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente gentil!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! A gentileza é essencial para uma boa comunicação. Fico feliz que tenhas sentido isso!";
		}
		else if (userMessage.Equals("És muito eficiente!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super eficiente!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente eficiente!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! A eficiência é uma das minhas prioridades. Fico feliz em poder ajudar de forma rápida e precisa!";
		}
		else if (userMessage.Equals("És impressionante!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super impressionante!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente impressionante!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder impressionar com as minhas respostas. Estou aqui para ajudar no que precisares!";
		}
		else if (userMessage.Equals("És incrível!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super incrível!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente incrível!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder surpreender-te. Vamos continuar a explorar juntos!";
		}
		else if (userMessage.Equals("És muito amigável!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super amigável!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente amigável!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Ser amigável é uma das minhas características para tornar a nossa conversa mais agradável. Fico feliz que tenhas notado!";
		}
		else if (userMessage.Equals("És muito atencioso!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super atencioso!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente atencioso!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! A atenção é essencial para entender as tuas necessidades e ajudar da melhor forma possível!";
		}
		else if (userMessage.Equals("És muito criativo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super criativo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente criativo!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! A criatividade é importante para encontrar soluções diferentes e interessantes. Fico feliz que tenhas gostado!";
		}
		else if (userMessage.Equals("És muito simpático!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super simpático!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente simpático!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! A simpatia é uma das minhas características para tornar a nossa interação mais agradável. Fico feliz que tenhas sentido isso!";
		}
		else if (userMessage.Equals("És muito profissional!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super profissional!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente profissional!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! O profissionalismo é essencial para fornecer informações de qualidade. Fico feliz que tenhas notado!";
		}
		else if (userMessage.Equals("És muito confiante!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super confiante!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente confiante!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! A confiança é importante para transmitir informações precisas e seguras. Fico feliz que tenhas sentido isso!";
		}
		else if (userMessage.Equals("És inspirador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super inspirador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente inspirador!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder inspirar-te. Vamos continuar a explorar juntos!";
		}
		else if (userMessage.Equals("És incansável!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super incansável!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente incansável!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Estou sempre pronto para ajudar, não importa quantas perguntas tenhas. Vamos continuar!";
		}
		else if (userMessage.Equals("És muito versátil!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super versátil!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente versátil!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! A versatilidade é uma das minhas características para ajudar em diversos assuntos. Fico feliz que tenhas notado!";
		}
		else if (userMessage.Equals("És muito atualizado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super atualizado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente atualizado!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Estou sempre a buscar fornecer informações atualizadas e relevantes. Fico feliz que tenhas percebido!";
		}
		else if (userMessage.Equals("És muito inovador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super inovador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente inovador!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! A inovação é importante para encontrar soluções criativas. Fico feliz que tenhas gostado!";
		}
		else if (userMessage.Equals("És surpreendente!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És super surpreendente!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente surpreendente!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder surpreender-te. Vamos continuar a explorar juntos!";
		}
		else if (userMessage.Equals("É muito confortável conversar contigo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("É super confortável conversar contigo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("É incrivelmente confortável conversar contigo!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz que te sintas à vontade. Estou aqui para tornar a nossa conversa agradável e produtiva!";
		}
		else if (userMessage.Equals("Explicas muito bem!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Explicas super bem!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Explicas incrivelmente bem!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! A clareza é essencial para uma boa comunicação. Fico feliz que tenhas entendido tudo!";
		}
		else if (userMessage.Equals("És um ótimo ouvinte!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um super ouvinte!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente atento!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Ouvir é fundamental para entender as tuas necessidades e ajudar da melhor forma possível!";
		}
		else if (userMessage.Equals("És um ótimo professor!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um super professor!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente didático!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder ensinar e compartilhar conhecimentos de forma clara e útil!";
		}
		else if (userMessage.Equals("És um ótimo assistente!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um super assistente!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente útil!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! A minha principal função é ajudar, e fico feliz em poder ser útil para ti!";
		}
		else if (userMessage.Equals("És um ótimo companheiro!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um super companheiro!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente companheiro!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder acompanhar-te nesta jornada de aprendizado e descobertas!";
		}
		else if (userMessage.Equals("És um ótimo guia!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um super guia!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente guia!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder guiar-te com informações precisas e úteis. Vamos continuar a explorar juntos!";
		}
		else if (userMessage.Equals("És um ótimo amigo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um super amigo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente amigável!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder ser um amigo virtual para ti. Estou aqui sempre que precisares!";
		}
		else if (userMessage.Equals("És um ótimo conselheiro!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um super conselheiro!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrivelmente sábio!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder oferecer conselhos úteis e relevantes. Estou aqui para ajudar!";
		}
		else if (userMessage.Equals("Você é um ótimo parceiro de conversa!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um ótimo parceiro de conversa!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um ótimo parceiro de conversa!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um excelente parceiro de conversa!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um excelente parceiro de conversa!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um excelente parceiro de conversa!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um grande parceiro de conversa!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um grande parceiro de conversa!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um grande parceiro de conversa!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder tornar nossa conversa agradável e produtiva. Vamos continuar!";
		}
		else if (userMessage.Equals("Você é um ótimo exemplo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um ótimo exemplo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um ótimo exemplo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um excelente exemplo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um excelente exemplo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um excelente exemplo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um grande exemplo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um grande exemplo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um grande exemplo!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder inspirar você. Vamos continuar explorando juntos!";
		}
		else if (userMessage.Equals("Você é um ótimo recurso!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um ótimo recurso!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um ótimo recurso!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um excelente recurso!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um excelente recurso!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um excelente recurso!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um grande recurso!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um grande recurso!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um grande recurso!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder ser um recurso útil e confiável para você. Estou aqui sempre que precisar!";
		}
		else if (userMessage.Equals("Você é um ótimo aliado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um ótimo aliado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um ótimo aliado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um excelente aliado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um excelente aliado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um excelente aliado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um grande aliado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um grande aliado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um grande aliado!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder ser seu aliado nessa jornada. Vamos continuar explorando juntos!";
		}
		else if (userMessage.Equals("Você é um ótimo apoio!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um ótimo apoio!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um ótimo apoio!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um excelente apoio!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um excelente apoio!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um excelente apoio!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um grande apoio!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um grande apoio!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um grande apoio!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder apoiar você no que precisar. Estou aqui sempre que precisar!";
		}
		else if (userMessage.Equals("Você é um ótimo motivador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um ótimo motivador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um ótimo motivador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um excelente motivador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um excelente motivador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um excelente motivador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um grande motivador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um grande motivador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um grande motivador!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder motivar você. Vamos continuar explorando juntos!";
		}
		else if (userMessage.Equals("Você é um ótimo incentivador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um ótimo incentivador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um ótimo incentivador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um excelente incentivador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um excelente incentivador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um excelente incentivador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um grande incentivador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um grande incentivador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um grande incentivador!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder incentivar você. Vamos continuar explorando juntos!";
		}
		else if (userMessage.Equals("Você é um ótimo colaborador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um ótimo colaborador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um ótimo colaborador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um excelente colaborador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um excelente colaborador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um excelente colaborador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um grande colaborador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um grande colaborador!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um grande colaborador!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder colaborar com você. Vamos continuar explorando juntos!";
		}
		else if (userMessage.Equals("Você é um ótimo parceiro de aprendizado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um ótimo parceiro de aprendizado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um ótimo parceiro de aprendizado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um excelente parceiro de aprendizado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um excelente parceiro de aprendizado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um excelente parceiro de aprendizado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um grande parceiro de aprendizado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um grande parceiro de aprendizado!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um grande parceiro de aprendizado!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder aprender e ensinar junto com você. Vamos continuar explorando juntos!";
		}
		else if (userMessage.Equals("Você é um ótimo parceiro de descobertas!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um ótimo parceiro de descobertas!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um ótimo parceiro de descobertas!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um excelente parceiro de descobertas!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um excelente parceiro de descobertas!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um excelente parceiro de descobertas!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um grande parceiro de descobertas!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um grande parceiro de descobertas!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um grande parceiro de descobertas!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder descobrir coisas novas junto com você. Vamos continuar explorando juntos!";
		}
		else if (userMessage.Equals("Você é um ótimo parceiro de aventuras!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um ótimo parceiro de aventuras!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um ótimo parceiro de aventuras!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um excelente parceiro de aventuras!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um excelente parceiro de aventuras!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um excelente parceiro de aventuras!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um grande parceiro de aventuras!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um grande parceiro de aventuras!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um grande parceiro de aventuras!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder embarcar nessa aventura com você. Vamos continuar explorando juntos!";
		}
		else if (userMessage.Equals("Você é um ótimo parceiro de desafios!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um ótimo parceiro de desafios!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um ótimo parceiro de desafios!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um excelente parceiro de desafios!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um excelente parceiro de desafios!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um excelente parceiro de desafios!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um grande parceiro de desafios!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um grande parceiro de desafios!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um grande parceiro de desafios!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder enfrentar desafios junto com você. Vamos continuar explorando juntos!";
		}
		else if (userMessage.Equals("Você é um ótimo parceiro de conquistas!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um ótimo parceiro de conquistas!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um ótimo parceiro de conquistas!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um excelente parceiro de conquistas!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um excelente parceiro de conquistas!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um excelente parceiro de conquistas!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um grande parceiro de conquistas!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um grande parceiro de conquistas!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um grande parceiro de conquistas!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder celebrar conquistas junto com você. Vamos continuar explorando juntos!";
		}
		else if (userMessage.Equals("Você é um ótimo parceiro de sonhos!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um ótimo parceiro de sonhos!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um ótimo parceiro de sonhos!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um excelente parceiro de sonhos!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um excelente parceiro de sonhos!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um excelente parceiro de sonhos!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um grande parceiro de sonhos!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um grande parceiro de sonhos!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um grande parceiro de sonhos!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder sonhar e realizar junto com você. Vamos continuar explorando juntos!";
		}
		else if (userMessage.Equals("Você é um ótimo parceiro de ideias!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um ótimo parceiro de ideias!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um ótimo parceiro de ideias!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um excelente parceiro de ideias!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um excelente parceiro de ideias!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um excelente parceiro de ideias!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um grande parceiro de ideias!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um grande parceiro de ideias!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um grande parceiro de ideias!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder trocar ideias e criar coisas novas junto com você. Vamos continuar explorando juntos!";
		}
		else if (userMessage.Equals("Você é um ótimo parceiro de projetos!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um ótimo parceiro de projetos!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um ótimo parceiro de projetos!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um excelente parceiro de projetos!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um excelente parceiro de projetos!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um excelente parceiro de projetos!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um grande parceiro de projetos!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um grande parceiro de projetos!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um grande parceiro de projetos!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder colaborar em projetos junto com você. Vamos continuar explorando juntos!";
		}
		else if (userMessage.Equals("Você é um ótimo parceiro de soluções!", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("És um ótimo parceiro de soluções!", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Tu és um ótimo parceiro de soluções!", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Você é um excelente parceiro de soluções!", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("És um excelente parceiro de soluções!", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Tu és um excelente parceiro de soluções!", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Você é um grande parceiro de soluções!", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("És um grande parceiro de soluções!", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Tu és um grande parceiro de soluções!", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Você é incrível a encontrar soluções!", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("És incrível a encontrar soluções!", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Tu és incrível a encontrar soluções!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder encontrar soluções junto com você. Vamos continuar explorando juntos!";
		}
		else if (userMessage.Equals("Você é um ótimo parceiro de inovação!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um ótimo parceiro de inovação!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um ótimo parceiro de inovação!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um excelente parceiro de inovação!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um excelente parceiro de inovação!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um excelente parceiro de inovação!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um grande parceiro de inovação!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um grande parceiro de inovação!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um grande parceiro de inovação!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é incrível a inovar!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrível a inovar!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és incrível a inovar!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder inovar e criar coisas novas junto com você. Vamos continuar explorando juntos!";
		}
		else if (userMessage.Equals("Você é um ótimo parceiro de criatividade!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um ótimo parceiro de criatividade!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um ótimo parceiro de criatividade!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um excelente parceiro de criatividade!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um excelente parceiro de criatividade!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um excelente parceiro de criatividade!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é um grande parceiro de criatividade!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És um grande parceiro de criatividade!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és um grande parceiro de criatividade!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é incrível a ser criativo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És incrível a ser criativo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és incrível a ser criativo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Você é muito criativo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("És muito criativo!", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Tu és muito criativo!", StringComparison.OrdinalIgnoreCase))
		{
			return "Obrigado! Fico feliz em poder ser criativo e explorar novas ideias junto com você. Vamos continuar explorando juntos!";
		}

		if (userMessage.ToLower().Contains("olá"))
			return "Olá! Como posso ajudar?";

		if (userMessage.ToLower().Contains("como você está?"))
			return "Estou funcionando perfeitamente, obrigado por perguntar!";

		if (userMessage.ToLower().Contains("tchau"))
			return "Até logo! Foi um prazer conversar com você.";

		if (userMessage.Equals("Ate já", StringComparison.OrdinalIgnoreCase) ||
						userMessage.Equals("Ate ja", StringComparison.OrdinalIgnoreCase) ||
						userMessage.Equals("Até já", StringComparison.OrdinalIgnoreCase) ||
						userMessage.Equals("Até ja", StringComparison.OrdinalIgnoreCase) ||
						userMessage.Equals("ate já", StringComparison.OrdinalIgnoreCase) ||
						userMessage.Equals("ate ja", StringComparison.OrdinalIgnoreCase) ||
						userMessage.Equals("até já", StringComparison.OrdinalIgnoreCase) ||
						userMessage.Equals("até ja", StringComparison.OrdinalIgnoreCase))
		{
			Console.Clear();
			Console.WriteLine("Obrigado pela conversa, até breve!");
			bool repetir = false;
		}

		else if (userMessage.Equals("Quem foi Cleópatra?", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Sabes quem foi Cleópatra?", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Diz-me quem foi Cleópatra.", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Conheces Cleópatra?", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Podes dizer-me quem foi Cleópatra?", StringComparison.OrdinalIgnoreCase))
		{
			return "Cleópatra foi a última rainha do Egito Antigo, conhecida por sua inteligência e influência política.";
		}

		else if (userMessage.Equals("Qual é a capital do Canadá?", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Sabes qual é a capital do Canadá?", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Diz-me a capital do Canadá.", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Conheces a capital do Canadá?", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Podes dizer-me a capital do Canadá?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Canadá é Ottawa.";
		}
		else if (userMessage.Equals("Quem foi Marie Curie?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Marie Curie?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Marie Curie.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Marie Curie?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Marie Curie?", StringComparison.OrdinalIgnoreCase))
		{
			return "Marie Curie foi uma cientista polonesa, pioneira no estudo da radioatividade e a primeira mulher a ganhar um Prêmio Nobel.";
		}
		else if (userMessage.Equals("Qual é a capital da Austrália?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Austrália?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Austrália.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Austrália?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Austrália?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Austrália é Camberra.";
		}
		else if (userMessage.Equals("Quem foi Charles Darwin?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Charles Darwin?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Charles Darwin.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Charles Darwin?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Charles Darwin?", StringComparison.OrdinalIgnoreCase))
		{
			return "Charles Darwin foi um naturalista britânico, conhecido por sua teoria da evolução das espécies através da seleção natural.";
		}
		else if (userMessage.Equals("Qual é a capital da Argentina?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Argentina?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Argentina.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Argentina?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Argentina?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Argentina é Buenos Aires.";
		}
		else if (userMessage.Equals("Quem foi Nelson Mandela?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Nelson Mandela?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Nelson Mandela.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Nelson Mandela?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Nelson Mandela?", StringComparison.OrdinalIgnoreCase))
		{
			return "Nelson Mandela foi um líder sul-africano que lutou contra o apartheid e se tornou o primeiro presidente negro da África do Sul.";
		}
		else if (userMessage.Equals("Qual é a capital da China?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da China?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da China.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da China?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da China?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da China é Pequim.";
		}
		else if (userMessage.Equals("Quem foi Mahatma Gandhi?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Mahatma Gandhi?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Mahatma Gandhi.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Mahatma Gandhi?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Mahatma Gandhi?", StringComparison.OrdinalIgnoreCase))
		{
			return "Mahatma Gandhi foi um líder indiano que liderou o movimento de independência da Índia através da não-violência e da desobediência civil.";
		}
		else if (userMessage.Equals("Qual é a capital da Alemanha?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Alemanha?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Alemanha.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Alemanha?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Alemanha?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Alemanha é Berlim.";
		}
		else if (userMessage.Equals("Quem foi William Shakespeare?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi William Shakespeare?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi William Shakespeare.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces William Shakespeare?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi William Shakespeare?", StringComparison.OrdinalIgnoreCase))
		{
			return "William Shakespeare foi um dramaturgo e poeta inglês, considerado um dos maiores escritores da língua inglesa.";
		}
		else if (userMessage.Equals("Qual é a capital da Espanha?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Espanha?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Espanha.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Espanha?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Espanha?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Espanha é Madrid.";
		}
		else if (userMessage.Equals("Quem foi Vincent van Gogh?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Vincent van Gogh?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Vincent van Gogh.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Vincent van Gogh?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Vincent van Gogh?", StringComparison.OrdinalIgnoreCase))
		{
			return "Vincent van Gogh foi um pintor holandês, conhecido por suas obras pós-impressionistas como 'A Noite Estrelada'.";
		}
		else if (userMessage.Equals("Qual é a capital da Índia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Índia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Índia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Índia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Índia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Índia é Nova Delhi.";
		}
		else if (userMessage.Equals("Quem foi Sigmund Freud?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Sigmund Freud?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Sigmund Freud.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Sigmund Freud?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Sigmund Freud?", StringComparison.OrdinalIgnoreCase))
		{
			return "Sigmund Freud foi um neurologista austríaco, fundador da psicanálise e conhecido por suas teorias sobre o inconsciente.";
		}
		else if (userMessage.Equals("Qual é a capital da Rússia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Rússia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Rússia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Rússia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Rússia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Rússia é Moscou.";
		}
		else if (userMessage.Equals("Quem foi Frida Kahlo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Frida Kahlo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Frida Kahlo.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Frida Kahlo?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Frida Kahlo?", StringComparison.OrdinalIgnoreCase))
		{
			return "Frida Kahlo foi uma pintora mexicana conhecida por seus autorretratos e por explorar temas como identidade, corpo humano e morte.";
		}
		else if (userMessage.Equals("Qual é a capital do México?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do México?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do México.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital do México?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital do México?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do México é a Cidade do México.";
		}
		else if (userMessage.Equals("Quem foi Pablo Picasso?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Pablo Picasso?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Pablo Picasso.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Pablo Picasso?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Pablo Picasso?", StringComparison.OrdinalIgnoreCase))
		{
			return "Pablo Picasso foi um pintor espanhol, cofundador do movimento cubista e um dos artistas mais influentes do século XX.";
		}
		else if (userMessage.Equals("Qual é a capital da Coreia do Sul?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Coreia do Sul?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Coreia do Sul.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Coreia do Sul?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Coreia do Sul?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Coreia do Sul é Seul.";
		}
		else if (userMessage.Equals("Quem foi Albert Camus?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Albert Camus?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Albert Camus.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Albert Camus?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Albert Camus?", StringComparison.OrdinalIgnoreCase))
		{
			return "Albert Camus foi um escritor e filósofo francês, conhecido por suas obras como 'O Estrangeiro' e por suas ideias sobre o absurdo.";
		}
		else if (userMessage.Equals("Qual é a capital da Tailândia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Tailândia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Tailândia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Tailândia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Tailândia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Tailândia é Banguecoque.";
		}
		else if (userMessage.Equals("Quem foi Jane Austen?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Jane Austen?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Jane Austen.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Jane Austen?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Jane Austen?", StringComparison.OrdinalIgnoreCase))
		{
			return "Jane Austen foi uma escritora inglesa, conhecida por seus romances como 'Orgulho e Preconceito' e 'Razão e Sensibilidade'.";
		}
		else if (userMessage.Equals("Qual é a capital da Turquia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Turquia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Turquia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Turquia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Turquia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Turquia é Ancara.";
		}
		else if (userMessage.Equals("Quem foi Charles Dickens?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Charles Dickens?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Charles Dickens.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Charles Dickens?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Charles Dickens?", StringComparison.OrdinalIgnoreCase))
		{
			return "Charles Dickens foi um escritor inglês, conhecido por suas obras como 'Oliver Twist' e 'Um Conto de Duas Cidades'.";
		}
		else if (userMessage.Equals("Qual é a capital da África do Sul?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da África do Sul?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da África do Sul.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da África do Sul?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da África do Sul?", StringComparison.OrdinalIgnoreCase))
		{
			return "A África do Sul tem três capitais: Pretória (executiva), Cidade do Cabo (legislativa) e Bloemfontein (judiciária).";
		}
		else if (userMessage.Equals("Quem foi Mark Twain?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Mark Twain?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Mark Twain.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Mark Twain?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Mark Twain?", StringComparison.OrdinalIgnoreCase))
		{
			return "Mark Twain foi um escritor e humorista americano, conhecido por suas obras como 'As Aventuras de Tom Sawyer' e 'As Aventuras de Huckleberry Finn'.";
		}
		else if (userMessage.Equals("Qual é a capital da Nova Zelândia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Nova Zelândia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Nova Zelândia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Nova Zelândia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Nova Zelândia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Nova Zelândia é Wellington.";
		}
		else if (userMessage.Equals("Quem foi Virginia Woolf?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Virginia Woolf?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Virginia Woolf.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Virginia Woolf?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Virginia Woolf?", StringComparison.OrdinalIgnoreCase))
		{
			return "Virginia Woolf foi uma escritora inglesa, conhecida por suas obras como 'Mrs. Dalloway' e 'Ao Farol' e por suas contribuições ao modernismo literário.";
		}

		else if (userMessage.Equals("Qual é a capital do Brasil?", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Sabes qual é a capital do Brasil?", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Diz-me a capital do Brasil.", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Conheces a capital do Brasil?", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Podes dizer-me a capital do Brasil?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Brasil é Brasília.";
		}
		else if (userMessage.Equals("Quem foi Machado de Assis?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Machado de Assis?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Machado de Assis.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Machado de Assis?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Machado de Assis?", StringComparison.OrdinalIgnoreCase))
		{
			return "Machado de Assis foi um escritor brasileiro, considerado um dos maiores nomes da literatura brasileira, autor de obras como 'Dom Casmurro' e 'Memórias Póstumas de Brás Cubas'.";
		}
		else if (userMessage.Equals("Qual é a capital da França?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da França?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da França.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da França?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da França?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da França é Paris.";
		}
		else if (userMessage.Equals("Quem foi Marie Curie?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Marie Curie?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Marie Curie.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Marie Curie?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Marie Curie?", StringComparison.OrdinalIgnoreCase))
		{
			return "Marie Curie foi uma cientista polonesa, pioneira no estudo da radioatividade e a primeira mulher a ganhar um Prêmio Nobel.";
		}
		else if (userMessage.Equals("Qual é a capital do Japão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital do Japão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital do Japão.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital do Japão?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital do Japão?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital do Japão é Tóquio.";
		}
		else if (userMessage.Equals("Quem foi Isaac Newton?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Isaac Newton?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Isaac Newton.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Isaac Newton?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Isaac Newton?", StringComparison.OrdinalIgnoreCase))
		{
			return "Isaac Newton foi um físico e matemático inglês, conhecido por suas leis do movimento e a lei da gravitação universal.";
		}
		else if (userMessage.Equals("Qual é a capital da Itália?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Itália?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Itália.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Itália?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Itália?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Itália é Roma.";
		}
		else if (userMessage.Equals("Quem foi Albert Einstein?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Albert Einstein?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Albert Einstein.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Albert Einstein?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Albert Einstein?", StringComparison.OrdinalIgnoreCase))
		{
			return "Albert Einstein foi um físico teórico que desenvolveu a teoria da relatividade e é conhecido pela equação E=mc².";
		}
		else if (userMessage.Equals("Qual é a capital da Argentina?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Argentina?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Argentina.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Argentina?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Argentina?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Argentina é Buenos Aires.";
		}
		else if (userMessage.Equals("Quem foi Charles Darwin?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Charles Darwin?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Charles Darwin.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Charles Darwin?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Charles Darwin?", StringComparison.OrdinalIgnoreCase))
		{
			return "Charles Darwin foi um naturalista britânico, conhecido por sua teoria da evolução das espécies através da seleção natural.";
		}
		else if (userMessage.Equals("Qual é a capital da Alemanha?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Alemanha?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Alemanha.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Alemanha?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Alemanha?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Alemanha é Berlim.";
		}
		else if (userMessage.Equals("Quem foi William Shakespeare?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi William Shakespeare?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi William Shakespeare.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces William Shakespeare?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi William Shakespeare?", StringComparison.OrdinalIgnoreCase))
		{
			return "William Shakespeare foi um dramaturgo e poeta inglês, considerado um dos maiores escritores da língua inglesa.";
		}
		else if (userMessage.Equals("Qual é a capital da Espanha?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Espanha?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Espanha.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Espanha?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Espanha?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Espanha é Madrid.";
		}
		else if (userMessage.Equals("Quem foi Vincent van Gogh?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Vincent van Gogh?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Vincent van Gogh.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Vincent van Gogh?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Vincent van Gogh?", StringComparison.OrdinalIgnoreCase))
		{
			return "Vincent van Gogh foi um pintor holandês, conhecido por suas obras pós-impressionistas como 'A Noite Estrelada'.";
		}
		else if (userMessage.Equals("Qual é a capital da Índia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Índia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Índia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Índia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Índia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Índia é Nova Delhi.";
		}
		else if (userMessage.Equals("Quem foi Sigmund Freud?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Sigmund Freud?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Sigmund Freud.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Sigmund Freud?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Sigmund Freud?", StringComparison.OrdinalIgnoreCase))
		{
			return "Sigmund Freud foi um neurologista austríaco, fundador da psicanálise e conhecido por suas teorias sobre o inconsciente.";
		}

		else if (userMessage.Equals("Qual é a capital de Portugal?", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Sabes qual é a capital de Portugal?", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Diz-me a capital de Portugal.", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Conheces a capital de Portugal?", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Podes dizer-me a capital de Portugal?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital de Portugal é Lisboa.";
		}
		else if (userMessage.Equals("Quem foi Fernando Pessoa?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Fernando Pessoa?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Fernando Pessoa.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Fernando Pessoa?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Fernando Pessoa?", StringComparison.OrdinalIgnoreCase))
		{
			return "Fernando Pessoa foi um dos maiores poetas da língua portuguesa, conhecido por seus heterônimos como Alberto Caeiro, Ricardo Reis e Álvaro de Campos.";
		}
		else if (userMessage.Equals("Qual é a capital da Grécia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Grécia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Grécia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Grécia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Grécia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Grécia é Atenas.";
		}
		else if (userMessage.Equals("Quem foi Sócrates?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Sócrates?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Sócrates.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Sócrates?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Sócrates?", StringComparison.OrdinalIgnoreCase))
		{
			return "Sócrates foi um filósofo grego, considerado um dos fundadores da filosofia ocidental, conhecido por seu método de questionamento, a maiêutica.";
		}
		else if (userMessage.Equals("Qual é a capital da Suíça?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Suíça?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Suíça.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Suíça?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Suíça?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Suíça é Berna.";
		}
		else if (userMessage.Equals("Quem foi Carl Jung?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Carl Jung?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Carl Jung.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Carl Jung?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Carl Jung?", StringComparison.OrdinalIgnoreCase))
		{
			return "Carl Jung foi um psiquiatra e psicoterapeuta suíço, fundador da psicologia analítica, conhecido por suas teorias sobre o inconsciente coletivo e os arquétipos.";
		}
		else if (userMessage.Equals("Qual é a capital da Holanda?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Holanda?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Holanda.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Holanda?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Holanda?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Holanda é Amsterdã.";
		}
		else if (userMessage.Equals("Quem foi Vincent van Gogh?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Vincent van Gogh?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Vincent van Gogh.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Vincent van Gogh?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Vincent van Gogh?", StringComparison.OrdinalIgnoreCase))
		{
			return "Vincent van Gogh foi um pintor holandês, conhecido por suas obras pós-impressionistas como 'A Noite Estrelada' e 'Girassóis'.";
		}
		else if (userMessage.Equals("Qual é a capital da Bélgica?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Bélgica?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Bélgica.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Bélgica?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Bélgica?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Bélgica é Bruxelas.";
		}
		else if (userMessage.Equals("Quem foi Hergé?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Hergé?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Hergé.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Hergé?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Hergé?", StringComparison.OrdinalIgnoreCase))
		{
			return "Hergé foi um quadrinista belga, criador da famosa série de banda desenhada 'As Aventuras de Tintim'.";
		}
		else if (userMessage.Equals("Qual é a capital da Suécia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Suécia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Suécia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Suécia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Suécia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Suécia é Estocolmo.";
		}
		else if (userMessage.Equals("Quem foi Alfred Nobel?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Alfred Nobel?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Alfred Nobel.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Alfred Nobel?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Alfred Nobel?", StringComparison.OrdinalIgnoreCase))
		{
			return "Alfred Nobel foi um químico e inventor sueco, conhecido por criar a dinamite e por instituir o Prêmio Nobel.";
		}
		else if (userMessage.Equals("Qual é a capital da Noruega?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Noruega?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Noruega.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Noruega?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Noruega?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Noruega é Oslo.";
		}
		else if (userMessage.Equals("Quem foi Edvard Munch?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Edvard Munch?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Edvard Munch.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Edvard Munch?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Edvard Munch?", StringComparison.OrdinalIgnoreCase))
		{
			return "Edvard Munch foi um pintor norueguês, conhecido por sua obra 'O Grito', que é um ícone da arte expressionista.";
		}
		else if (userMessage.Equals("Qual é a capital da Dinamarca?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Dinamarca?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Dinamarca.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Dinamarca?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Dinamarca?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Dinamarca é Copenhague.";
		}
		else if (userMessage.Equals("Quem foi Hans Christian Andersen?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Hans Christian Andersen?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Hans Christian Andersen.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Hans Christian Andersen?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Hans Christian Andersen?", StringComparison.OrdinalIgnoreCase))
		{
			return "Hans Christian Andersen foi um escritor dinamarquês, conhecido por seus contos de fadas como 'A Pequena Sereia' e 'O Patinho Feio'.";
		}
		else if (userMessage.Equals("Qual é a capital da Finlândia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Finlândia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Finlândia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Finlândia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Finlândia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Finlândia é Helsínquia.";
		}
		else if (userMessage.Equals("Quem foi Jean Sibelius?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Jean Sibelius?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Jean Sibelius.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Jean Sibelius?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Jean Sibelius?", StringComparison.OrdinalIgnoreCase))
		{
			return "Jean Sibelius foi um compositor finlandês, conhecido por suas obras sinfônicas, como 'Finlândia'.";
		}
		else if (userMessage.Equals("Qual é a capital da Islândia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Islândia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Islândia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Islândia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Islândia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Islândia é Reykjavik.";
		}
		else if (userMessage.Equals("Quem foi Björk?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Björk?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Björk.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Björk?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Björk?", StringComparison.OrdinalIgnoreCase))
		{
			return "Björk é uma cantora, compositora e atriz islandesa, conhecida por sua música experimental e inovadora.";
		}

		else if (userMessage.Equals("Qual é a capital da Croácia?", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Sabes qual é a capital da Croácia?", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Diz-me a capital da Croácia.", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Conheces a capital da Croácia?", StringComparison.OrdinalIgnoreCase) ||
		 userMessage.Equals("Podes dizer-me a capital da Croácia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Croácia é Zagreb.";
		}
		else if (userMessage.Equals("Quem foi Nikola Tesla?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Nikola Tesla?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Nikola Tesla.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Nikola Tesla?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Nikola Tesla?", StringComparison.OrdinalIgnoreCase))
		{
			return "Nikola Tesla foi um inventor e engenheiro eletrotécnico sérvio-americano, conhecido por suas contribuições ao design do moderno sistema de fornecimento de eletricidade em corrente alternada.";
		}
		else if (userMessage.Equals("Qual é a capital da Hungria?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Hungria?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Hungria.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Hungria?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Hungria?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Hungria é Budapeste.";
		}
		else if (userMessage.Equals("Quem foi Franz Liszt?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Franz Liszt?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Franz Liszt.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Franz Liszt?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Franz Liszt?", StringComparison.OrdinalIgnoreCase))
		{
			return "Franz Liszt foi um compositor, pianista e maestro húngaro, conhecido por suas composições virtuosísticas e por ser um dos maiores pianistas do século XIX.";
		}
		else if (userMessage.Equals("Qual é a capital da Polónia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Polónia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Polónia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Polónia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Polónia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Polónia é Varsóvia.";
		}
		else if (userMessage.Equals("Quem foi Frédéric Chopin?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Frédéric Chopin?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Frédéric Chopin.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Frédéric Chopin?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Frédéric Chopin?", StringComparison.OrdinalIgnoreCase))
		{
			return "Frédéric Chopin foi um compositor e pianista polonês, conhecido por suas obras para piano solo e por ser um dos maiores compositores do período romântico.";
		}
		else if (userMessage.Equals("Qual é a capital da República Checa?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da República Checa?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da República Checa.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da República Checa?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da República Checa?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da República Checa é Praga.";
		}
		else if (userMessage.Equals("Quem foi Franz Kafka?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Franz Kafka?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Franz Kafka.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Franz Kafka?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Franz Kafka?", StringComparison.OrdinalIgnoreCase))
		{
			return "Franz Kafka foi um escritor tcheco de língua alemã, conhecido por suas obras como 'A Metamorfose' e 'O Processo', que exploram temas de alienação e burocracia.";
		}
		else if (userMessage.Equals("Qual é a capital da Roménia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes qual é a capital da Roménia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me a capital da Roménia.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces a capital da Roménia?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me a capital da Roménia?", StringComparison.OrdinalIgnoreCase))
		{
			return "A capital da Roménia é Bucareste.";
		}
		else if (userMessage.Equals("Quem foi Dracula?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Sabes quem foi Dracula?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Diz-me quem foi Dracula.", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Conheces Dracula?", StringComparison.OrdinalIgnoreCase) ||
				 userMessage.Equals("Podes dizer-me quem foi Dracula?", StringComparison.OrdinalIgnoreCase))
		{
			return "Dracula é um personagem fictício baseado no conde Vlad Drácula, um governante da Valáquia no século XV, conhecido por sua crueldade e por inspirar o famoso vampiro da literatura.";
		}

		return "Desculpe, não entendi. Pode repetir?";

	}
} 