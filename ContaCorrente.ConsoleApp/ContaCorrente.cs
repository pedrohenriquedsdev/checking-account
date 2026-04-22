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

        public void Depositar(decimal valorDeposito)
        {
            saldo += valorDeposito;
        }

        public bool TransferirPara(ContaCorrente contaDestino, decimal valorTransferencia)
        {
            bool conseguiuSacar = this.Sacar(valorTransferencia);

            if (!conseguiuSacar)
                return false;

            contaDestino.Depositar(valorTransferencia);

            return true;
        }

        public decimal ObterSaldo()
        {
            return saldo;
        }
    }
}
