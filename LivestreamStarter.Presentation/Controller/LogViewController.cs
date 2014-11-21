using LivestreamStarter.Presentation.Controller.Base;
using LivestreamStarter.Presentation.ViewModel;

using Logic.ViewServiceInterfaces;

namespace LivestreamStarter.Presentation.Controller
{
    public class LogViewController : ViewControllerBase<LogViewModel, ILogViewService>
    {
        public override void Initialize()
        {
        }

        public override void InitializeModel()
        {
            if (IsInDesignModeStatic)
            {
                this.Model.Message = "Message!";
                return;
            }

            this.Service.RegisterLogMessagesAddedEvent((sender, args) => this.Model.Message = args.Message);
            this.Model.Message = this.Service.GetLog();
        }
    }
}