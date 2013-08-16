namespace PriorityQueue
{
    using System;

    public class Task : IComparable<Task>
    {
        public string Description { get; set; }
        public int Priority { get; set; }

        public Task(string description, int priority)
        {
            this.Description = description;
            this.Priority = priority;
        }

        public override string ToString()
        {
            string resultString = "(" + Priority.ToString() + ". " + Description + ")";

            return resultString;
        }

        public int CompareTo(Task other)
        {
            if (this.Priority < other.Priority)
            {
                return -1;
            }
            else if (this.Priority > other.Priority)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
