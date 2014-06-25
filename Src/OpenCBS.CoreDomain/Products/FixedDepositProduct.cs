﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.Enums;
using OpenCBS.Shared;
using OpenCBS.CoreDomain.Accounting;

namespace OpenCBS.CoreDomain.Products
{
    [Serializable]
    public class FixedDepositProduct : IFixedDepositProduct
    {
        public int Id { get; set; }
        public int Delete { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ClientType { get; set; }
        public string Currency { get; set; }
        public double InitialAmountMin { get; set; }
        public double InitialAmountMax { get; set; }
        public string InterestCalculationFrequency { get; set; }
        public string PenalityType { get; set; }
        public double? InterestRateMin { get; set; }
        public double? InterestRateMax { get; set; }
        public double? PenalityRateMin { get; set; }
        public double? PenalityRateMax { get; set; }
        public double? MaturityPeriodMin { get; set; }
        public double? MaturityPeriodMax { get; set; }

        private List<ProductClientType> productClientTypes = new List<ProductClientType>();

        public List<ProductClientType> ProductClientTypes
        {
            get { return productClientTypes; }
            set { productClientTypes = value; }
        }
    }
}