using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;

using ODataBridge.Data;

namespace ODataBridge.Controllers
{
    public class RegionsController : ODataController
    {
        private MyDbContext _db;

        public RegionsController(MyDbContext context)
        {
            _db = context;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.Regions);
        }
    }
}
