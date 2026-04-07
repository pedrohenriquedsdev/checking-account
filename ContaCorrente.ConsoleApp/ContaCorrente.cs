/*
    Abstração da Conta Corrente

    (Descrição/Atributos) [x]
    Uma conta corrente é composta por diversos atributos essenciais para sua operação.
    Ela possui um número de identificação único, um saldo disponível e um limite de débito estabelecido.

    (Ações/Métodos) [x]
    Saque: Permite a retirada de valores, respeitando o limite máximo permitido.
    Depósito: Possibilita a adição de fundos à conta.
    Consulta de saldo: Fornece informações atualizadas sobre o montante disponível.
    Transferência entre contas: Permite a movimentação de valores entre contas correntes distintas.
*/
class ContaCorrente
{
    public int numeroIdentificacao;
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