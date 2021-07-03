using System;

namespace ClienteCompraCenario
{
    public class Compra
    {
        public Guid Id { get; set; }
        public string CpfCliente { get; set; }
        public decimal Valor { get; set; }
    }
}
