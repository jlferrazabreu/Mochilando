using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using AppMochilando.Model;
using System.Threading.Tasks;

namespace AppMochilando.Api
{
    public class SqLiteDataBaseHelper
    {
        readonly SQLiteAsyncConnection _db;

        public SqLiteDataBaseHelper(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Excursao>().Wait();
        }

        
        public Task<List<Excursao>> GetAllRows()
        {
            return _db.Table<Excursao>().OrderBy(e => e.Nome).ToListAsync();
        }
        
        public Task<Excursao> GetById(int id)
        {
            return _db.Table<Excursao>().FirstAsync(e => e.Id == id);
        }
        
        public Task<int> Insert(Excursao model)
        {
            return _db.InsertAsync(model);
        }
        
        public Task<List<Excursao>> Update(Excursao model)
        {
            string sql = "UPDATE Excursao SET Nome=?, Origem=?, Destino=?, Data=?, Valor=?, Descricao=?, NomeImagem=? WHERE Id=?";
            return _db.QueryAsync<Excursao>(
                sql,
                model.Nome,
                model.Origem,
                model.Destino,
                model.Data,
                model.Valor,
                model.Descricao,
                model.NomeImagem
                );
        }
        
        public Task<int> Delete(int id)
        {
            return _db.Table<Excursao>().DeleteAsync(e => e.Id == id);
        }
        
        public Task<List<Excursao>> Serch(string query)
        {
            string sql = "SELECT * FROM Excursao WHERE Nome LIKE  '%" + query + "%' or Origem LIKE '%" + query + "%' or Destino LIKE '%" + query + "%' or Descricao LIKE '%" + query + "%' or Data LIKE '%" + query + "%'";
            return _db.QueryAsync<Excursao>(sql);
        }
    }
}
