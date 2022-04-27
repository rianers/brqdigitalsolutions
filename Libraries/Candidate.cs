namespace Libraries
{
    public class Candidate
    {
        public string Name { get; set; }
        public long CPF { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Gender { get; set; }
        public DateTime Bithdate { get; set; }
        public Skill[] Skill { get; set; }
        public Certification[] Certification { get; set; }
    }
}
