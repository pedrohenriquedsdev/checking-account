using System.Security.Cryptography;

namespace ContaCorrente
{
    class TelaPrincipal //Aprensentação e Interface com o Usuário
    {
        public string? ApresentarOpcoesDoMenu(ContaCorrente contaAcessada)
        {
            Console.Clear();

            Console.WriteLine("MENU DE OPÇÕES");

            Console.WriteLine("==========================");
            Console.WriteLine($"Conta corrente #{contaAcessada.numeroIndentificacao} de {contaAcessada.titular}");
            Console.WriteLine("==========================");
            Console.WriteLine("1 - Sacar");
            Console.WriteLine("2 - Depositar");
            Console.WriteLine("3 - Transferência");
            Console.WriteLine("4 - Consultar Saldo");
            Console.WriteLine("S - Sair");
            string? opcaoMenu = Console.ReadLine()?.ToUpper();

            return opcaoMenu;
        }

        public void ApresentarOperacaoDeSaque(ContaCorrente contaAcessada)
        {
            Console.WriteLine("-------------------------------------");
            Console.Write("Digite o valor que deseja sacar (R$): ");
            decimal valorSaque = Convert.ToDecimal(Console.ReadLine());

            bool conseguiuSacar = contaAcessada.Sacar(valorSaque);

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

        public void ApresentarOperacaoDeDeposito(ContaCorrente contaAcessada)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Digite o valor que deseja depositar (R$): ");
            decimal valorDeposito = Convert.ToDecimal(Console.ReadLine());

            contaAcessada.Depositar(valorDeposito);

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("O valor foi depositado com sucesso!");
            Console.WriteLine("-----------------------------------");
            Console.Write("Digite ENTER para continuar");
            Console.ReadLine();
        }

        public void ApresentarOperacaoDeTransferencia(ContaCorrente contaAcessada, ContaCorrente contaDestino)
        {
            Console.WriteLine("------------------------------------------");
            Console.Write("Digite o valor que deseja transferir (R$): ");
            decimal valorTransferencia = Convert.ToDecimal(Console.ReadLine());

            bool conseguiuTransferir = contaAcessada.TransferirPara(contaDestino, valorTransferencia);

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

        public void ApresentarOperacaoObterSaldo(ContaCorrente contaAcessada)
        {
            decimal saldo = contaAcessada.ObterSaldo();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"O saldo da conta é de: R${saldo}");
            Console.WriteLine("------------------------------------------");
            Console.Write("Digite ENTER para continuar...");
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
            contaUm.saldo = 400;
            contaUm.limiteDebito = 1200;

            ContaCorrente contaDois = new ContaCorrente();
            contaDois.numeroIndentificacao = 2;
            contaDois.titular = "Rech";
            contaDois.saldo = 12000;
            contaDois.limiteDebito = 1200;

            TelaPrincipal tela = new TelaPrincipal();
            ContaCorrente contaAcessada = contaUm; //passagem por referência (literalmente iguais)

            while (true)
            {
                string? opcaoMenu = tela.ApresentarOpcoesDoMenu(contaAcessada);

                if (opcaoMenu == "S")
                    break;

                if (opcaoMenu == "1") //sacar
                    tela.ApresentarOperacaoDeSaque(contaAcessada);

                else if (opcaoMenu == "2") //depositar
                    tela.ApresentarOperacaoDeDeposito(contaAcessada);

                else if (opcaoMenu == "3") //transferir
                    tela.ApresentarOperacaoDeTransferencia(contaAcessada, contaDestino: contaDois); //assim contaDestino é preenchido com contaDois

                else if (opcaoMenu == "4") //consultar
                    tela.ApresentarOperacaoObterSaldo(contaAcessada);
            }



        }
    }
}
