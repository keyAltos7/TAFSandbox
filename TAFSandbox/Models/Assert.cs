namespace TAFSandbox.Models
{
    using System;

    public class Assert
    {
        public string Name { get; set; }

        public Exception Exception { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;

        public Outcome Outcome { get; set; } = Outcome.Inconclusive;

        public override string ToString()
        {
            return $"Assert: {this.Name} - {this.DateTime} - {this.Outcome}{Environment.NewLine}";
        }
    }
}
