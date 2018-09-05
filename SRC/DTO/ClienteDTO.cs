using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ClienteDTO
    {
        private int _id;
        private string _nome;
        private string _sobreNome;

        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }

    }
}
