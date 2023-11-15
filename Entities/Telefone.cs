﻿using ProjetoTesteLar.Enums;

namespace ProjetoTesteLar.DTOs
{
    public class Telefone
    {
        public Pessoa Pessoa{ get; set; } = new Pessoa();
        public string Numero { get; set; } = string.Empty;

        public TipoTelefone Tipo { get; set; }
    }
}
