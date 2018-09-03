using CommandLine;

namespace Polly_Examples.Options
{
    [Verb("timeout", HelpText = "Runs a timeout policy example")]
    public class TimeoutOptions
    {
        [Value(
            0, 
            MetaName = "ExampleKey",
            HelpText = "The string key representing the Timeout example to run"
        )]
        public string ExampleKey { get; set; }
    }
}