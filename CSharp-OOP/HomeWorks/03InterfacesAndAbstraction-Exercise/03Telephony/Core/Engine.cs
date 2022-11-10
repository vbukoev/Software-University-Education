namespace Telephony.Core
{
    using System;
    using Telephony.Core.Interfaces;
    using Telephony.Exceptions;
    using Telephony.IO.Interfaces;
    using Telephony.Models;
    using Telephony.Models.Interfaces;

    public class Engine : IEngine
    {
        // we dont know the type of reader and writer, someonone outside sets their value
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IStationaryPhone stationaryPhone;
        private readonly ISmartphone smartphone;
        private Engine() // we hide two instances
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new Smartphone();
        }
        public Engine(IReader reader, IWriter writer) : this() // chaining the two constructors
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {

            string[] phoneNumbers = this.reader.ReadLine().Split(' ');
            string[] urls = this.reader.ReadLine().Split(' ');
            foreach (string phoneNumber in phoneNumbers)
            {
                try
                {
                    if (phoneNumber.Length == 10)
                    {
                        this.writer.WriteLine(smartphone.Call(phoneNumber));
                    }
                    else if (phoneNumber.Length == 7)
                    {
                        this.writer.WriteLine(stationaryPhone.Call(phoneNumber));
                    }
                    else
                    {
                        throw new InvalidPhoneNumberException();
                    }
                }
                catch (InvalidPhoneNumberException ipne)
                {
                    this.writer.WriteLine(ipne.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            foreach (string url in urls)
            {
                try
                {
                    this.writer.WriteLine(smartphone.BrowseURL(url));
                }
                catch (InvalidURLException iue)
                {
                    this.writer.WriteLine(iue.Message);
                }
                catch(Exception)
                {
                    throw;
                }
            }
        }
    }
}