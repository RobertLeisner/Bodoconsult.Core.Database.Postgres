using System;
using System.Collections.Generic;
using Npgsql;

namespace Bodoconsult.Core.Database.Postgres.Test.MetaDataSample
{
	public class CustomerService
	{

		private readonly IConnManager _db;

		public CustomerService(string connectionString)
		{
			_db = new PostgresConnManager(connectionString);
		}

		/// <summary>
		/// Insert a data row into table Customer from entity class Customer object
		/// </summary>
		public void AddNew(Customer item)
		{

			const string sql = "INSERT INTO \"Customer\"(\"CustomerId\", \"FirstName\", \"LastName\", \"Company\", \"Address\", \"City\", \"State\", \"Country\", \"PostalCode\", \"Phone\", \"Fax\", \"Email\", \"SupportRepId\") " +
					"VALUES (@CustomerId, @FirstName, @LastName, @Company, @Address, @City, @State, @Country, @PostalCode, @Phone, @Fax, @Email, @SupportRepId)";

			var cmd = new NpgsqlCommand(sql);

			NpgsqlParameter p;

			// Parameter @CustomerId
			p = new NpgsqlParameter("@CustomerId", "System.Int32") { Value = item.CustomerId };
			cmd.Parameters.Add(p);

			// Parameter @FirstName
			p = new NpgsqlParameter("@FirstName", "System.String") { Value = item.FirstName };
			cmd.Parameters.Add(p);

			// Parameter @LastName
			p = new NpgsqlParameter("@LastName", "System.String") { Value = item.LastName };
			cmd.Parameters.Add(p);

			// Parameter @Company
			p = new NpgsqlParameter("@Company", "System.String") { Value = item.Company };
			cmd.Parameters.Add(p);

			// Parameter @Address
			p = new NpgsqlParameter("@Address", "System.String") { Value = item.Address };
			cmd.Parameters.Add(p);

			// Parameter @City
			p = new NpgsqlParameter("@City", "System.String") { Value = item.City };
			cmd.Parameters.Add(p);

			// Parameter @State
			p = new NpgsqlParameter("@State", "System.String") { Value = item.State };
			cmd.Parameters.Add(p);

			// Parameter @Country
			p = new NpgsqlParameter("@Country", "System.String") { Value = item.Country };
			cmd.Parameters.Add(p);

			// Parameter @PostalCode
			p = new NpgsqlParameter("@PostalCode", "System.String") { Value = item.PostalCode };
			cmd.Parameters.Add(p);

			// Parameter @Phone
			p = new NpgsqlParameter("@Phone", "System.String") { Value = item.Phone };
			cmd.Parameters.Add(p);

			// Parameter @Fax
			p = new NpgsqlParameter("@Fax", "System.String") { Value = item.Fax };
			cmd.Parameters.Add(p);

			// Parameter @Email
			p = new NpgsqlParameter("@Email", "System.String") { Value = item.Email };
			cmd.Parameters.Add(p);

			// Parameter @SupportRepId
			p = new NpgsqlParameter("@SupportRepId", "System.Int32") { Value = item.SupportRepId };
			cmd.Parameters.Add(p);

			_db.Exec(cmd);

		}

		/// <summary>
		/// Update a data row in table Customer from an entity class Customer object
		/// </summary>
		public void Update(Customer item)
		{

			const string sql = "UPDATE \"Customer\" SET \"CustomerId\"=@CustomerId, \"FirstName\"=@FirstName, \"LastName\"=@LastName, \"Company\"=@Company, \"Address\"=@Address, \"City\"=@City, \"State\"=@State, \"Country\"=@Country, \"PostalCode\"=@PostalCode, \"Phone\"=@Phone, \"Fax\"=@Fax, \"Email\"=@Email, \"SupportRepId\"=@SupportRepId WHERE \"CustomerId\"=@CustomerId; ";

			var cmd = new NpgsqlCommand(sql);

			NpgsqlParameter p;

			// Parameter @CustomerId
			p = new NpgsqlParameter("@CustomerId", "System.Int32") { Value = item.CustomerId };
			cmd.Parameters.Add(p);

			// Parameter @FirstName
			p = new NpgsqlParameter("@FirstName", "System.String") { Value = item.FirstName };
			cmd.Parameters.Add(p);

			// Parameter @LastName
			p = new NpgsqlParameter("@LastName", "System.String") { Value = item.LastName };
			cmd.Parameters.Add(p);

			// Parameter @Company
			p = new NpgsqlParameter("@Company", "System.String") { Value = item.Company };
			cmd.Parameters.Add(p);

			// Parameter @Address
			p = new NpgsqlParameter("@Address", "System.String") { Value = item.Address };
			cmd.Parameters.Add(p);

			// Parameter @City
			p = new NpgsqlParameter("@City", "System.String") { Value = item.City };
			cmd.Parameters.Add(p);

			// Parameter @State
			p = new NpgsqlParameter("@State", "System.String") { Value = item.State };
			cmd.Parameters.Add(p);

			// Parameter @Country
			p = new NpgsqlParameter("@Country", "System.String") { Value = item.Country };
			cmd.Parameters.Add(p);

			// Parameter @PostalCode
			p = new NpgsqlParameter("@PostalCode", "System.String") { Value = item.PostalCode };
			cmd.Parameters.Add(p);

			// Parameter @Phone
			p = new NpgsqlParameter("@Phone", "System.String") { Value = item.Phone };
			cmd.Parameters.Add(p);

			// Parameter @Fax
			p = new NpgsqlParameter("@Fax", "System.String") { Value = item.Fax };
			cmd.Parameters.Add(p);

			// Parameter @Email
			p = new NpgsqlParameter("@Email", "System.String") { Value = item.Email };
			cmd.Parameters.Add(p);

			// Parameter @SupportRepId
			p = new NpgsqlParameter("@SupportRepId", "System.Int32") { Value = item.SupportRepId };
			cmd.Parameters.Add(p);

			_db.Exec(cmd);

		}

		/// <summary>
		/// Get all rows in table Customer
		/// </summary>
		public IList<Customer> GetAll()
		{

			var result = new List<Customer>();

			var reader = _db.GetDataReader("SELECT * FROM \"Customer\"");

			while (reader.Read())
			{
				var dto = DataHelper.MapFromDbToCustomer(reader);
				result.Add(dto);

			}

			reader.Dispose();

			return result;
		}

		/// <summary>
		/// Get all rows in table Customer
		/// </summary>
		public Customer GetById(System.Int32 pkCustomerId)
		{

			Customer dto = null;

			var reader = _db.GetDataReader($"SELECT * FROM \"Customer\" WHERE \"CustomerId\"={pkCustomerId};");

			while (reader.Read())
			{
				dto = DataHelper.MapFromDbToCustomer(reader);
				break;

			}

			reader.Dispose();

			return dto;
		}

		/// <summary>
		/// Count all rows in table Customer 
		/// </summary>
		public int Count()
		{

			var result = _db.ExecWithResult("SELECT COUNT(*) FROM \"Customer\"");

			return Convert.ToInt32(result);
		}


	}
}