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
                    contaUm.Sacar();
                }

                else if (opcaoMenu == "2") //depositar
                {
                    contaUm.Depositar();
                }

                else if (opcaoMenu == "3") //transferir
                {
                    contaUm.TransferirPara(contaDois);
                }

                else if (opcaoMenu == "4") //consultar
                {
                    contaUm.ObterSaldo();
                }
            }



        }
    }
}
