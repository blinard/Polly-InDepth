using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Polly_InDepth_Target.Controllers
{
    [ApiController]
    public class ExamplesController : ControllerBase
    {
        private readonly IDictionary<string, int> _callCounts;

        public ExamplesController(IDictionary<string, int> callCounts) {
            _callCounts = callCounts;
        }

        [Route("api/examples/ex1")]
        public ActionResult<string> Ex1() {
            var callCount = GetAndUpdateCallCount();

            // Waits for 20 seconds
            Task.Delay(TimeSpan.FromSeconds(20)).Wait();

            return ErrorWithCallCount(callCount);            
        }

        [Route("api/examples/ex2")]
        public ActionResult<string> Ex2() {
            var callCount = GetAndUpdateCallCount();

            // Every 3rd call succeeds, all others fail
            if (callCount < 2) {
                return ErrorWithCallCount(callCount);
            }

            ResetCallCount();
            return OkWithCallCount(callCount);
        }

        private int GetAndUpdateCallCount() {
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            if (!_callCounts.TryGetValue(actionName, out var callsCount)) {
                _callCounts[actionName] = 1;
                return 0;
            }

            _callCounts[actionName] = callsCount + 1;
            return callsCount;
        }

        private void ResetCallCount() {
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            _callCounts[actionName] = 0;
        }

        private ActionResult OkWithCallCount(int callCount) {
            return Ok(new {
                CallCount = callCount
            });
        }

        private ActionResult ErrorWithCallCount(int callCount) {
            var result = new ObjectResult(new { CallCount = callCount });
            result.StatusCode = 500;
            return result;
        }
    }
}