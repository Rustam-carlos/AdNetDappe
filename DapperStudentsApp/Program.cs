using Dapper.DataAccess;
using DapperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperStudentsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentsRepository _userRep = new StudentsRepository();
            do
            {
                //1
                #region AddStudent
                //Console.WriteLine("Сколько студентов хотите добавить?");
                //int countStudents = int.Parse(Console.ReadLine());
                //for (int i = 0; i < countStudents; i++)
                //{
                //    Console.WriteLine("ВВедите LastName");
                //    string nameLast = Console.ReadLine();
                //    Console.WriteLine("ВВедите FirstName");
                //    string nameFirst = Console.ReadLine();
                //    Console.WriteLine("ВВедите MiddleName");
                //    string nameMiddle = Console.ReadLine();
                //    Console.WriteLine("ВВедите GroupId");
                //    int idGroup = int.Parse(Console.ReadLine());
                //    _userRep.InsertStudent(@"INSERT INTO Students (LastName, FirstName, MiddleName, GroupID) VALUES (@LastName, @FirstName, @MiddleName, @GroupId)", new Students()
                //    {
                //        LastName = nameLast,
                //        FirstName = nameFirst,
                //        MiddleName = nameMiddle,
                //        GroupId = idGroup
                //    });
                //}
                #endregion

                #region Update
                //  Console.WriteLine("Изменить студента");
                //  Console.WriteLine("ВВедите измененый LastName");
                //  string nameLastChange = Console.ReadLine();
                //  Console.WriteLine("ВВедите измененый FirstName");
                //  string nameFirstChange = Console.ReadLine();
                //  Console.WriteLine("ВВедите измененый MiddleName");
                //  string nameMiddleChange = Console.ReadLine();
                //  Console.WriteLine("ВВедите измененый GroupId");
                //  int idGroupChange = int.Parse(Console.ReadLine());
                //  Console.WriteLine("ВВедите Id в котором хотите поменять значения");
                //  int idStudent = int.Parse(Console.ReadLine());
                //  _userRep.UpdateStudent($@"UPDATE Students SET LastName = @LastName, FirstName = @FirstName, MiddleName = @MiddleName WHERE Id = {idStudent}", new Students()
                //{
                //    LastName = nameLastChange,
                //    FirstName = nameFirstChange,
                //    MiddleName = nameMiddleChange,
                //    GroupId = idGroupChange
                //  });
                #endregion

                #region Delete
                //Console.WriteLine("ВВедите Id в студента которого хотите удалить?");
                //int idStudent = int.Parse(Console.ReadLine());
                //_userRep.DeleteStudent($@"Delete from Students where Id ={idStudent}");
                #endregion


                //2
                //Console.WriteLine("Сколько студентов хотите добавить в журнал?");
                //int countStudentsInJournal = int.Parse(Console.ReadLine());
                //for (int i = 0; i < countStudentsInJournal; i++)
                //{
                //    Console.WriteLine("ВВедите Дату когда пришел(гг.м.д)");
                //    int yearBegin = int.Parse(Console.ReadLine());
                //    int monthBegin = int.Parse(Console.ReadLine());
                //    int dayBegin = int.Parse(Console.ReadLine());
                //    Console.WriteLine("ВВедите Дату когда ушел(гг.м.д)");
                //    int yearEnd = int.Parse(Console.ReadLine());
                //    int monthEnd = int.Parse(Console.ReadLine());
                //    int dayEnd = int.Parse(Console.ReadLine());
                //    Console.WriteLine("ВВедите Id студента");
                //    int idStudent = int.Parse(Console.ReadLine());
                //    _userRep.InsertJournal(@"INSERT INTO Journal Values () VALUES (@DateBegin, @DateEnd, @StudentId)", new Journal()
                //    {
                //        DateBegin = new DateTime(yearBegin, monthBegin, dayBegin),
                //        DateEnd = new DateTime(yearEnd, monthEnd, dayEnd),
                //        StudentId = idStudent
                //    });
                //}

                ///3 Выборки
                //1
                //  Console.WriteLine("Введите Id группы, из которых хотите вытащить студентов");
                //  int idGroup = int.Parse(Console.ReadLine());
                //  var students = _userRep.GetAllStudent($@"SELECT * from Students where GroupId = {idGroup}");
                //students.ForEach(f =>
                //{
                //    Console.WriteLine($"{f.Id}\t {f.LastName}\t {f.FirstName}\t {f.MiddleName}");
                //});

                //2 
                Console.WriteLine("Введите дату посещения");
                int yearBegin = int.Parse(Console.ReadLine());
                int monthBegin = int.Parse(Console.ReadLine());
                int dayBegin = int.Parse(Console.ReadLine());
                int idGroup = int.Parse(Console.ReadLine());
                var students = _userRep.GetAllStudent($@"SELECT LastName,FirstName, MiddleName,(select DateBegin from Journal where DateBegin = {new DateTime(yearBegin, monthBegin, dayBegin)} & Students.Id = StudentId) from Students");
                students.ForEach(f =>
                {
                    Console.WriteLine($"{f.Id}\t {f.LastName}\t {f.FirstName}\t {f.MiddleName}");
                });




            } while (Console.ReadKey().Key == ConsoleKey.Escape);    
        }
    }
}
