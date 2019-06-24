using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace bank3
{
    public class ConsumeEventSync
    {
        public void GetAllBankData(int account_number)
        {
            using (var client = new WebClient()) 
            {
                client.Headers.Add("Content-Type:application/json"); 
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://bizfibank-bizfitech.azurewebsites.net/api/v1/accounts/" + account_number);
                Console.WriteLine(Environment.NewLine + result);

            }
        }

        public void GetAllBankData_ByAccount_number(string Account_number) 
        {
            using (var client = new WebClient()) 
            {
                client.Headers.Add("Content-Type:application/json"); 
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://bizfibank-bizfitech.azurewebsites.net/api/v1/accounts/" + Account_number); 
                Console.WriteLine(Environment.NewLine + result);
            }
        }

        public void PostBank_data() 
        {
            using (var client = new WebClient())
            {
                BankAccount objtb = new BankAccount();
                objtb.account_name = "Savings";
                objtb.account_number = "87459785"; 
                objtb.sort_code = "102345";
                objtb.balance = 101478.00;
                objtb.overdraft = 0.00;
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");

                var result = client.UploadString("http://bizfibank-bizfitech.azurewebsites.net/api/v1/accounts/", JsonConvert.SerializeObject(objtb));

                Console.WriteLine(result);
            }
        }




    }
}
