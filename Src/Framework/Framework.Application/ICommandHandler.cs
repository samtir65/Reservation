namespace Framework.Application
{
    public interface ICommandHandler<in T>
    {
        void Handle(T command);
    }
}
