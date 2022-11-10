namespace _08CollectionHierarchy.Models
{
    using Contracts;

    public class AddRemoveCollection : Collection, IAddRemoveCollection
    {
        public virtual string Remove()
        {
            string item = Data[Data.Count - 1];
            Data.RemoveAt(Data.Count - 1);
            return item;
        }
    }
}
