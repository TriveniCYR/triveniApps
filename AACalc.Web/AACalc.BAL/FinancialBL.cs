using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AACalc.DAL.Data;
using AACalc.Entity.ViewModel;
using System.Data.Entity;

namespace AACalc.BAL
{
   public class FinancialBL:BaseBL
    {
       public static int CreateNewPersonFinancial(PersonFinancialViewModel objPersonFinancialViewModel)
        {
            tblPersonFinancial _tblPersonFinancial = GettblAddressEntityfromAddressViewModel(objPersonFinancialViewModel);
            _context.tblPersonFinancials.Add(_tblPersonFinancial);
            _context.SaveChanges();
            return _tblPersonFinancial.CustomerId;
        }

       public static int UpdatePersonFinancial(PersonFinancialViewModel objPersonFinancialViewModel)
        {
            tblPersonFinancial _tblPersonFinancial = GettblAddressEntityfromAddressViewModel(objPersonFinancialViewModel);
            _context.Entry(_tblPersonFinancial).State = EntityState.Modified;
            _context.SaveChanges();
            return _tblPersonFinancial.CustomerId;
        }

       public static List<PersonFinancialViewModel> GetAllPersonFinancial()
        {
            List<tblPersonFinancial> _listPersonFinancial = _context.tblPersonFinancials.ToList();
            var lstPersons = GetPersonFinancialfromPersonFinancialEntityList(_listPersonFinancial);

            return lstPersons;
        }




       protected static List<PersonFinancialViewModel> GetPersonFinancialfromPersonFinancialEntityList(List<tblPersonFinancial> tblPersonFinancialList)
       {
           var lstPersonFinancial = new List<PersonFinancialViewModel>();
           foreach (var tblPersonFinancial in tblPersonFinancialList)
           {
               var personFinancial = GetAddressViewModelfromtblAddressEntity(tblPersonFinancial);

               lstPersonFinancial.Add(personFinancial);
           }
           return lstPersonFinancial;
       }




       protected static tblPersonFinancial GettblAddressEntityfromAddressViewModel(PersonFinancialViewModel objPersonFinancialViewModel)
       {
           var tblPersonFinancial = new tblPersonFinancial()
           {
               AnnualIRAContributionAmount=objPersonFinancialViewModel.AnnualIRAContributionAmount,
               Balance401KAmount=objPersonFinancialViewModel.Balance401KAmount,
               CompanyContributionAmount=objPersonFinancialViewModel.CompanyContributionAmount,
               CustomerId=objPersonFinancialViewModel.CustomerId,
               FinancialId=objPersonFinancialViewModel.FinancialId,
               FundAnnuityAmount = objPersonFinancialViewModel.FundAnnuityAmount,
               MilitaryAnnuity = objPersonFinancialViewModel.MilitaryAnnuity,
               MilitarySurvivorAnnuity = objPersonFinancialViewModel.MilitarySurvivorAnnuity,
               OtherIRAbalanceAmount = objPersonFinancialViewModel.OtherIRAbalanceAmount,
               ProjectedRetuPer = objPersonFinancialViewModel.ProjectedRetuPer,
               Spouse401kBalance = objPersonFinancialViewModel.Spouse401kBalance,
               SpouseAnnualIRAProjAmount = objPersonFinancialViewModel.SpouseAnnualIRAProjAmount,
               SpouseAnnuityAmount = objPersonFinancialViewModel.SpouseAnnuityAmount,
               SpouseIRABalance = objPersonFinancialViewModel.SpouseIRABalance,
               SpouseSSBenifitAmount = objPersonFinancialViewModel.SpouseSSBenifitAmount,
               SSBeniftAmount = objPersonFinancialViewModel.SSBeniftAmount,
               SSProjAge = objPersonFinancialViewModel.SSProjAge,
               SSSpouseProjAge = objPersonFinancialViewModel.SSSpouseProjAge,
               TaxableAccountBal = objPersonFinancialViewModel.TaxableAccountBal,
               TaxableAccountContributions = objPersonFinancialViewModel.TaxableAccountContributions,
               WithdrawRatePer = objPersonFinancialViewModel.WithdrawRatePer,
               CreatedBy = objPersonFinancialViewModel.CreatedBy,
               CreatedDate = objPersonFinancialViewModel.CustomerId != 0 ? objPersonFinancialViewModel.CreatedDate : DateTime.Now,
               UpdatedBy = objPersonFinancialViewModel.UpdatedBy,
               UpdatedDate = objPersonFinancialViewModel.CustomerId != 0 ? objPersonFinancialViewModel.UpdatedDate : DateTime.Now,
           };
           return tblPersonFinancial;
       }




       protected static PersonFinancialViewModel GetAddressViewModelfromtblAddressEntity(tblPersonFinancial objPersonFinancialViewModel)
       {
           var tblPersonFinancial = new PersonFinancialViewModel()
           {
               AnnualIRAContributionAmount = objPersonFinancialViewModel.AnnualIRAContributionAmount,
               Balance401KAmount = objPersonFinancialViewModel.Balance401KAmount,
               CompanyContributionAmount = objPersonFinancialViewModel.CompanyContributionAmount,
               CustomerId = objPersonFinancialViewModel.CustomerId,
               FinancialId = objPersonFinancialViewModel.FinancialId,
               FundAnnuityAmount = objPersonFinancialViewModel.FundAnnuityAmount,
               MilitaryAnnuity = objPersonFinancialViewModel.MilitaryAnnuity,
               MilitarySurvivorAnnuity = objPersonFinancialViewModel.MilitarySurvivorAnnuity,
               OtherIRAbalanceAmount = objPersonFinancialViewModel.OtherIRAbalanceAmount,
               ProjectedRetuPer = objPersonFinancialViewModel.ProjectedRetuPer,
               Spouse401kBalance = objPersonFinancialViewModel.Spouse401kBalance,
               SpouseAnnualIRAProjAmount = objPersonFinancialViewModel.SpouseAnnualIRAProjAmount,
               SpouseAnnuityAmount = objPersonFinancialViewModel.SpouseAnnuityAmount,
               SpouseIRABalance = objPersonFinancialViewModel.SpouseIRABalance,
               SpouseSSBenifitAmount = objPersonFinancialViewModel.SpouseSSBenifitAmount,
               SSBeniftAmount = objPersonFinancialViewModel.SSBeniftAmount,
               SSProjAge = objPersonFinancialViewModel.SSProjAge,
               SSSpouseProjAge = objPersonFinancialViewModel.SSSpouseProjAge,
               TaxableAccountBal = objPersonFinancialViewModel.TaxableAccountBal,
               TaxableAccountContributions = objPersonFinancialViewModel.TaxableAccountContributions,
               WithdrawRatePer = objPersonFinancialViewModel.WithdrawRatePer,
               CreatedBy = objPersonFinancialViewModel.CreatedBy,
               CreatedDate = objPersonFinancialViewModel.CustomerId != 0 ? objPersonFinancialViewModel.CreatedDate : DateTime.Now,
               UpdatedBy = objPersonFinancialViewModel.UpdatedBy,
               UpdatedDate = objPersonFinancialViewModel.CustomerId != 0 ? objPersonFinancialViewModel.UpdatedDate : DateTime.Now,
           };
           return tblPersonFinancial;
       }
    }
}
