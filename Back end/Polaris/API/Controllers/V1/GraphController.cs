using API.Services.GraphBusiness;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class GraphController : ControllerBase
    {
        private readonly IGraphService _graphService;

        public GraphController(IGraphService graphService)
        {
            _graphService = graphService;
        }

        [HttpGet]
        public ActionResult GetWholeGraph()
        {
            var wholeGraph = "{  \"nodes\": [    {      \"id\": \"6534454617\",      \"data\": {        \"AccountID\": \"6534454617\",        \"CardID\": \"6104335000000190\",        \"Sheba\": \"IR120778801496000000198\",        \"AccountType\": \"پس انداز\",        \"BranchTelephone\": \"24357892\",        \"BranchAdress\": \"کنار دریا\",        \"BranchName\": \"دریا\",        \"OwnerName\": \"مهدی\",        \"OwnerFamilyName\": \"خضرایی\",        \"OwnerID\": \"345623\"      },      \"attributes\": {        \"shape\": \"circle\",        \"color\": \"blue\",        \"radius\": 8      }    },    {      \"id\": \"3000000406\",      \"data\": {        \"AccountID\": \"3000000406\",        \"CardID\": \"female\",        \"Sheba\": \"female\",        \"AccountType\": \"female\",        \"BranchTelephone\": \"female\",        \"BranchAdress\": \"female\",        \"BranchName\": \"دیباجی\",        \"OwnerName\": \"سارا\",        \"OwnerFamilyName\": \"رحیمی\",        \"OwnerID\": \"female\"      },      \"attributes\": {        \"shape\": \"circle\",        \"color\": \"purple\",        \"radius\": 8      }    },    {      \"id\": \"123456896\",      \"data\": {        \"AccountID\": \"123456896\",        \"CardID\": \"female\",        \"Sheba\": \"female\",        \"AccountType\": \"female\",        \"BranchTelephone\": \"female\",        \"BranchAdress\": \"female\",        \"BranchName\": \"انقلاب\",        \"OwnerName\": \"صبا\",        \"OwnerFamilyName\": \"ابراهیمی\",        \"OwnerID\": \"female\"      },      \"attributes\": {        \"shape\": \"circle\",        \"color\": \"pink\",        \"radius\": 8      }    },    {      \"id\": \"156344565496\",      \"data\": {        \"AccountID\": \"156344565496\",        \"CardID\": \"female\",        \"Sheba\": \"female\",        \"AccountType\": \"female\",        \"BranchTelephone\": \"female\",        \"BranchAdress\": \"female\",        \"BranchName\": \"دروازه دولت\",        \"OwnerName\": \"مهلا\",        \"OwnerFamilyName\": \"شریفی\",        \"OwnerID\": \"female\"      },      \"attributes\": {        \"shape\": \"circle\",        \"color\": \"purple\",        \"radius\": 8      }    },    {      \"id\": \"65344ff54617\",      \"data\": {        \"AccountID\": \"6534454617\",        \"CardID\": \"6104335000000190\",        \"Sheba\": \"IR120778801496000000198\",        \"AccountType\": \"پس انداز\",        \"BranchTelephone\": \"24357892\",        \"BranchAdress\": \"کنار دریا\",        \"BranchName\": \"tara \",        \"OwnerName\": \"arghavani\",        \"OwnerFamilyName\": \"خضرایی\",        \"OwnerID\": \"345623\"      },      \"attributes\": {        \"shape\": \"circle\",        \"color\": \"blue\",        \"radius\": 8      }    },    {      \"id\": \"65344dd54617\",      \"data\": {        \"AccountID\": \"6534454617\",        \"CardID\": \"6104335000000190\",        \"Sheba\": \"IR120778801496000000198\",        \"AccountType\": \"پس انداز\",        \"BranchTelephone\": \"24357892\",        \"BranchAdress\": \"کنار دریا\",        \"BranchName\": \"دریا\",        \"OwnerName\": \"هاله\",        \"OwnerFamilyName\": \"رشدی\",        \"OwnerID\": \"345623\"      },      \"attributes\": {        \"shape\": \"circle\",        \"color\": \"blue\",        \"radius\": 8      }    }  ],  \"edges\": [    {      \"id\": \"5\",      \"source\": \"123456896\",      \"target\": \"156344565496\",      \"data\": {        \"amount\": 20000,        \"date\": \"1399/04/23\",        \"type\": \"پایا\"      },      \"attributes\": {        \"width\": 1,        \"shape\": \"arrow\"      }    },    {      \"id\": \"6\",      \"source\": \"3000000406\",      \"target\": \"156344565496\",      \"data\": {        \"amount\": 560000,        \"date\": \"1399/07/13\",        \"type\": \"کارت به کارت\"      },      \"attributes\": {        \"width\": 1,        \"shape\": \"arrow\"		      }    },    {      \"id\": \"7\",      \"source\": \"3000000406\",      \"target\": \"123456896\",      \"data\": {        \"amount\": 98000,        \"date\": \"1398/02/23\",        \"type\": \"پایا\"      },      \"attributes\": {        \"width\": 1,        \"shape\": \"arrow\"      }    },    {      \"id\": \"8\",      \"source\": \"6534454617\",      \"target\": \"3000000406\",      \"data\": {        \"amount\": 209650,        \"date\": \"1397/11/19\",        \"type\": \"ساتنا\"      },      \"attributes\": {        \"width\": 1,        \"shape\": \"arrow\"      }    },    {      \"id\": \"9\",      \"source\": \"6534454617\",      \"target\": \"123456896\",      \"data\": {        \"amount\": 45628,        \"date\": \"1398/06/29\",        \"type\": \"ساتنا\"      },      \"attributes\": {        \"width\": 1,        \"shape\": \"arrow\"      }    },    {      \"id\": \"10\",      \"source\": \"65344ff54617\",      \"target\": \"123456896\",      \"data\": {        \"amount\": 12555,        \"date\": \"1397/07/08\",        \"type\": \"پایا\"      },      \"attributes\": {        \"width\": 1,        \"shape\": \"arrow\"      }    }  ]}";
            return Ok(wholeGraph);
        }

        [HttpGet]
        [Route("expansion/{nodeId}")]
        public ActionResult ExpandSingleNode(string nodeId)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        [Route("expansion")]
        public ActionResult ExpandNodes()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        [Route("paths")]
        public ActionResult GetPaths()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        [Route("max-flow")]
        public ActionResult GetMaxFlow()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        [Route("stats")]
        public ActionResult GetStats()
        {
            throw new System.NotImplementedException();
        }
    }
}