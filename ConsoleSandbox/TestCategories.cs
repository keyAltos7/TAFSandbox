using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSandbox
{
    public static class TestCategories
    {
        public enum TestingProcedure
        {
            BuildCertification,
            ReleaseTesting
        }

        public enum TestSuite
        {
            BuildCertification,
            ReleaseTesting
        }

        public enum Feature
        {
            Search
        }

        public enum Product
        {
            Innovator11,
            Innovator12,
            StandardSolutions,
            ASF
        }


        //#region Testing procedures 
        //public const string BuildCertification = "Build Certification";

        //public const string ReleaseTesting = "Release Testing";
        //#endregion

        //#region Test suites 
        //public const string CoreSmoke = "Core Smoke Tests";

        //public const string  = "Smoke Tests";

        //public const string FullFunctionalRegression = "Full Functional Regression";
        //#endregion

        //#region Features 
        //public const string Searching = "Searching";

        //// ToDo: TBD
        //#endregion

        //#region Products 
        //public const string Innovator11 = "Innovator 11";

        //public const string Innovator12 = "Innovator 12";

        //public const string StandardSolutions = "Standard Solutions";

        //public const string ASF = "ASF";
        //#endregion
    }
}
