using FlattenTreeExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlattenTreeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Flattening a tree of Tasks");



            FQJob job = new FQJob();
            job.Id = 1;
            
            //new task 1 no sub tasks
            FQTask task1 = new FQTask(1, Guid.NewGuid().ToString(), 1, null);
            
            //new task 2 child sub tasks
            FQTask task2 = new FQTask(2, Guid.NewGuid().ToString(), 2, 0);
            FQTask task2_1 = new FQTask(3, Guid.NewGuid().ToString(), 3, 2);
            task2.FQTasks = new List<FQTask>();
            task2.FQTasks.Add(task2_1);

            //new task 3 child sub tasks
            FQTask task3 = new FQTask(4, Guid.NewGuid().ToString(), 4, 0);
            FQTask task3_1 = new FQTask(5, Guid.NewGuid().ToString(), 5, 4);
            FQTask task3_2 = new FQTask(6, Guid.NewGuid().ToString(), 6, 4);
            task3.FQTasks = new List<FQTask>();
            task3.FQTasks.Add(task3_1);
            task3.FQTasks.Add(task3_2);


            //new task 4 child sub tasks and a further child of a child
            FQTask task4 = new FQTask(7, Guid.NewGuid().ToString(), 7, 0);
            FQTask task4_1 = new FQTask(8, Guid.NewGuid().ToString(), 8, 7);
            FQTask task4_2 = new FQTask(9, Guid.NewGuid().ToString(), 9, 7);
            FQTask task4_2_1 = new FQTask(10, Guid.NewGuid().ToString(), 10, 9);
            FQTask task4_2_1_1 = new FQTask(11, Guid.NewGuid().ToString(), 11, 10);




            task4.FQTasks = new List<FQTask>();
            task4.FQTasks.Add(task4_1);
            task4.FQTasks.Add(task4_2);
            task4_2.FQTasks = new List<FQTask>();
            task4_2.FQTasks.Add(task4_2_1);
            task4_2_1.FQTasks = new List<FQTask>();
            task4_2.FQTasks.Add(task4_2_1_1);

            job.FQTasks = new List<FQTask>();
            job.FQTasks.Add(task1);
            job.FQTasks.Add(task2);
            job.FQTasks.Add(task3);
            job.FQTasks.Add(task4);

            List<List<FQTask>> flattened = new List<List<FQTask>>();
            foreach(var task in job.FQTasks)
            {
                flattened.Add(Flatten(task));
            }

            var finalList = flattened.SelectMany(x => x).ToList();
            foreach(var item in finalList)
            {
                string parId = "";
                if(item.ParentId != null)
                {
                    parId = item.ParentId.ToString();
                }
                Console.WriteLine("id: " + item.Id + " seq: " + item.ProcessSeq + " parentId: " + parId);
            }
        }


        public static List<FQTask> Flatten(FQTask task)
        {           
            //create new list and add intial task
            var flattened = new List<FQTask> { task };

            //does taks have any children
            var children = task.FQTasks;

            if (children != null)
            {
                //iterate through the siblings and flatten them
                foreach (var child in children)
                {
                    //recursively add the siblings and their children to the list
                    flattened.AddRange(Flatten(child));
                }
            }
            return flattened;
        }


    }
}
