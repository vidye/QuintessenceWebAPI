using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuintessenceStocks.Models;
using System.Data;
using System.Reflection.PortableExecutable;

namespace QuintessenceStocks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public StocksController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        
        [HttpGet]
        public IEnumerable<Stock> Getstocks()
        { 
            List<Stock> stocks = new List<Stock>();

            using (StreamReader reader = new StreamReader($"{_webHostEnvironment.ContentRootPath}/Data/Stocks.json"))//Innitialise and invoke the file reader and pick the file
            {
                stocks = JsonConvert.DeserializeObject<List<Stock>>(reader.ReadToEnd());//read all the content inside the file
            }
                     
            return stocks;
        }

        [Route("StockDetails/{Id}")]
        [HttpGet]
        public IEnumerable<StockValues> GetUser(int Id)
        {

            var rootPath = _webHostEnvironment.ContentRootPath; //get the root path

            var fullPath = Path.Combine(rootPath, "Data/Stock Values.json"); //combine the root path with that of our json file inside mydata directory

            var jsonData = System.IO.File.ReadAllText(fullPath); //read all the content inside the file


            var stockdetails = JsonConvert.DeserializeObject<List<StockValues>>(jsonData); //deserialize object as a list of users in accordance with your json file


            return stockdetails.FindAll(x => x.stock_id == Id); //filter the list to match with the first name that is being passed in

          

        }
    }
}
