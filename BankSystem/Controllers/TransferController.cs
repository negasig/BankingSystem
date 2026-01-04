using BankSystem.Models;
using BankSystem.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System.Diagnostics;
using BankSystem.Domains;
using BankSystem.Infrastructure;

[ApiController]
 [Route("api/")]

        public class TransferController : ControllerBase
        {
            private readonly AppDbContext _context;
        public TransferController(AppDbContext context)
            {
                _context = context;
            }
            [HttpPost("transfernew")]
            public Task<IActionResult> Transfer(Transactionn tr)
            {
                var sender = _context.Customern.FirstOrDefault(c => c.AccountNumber == tr.SenderAccount);
                var receiver = _context.Customern.FirstOrDefault(c => c.AccountNumber == tr.ReceiverAccount);

                if (sender != null && receiver != null && sender.Balance > tr.Amount)
                {
                    receiver.Balance += tr.Amount;
                    sender.Balance -= tr.Amount;
                    _context.SaveChanges();

                    _context.Transactionsn.Add(new Transactionn
                    {
                        FirstName = sender.FirstName,
                        LastName = sender.LastName,
                        Amount = tr.Amount,
                        SenderAccount = tr.SenderAccount,
                        ReceiverAccount = tr.ReceiverAccount,
                        Reason = tr.Reason
                    });
                    _context.SaveChanges();
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
                var transactions = await _context.Transactionsn.ToListAsync();
                return Ok(transactions);
            }
        }

