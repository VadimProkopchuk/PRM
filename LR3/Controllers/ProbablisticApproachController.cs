// ======================================
// Copyright © 2019 Vadim Prokopchuk. All rights reserved.
// Contacts: mailvadimprokopchuk@gmail.com
// License:  http://opensource.org/licenses/MIT
// ======================================

using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using PRM.Algorithms;
using PRM.Models;

namespace LR3.Controllers
{
    [Route("api/ProbablisticApproach")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProbablisticApproachController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(ProbablisticApproachResult))]
        public IHttpActionResult Get(double pc1, int countOfPoints, int countOfGraphPoints, double eps)
        {
            var algorithm = new ProbablisticApproachAlgorithm(eps);

            return Ok(algorithm.GetResult(pc1, countOfPoints, countOfGraphPoints));
        }
    }
}
