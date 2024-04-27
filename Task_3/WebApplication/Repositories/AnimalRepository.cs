using Microsoft.Extensions.Configuration;

namespace WebApplication.Repositories
{
    public class AnimalsRepository : IAnimalRepository
    {
        private IConfiguration _configuration;

        public AnimalsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int CreateAnimal(Animal animal)
        {
            using SqlConnection con = new SqlConnection(_configuration.GetValue<string>("ConnectionString"));

            using sqlCommand com = new sqlCommand();
            con.Connection = con;

            com.CommandText = "INSER INTO Animals(Name, Description, Area, Category) VALUES (@Name, @Description, @Area, @Category); SELECT SCOPE_IDENTITY()\";")
            com.Parameters.AddWithValue("@Name", animal.Name);
            com.Parameters.AddWithValue("@Description", animal.Description);
            com.Parameters.AddWithValue("@Area", animal.Area);
            com.Parameters.AddWithValue("@Category", animal.Category);

            con.Open();
            var affectedCount = (decimal)com.ExecuteScalar();
            return (int)affectedCount;
        }

        public Animal GetAnimalById(int id)
        {
            using SqlConnection con = new SqlConnection(_configuration.GetValue<string>("ConnectionString"));

            using sqlCommand com = new sqlCommand();
            com.Connection = con;

            com.CommandText = "SELECT * FROM Animals WHERE Id = @id";
            com.Parameters.AddWithValue("@id", id);

            con.Open();

            SqlDataReader dr = com.ExecuteReader();
            AnimalRepository a = new Animal();

            while (dr.Read())
            {
                a.Id = (int)dr["id"];
                a.Name = (string)dr["Name"];
                a.Description = (string)dr["Description"];
                a.Area = (string)dr["Area"];
                a.Category = (string)dr["Category"];
            }

            return a;
        }

        public IEnumerable<Animal> GetAnimals(string orderBy)
        {
            using SqlConnection con = new SqlConnection(_configuration.GetValue<string>("ConnectionString"));

            using sqlCommand com = new sqlCommand();
            con.Connection = con;

            string orderByClause = "";
            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case "name":
                        orderByClause = "ORDER BY Name";
                        break;
                    case "area":
                        orderByClause = "ORDER BY area";
                        break;
                    case "category":
                        orderByClause = "ORDER BY category";
                        break;
                    default:
                        break;
                }
            }

            com.CommandText = $"SELECT * FROM Animals {orderByClause}";

            con.Open();


            SqlDataReader dr = com.ExecuteReader();
            List<Animal> animals = new List<Animals>();

            while (dr.Read())
            {
                Animal a = new Animal();
                a.Id = (int)dr["id"];
                a.Name = (string)dr["Name"];
                a.Description = (string)dr["Description"];
                a.Area = (string)dr["Area"];
                a.Category = (string)dr["Category"];

                animals.Add(a);
            }

            return animals;
        }

        public int DeleteAnimal(int id)
        {
            using SqlConnection con = new SqlConnection(_configuration.GetValue<string>("ConnectionString"));
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM Animals WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);

            var affectedCount = cmd.ExecuteNonQuery();
            return affectedCount;
        }

        public int UpdateAnimal(AnimalRepository animal)
        {
            using SqlConnection con = new SqlConnection(_configuration.GetValue<string>("ConnectionString"));
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Animals SET Name=@Name, Description=@Description, Area=@Area, Category=@Category WHERE Id=@Id";
            cmd.Parameters.AddWithValue("@Id", animal.Id);
            cmd.Parameters.AddWithValue("@Name", animal.Name);
            cmd.Parameters.AddWithValue("@Description", animal.Description);
            cmd.Parameters.AddWithValue("@Area", animal.Area);
            cmd.Parameters.AddWithValue("@Category", animal.Category);

            var affectedCount = cmd.ExecuteNonQuery();
            return affectedCount;
        }
    }
}
