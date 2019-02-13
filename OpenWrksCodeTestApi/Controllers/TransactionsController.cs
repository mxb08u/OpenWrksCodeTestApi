using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenWrksCodeTestApi.Core.Contracts.Services;
using OpenWrksCodeTestApi.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenWrksCodeTestApi.Controllers
{
    [Route("api/v{version:apiVersion}/users/{userId}/accounts/{accountNumber}/transactions")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITransactionsService _transactionsService;
        
        public TransactionsController(IMapper mapper, ITransactionsService transactionsService)
        {
            _mapper = mapper;
            _transactionsService = transactionsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionsViewModel>>> Get(string userId, string accountNumber)
        {
            var transactions = await _transactionsService.GetTransactionsAsync(userId, accountNumber);

            var mappedTransactions = _mapper.Map<IEnumerable<TransactionsViewModel>>(transactions);

            return Ok(mappedTransactions);
        }
    }
}
