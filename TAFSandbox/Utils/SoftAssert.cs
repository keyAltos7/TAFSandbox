namespace TAFSandbox.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Models;

    using Assert = TAFSandbox.Models.Assert;

    /// <summary>
    /// Provide a .
    /// </summary>
    public sealed partial class SoftAssert
    {
        private List<Assert> asserts = new List<Assert>();
        
        /// <summary>
        /// Asserts that a condition is true. 
        /// </summary>
        /// <param name="condition">The evaluated condition</param>
        /// <param name="assertName">The name of assert to display in case of failure</param>
        public void IsTrue(bool condition, string assertName = null)
        {
            VerifyCondition(() => NUnit.Framework.Assert.IsTrue(condition, assertName), assertName);
        }

        /// <summary>
        /// The print results.
        /// </summary>
        public void PrintResults()
        {
            // ToDo: rewrite logging
            Console.WriteLine(this);
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Assert assert in this.asserts)
            {
                sb.Append($"{assert}{Environment.NewLine}");
            }

            return sb.ToString();
        }

        /// <summary>
        /// The verify action in 'safe' mode. If action performing leads to a new exception the assert will be registred as failed 
        /// </summary>
        /// <param name="action">
        /// The action for verification
        /// </param>
        /// <param name="assertName">
        /// The assert name.
        /// </param>
        private void VerifyCondition(Action action, string assertName = null)
        {
            var conditonVerifyingResult = SafeExecutor.Execute(action);
            
            var assert = new Assert
            {
                Name = string.IsNullOrEmpty(assertName) ? $"{action.Method.Name}" : assertName,
                Outcome = conditonVerifyingResult.ResultType == ResultType.Success ? Outcome.Passed : Outcome.Failed,
                Exception = conditonVerifyingResult.Details
            };

            asserts.Add(assert);
        }
    }   
}
