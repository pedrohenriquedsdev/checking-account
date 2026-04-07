class Program
{
    static void Main(string[] args)
    {
        // Conta Corrente 1
        ContaCorrente contaUm = new ContaCorrente();
        contaUm.numeroIdentificacao = 1;
        contaUm.titular = "Tiago";
        contaUm.saldo = 400;
        contaUm.limiteDebito = 1200;

        // Conta Corrente 2
        ContaCorrente contaDois = new ContaCorrente();
        contaDois.numeroIdentificacao = 2;
        contaDois.titular = "Rech";
        contaDois.saldo = 12000;
        contaDois.limiteDebito = 1200;

        TelaPrincipal tela = new TelaPrincipal();
        ContaCorrente contaAcessada = contaUm;

        while (true)
        {
            string? opcaoMenu = tela.ApresentarOpcoesMenu(contaAcessada);

            if (opcaoMenu == "S")
                break;

            if (opcaoMenu == "1")
                tela.ApresentarOperacaoSaque(contaAcessada);

            else if (opcaoMenu == "2")
                tela.ApresentarOperacaoDeposito(contaAcessada);

            else if (opcaoMenu == "3")
                tela.ApresentarOperacaoTransferencia(contaAcessada, contaDestino: contaDois);

            else if (opcaoMenu == "4")
                tela.ApresentarOperacaoObterSaldo(contaAcessada);
        }
    }
}