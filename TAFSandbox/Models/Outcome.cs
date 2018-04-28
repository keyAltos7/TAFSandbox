namespace TAFSandbox.Models
{
    /// <summary>
    /// Enumerates all valid Assert outcomes.
    /// </summary>
    public enum Outcome
    {
        /// <summary>
        /// Indicates a quality check outcome of passed.
        /// </summary>
        Passed = 1,

        /// <summary>
        /// Indicates a quality check outcome of failed.
        /// </summary>
        Failed = 2,

        /// <summary>
        /// Indicates a quality check outcome of inconclusive.
        /// </summary>
        Inconclusive = 3
    }
}
