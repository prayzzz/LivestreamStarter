using System;

using GalaSoft.MvvmLight.Messaging;

using LivestreamStarter.Presentation.Common;

namespace LivestreamStarter.Presentation.ViewMessages
{
    public class ViewActionMessage : MessageBase
    {
        private readonly Type viewType;

        private readonly ViewActionEnum action;

        public ViewActionMessage(Type viewType, ViewActionEnum action)
        {
            this.viewType = viewType;
            this.action = action;
        }

        public ViewActionEnum Action
        {
            get
            {
                return this.action;
            }
        }

        public Type ViewType
        {
            get
            {
                return this.viewType;
            }
        }
    }
}