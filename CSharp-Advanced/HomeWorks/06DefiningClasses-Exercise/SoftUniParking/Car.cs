using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registrationNumber;
        }
        public override string ToString()
        {
            var res = new StringBuilder();
            res.AppendLine($"Make: {this.Make}");
            res.AppendLine($"Model: {this.Model}");
            res.AppendLine($"HorsePower: {this.HorsePower}");
            res.Append($"RegistrationNumber: {this.RegistrationNumber}");
            return res.ToString();
        }
    }
    
}
