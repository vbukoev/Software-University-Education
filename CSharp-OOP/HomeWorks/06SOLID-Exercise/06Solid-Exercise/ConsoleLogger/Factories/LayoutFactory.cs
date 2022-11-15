using System;
using SoftUniLogger.Layouts;

namespace ConsoleLogger.Factories
{
    using ConsoleLogger.Factories.Interfaces;
    using SoftUniLogger.Layouts.Interfaces;


    internal class LayoutFactory : ILayoutFactory
    {
        public ILayout Create(string type)
        {
            ILayout layout = null;
            if (type == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (type == "XmlLayout")
            {
                //layout = new XmlLayout();
            }
            else
            {
                throw new InvalidOperationException("Invalid layout type!");
            }

            return layout;
        }
    }
}
