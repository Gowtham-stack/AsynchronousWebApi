namespace AsynchronousWebApi.Processors
{
    public class ThreadProcessor
    {

        private static async Task DoingAsynchronousOperation()
        {
            await Task.Delay(3000);
            int b = 1;
            foreach (var a in Enumerable.Range(1, 1000))
            {
                b += a;
            }
            Console.WriteLine($"Thread Id:{Environment.CurrentManagedThreadId}");
        }
        public static void CreateMultipleThreads()
        {
            foreach (var a in Enumerable.Range(1, 10000))
            {
                Thread y = new Thread(() => WriteZ(a)); // create a new thread
                                                        //Thread.Sleep(3000); //suspend the thread for 3 seconds
                y.Start();// execute of the method WriteX()
                
           //     y.Join(); // Wait for thread to completed his task
            }
        }
        static void WriteZ(int id)
        {
            Thread.Sleep(20000);
            Console.WriteLine("" +
            $"{id} Done, Thread Id : {Environment.CurrentManagedThreadId}, Process Id : {Environment.ProcessId}");

        }
    }
}
