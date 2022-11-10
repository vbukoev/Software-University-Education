using System;

namespace demo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //private -> visible only in the current class, least visual(higher encapsulation)
            //protected -> visible only in the inherited members                              
            //internal -> visible only in the current assembly                                
            //public -> visible in the whole solution (most visual, lowest encapsulation)     
            
            //fields -> private
            //constructors -> private(ctor chaining), protected (inheritance), public
            //properties -> public(get, set -> private, protected)
            //methods-> private, protected, public

            //Validation -> get (just return the value of a field), set (validation inside-> validate the value), methods(custom validation)
        }
    }
}
