using ChainOfResponsibility.UpSchool.DAL;
using ChainOfResponsibility.UpSchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponsibility.UpSchool.ChainOfResponsibility
{
    public class RegionManager : Employee
    {
        public override void ProcessRequest(WithdrawVM req)
        {
            Context context = new Context();

            if (req.Amount <= 250000)
            {
                BankProcess bankProcess = new BankProcess();

                bankProcess.EmployeeName = "Bölge Müdürü-Mert Taşan";
                bankProcess.Description = "Müşteriye talep etmiş olduğu tutarın ödemesi bölge müdürü tarafından gerçekleştirildi.";
                bankProcess.Amount = req.Amount;
                bankProcess.CustomerName = req.CustomerName;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();

            }
            else if (NextApprover != null)
            {
                BankProcess bankProcess = new BankProcess();

                bankProcess.EmployeeName = "Bölge Müdürü-Mert Taşan";
                bankProcess.Description = "Müşterinin talep ettiği tutar banka limitlerinin günlük çekim tutarı üzerinde olduğu için müşteriye ödeme yapılamadı.";
                bankProcess.Amount = req.Amount;
                bankProcess.CustomerName = req.CustomerName;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
            }
        }
    }
}
