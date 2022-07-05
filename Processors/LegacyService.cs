namespace AsynchronousWebApi.Processors
{
    public class LegacyService
    {
        public async Task<string> DoAsyncOperationWell()
        {
            var random = new Random();
            await Task.Delay(random.Next(10) * 1000);
            return Guid.NewGuid().ToString();
        }
    }
}
