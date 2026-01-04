namespace BankSystem.Controllers
{
using BankSystem.Models;
using BankSystem.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System.Diagnostics;
using BankSystem.Domains;
using BankSystem.Infrastructure;
using Microsoft.Extensions.Logging.TraceSource;

    [ApiController]
    [Route("api/")]

        public class TransferController : ControllerBase
        {
            private readonly AppDbContext appdb;
  
        public TransferController(AppDbContext appdbc)
            {
               this.appdb = appdbc;
            }
            [HttpPost("transfer")]
            public Task<IActionResult> Transfer(Transactionn tr)
            {
                var sender = appdb.Customern.FirstOrDefault(c => c.AccountNumber == tr.SenderAccount);
                var receiver = appdb.Customern.FirstOrDefault(c => c.AccountNumber == tr.ReceiverAccount);

                if (sender != null && receiver != null && sender.Balance > tr.Amount)
                {
                    receiver.Balance += tr.Amount;
                    sender.Balance -= tr.Amount;
                appdb.SaveChanges();

                appdb.Transactionsn.Add(new Transactionn
                    {
                        FirstName = sender.FirstName,
                        LastName = sender.LastName,
                        Amount = tr.Amount,
                        SenderAccount = tr.SenderAccount,
                        ReceiverAccount = tr.ReceiverAccount,
                        Reason = tr.Reason
                    });
                appdb.SaveChanges();
                }

                else if (sender != null && sender.Balance < tr.Amount)
                {
                    return Task.FromResult<IActionResult>(BadRequest("Sender has insufficient balance"));
                }
                else if (sender == null)
                {
                    return Task.FromResult<IActionResult>(BadRequest(tr.SenderAccount + " is not valid account"));
                }
                else if (receiver == null)
                {
                    return Task.FromResult<IActionResult>(BadRequest(tr.ReceiverAccount + " is not valid account"));
                }
                 return Task.FromResult<IActionResult>(Ok("trsnaferd"));
            }
            [HttpGet("transactions")]
            public async Task<IActionResult> geTransactions()
            {
                var transactions = await appdb.Transactionsn.ToListAsync();
            return Ok(transactions);
            }
        }


}
