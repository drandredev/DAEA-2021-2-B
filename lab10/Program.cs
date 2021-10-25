using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.SqlClient;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwndDataContext context = new NorthwndDataContext();

            //var query = from p in context.Products
            //            select p;

            //var query = from p in context.Products
            //            where p.Categories.CategoryName == "Beverages"
            //            select p;

            //var query = from p in context.Products
            //            where p.UnitPrice < 20
            //            select p;

            //Queso
            //var query = from p in context.Products
            //            where SqlMethods.Like(p.ProductName, "Queso%")
            //            select p;

            //pkg pkgs
            //var query = from p in context.Products
            //            where SqlMethods.Like(p.QuantityPerUnit, "%pkg%")
            //            select p;

            //inicio A
            //var query = from p in context.Products
            //            where SqlMethods.Like(p.ProductName, "A%")
            //            select p;

            //no stock
            //var query = from p in context.Products
            //            where p.UnitsInStock == 0
            //            select p;

            //descontinuados
            //var query = from p in context.Products
            //            where p.Discontinued == 1
            //            select p;

            //foreach (var prod in query)
            //{
            //Console.WriteLine("ID={0} \t Nombre={1}", prod.ProductID, prod.ProductName);

            //Console.WriteLine("ID={0} \t Precio={1} \t Nombre={2}", prod.ProductID, prod.UnitPrice, prod.ProductName);

            //Console.WriteLine("ID={0} \t Nombre={1} \t Presentacion={2}", prod.ProductID, prod.ProductName, prod.QuantityPerUnit);

            //Console.WriteLine("ID={0} \t Nombre={1} \t Stock={2}", prod.ProductID, prod.ProductName, prod.UnitsInStock);

            //Console.WriteLine("ID={0} \t Nombre={1} \t Descontinuado={2}", prod.ProductID, prod.ProductName, prod.Discontinued);
            //}

            //Insercion peruvian
            //Products p = new Products();
            //p.ProductName = "Peruvian Coffe";
            //p.SupplierID = 20;
            //p.SupplierID = 20;
            //p.CategoryID = 1;
            //p.QuantityPerUnit = "10 pkgs";
            //p.UnitPrice = 25;

            //context.Products.InsertOnSubmit(p);
            //context.SubmitChanges();




            //nueva cat
            //Categories c = new Categories();
            //c.CategoryName = "Cafes";
            //c.Description = "Cafes del mundo";

            //context.Categories.InsertOnSubmit(c);
            //context.SubmitChanges();




            //edicion
            //var product = (from p in context.Products
            //               where p.ProductName == "Tofu"
            //               select p).FirstOrDefault();

            //product.UnitPrice = 100;
            //product.UnitsInStock = 15;
            //product.Discontinued = true;

            //context.SubmitChanges();


            //eliminacion
            //var productEliminar = (from pr3 in context.Products
            //               where pr3.ProductID == 78
            //               select pr3).FirstOrDefault();

            //context.Products.DeleteOnSubmit(productEliminar);
            //context.SubmitChanges();


            //nombre producto, proveedor y categoria dairy products
            //var query = from p in context.Products
            //            join s in context.Suppliers on p.SupplierID equals s.SupplierID into nTable
            //            from ps in nTable.DefaultIfEmpty()
            //            join c in context.Categories on p.CategoryID equals c.CategoryID
            //            where c.CategoryName == "Dairy Products"
            //            select new { idProd = p.ProductID, product = p.ProductName, provider = ps.CompanyName, category = c.CategoryName };

            //foreach (var p in query)
            //{
            //    Console.WriteLine("id={0} \t product={1} \t provider={2}", p.idProd, p.product, p.provider);
            //}

            //usa
            var usa = from p in context.Products
                         join s in context.Suppliers on p.CategoryID equals s.SupplierID
                         where s.Country == "USA"
                         select new { id = p.ProductID, product = p.ProductName, country = s.Country };

            foreach (var p in usa)
            {
                Console.WriteLine("ID={0} \t product={1} \t country={2}", p.id, p.product, p.country);
            }

            Console.ReadKey();

           
        }
    }
}
