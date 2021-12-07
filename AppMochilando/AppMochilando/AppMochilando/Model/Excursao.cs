using SQLite;
using System;

namespace AppMochilando.Model
{
    public class Excursao
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime? Data { get; set; }
        public decimal? Valor { get; set; }
        public string Descricao { get; set; }
        public string NomeImagem { get; set; }
    }
}
