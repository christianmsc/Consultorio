using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consultorio
{
    public abstract class EntidadeBase
    {
        /// <summary>
        /// Data que foi Inserido o registro no banco de dados
        /// </summary>
        public DateTime? DataRegistro { get; set; }

        protected EntidadeBase()
        {
            if (!DataRegistro.HasValue)
            {
                DataRegistro = DateTime.Now;
            }
        }
    }
}