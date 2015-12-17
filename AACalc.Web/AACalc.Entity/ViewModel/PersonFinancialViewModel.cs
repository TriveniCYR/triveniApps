using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AACalc.Entity.ViewModel
{
    public class PersonFinancialViewModel
    {

        public int FinancialId { get; set; }
        public int CustomerId { get; set; }
        public Nullable<decimal> Balance401KAmount { get; set; }
        public Nullable<decimal> CompanyContributionAmount { get; set; }
        public Nullable<decimal> ProjectedRetuPer { get; set; }
        public Nullable<decimal> OtherIRAbalanceAmount { get; set; }
        public Nullable<decimal> AnnualIRAContributionAmount { get; set; }
        public string FundAnnuityAmount { get; set; }
        public Nullable<decimal> WithdrawRatePer { get; set; }
        public Nullable<decimal> SSBeniftAmount { get; set; }
        public Nullable<decimal> SpouseSSBenifitAmount { get; set; }
        public Nullable<int> SSProjAge { get; set; }
        public Nullable<int> SSSpouseProjAge { get; set; }
        public Nullable<decimal> Spouse401kBalance { get; set; }
        public Nullable<decimal> SpouseIRABalance { get; set; }
        public Nullable<decimal> SpouseAnnualIRAProjAmount { get; set; }
        public Nullable<decimal> TaxableAccountBal { get; set; }
        public Nullable<decimal> MilitarySurvivorAnnuity { get; set; }
        public Nullable<decimal> MilitaryAnnuity { get; set; }
        public Nullable<decimal> TaxableAccountContributions { get; set; }
        public Nullable<decimal> SpouseAnnuityAmount { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; } 
    }
}
