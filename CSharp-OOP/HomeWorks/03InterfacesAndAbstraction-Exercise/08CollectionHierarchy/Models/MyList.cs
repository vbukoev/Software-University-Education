namespace _08CollectionHierarchy.Models
{
    using Contracts; 

    public class MyList : AddRemoveCollection, IMyList
    {
        public int Used
            => Data.Count;
        public override string Remove()
        {
            string item = Data[0];
            Data.RemoveAt(0);
            return item;
        }
    }
}
