using Newtonsoft.Json;

namespace BikerCardio.Class
{
    public class Member
    {
        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        //[JsonProperty("DOB")]
        //public string DateOfBirth { get; set; }

        [JsonProperty("Wieght")]
        public string Wieght { get; set; }

        [JsonProperty("Hieght")]
        public string Hieght { get; set; }

        [JsonProperty("Location")]
        public string Location { get; set; }

    }
}