// Decompiled with JetBrains decompiler
// Type: Respect.Application.TransactionalCommandHandlerDecorator`1
// Assembly: Respect.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47073220-2394-4508-A8A1-F5AE07373DEB
// Assembly location: C:\Users\admin\.nuget\packages\respect.application\1.0.0\lib\net5.0\Respect.Application.dll

using System;

namespace Framework.Application
{
    public class TransactionalCommandHandlerDecorator<T> : ICommandHandler<T>
    {
        private readonly ICommandHandler<T> _commandHandler;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionalCommandHandlerDecorator(
            ICommandHandler<T> commandHandler,
            IUnitOfWork unitOfWork)
        {
            this._commandHandler = commandHandler;
            this._unitOfWork = unitOfWork;
        }

        public void Handle(T command)
        {
            try
            {
                this._unitOfWork.Begin();
                this._commandHandler.Handle(command);
                this._unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                this._unitOfWork.Rollback();
                throw;
            }
        }
    }
}