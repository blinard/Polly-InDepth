using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Polly;
using Polly.Timeout;

namespace Polly_Examples.Examples.Timeout
{
    public class SimpleTimeoutExample
    {
        public async Task<int> RunExample() {
            var timeout = Policy
                .TimeoutAsync(
                    TimeSpan.FromSeconds(1),
                    (exeContext, timeSpan, abandonedTask) => {
                        Console.WriteLine($"Timeout triggered after {timeSpan.TotalMilliseconds}ms.");
                        return Task.FromResult((object) null);
                    }
                );

            var url = "http://localhost:5000/api/examples/ex1";
            Console.WriteLine($"Issuing GET request to: {url}");

            var client = new HttpClient();

            try {
                var response = await timeout
                    .ExecuteAsync(
                        ct => client.GetAsync(url, ct),
                        CancellationToken.None
                    );

                //response.EnsureSuccessStatusCode();
                //var respString = await response.Content.ReadAsStringAsync();
                //dynamic result = JsonConvert.DeserializeObject(respString);

                Console.WriteLine($"Response received."); //callCount: {result.callCount}
            }
            catch(TimeoutRejectedException tre) {

            }
            catch(TaskCanceledException tce) {
                
            }
            finally {
                Console.WriteLine("SimpleTimeoutExample complete");
            }

            return 0;
        }
    }
}