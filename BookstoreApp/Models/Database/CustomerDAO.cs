
using System;
using System.Collections.Generic;
using BookstoreApp.Models.Database;


namespace BookstoreApp.Models.Database
{
    class CustomerDAO
    {

        public static void Create(Customer customer)
        {
            var db = MyDB.GetInstance();
            var sql =
                string.Format("INSERT INTO Customers VALUES ('{0}' , '{1}', {2}, '{3}' )",customer.Name,customer.Email,customer.IsSubscriber? 1 : 0, customer.BirthDate);
            db.ExecuteSql(sql);
        }

        public static Customer GetCustomer(int id)
        {
            var db = MyDB.GetInstance();
            var sql =
                string.Format("Select * from Customers where CustomerID = {0}", id);
            var result = db.ExecuteSelectSql(sql);
            if (result.HasRows)
            {
                result.Read();
                return new Customer
                {
                    Id = (int) result["CustomerID"],
                    Name = result["Name"].ToString(),
                    Email = result["Email"].ToString(),
                    BirthDate = Convert.ToDateTime(result["BirthDate"]),
                    IsSubscriber = (bool) result["IsSubscriber"]
                };
            }
            return null;
        }

        public static List<Customer> GetCustomerList()
        {
            var list = new List<Customer>();
            var results = MyDB.GetInstance().ExecuteSelectSql("Select * from Customers");
            while (results.Read())
            {
                var customer = new Customer
                {
                    Id = (int) results["CustomerID"],
                    Name = results["Name"].ToString(),
                    Email = results["Email"].ToString(),
                    BirthDate = Convert.ToDateTime(results["BirthDate"]),
                    IsSubscriber = (bool)results["IsSubscriber"]
                };
                list.Add(customer);
            }
            return list;
        }


        /* 
         public static List<Course> GetCourses()
        {
            var list = new List<Course>();

            var results = MyDB.GetInstance()
                .ExecuteSelectSql("Select * from Courses");

            while (results.Read())
            {
                var course = new Course
                {
                    Id = (decimal)results["CourseID"],
                    Name = results["CourseName"].ToString()
                };

                list.Add(course);
            }

            return list;
        }
         
         
         */



        /* public static void Delete(Customer customer)
         {
             var db = MyDB.GetInstance();
             var sql =
                 string.Format("Delete From Students where StuID = {0}", customer.ID);
             db.ExecuteSql(sql);
         }

         public static Customer GetStudent(int id)
         {
             var db = MyDB.GetInstance();
             var sql =
                 string.Format("Select * from Students where StuID = {0}", id);
             var result = db.ExecuteSelectSql(sql);
             if (result.HasRows)
             {
                 result.Read();
                 return new Customer
                 {
                     ID = (Decimal)result["StuID"],
                     FirstName = result["FirstName"].ToString(),
                     LastName = result["LastName"].ToString()
                 };
             }
             return null;
         }

         public static List<Course> GetStudentEnrollment(int id)
         {
             var list = new List<Course>();

             var db = MyDB.GetInstance();
             var sql =
                 string.Format("select * from Enrollment  where  StuID =  {0}",
                     id);
             var results = db.ExecuteSelectSql(sql);
             while (results.Read())
             {
                 int courseID = int.Parse(results["CourseID"].ToString());

                 var course =
                   CourseDAO.GetCourse(courseID); // int


                 list.Add(course);
             }

             return list;
             return null;
         }



         public static List<Customer> GetStudents()
         {
             return null;
         }

         public static void DeleteEnrolment(Customer customer)
         {
             var db = MyDB.GetInstance();
             var sql =
                 string.Format("Delete From Enrollment where StuID = {0}", customer.ID);
             db.ExecuteSql(sql);
         }

         public static void CreateEnrolment(int stuID, int courseID)
         {
             var db = MyDB.GetInstance();
             var sql =
                 string.Format("INSERT INTO Enrollment VALUES ('{0}' , '{1}')", stuID,courseID);
             db.ExecuteSql(sql);
         }*/


    }
}
