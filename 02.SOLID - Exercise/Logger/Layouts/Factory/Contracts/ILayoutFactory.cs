using Logger.Layouts.Contracts;

namespace Logger.Layouts.Factory.Contracts
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}