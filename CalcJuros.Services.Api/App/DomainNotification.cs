using MediatR;
using System;

namespace CalcJuros.Services.Api.App
{
    public class DomainNotification : IRequest, INotification
    {
        public string Description { get; private set; }

        public Type CommandType { get; private set; }

        #region Factory

        public  static class Factory
        {
            public static DomainNotification Create(object commandType, string description)
                => new DomainNotification()
                {
                    CommandType = commandType.GetType(),
                    Description = description
                };
        }

        #endregion
    }
}
