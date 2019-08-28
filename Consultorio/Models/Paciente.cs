using System;
using System.Collections.Generic;
using System.Linq;

namespace Consultorio
{
    class Paciente : EntidadeBase
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string TelefoneResidencial { get; set; }

        public string TelefoneCelular { get; set; }
        
        public DateTime DataNascimento { get; set; }

        public virtual IList<Endereco> Enderecos { get; set; }

        public override string ToString()
        {
            string s = this.Nome + " - ";
            s += this.Email + " - ";
            s += this.TelefoneCelular != null ? "Cel: " + this.TelefoneCelular + " - " : this.TelefoneResidencial != null ? "Tel: " + this.TelefoneResidencial + " - " : "";
            s += "Nascimento: " + this.DataNascimento.ToString("dd/MM/yyyy") + " - ";
            s += "Cadastro Em: " + this.DataRegistro.ToString();

            s += "\nEndereço(s):\n";

            foreach(Endereco endereco in this.Enderecos)
            {
                s += endereco.ToString() + "\n";
            }
            

            return s;
        }
    }
}