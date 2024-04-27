using Microsoft.Extensions.Configuration;

namespace WebApplication.Repositories
{
    public class AnimalRepository
    {

    }









    public int CreateAnimal(AnimalRepository animal)
    {
        using SqlConnection con = new SqlConnection(_configuration.GetValue<string>("ConnectionString"));

        using sqlCommand con = new sqlCommand();
        con.Connection = con;

        con.CommandText = "INSER INTO Animals(Name, Description, Area, Category) VALUES (@Name, @Description, @Area, @Category);")
        con.Parameters.AddWithValue("@Name", animal.Name);
        con.Parameters.AddWithValue("@Description", animal.Description);
        con.Parameters.AddWithValue("@Area", animal.Area);
        con.Parameters.AddWithValue("@Category", animal.Category);

        con.Open();

        var affectedCount = (decimal)con.ExecuteScalar();

        return (int)affectedCount;
    }

    public Animal GetAnimalById(int id)
    {
        using SqlConnection con = new SqlConnection(_configuration.GetValue<string>("ConnectionString"));

        using sqlCommand con = new sqlCommand();
        con.Connection = con;

        con.CommandText = "SELECT * FROM Animals WHERE Id = @id";
        con.Parameters.AddWithValue("@id", id);

        con.Open();

        SqlDataReader dr = con.ExecuteReader();
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

        using sqlCommand con = new sqlCommand();
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

        con.CommandText = $"SELECT * FROM Animals {orderByClause}";

        con.Open();


        SqlDataReader dr = con.ExecuteReader();
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

        using var con = new SqlCommand();
        con.Connection = con;
        con.CommandText = "DELETE FROM Animals WHERE Id = @id";
        con.Parameters.AddWithValue("@id", id);

        var affectedCount = con.ExecuteNonQuery();
        return affectedCount;
    }

}
