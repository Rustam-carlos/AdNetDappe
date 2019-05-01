using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperModels;

namespace Dapper.DataAccess
{
    public class StudentsRepository
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\МашимовН.CORP\Desktop\DapperStudentsApp\Dapper.DataAccess\StudentsDB.mdf;Integrated Security=True";
        public string InsertStudent(string query, Students student)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                var result = sql.Execute(query, student);
                if (result < 1) throw new Exception("Ошибка при вставке записи");
            }
            return "Вставка произошла успешно";
        }

        public string InsertJournal(string query, Journal journal)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                var result = sql.Execute(query, journal);
                if (result < 1) throw new Exception("Ошибка при вставке записи");
            }
            return "Вставка произошла успешно";
        }

        public List<Students> GetAllStudent(string query)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                return sql.Query<Students>(query).ToList();
            }
        }

        public string UpdateStudent(string query, Students student)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                var result = sql.Execute(query, student);
                if (result < 1) throw new Exception("Ошибка при вставке записи");
            }
            return "Вставка произошла успешно";
        }

        public string DeleteStudent(string query)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                var result = sql.Execute(query);
                if (result < 1) throw new Exception("Ошибка при вставке записи");
            }
            return "Вставка произошла успешно";
        }
    }
}
