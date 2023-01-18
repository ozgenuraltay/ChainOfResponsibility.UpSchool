using ChainOfResponsibility.UpSchool.DAL;
using ChainOfResponsibility.UpSchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponsibility.UpSchool.ChainOfResponsibility
{
    public class Manager : Employee
    {
        public override void ProcessRequest(WithdrawVM req)
        {
            Context context = new Context();

            if (req.Amount <= 150000)
            {
                BankProcess bankProcess = new BankProcess();

                bankProcess.EmployeeName = "Şube Müdürü-Aslı Kabak";
                bankProcess.Description = "Müşteriye talep etmiş olduğu tutarın ödemesi şube müdürü tarafından gerçekleştirildi.";
                bankProcess.Amount = req.Amount;
                bankProcess.CustomerName = req.CustomerName;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                BankProcess bankProcess = new BankProcess();

                req.EmployeeName = "Şube Müdürü-Aslı Kabak";
                req.Description = "Müşterinin talep ettiği tutar yetkim dahilinde olmadığı için işlem Bölge Müdürüne gönderildi.";
                bankProcess.Amount = req.Amount;
                bankProcess.CustomerName = req.CustomerName;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
