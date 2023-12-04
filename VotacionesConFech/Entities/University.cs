namespace VotacionesConFech.Entities
{
    public class University
    {
        public string name { get; set; }
        public List<string> votes { get; set; } = new List<string>();
        public List<int> result { get; set; } = new List<int>();
    }
}