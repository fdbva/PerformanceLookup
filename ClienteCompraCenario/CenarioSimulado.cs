using System;
using System.Collections.Generic;
using System.Linq;

namespace ClienteCompraCenario
{
    public class CenarioSimulado
    {
        private const int QuantidadeDeClients = 50000;
        private const int QuantidadeDeCompras = 50000;
        private readonly Random _random = new();

        private readonly List<Cliente> _clientes = new();
        private readonly List<Compra> _compras = new();

        public CenarioSimulado()
        {
            SetupInicial();
        }

        private void SetupInicial()
        {
            for (var index = 0; index < QuantidadeDeClients; index++)
            {
                var cpf = _random.Next(100000, 999999).ToString() + _random.Next(100000, 999999);

                var cliente = new Cliente
                {
                    Cpf = cpf,
                    Email = cpf
                };
                _clientes.Add(cliente);
            }

            for (var index = 0; index < QuantidadeDeCompras; index++)
            {
                var compra = new Compra
                {
                    Id = Guid.NewGuid(),
                    Valor = _random.Next(1, 111),
                    CpfCliente = _clientes[_random.Next(0, QuantidadeDeClients)].Cpf
                };

                _compras.Add(compra);
            }
        }

        public decimal AlgoritmoOtimizado()
        {
            var somatorioSemSentido = 0m;

            var lookupDeCompras = _compras.ToLookup(x => x.CpfCliente);

            foreach (var cliente in _clientes) // O(n)
            {
                var comprasDoCliente = lookupDeCompras[cliente.Cpf].ToList();
                
                var valorTotalDoCliente = comprasDoCliente.Sum(x => x.Valor);

                //fazer alguma outra operação
                somatorioSemSentido += valorTotalDoCliente;
            }

            return somatorioSemSentido;
        }

        public decimal AlgoritmoNaoOtimizado()
        {
            var somatorioSemSentido = 0m;

            foreach (var cliente in _clientes) // O(n^2)
            {
                var comprasDoCliente = _compras.Where(x => x.CpfCliente == cliente.Cpf).ToList();

                var valorTotalDoCliente = comprasDoCliente.Sum(x => x.Valor);

                //fazer alguma outra operação
                somatorioSemSentido += valorTotalDoCliente;
            }

            return somatorioSemSentido;
        }
    }
}
