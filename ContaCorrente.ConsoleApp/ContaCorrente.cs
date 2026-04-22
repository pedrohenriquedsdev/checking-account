namespace ContaCorrente
{
    class ContaCorrente
    {
        public int numeroIndentificacao;
        public string titular;
        public decimal saldo;
        public decimal limiteDebito;

        public bool Sacar(decimal valorSaque)
        {
            if (valorSaque > saldo + limiteDebito)
                return false;

            saldo -= valorSaque;

            return true;
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
}
