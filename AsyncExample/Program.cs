using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Share;

//Console.WriteLine("Hello, World!");

//var itemsService = new ItemsService();

//List<Item> items = new();

//// 1
////for (int i = 0; i < 5; i++)
////{
////    var bunch = await itemsService.GetBunchOfItemsAsync(i, 50);
////    items.AddRange(bunch);
////}

////2
//List<Task<IEnumerable<Item>>> itemsTasks = new();
//for (int i = 0; i < 5; i++)
//{
//    var bunchTask = itemsService.GetBunchOfItemsAsync(i, 50);
//    itemsTasks.Add(bunchTask);
//}

////Task.WhenAll(itemsTasks);

//items = itemsTasks.SelectMany(x => x.Result).ToList();

////

//Console.WriteLine("Start parallel calculation");
//foreach (var item in items)
//{
//    item.Name += "_changed";
//    //await Task.Delay(500);
//}

//foreach (var item in items)
//{
//    Console.WriteLine(item.Code + " * " + item.Name);
//}

//Parallel.ForEach(items, async x => { x.Name += "_changed"; await Task.Delay(500); });

//foreach (var item in items)
//{
//    Console.WriteLine(item.Code + " * " + item.Name);
//}

// Thread
ConcurrentDictionary<int, string> shareSource = new ConcurrentDictionary<int, string>();

foreach (var item in Enumerable.Range(0, 10))
{
    shareSource.TryAdd(item, item.ToString());

}


var myThread = new Thread(ShareResourceRun);
myThread.Name = "My thread";

myThread.Start();

var myThread1 = new Thread(ShareResourceRun);
myThread1.Name = "My thread 1";

myThread1.Start();


void MyThreadRun()
{
    var threadCurrent = Thread.CurrentThread;
    foreach (var item in Enumerable.Range(0, 10))
    {
        Thread.Sleep(1000);
        Console.WriteLine("Thread: " + threadCurrent.Name + "(" + threadCurrent.ManagedThreadId + ") " + "number: " + item);
    }
}
void ShareResourceRun()
{
    var rnd = new Random();
    var threadCurrent = Thread.CurrentThread;
    foreach (var item in shareSource)
    {
        Thread.Sleep(rnd.Next(1000, 5000));
        shareSource.Remove(item.Key, out string value);
        Console.WriteLine("Thread: " + threadCurrent.Name + "(" + threadCurrent.ManagedThreadId + ") " + "number: " + value);
    }
}
