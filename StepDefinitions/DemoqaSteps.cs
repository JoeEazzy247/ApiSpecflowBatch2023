using NUnit.Framework;
using RestSharp;

namespace ApiSpecflowBatch2023October.StepDefinitions
{
    [Binding]
    public sealed class DemoqaSteps
    {
        Pageobject pageobject;
        RestResponse response;
        public DemoqaSteps()
        {
            pageobject = new Pageobject(); 
        }

        [Given(@"I have a client")]
        public void GivenIAmAnEndpoint()
        {
            var client = pageobject.SetUrl();
        }

        //[When(@"I make a '([^']*)' request")]
        [When(@"I make a '(GET|POST|PUT|DELETE)' request")]
        public void WhenIMakeARequest(string option)
        {
            if (option == "GET")
            {
                var request = 
                    pageobject.GetRequest(pageobject.baseurl2,
                    "/BookStore/v1/Books", RestSharp.Method.Get);
            }
            else if (option == "POST")
            {

                var payload = new
                {
                    userName = "Joe_001" + new Random().Next(1, 999),
                    password = "Password001!"
                };
                var request =
                    pageobject.PostRequest2(pageobject.baseurl2,
                    "/Account/v1/User", RestSharp.Method.Post, payload);
            }
            else if (option == "DELETE")
            {
                var request =
                    pageobject.DeleteRequest(pageobject.baseurl2,
                    "/Account/v1/User", RestSharp.Method.Put,
                    new { username = "", password = "" });
            }
        }

        [Then(@"I have '([^']*)' status code")]
        public void ThenIHaveStatusCode(string statusCode)
        {
            response = pageobject.GetResponse();
            Assert.True(Convert.ToInt32(response.StatusCode)
                .Equals(Convert.ToInt32(statusCode)));
        }

        [Then(@"The response body is as expected")]
        public void ThenTheResponseBodyIsAsExpected()
        {
            var data = pageobject.GetDeserializedcontent<object>(response);
        }

    }
}