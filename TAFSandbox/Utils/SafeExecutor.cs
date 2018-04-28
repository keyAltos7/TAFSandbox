namespace TAFSandbox.Utils
{
    using System;

    using Models;

    /// <summary>
    /// Provides for safe execution of blocks of managed code.
    /// </summary>
    public static class SafeExecutor
    {
        /// <summary>
        /// Executes a method and returns the result of operation.
        /// </summary>
        /// <param name="method">A void-return delegate.</param>
        /// <returns>The result of a method invocation.</returns>
        public static ExecutionResult Execute(Action method)
        {
            var result = new ExecutionResult();

            try
            {
                method();
                result.ResultType = ResultType.Success;
            }
            catch (Exception e)
            {
                result.ResultType = ResultType.Failure;
                result.Details = e;
            }

            return result;
        }

        /// <summary>
        /// Executes a method that returns a value and returns the result of operation.
        /// </summary>
        /// <param name="method">A value-return delegate.</param>
        /// <param name="returnedValue">A value returned by the method.</param>
        /// <typeparam name="T">The type of the value returned by the method.</typeparam>
        /// <returns>The result of a method invocation.</returns>
        public static ExecutionResult Execute<T>(Func<T> method, out T returnedValue)
        {
            T value = default(T);
            ExecutionResult result = SafeExecutor.Execute(() => { value = method(); });

            returnedValue = value;
            return result;
        }
    }
}
