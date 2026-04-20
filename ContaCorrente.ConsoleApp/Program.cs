using System.Security.Cryptography;

namespace ContaCorrente
{
    class ContaCorrente
    {
        public int numeroIndentificacao;
        public string titular;
        public decimal saldo;
        public decimal limiteDebito;

        public void Sacar()
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

        public void Depositar()
        {
            Console.Write("Digite o valor que deseja depositar (R$): ");
            decimal valorDeposito = Convert.ToDecimal(Console.ReadLine());

            saldo += valorDeposito;
        }

        public decimal TransferirPara(ContaCorrente contaDestino)
        {
            Console.Write("Digite o valor que deseja transferir (R$): ");
            decimal valorTransferencia = Convert.ToDecimal(Console.ReadLine());

            saldo -= valorTransferencia;
            contaDestino.saldo += valorTransferencia;

            Console.WriteLine($"O valor de R${valorTransferencia} foi transferido com sucesso!");
            Console.ReadLine();

            return saldo;
        }

        public void ObterSaldo()
        {
            Console.WriteLine($"O saldo da conta é de: R${saldo}");
            Console.ReadLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaUm = new ContaCorrente();
            contaUm.numeroIndentificacao = 1;
            contaUm.titular = "Tiago";
            contaUm.saldo = 1000;

            ContaCorrente contaDois = new ContaCorrente();
            contaDois.numeroIndentificacao = 2;
            contaDois.titular = "Rech";
            contaDois.saldo = 12000;



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
                    return;

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
