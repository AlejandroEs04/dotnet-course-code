namespace AsyncTask 
{
    internal class Program 
    {
        static async Task Main(string[] agrs) // We're use async Task for creating a asynchronous method
        {   
            Task firstTask = new Task(() => {
                Thread.Sleep(100);
                Console.WriteLine("Task 1");
            });

            firstTask.Start(); // Whitout this, the task will not work

            Task secondTask = ConsoleAfterDelayAsync("Task 2", 150);

            ConsoleAfterDelay("Delay", 101);

            Task thirdTask = ConsoleAfterDelayAsync("Task 3", 50);

            await firstTask; // We have to add this for the program await to the task
            await secondTask;
            await thirdTask;

            Console.WriteLine("After the task was created");
        }

        static void ConsoleAfterDelay(string text, int delayTime)
        {
            Thread.Sleep(delayTime);
            Console.WriteLine(text);
        }

        static async Task ConsoleAfterDelayAsync(string text, int delayTime)
        {
            await Task.Delay(delayTime);
            Console.WriteLine(text);
        }
    }   
}