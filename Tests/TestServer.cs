namespace Assessment.Tests
{
    internal class TestServer
    {
        private object value;

        public TestServer(object value)
        {
            this.value = value;
        }

        internal object CreateHttpClient()
        {
            throw new NotImplementedException();
        }
    }
}