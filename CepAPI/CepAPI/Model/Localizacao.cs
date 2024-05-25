﻿namespace CepAPI.Model
{
    public class Localizacao
    {
        public int Id { get; set; }
        public string Cep {  get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public string UF { get; set; }
        public int Numero { get; set; }
        public string Logradouro {  get; set; }

    }
}
