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
}
