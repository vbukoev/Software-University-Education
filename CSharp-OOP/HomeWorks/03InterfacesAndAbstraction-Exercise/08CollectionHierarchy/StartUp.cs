namespace _08CollectionHierarchy
{
    using Core;
    using Models;
    public class StartUp
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();
            var engine = new Engine(addCollection, addRemoveCollection, myList);
            engine.Run();
        }
    }
}
