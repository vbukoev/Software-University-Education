using System;
using System.Linq;
using System.Text;
using SoftUni.Models;

namespace SoftUni
{
    using Data;

    public class StartUp
    {
        static void Main()
        {
            var context = new SoftUniContext();
            string output = RemoveTown(context);
            Console.WriteLine(output);
        }

        public static string RemoveTown(SoftUniContext context)
        {
            Town townToDelete = context.Towns
                .Where(t => t.Name == "Seattle")
                .FirstOrDefault();
            
            Address[] addressesToDelete = context.Addresses
                .Where(a => a.TownId == townToDelete.TownId)
                .ToArray();

            Employee[] employeesToDelete = context.Employees
                .Where(e => addressesToDelete
                    .Contains(e.Address))
                .ToArray();
            foreach (var e in employeesToDelete) e.AddressId = null;
            context.Addresses.RemoveRange(addressesToDelete);
            context.Towns.RemoveRange(townToDelete);
            context.SaveChanges();
            return $"{addressesToDelete.Count()} addresses in Seattle were deleted";
        }
    }
}