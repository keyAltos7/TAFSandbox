namespace TAFSandbox.Models
{
    using System;

    /// <summary>
    /// The execution result.
    /// </summary>
    public sealed class ExecutionResult
    {
        /// <summary>
        /// Contains details of an exception that led to errors in execution of code.
        /// </summary>
        public Exception Details { get; set; }

        /// <summary>
        /// The type of execution result.
        /// </summary>
        public ResultType ResultType { get; set; }
    }
}
