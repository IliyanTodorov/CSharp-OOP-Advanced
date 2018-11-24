using System;

namespace Logger.Layouts.Factory
{
    using Contracts;
    using Layouts.Contracts;

    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            string typeAsLowerCase = type.ToLower();
            ILayout layout = null;

            switch (typeAsLowerCase)
            {
                case "simplelayout":
                    layout = new SimpleLayout();
                    break;
                case "xmllayout":
                    layout = new XmlLayout();
                    break;
                default: throw new ArgumentException("Invalid layout type!");
            }

            return layout;
        }
    }
}