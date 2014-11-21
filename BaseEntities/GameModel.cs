namespace BaseEntities
{
    public class GameModel : BaseModel
    {
        public string Name { get; set; }

        public string AliasName { get; set; }

        public string ShortCut { get; set; }

        public string Path { get; set; }

        public string ImagePath { get; set; }

        public bool IsCustomGame { get; set; }

        public bool IsDefault { get; set; }
    }
}