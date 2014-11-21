using System.Linq;

using BaseEntities;

using Services.Interfaces;

namespace Services.Extensions
{
    public static class RepositoryExtension
    {
        public static GameModel GetGameOrDefault(this IRepository repository, string name)
        {
            return repository.GetQueryable<GameModel>().FirstOrDefault(x => x.Name == name || x.AliasName == name || x.ShortCut == name) ?? repository.GetQueryable<GameModel>().FirstOrDefault(x => x.IsDefault);
        }

        public static ChannelModel GetChannelOrDefault(this IRepository repository, string name)
        {
            return repository.GetQueryable<ChannelModel>().FirstOrDefault(x => x.Name == name || x.AliasName == name) ?? repository.GetQueryable<ChannelModel>().FirstOrDefault(x => x.IsDefault);
        }
    }
}