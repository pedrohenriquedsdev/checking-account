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
