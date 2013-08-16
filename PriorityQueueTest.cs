namespace PriorityQueue
{
    using System;
    using System.Collections.Generic;

    class PriorityQueueTest
    {
        static void Main()
        {
            PriorityQueue<Task> tasksQueue = new PriorityQueue<Task>();
            tasksQueue.Enqueue(new Task("Eat something", 1));
            tasksQueue.Enqueue(new Task("Go to work", 2));
            tasksQueue.Enqueue(new Task("Do the dishes", 3));
            tasksQueue.Enqueue(new Task("Sleep", 5));
            tasksQueue.Enqueue(new Task("Do nothing", 4));

            Console.WriteLine("Priory queue is: ");
            Console.WriteLine(tasksQueue.ToString());
          
            Task removed = tasksQueue.Dequeue();
            Console.WriteLine("Removed: " + removed);
            Console.WriteLine("Priory queue is now: ");
            Console.WriteLine(tasksQueue.ToString());

            removed = tasksQueue.Dequeue();
            Console.WriteLine("Removed: " + removed);
            Console.WriteLine("Priory queue is now: ");
            Console.WriteLine(tasksQueue.ToString());

            removed = tasksQueue.Dequeue();
            Console.WriteLine("Removed:" + removed);
            Console.WriteLine(tasksQueue.ToString());

            Task urgentTask = new Task("Go to the protests", 1);
            tasksQueue.Enqueue(urgentTask);
            Console.WriteLine("Enqueued: " + urgentTask);
            Console.WriteLine("Priory queue is now: ");
            Console.WriteLine(tasksQueue.ToString());

            removed = tasksQueue.Dequeue();
            Console.WriteLine("Removed: " + removed);
            Console.WriteLine("Priory queue is now: ");
            Console.WriteLine(tasksQueue.ToString());

            removed = tasksQueue.Dequeue();
            Console.WriteLine("Removed: " + removed);
            Console.WriteLine("Priory queue is now: ");
            Console.WriteLine(tasksQueue.Peek());
        }
    }
}
