namespace Logic.Dto
{
    public class AddStreamDto : BaseDto
    {
        private string name;

        private string displayName;

        private int? channel;

        private int? game;

        private bool isFavorite;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.RaisePropertyChanged();
            }
        }

        public string DisplayName
        {
            get
            {
                return this.displayName;
            }
            set
            {
                this.displayName = value;
                this.RaisePropertyChanged();
            }
        }

        public int? Channel
        {
            get
            {
                return this.channel;
            }

            set
            {
                this.channel = value;
                this.RaisePropertyChanged();
            }
        }

        public int? Game
        {
            get
            {
                return this.game;
            }

            set
            {
                this.game = value;
                this.RaisePropertyChanged();
            }
        }

        public bool IsFavorite
        {
            get
            {
                return this.isFavorite;
            }
            set
            {
                this.isFavorite = value;
                this.RaisePropertyChanged();
            }
        }
    }
}