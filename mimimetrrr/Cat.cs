namespace mimimetrrr
{
    public class Cat
    {
        public long ID { get; set; }
        public string name { get; set; }
        public int votes { get; set; }
        public string filename { get; set; }
        public bool Chosen { get; set; }
        public bool Shown { get; set; }


        public Cat(long ID, string name, int votes, string filename)
        {
            this.ID = ID;
            this.name = name;
            this.votes = votes;
            this.filename = filename;
        }

        public override string ToString()
        {
            return $"{name} - {votes} голосов";
        }
    }
}
