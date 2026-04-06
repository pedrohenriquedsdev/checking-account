using System.Security.Cryptography;

namespace ContaCorrente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ID - TITULAR - SALDO - LIMITEDEBITO   
            int numeroIndentificacao = RandomNumberGenerator.GetInt32(1, 101);
            string titular = "Pedro";
            decimal saldo = 1000;
            decimal limiteDebito = 1200;

            while (true)
            {
                Console.WriteLine("MENU DE OPÇÕES");

                Console.WriteLine("==========================");
                Console.WriteLine("1 - Sacar");
                Console.WriteLine("2 - Depositar");
                Console.WriteLine("3 - Consultar Saldo");
                Console.WriteLine("S - Sair");
                string? opcaoMenu = Console.ReadLine()?.ToUpper();
                Console.WriteLine("==========================");

                if (opcaoMenu == "S")
                    return;

                if (opcaoMenu == "1") //sacar
                {
                    Console.Write("Digite o valor que deseja sacar (R$): ");
                    decimal valorSaque = Convert.ToDecimal(Console.ReadLine());

                    if (saldo <= -limiteDebito)
                    {
                        Console.WriteLine("O valor do limite de débito já foi ultrapassado!");
                        Console.ReadLine();
                        return;
                    }

                    else
                    {
                        saldo -= valorSaque;

                        Console.WriteLine("O valor foi sacado com sucesso!");
                        Console.ReadLine();
                    }
                }



                else if (opcaoMenu == "2") //depositar
                {
                    Console.Write("Digite o valor que deseja depositar (R$): ");
                    decimal valorDeposito = Convert.ToDecimal(Console.ReadLine());

                    saldo += valorDeposito;
                }

                else if (opcaoMenu == "3")
                {
                    Console.WriteLine($"O saldo da conta é de: R${saldo}");
                    Console.ReadLine();
                }
            }

            

        }
    }
}
