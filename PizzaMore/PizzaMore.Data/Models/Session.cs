namespace PizzaMore.Data.Models
{
    public class Session
    {
       
        public string Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public Session(int userId)
        {
            UserId = userId;
        }

        public Session() { }

        public override string ToString()
        {
            return $"{this.Id}\t{this.User.Id}";
        }
    }
}