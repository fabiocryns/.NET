using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqModule.Model.Queries {
    public class CategoriesQuery : Query {
        public CategoriesQuery() : base("Categories", "Lists all categories in the database.", QueryTypes.NoLinq) { }

        public override object Execute() {
            return ObjectDatabase.Categories;            
        }
    }
    public class CustomersQuery : Query {
        public CustomersQuery() : base("Customers", "Lists all customers in the database.", QueryTypes.NoLinq) { }

        public override object Execute() {
            return ObjectDatabase.Customers;
        }
    }
    public class EmployeesQuery : Query {
        public EmployeesQuery() : base("Employees", "Lists all employees in the database.", QueryTypes.NoLinq) { }

        public override object Execute() {
            return ObjectDatabase.Employees;
        }
    }
    public class OrderDetailsQuery : Query {
        public OrderDetailsQuery() : base("OrderDetails", "Lists all order details in the database.", QueryTypes.NoLinq) { }

        public override object Execute() {
            return ObjectDatabase.OrderDetails;
        }
    }
    public class OrdersQuery : Query {
        public OrdersQuery() : base("Orders", "Lists all orders in the database.", QueryTypes.NoLinq) { }

        public override object Execute() {
            return ObjectDatabase.Orders;
        }
    }
    public class ProductsQuery : Query {
        public ProductsQuery() : base("Products", "Lists all products in the database.", QueryTypes.NoLinq) { }

        public override object Execute() {
            return ObjectDatabase.Products;
        }
    }
    public class RegionsQuery : Query {
        public RegionsQuery() : base("Regions", "Lists all regions in the database.", QueryTypes.NoLinq) { }

        public override object Execute() {
            return ObjectDatabase.Regions;
        }
    }
    public class ShippersQuery : Query {
        public ShippersQuery() : base("Shippers", "Lists all shippers in the database.", QueryTypes.NoLinq) { }

        public override object Execute() {
            return ObjectDatabase.Shippers;
        }
    }
    public class SuppliersQuery : Query {
        public SuppliersQuery() : base("Suppliers", "Lists all suppliers in the database.", QueryTypes.NoLinq) { }

        public override object Execute() {
            return ObjectDatabase.Suppliers;
        }
    }
    public class TerritoriesQuery : Query {
        public TerritoriesQuery() : base("Territories", "Lists all territories in the database.", QueryTypes.NoLinq) { }

        public override object Execute() {
            return ObjectDatabase.Territories;
        }
    }
}
