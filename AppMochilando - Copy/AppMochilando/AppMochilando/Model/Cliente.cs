namespace AppMochilando.Model
{
    using System;


    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string Telefone { get; set; }
        public bool? Ativo { get; set; }
    }
}
