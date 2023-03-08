using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Banco.Titular
{
    internal class Cliente
    {
        public string Nome { get; set; }
        public string cpf { get; set; }
        public string Profissao { get; set; }

        public static int TotalClientesCadastrados { get; set; }

        public Cliente()
        {
            TotalClientesCadastrados = TotalClientesCadastrados + 1;
        }

        public void teste()
        {
            Console.WriteLine("Classe Cliente Funcionando! ");
        }
    }
}
