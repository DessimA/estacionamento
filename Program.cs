using System;
using System.Globalization;
using EstacionamentoDesafio.Models;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Seja bem-vindo ao sistema de estacionamento!");

        decimal precoInicial = ObterDecimalDoUsuario("Digite o preço inicial:");
        decimal precoPorHora = ObterDecimalDoUsuario("Agora digite o preço por hora:");

        Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

        bool continuarExecucao = true;

        while (continuarExecucao)
        {
            Console.Clear();
            ExibirMenu();

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    estacionamento.AdicionarVeiculo();
                    break;

                case "2":
                    estacionamento.RemoverVeiculo();
                    break;

                case "3":
                    estacionamento.ListarVeiculos();
                    break;

                case "4":
                    continuarExecucao = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }

            Console.WriteLine("Pressione uma tecla para continuar");
            Console.ReadLine();
        }

        Console.WriteLine("O programa se encerrou");
    }

    static void ExibirMenu()
    {
        Console.WriteLine("Digite a sua opção:");
        Console.WriteLine("1 - Cadastrar veículo");
        Console.WriteLine("2 - Remover veículo");
        Console.WriteLine("3 - Listar veículos");
        Console.WriteLine("4 - Encerrar");
    }

    static decimal ObterDecimalDoUsuario(string mensagem)
    {
        decimal resultado;
        bool entradaValida;

        do
        {
            Console.WriteLine(mensagem);
            string entradaUsuario = Console.ReadLine();

            entradaUsuario = entradaUsuario.Replace(',', '.'); // Substituir ',' por '.' para garantir a interpretação correta

            entradaValida = decimal.TryParse(entradaUsuario, NumberStyles.Number, CultureInfo.InvariantCulture, out resultado);

            if (!entradaValida || resultado < 0)
            {
                Console.WriteLine("Valor inválido. Tente novamente.");
            }

        } while (!entradaValida || resultado < 0);

        return resultado;
    }
}
