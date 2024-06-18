namespace Project_1
{
    public class KeyMeta
    {
        public string key { get; set; }
        public string hash { get; set; }

        public KeyMeta(string key, string hash)
        {
            this.key = key;
            this.hash = hash;
        }
    }
}
