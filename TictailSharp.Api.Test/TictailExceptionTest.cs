using TictailSharp.Api.Model;
using Xunit;

namespace TictailSharp.Api.Test
{
    public class TictailExceptionTest
    {
        [Fact]
        public void Constructor_ExceptionJson_PropertiesPopulated()
        {
            const string tictailJsonReponse = "{" +
                                      "\"status\": 400, " +
                                      "\"message\": \"Invalid authorization code given\"," +
                                      "\"params\": {}, " +
                                      "\"support_email\": \"some@email2.com\"" +
                                  "}";

            var tictailException = new TictailException(tictailJsonReponse, "Detailed message");
            Assert.Equal(400, tictailException.Status);
            Assert.Equal("Invalid authorization code given", tictailException.Message);
            Assert.Equal("some@email2.com", tictailException.SupportEmail);
            Assert.Equal("Detailed message", tictailException.CustomMessage);
        }
    }
}
