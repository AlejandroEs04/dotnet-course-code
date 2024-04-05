namespace ModelsCourse.Models 
{
    public class ComputerSnake
    {
        /** Do that if the value is private **/
        // private string _motherboard;
        // private string Motherboard { get { return _motherboard; } set { _motherboard = value; } }
        /** OR **/
        public int computer_id { get; set; }
        public string? motherboard { get; set; } = ""; // The '?' is for making a variable nulleable

        // Do that if the value is public
        public int cpu_cores { get; set; }
        public bool has_wifi { get; set; }
        public bool has_lte { get; set; }
        public DateTime? release_date { get; set; }
        public decimal price { get; set; }
        public string video_card { get; set; } = "";
    }
}
