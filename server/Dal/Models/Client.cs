namespace Dal.Models
{
    public class Client
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _Id { get; set; }
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }//נדרשת הצפנה

        public Client(string id, string firstName, string lastName, string phoneNumber, string email,string userName, string password)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            UserName = userName;
            Password = password;

        }
        public Client(string id,string firstName, string email, string userName, string password)
        {
            ID = id;
            FirstName = firstName;
            Email = email;
            UserName = userName;
            Password = password;

        }

    }
}
