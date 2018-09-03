using System;
using System.Threading.Tasks;
using Polly_Examples.Options;

namespace Polly_Examples.Examples.Timeout
{
    public static class TimeoutRunner
    {
        public static Task<int> Run(TimeoutOptions opts) {
            if (string.IsNullOrWhiteSpace(opts.ExampleKey) || opts.ExampleKey.Equals("simple", StringComparison.OrdinalIgnoreCase)) {
                return new SimpleTimeoutExample().RunExample();
            }

            Console.WriteLine("Timeout example stub");
            return Task.FromResult(0);
        }
    }
}