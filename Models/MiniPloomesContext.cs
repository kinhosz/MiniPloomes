using Microsoft.Data.SqlClient;

namespace miniPloomes.Models;

// Server=localhost;Database=barraca_db;User Id=sa;Password=Sql_server;trusted_connection=false;Persist Security Info=False;Encrypt=False"
public class MiniPloomesContext {

    SqlConnectionStringBuilder _builder;
    public MiniPloomesContext() {
        SqlConnectionStringBuilder builder = new("Server=localhost;Database=barraca_db;" + 
        "User Id=sa;Password=Sql_server;trusted_connection=false;Persist Security Info=False;Encrypt=False");

        _builder = builder;

        CreateTables();
    }

    private void CreateTables() {
        using SqlConnection connection = new(_builder.ConnectionString);
        connection.Open();

        string sql = "if not exists (SELECT * from sysobjects WHERE name = 'Users' and xtype = 'U')" + 
            "CREATE TABLE Users(" +
            "ID int IDENTITY(1,1)," +
            "name varchar(255)" + 
            "email varchar(255)" +
            ")";
        
       using SqlCommand command = new(sql, connection);
    }

    public User GetUserByEmail(string email) {
        using SqlConnection connection = new(_builder.ConnectionString);
        connection.Open();

        String sql = "SELECT * " + 
        "FROM Users" + 
        "WHERE Email = " + email;

        using SqlCommand command = new(sql, connection);
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.Read()){
            Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
        }

        return new User("a", "a");
    }

    public void InsertUser(User user) {
        using SqlConnection connection = new(_builder.ConnectionString);
        connection.Open();

        string sql = "INSERT INTO Users(name, email)" + 
        "values(" + user.Name + "," + user.Email + ");";

        using SqlCommand command = new(sql, connection);
    }
}
