namespace PatternsTrainingExamples
{
	using System;

	namespace DoFactory.GangOfFour.Facade.Structural
    {
        class MainApp

        {
            /// <summary>

            /// Entry point into console application.

            /// </summary>

            public static void Main()
            {
                Facade facade = new Facade();

                facade.MethodA();
                facade.MethodB();

                // Wait for user

                Console.ReadKey();
            }
        }

        /// <summary>

        /// The 'Subsystem ClassA' class

        /// </summary>

        class SubSystemOne

        {
            public void MethodOne()
            {
                Console.WriteLine(" SubSystemOne Method");
            }
        }

        /// <summary>

        /// The 'Subsystem ClassB' class

        /// </summary>

        class SubSystemTwo

        {
            public void MethodTwo()
            {
                Console.WriteLine(" SubSystemTwo Method");
            }
        }

        /// <summary>

        /// The 'Subsystem ClassC' class

        /// </summary>

        class SubSystemThree

        {
            public void MethodThree()
            {
                Console.WriteLine(" SubSystemThree Method");
            }
        }

        /// <summary>

        /// The 'Subsystem ClassD' class

        /// </summary>

        class SubSystemFour

        {
            public void MethodFour()
            {
                Console.WriteLine(" SubSystemFour Method");
            }
        }

        /// <summary>

        /// The 'Facade' class

        /// </summary>

        class Facade

        {
            private SubSystemOne _one;
            private SubSystemTwo _two;
            private SubSystemThree _three;
            private SubSystemFour _four;

            public Facade()
            {
                this._one = new SubSystemOne();
                this._two = new SubSystemTwo();
                this._three = new SubSystemThree();
                this._four = new SubSystemFour();
            }

            public void MethodA()
            {
                Console.WriteLine("\nMethodA() ---- ");
                this._one.MethodOne();
                this._two.MethodTwo();
                this._four.MethodFour();
            }

            public void MethodB()
            {
                Console.WriteLine("\nMethodB() ---- ");
                this._two.MethodTwo();
                this._three.MethodThree();
            }
        }
    }
}

//public class InnovatorHelper : IDisposable
//{
//	public static Item ApplyAml(InnovatorConnection conn, string aml)
//	{
//		Validator.CheckParamatersForNull(aml);
//		Validator.CheckParamatersForNull(conn);
//		Item applyRes = conn.Innovator.applyAML(aml);
//		if (!string.IsNullOrEmpty(applyRes.getErrorCode()))
//		{
//			ReportHelper.Instance.Info("Error on applying aml!!!");
//			ReportHelper.Instance.Info(applyRes.getErrorDetail());
//		}

//		return applyRes;
//	}

//	public static string ActivateFeature(InnovatorConnection conn, string featureName)
//	{
//		Validator.CheckParamatersForNull(conn);
//		string webServiceUrl = AppConfig.Instance.BaseUrl + "/Server/Licensing.asmx/ImportFeatureLicense";
//		string postData = "encryptedFeatureLicense=" + WebUtility.UrlEncode(GetFeatureLicense(featureName));
//		ICookieContainerProvider ccProvider =
//			CookieContainerProviderFactory.GetCookieContainerProviderWrapper(new CookieContainer());
//		HttpWebRequest webRequest =
//			(HttpWebRequest)ApplicationRequestProvider.Instance.GetWebRequest(new Uri(webServiceUrl), ccProvider);
//		webRequest.Headers.Set("AUTHUSER", conn.LogOnName);
//		webRequest.Headers.Set("AUTHPASSWORD", conn.PasswordHash);
//		webRequest.Headers.Set("DATABASE", conn.GetDatabaseName());
//		webRequest.AllowWriteStreamBuffering = true;
//		webRequest.Method = WebRequestMethods.Http.Post;
//		webRequest.ContentLength = postData.Length;
//		webRequest.ContentType = "application/x-www-form-urlencoded";
//		bool isError = false;
//		HttpWebResponse webResponse;
//		try
//		{
//			if (postData.Length > 0)
//			{
//				using (var writer = new StreamWriter(webRequest.GetRequestStream()))
//				{
//					writer.Write(postData);
//				}
//			}

//			webResponse = (HttpWebResponse)webRequest.GetResponse();
//		}
//		catch (WebException ex)
//		{
//			isError = true;
//			webResponse = (HttpWebResponse)ex.Response;
//		}

//		string result;
//		using (var streamReader = new StreamReader(webResponse.GetResponseStream()))
//		{
//			result = streamReader.ReadToEnd();
//		}

//		if (isError)
//		{
//			return "<Result>" + SecurityElement.Escape(result) + "</Result>";
//		}

//		return result;
//	}

//	public static string GetFeatureLicense(string featureName)
//	{
//		string result;
//		switch (featureName)
//		{
//			case "Aras.PremierSubscription":
//				result = AppConfig.Instance.ArasPremierSubscriptionFeatureLicense;
//				break;
//			case "Aras.PDFViewer":
//				result = AppConfig.Instance.ArasPdfViewerFeatureLicense;
//				break;
//			case "Aras.SelfServiceReporting":
//				result = AppConfig.Instance.ArasSelfServiceReportingFeatureLicense;
//				break;
//			default:
//				throw new NotSupportedException(featureName);
//		}

//		return result;
//	}
//}
