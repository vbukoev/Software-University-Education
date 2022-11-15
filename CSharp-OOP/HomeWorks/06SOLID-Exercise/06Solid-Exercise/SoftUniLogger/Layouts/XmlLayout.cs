namespace SoftUniLogger.Layouts
{
    using SoftUniLogger.Layouts.Interfaces;
    public class XmlLayout : IXmlLayout
    {
        public string Format
            => "{0} - {1} - {2}";
    }
}
