# Integration Engine
### *Asynchronous Resilience & Fault Tolerance Study*

## Overview
A high-level C# engine designed to handle "flaky" integrations using the **Circuit Breaker** and **Retry** patterns. This project demonstrates advanced mastery of **Generics**, **Delegates**, and **Asynchronous Programming**.

## Key Features
- **Generic Resilience Wrapper:** Implements `ExecuteWithRetryAsync<T>` using `Func<Task<T>>` delegates, allowing any logic to be wrapped in a fault-tolerant supervisor.
- **Asynchronous Execution:** Fully non-blocking I/O using the `async/await` pattern and `Task.Delay` for efficient resource management.
- **Circuit Breaker Pattern:** Monitors attempt counts and "trips" the circuit after a defined threshold to prevent system cascading failures.
