﻿using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }//props
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }        
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires) //ctor
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }        
        public override string ToString()
        {
            return $"{this.Model}"; 
        }
    }
}