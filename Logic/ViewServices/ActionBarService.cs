using BaseEntities;

using Logic.ViewServiceInterfaces;

namespace Logic.ViewServices
{
    public class ActionBarService : ViewServiceBase, IActionBarService
    {
        public string GetStreamName(int id)
        {
            return Repository.GetById<StreamModel>(id).DisplayName;
        }
    }
}