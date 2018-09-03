using CommandLine;

namespace Polly_Examples.Options
{
    [Verb("retry", HelpText = "Runs a retry policy example")]
    public class RetryOptions
    {
        [Value(
            0, 
            MetaName = "ExampleKey",
            HelpText = "The string key representing the Retry example to run"
        )]
        public string ExampleKey { get; set; }
    }
}