
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
                    BirthDate = (DateTime)(result["BirthDate"]),
                    IsSubscriber = (bool) result["IsSubscriber"]
                };
            }
            return null;
        }

        public static List<Customer> GetCustomerList()
        {
            var customers = new List<Customer>();
            var results = MyDB.GetInstance().ExecuteSelectSql("Select * from Customers");
            while (results.Read())
            {
                var customer = new Customer
                {
                    Id = (int) results["CustomerID"],
                    Name = results["Name"].ToString(),
                    Email = results["Email"].ToString(),
                    BirthDate = (DateTime)(results["BirthDate"]),
                    IsSubscriber = (bool)results["IsSubscriber"]
                };
                customers.Add(customer);
            }
            return customers;
        }



    }
}
