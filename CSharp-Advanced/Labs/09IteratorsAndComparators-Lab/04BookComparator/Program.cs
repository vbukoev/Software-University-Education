namespace IteratorsAndComparators

{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");//we get a new bookOne
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");//we get a new bookTwo
            Book bookThree = new Book("The Documents in the Case", 1930);//we get a new bookThree

            Library library = new Library(bookOne, bookTwo, bookThree); // in the class library we store the book 
            // with a foreach loop we are going to print the books to the console
            foreach (var item in library)
            {
                Console.WriteLine(item);
            }
        } 

    }
}
