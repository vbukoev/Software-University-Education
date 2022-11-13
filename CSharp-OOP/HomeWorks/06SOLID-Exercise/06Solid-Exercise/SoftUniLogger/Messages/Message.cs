using System.Globalization;
using SoftUniLogger.Exceptions;

namespace SoftUniLogger.Messages
{
    using System;

    using Enums;
    using Interfaces;
    internal class Message : IMessage
    {
        private const string EmptyArgumentMessage = "Argument cannot be null or empty string!";
        private string logTime;
        private string messageText;
        
        public Message(string logTime, string messageText, ReportLevel level)
        { 
            this.LogTime = logTime;
            this.MessageText = messageText;
            this.Level = level;
        }

        public string LogTime
        {
            get => this.logTime;
            private set
            {
                if (!IsValidDateTime(value))
                {
                    new InvalidDateTimeException();
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.LogTime), EmptyArgumentMessage);
                }
                this.logTime = value;
            }
        }

        public string MessageText
        {
            get => this.messageText;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    new ArgumentNullException(nameof(this.MessageText), EmptyArgumentMessage);
                }
            }
        }
        public ReportLevel Level { get; }

        private bool IsValidDateTime(string text)
            => DateTime.TryParse(text, out DateTime date);
    }
}