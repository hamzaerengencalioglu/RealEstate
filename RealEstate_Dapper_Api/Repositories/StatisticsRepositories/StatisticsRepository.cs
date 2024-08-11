using Dapper;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly Context _context;
        public StatisticsRepository(Context context)
        {
            _context = context;
        }
        public int ActiveCategoryCount()
        {
            string query = "SELECT Count(*) FROM Category where CategoryStatus=1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values; ;
            }
        }

        public int ActiveEmployeeCount()
        {
            string query = "SELECT Count(*) FROM Employee where Status=1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values; ;
            }
        }

        public int ApartmentCount()
        {
            string query = "SELECT Count(*) FROM Product where Title like '%Daire%'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values; ;
            }
        }

        public decimal AverageProductPriceByRent()
        {
            string query = "SELECT AVG(Price) FROM Product where Type='Kiralık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values; ;
            }
        }

        public decimal AverageProductPriceBySale()
        {
            string query = "SELECT AVG(Price) FROM Product where Type='Satılık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values; ;
            }
        }

        public int AverageRoomCount()
        {
            string query = "SELECT AVG(RoomCount) FROM ProductDetails";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values; ;
            }
        }

        public int CategoryCount()
        {
            string query = "SELECT Count(*) FROM Category";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values; ;
            }
        }

        public string CategoryNameByMaxProductCount()
        {
            string query = @"SELECT top(1) CategoryName, Count(*) from Product inner join Category On
                Product.ProductCategory=Category.CategoryID Group By CategoryName order by Count(*) Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values; ;
            }
        }

        public string CityNameByMaxProductCount()
        {
            string query = @"SELECT top(1) City, Count(*) as 'Number_Of_Listings' From Product Group
                By City order by Number_Of_Listings Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values; ;
            }
        }

        public int DifferentCityCount()
        {
            string query = "SELECT Count(Distinct(City)) FROM Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values; ;
            }
        }

        public string EmployeeNameByMaxProductCount()
        {
            string query = @"SELECT Name, Count(*) 'product_count' FROM Product Inner Join
                Employee on Product.EmployeeID=Employee.EmployeeID Group By Name Order By
                product_count Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values; ;
            }
        }

        public decimal LastProductPrice()
        {
            string query = "SELECT Top(1) Price FROM Product Order By ProductId Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values; ;
            }
        }

        public string NewestBuildingYear()
        {
            string query = "SELECT Top(1) BuildYear FROM ProductDetails Order By BuildYear Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values; ;
            }
        }

        public string OldestBuildingYear()
        {
            string query = "SELECT Top(1) BuildYear FROM ProductDetails Order By BuildYear Asc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values; ;
            }
        }

        public int PassiveCategoryCount()
        {
            string query = "SELECT Count(*) FROM Category Where CategoryStatus=0";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values; ;
            }
        }

        public int ProductCount()
        {
            string query = "SELECT Count(*) FROM Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values; ;
            }
        }
    }
}
