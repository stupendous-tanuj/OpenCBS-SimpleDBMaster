﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace OpenCBS.ExceptionsHandler
{
    [Serializable]
    public class OpenCbsAllocateCounterException : OpenCbsException
    {
        private readonly string _message;
        private OpenCbsAllocateCounterExceptionEnum _code;
        public OpenCbsAllocateCounterExceptionEnum Code { get { return _code; } }

        protected OpenCbsAllocateCounterException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            _code = (OpenCbsAllocateCounterExceptionEnum)info.GetInt32("Code");
        }

        protected OpenCbsAllocateCounterException(SerializationInfo info, StreamingContext context, List<string> options)
            : base(info, context)
        {
            _code = (OpenCbsAllocateCounterExceptionEnum)info.GetInt32("Code");
            AdditionalOptions = options;
        }


        public OpenCbsAllocateCounterException()
        {
            _message = string.Empty;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Code", _code);
            base.GetObjectData(info, context);
        }

        public OpenCbsAllocateCounterException(OpenCbsAllocateCounterExceptionEnum exceptionCode)
        {
            _code = exceptionCode;
            _message = FindException(exceptionCode);
        }

        public OpenCbsAllocateCounterException(string message)
        {
            _message = message;
        }

        public override string ToString()
        {
            return _message;
        }

        private static string FindException(OpenCbsAllocateCounterExceptionEnum exceptionId)
        {
            string returned = String.Empty;
            switch (exceptionId)
            {

            }
            return returned;
        }

    }


    [Serializable]
    public enum OpenCbsAllocateCounterExceptionEnum
    {


    }
}
