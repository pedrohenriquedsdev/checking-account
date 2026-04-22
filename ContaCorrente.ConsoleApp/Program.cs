using System.Security.Cryptography;

namespace ContaCorrente
{

    internal class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaUm = new ContaCorrente();
            contaUm.numeroIndentificacao = 1;
            contaUm.titular = "Tiago";
            contaUm.saldo = 1000;
            contaUm.saldo = 400;
            contaUm.limiteDebito = 1200;

            ContaCorrente contaDois = new ContaCorrente();
            contaDois.numeroIndentificacao = 2;
            contaDois.titular = "Rech";
            contaDois.saldo = 12000;
            contaDois.limiteDebito = 1200;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("MENU DE OPÇÕES");

                Console.WriteLine("==========================");
                Console.WriteLine($"Conta corrente #{contaUm.numeroIndentificacao} de {contaUm.titular}");
                Console.WriteLine("==========================");
                Console.WriteLine("1 - Sacar");
                Console.WriteLine("2 - Depositar");
                Console.WriteLine("3 - Transferência");
                Console.WriteLine("4 - Consultar Saldo");
                Console.WriteLine("S - Sair");
                string? opcaoMenu = Console.ReadLine()?.ToUpper();
                Console.WriteLine("==========================");

                if (opcaoMenu == "S")
                    break;

                if (opcaoMenu == "1") //sacar
                {
                    Console.WriteLine("-------------------------------------");
                    Console.Write("Digite o valor que deseja sacar (R$): ");
                    decimal valorSaque = Convert.ToDecimal(Console.ReadLine());

                    bool conseguiuSacar = contaUm.Sacar(valorSaque);

                    if (!conseguiuSacar)
                    {
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("O valor do limite de débito foi ultrapassado!");
                    }

                    else
                    {
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("O valor foi sacado com sucesso!");
                    }

                    Console.WriteLine("-----------------------------------------");
                    Console.Write("Digite ENTER para continuar...");
                    Console.ReadLine();
                }

                else if (opcaoMenu == "2") //depositar
                {
                    Console.WriteLine("------------------------------------------");
                    Console.Write("Digite o valor que deseja depositar (R$): ");
                    decimal valorDeposito = Convert.ToDecimal(Console.ReadLine());

                    contaUm.Depositar(valorDeposito);

                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("O valor foi depositado com sucesso!");
                    Console.WriteLine("-----------------------------------------");
                    Console.Write("Digite ENTER para continuar...");
                    Console.ReadLine();
                }

                else if (opcaoMenu == "3") //transferir
                {
                    Console.WriteLine("------------------------------------------");
                    Console.Write("Digite o valor que deseja transferir (R$): ");
                    decimal valorTransferencia = Convert.ToDecimal(Console.ReadLine());

                    bool conseguiuTransferir = contaUm.TransferirPara(contaDois, valorTransferencia);

                    if (!conseguiuTransferir)
                    {
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine($"Não foi possível transferir o valor de R${valorTransferencia}");
                    }

                    else
                    {
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine($"O valor de R${valorTransferencia} foi transferido com sucesso!");
                    }

                    Console.WriteLine("------------------------------------------");
                    Console.Write("Digite ENTER para continuar...");
                    Console.ReadLine();
                }

                else if (opcaoMenu == "4") //consultar
                {
                    decimal saldo = contaUm.ObterSaldo();

                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine($"O saldo da conta é de: R${saldo}");
                    Console.WriteLine("------------------------------------------");
                    Console.Write("Digite ENTER para continuar...");
                    Console.ReadLine();
                }
            }



        }
    }
}
