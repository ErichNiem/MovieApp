﻿using System.Runtime.Serialization;

namespace MovieApp.Domain.Exceptions
{
    [Serializable]
    internal class HandlerNotFoundException : Exception
    {
        public HandlerNotFoundException()
        {
        }

        public HandlerNotFoundException(string? message) : base(message)
        {
        }

        public HandlerNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected HandlerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}