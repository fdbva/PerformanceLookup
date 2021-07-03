using System.Collections.Generic;

namespace ClienteCompraCenario
{
    public class Cliente
    {
        public string Cpf { get; set; }
        public string Email { get; set; }

        public List<Compra> Compras { get; set; }
    }
}
