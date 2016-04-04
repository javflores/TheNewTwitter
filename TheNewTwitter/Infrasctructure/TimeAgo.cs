namespace TheNewTwitter.Infrasctructure
{
    public class TimeAgo
    {
        public const string Minutes = "minutes";
        public const string Seconds = "seconds";

        public int Amount { get; }
        public string Unit { get; set; }

        public TimeAgo(int amount, string unit)
        {
            Amount = amount;
            Unit = unit;
        }
    }
}