

namespace SoftUniLogger.Messages
{
    using System;

    using Enums;
    using Interfaces;
    using System.Globalization;
    using SoftUniLogger.Exceptions;
    using SoftUniLogger.Validators.Interfaces;
    internal class Message : IMessage
    {
        private const string EmptyArgumentMessage = "Argument cannot be null or empty string!";
        private string logTime;
        private string messageText;

        private readonly IValidator dateTimeValidator;

        public Message()
        {
            this.dateTimeValidator = new DateTimeValidator();
        }
        
        public Message(string logTime, string messageText, ReportLevel level) : this()
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
                if (!this.dateTimeValidator.isValid(value))
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
    }
}