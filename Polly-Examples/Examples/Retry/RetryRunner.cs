
using System;
using System.Threading.Tasks;
using Polly_Examples.Options;

namespace Polly_Examples.Examples.Retry
{
    public static class RetryRunner
    {
        public static Task<int> Run(RetryOptions opts) {
            Console.WriteLine("Retry example stub");
            return Task.FromResult(0);
        }
    }
}