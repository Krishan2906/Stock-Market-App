using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stock.Api.Entities;
using Stock.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        public IStocksRepository _repo;

        public StocksController(IStocksRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("/stocks")]
        public IActionResult GetStockList()
        {
            var result = _repo.getStockExchangesList();
            //string json = JsonConvert.SerializeObject(result);
            return Ok(result);
        }

        [HttpPost]
        [Route("/add")]
        public IActionResult AddStockExchange([FromBody]StockExchanges stockExchange)
        {
            _repo.addStockExchange(stockExchange);
            return Ok();
        }

        [HttpGet]
        [Route("/companies{id}")]
        public IActionResult GetCompaniesList(int id)
        {
            return Ok(_repo.getCompaniesList(id));
        }

    }
}
