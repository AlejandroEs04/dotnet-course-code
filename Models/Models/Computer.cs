namespace ModelsCourse.Models 
{
    public class Computer 
    {
        /** Do that if the value is private **/
        // private string _motherboard;
        // private string Motherboard { get { return _motherboard; } set { _motherboard = value; } }
        /** OR **/
        public string? Motherboard { get; set; } = ""; // The '?' is for making a variable nulleable

        // Do that if the value is public
        public int CPUCores { get; set; }
        public bool hasWifi { get; set; }
        public bool HasLTE { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string VideoCard { get; set; } = "";
    }
}
