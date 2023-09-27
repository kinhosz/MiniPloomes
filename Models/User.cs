using System.Text.Json.Serialization;

namespace miniPloomes.Models;

public class User {
    [JsonIgnore]
    public long Id { set; get; }
    public string Name { set; get; }
    public string Email { set; get; }

    public User(string name, string email) {
        Name = name;
        Email = email;
    }
}
