using System;
using System.Threading.Tasks;
using CommandLine;
using Polly_Examples.Examples.Retry;
using Polly_Examples.Examples.Timeout;
using Polly_Examples.Options;

namespace Polly_Examples
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            return await
            Parser.Default.ParseArguments<
            TimeoutOptions,
            RetryOptions
            >(args)
                .MapResult<TimeoutOptions, RetryOptions, Task<int>>(
                    (TimeoutOptions opts) => TimeoutRunner.Run(opts),
                    (RetryOptions opts) => RetryRunner.Run(opts),
                    err => Task.FromResult(1)
                );
        }
    }
}
