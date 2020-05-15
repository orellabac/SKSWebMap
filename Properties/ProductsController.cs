namespace SKS
{
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using System.Data;
    using System.Linq;
    using Microsoft.Extensions.Logging;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ILogger<ProductController> logger;

        public ProductController(ILogger<ProductController> logger) {
            this.logger = logger;
        }

       [HttpGet("{id}")]
        public IEnumerable Get(WindowOne window)
        {
            this.logger.LogInformation($"Start controller {nameof(ProductController)}");
            // ADD your code here
           modConnection.ExecuteSql("select * from Product");
           foreach(DataRow row in modConnection.rs.Tables[0].Rows)
            {
                var dict = row.Table.Columns
                    .Cast<DataColumn>()
                    .ToDictionary(c => c.ColumnName, c => row[c]);
                yield return dict;
            }
            this.logger.LogInformation($"Finish controller {nameof(ProductController)}");
       }
    }
}