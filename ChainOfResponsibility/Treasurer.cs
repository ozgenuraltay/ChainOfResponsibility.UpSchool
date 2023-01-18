using ChainOfResponsibility.UpSchool.DAL;
using ChainOfResponsibility.UpSchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponsibility.UpSchool.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        public override void ProcessRequest(WithdrawVM req)
        {
            Context context = new Context();
            if (req.Amount <= 40000)
            {
                BankProcess bankProcess = new BankProcess();

                bankProcess.EmployeeName = "Veznedar-Ayşegül Yıldız";
                bankProcess.Description = "Müşteriye talep etmiş olduğu tutarın ödemesi gerçekleştirildi.";
                bankProcess.Amount = req.Amount;
                bankProcess.CustomerName = req.CustomerName;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                BankProcess bankProcess = new BankProcess();

                bankProcess.EmployeeName = "Veznedar-Ayşegül Yıldız";
                bankProcess.Description = "Müşterinin talep ettiği tutar yetkim dahilinde olmadığı için işlem Şube Müdür Yardımcısına gönderildi.";
                bankProcess.Amount = req.Amount;
                bankProcess.CustomerName = req.CustomerName;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
