using System.Security.Cryptography;

namespace ContaCorrente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //conta 1 = ID - TITULAR - SALDO - LIMITEDEBITO   
            int numeroIndentificacao = RandomNumberGenerator.GetInt32(1, 101);
            string titular = "Pedro";
            decimal saldo = 1000;
            decimal limiteDebito = 1200;

            //conta 2 = ID - TITULAR - SALDO - LIMITEDEBITO   
            int numeroIndentificacao2 = RandomNumberGenerator.GetInt32(1, 101);
            string titular2 = "Allicia";
            decimal saldo2 = 12000;
            decimal limiteDebito2 = 6000;


            while (true)
            {
                Console.Clear();

                Console.WriteLine("MENU DE OPÇÕES");

                Console.WriteLine("==========================");
                Console.WriteLine($"Conta corrente #{numeroIndentificacao} de {titular}");
                Console.WriteLine("==========================");
                Console.WriteLine("1 - Sacar");
                Console.WriteLine("2 - Depositar");
                Console.WriteLine("3 - Transferência");
                Console.WriteLine("4 - Consultar Saldo");
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

                else if (opcaoMenu == "3") //transferir
                {
                    Console.Write("Digite o valor que deseja transferir (R$): ");
                    decimal valorTransferencia = Convert.ToDecimal(Console.ReadLine());

                    saldo -= valorTransferencia;
                    saldo2 += valorTransferencia;

                    Console.WriteLine($"O valor de R${valorTransferencia} foi transferido com sucesso!");
                    Console.ReadLine();
                }

                else if (opcaoMenu == "4") //consultar
                {
                    Console.WriteLine($"O saldo da conta é de: R${saldo}");
                    Console.ReadLine();
                }
            }



        }
    }
}
