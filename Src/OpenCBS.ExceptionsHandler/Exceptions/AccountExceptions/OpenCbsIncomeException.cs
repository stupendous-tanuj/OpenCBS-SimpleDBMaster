﻿// Octopus MFS is an integrated suite for managing a Micro Finance Institution: 
// clients, contracts, accounting, reporting and risk
// Copyright © 2006,2007 OCTO Technology & OXUS Development Network
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
//
// Website: http://www.opencbs.com
// Contact: contact@opencbs.com

using System;
using System.Runtime.Serialization;

namespace OpenCBS.ExceptionsHandler.Exceptions.AccountExceptions
{
    /// <summary>
    /// Summary description for OpenCbsAccountException.
    /// </summary>
    [Serializable]
    public class OpenCbsIncomeException : OpenCbsException
    {
        private readonly string _code;
        public OpenCbsIncomeException(OpenCbsIncomeExceptionEnum exceptionCode)
        {
            _code = _FindException(exceptionCode);
        }

        public override string ToString()
        {
            return _code;
        }

        protected OpenCbsIncomeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            _code = info.GetString("Code");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Code", _code);
            base.GetObjectData(info, context);
        }

        private string _FindException(OpenCbsIncomeExceptionEnum exceptionId)
        {
            string returned = String.Empty;
            switch (exceptionId)
            {
                case OpenCbsIncomeExceptionEnum.IncomeDateIsEmpty:
                    returned = "IncomeDateIsEmpty";
                    break;
                case OpenCbsIncomeExceptionEnum.IncomeDateIsInvalid:
                    returned = "IncomeDateIsInvalid";
                    break;
                case OpenCbsIncomeExceptionEnum.IncomeCategoryIsEmpty:
                    returned = "IncomeCategoryIsEmpty";
                    break;
                case OpenCbsIncomeExceptionEnum.IncomeDescriptionIsEmpty:
                    returned = "IncomeDescriptionIsEmpty";
                    break;
                case OpenCbsIncomeExceptionEnum.IncomeAmountIsEmpty:
                    returned = "IncomeAmountIsEmpty";
                    break;
                case OpenCbsIncomeExceptionEnum.IncomeAmountIsInvalid:
                    returned = "IncomeAmountIsInvalid ";
                    break;
                case OpenCbsIncomeExceptionEnum.ReferenceIsEmpty:
                    returned = "ReferenceIsEmpty";
                    break;
                case OpenCbsIncomeExceptionEnum.CurrencyIsEmpty:
                    returned = "CurrencyIsEmpty ";
                    break;
                case OpenCbsIncomeExceptionEnum.BranchIsEmpty:
                    returned = "BranchIsEmpty ";
                    break;

            }
            return returned;
        }
    }

    [Serializable]
    public enum OpenCbsIncomeExceptionEnum
    {


        IncomeDateIsEmpty,
IncomeDateIsInvalid,
IncomeCategoryIsEmpty,
IncomeDescriptionIsEmpty,
IncomeAmountIsEmpty,
IncomeAmountIsInvalid,
ReferenceIsEmpty,
CurrencyIsEmpty ,
BranchIsEmpty




    }
}
