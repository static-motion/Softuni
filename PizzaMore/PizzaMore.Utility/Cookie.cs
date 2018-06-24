namespace PizzaMore.Utility
{
    public class Cookie
    {
        public Cookie(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public Cookie()
        {
            Name = null;
            Value = null;
        }
        public string Name { get; private set; }

        public string Value { get; private set; }

        public override string ToString()
        {
            return $"{this.Name}={this.Value}";
        }
    }
}