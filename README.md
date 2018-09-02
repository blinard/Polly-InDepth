# Polly-InDepth

A set of in-depth Polly examples with a WebAPI project for them to target

## Scenarios to Cover

### Policy Concepts

#### Proactive vs Fault-Handling (Reactive) Policies

Briefly discuss

- Proactive policies
    - Timeout
    - Bulkhead Isolation
    - Cache
- Reactive policies
    - Retry
    - Circuit Breaker
    - Fallback

- Policy Execution Context (kvp bag)
    - https://github.com/App-vNext/Polly/wiki/Keys-And-Context-Data
- Policy Scopes (CB needs to be a higher scope than Retry, Fallback, etc. - CB tracks for all calls while Retry/Fallback are for specific calls)

### Timeout

1. Based on CancellationTokens by default (Optimistic)
2. Can be made to strictly enforce timeouts (Pessimistic) - this involves spinning up the action/delegate in a new thread though.
3. Careful about onTimeout event handlers - they need to return a Task (it's only used/applicable for pessimistic timeouts though)

### Retry

### Fallback

### Cache

### Circuit Breaker

1. Polly CBs maintain their CB state per instance - so be sure that you're not recreating the CB every time you instantiate the class. Additionally, if you want to apply the CB across multiple call sites, you need to make sure you're using the same CB instance for those sites.
2. Breaking can occur based on exceptions thrown from the underlying delegate or result returned from the underlying delegate
3. When a Polly CB is broken/open, it will return a BrokenCircuitException for each call.
3. Can Polly CBs be made to report failure some way other than throwing an exception? (Exceptions are still somewhat expensive right?). Can they be made to execute a fallback (internally) and return that result instead?

Advanced Circuit Breaker deets: https://github.com/App-vNext/Polly/wiki/Advanced-Circuit-Breaker

### Composition - PolicyWrap

[//]: # (MSEG vNext to include a SLLLogger Policy?)

### Bulkhead Isolation

[//]: # (Discuss MSEG-specific implementation - ResiliencyContext, etc.)