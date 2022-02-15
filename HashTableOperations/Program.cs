// See https://aka.ms/new-console-template for more information
using HashTableOperations;

MyMapNode<string, string> hash = new MyMapNode<string, string>(5);
hash.Add("0", "to");
hash.Add("1", "be");
hash.Add("2", "or");
hash.Add("3", "not");
hash.Add("4", "to");
hash.Add("5", "be");

Console.WriteLine($"5th index value:{hash.Get("5")}");
Console.WriteLine($"2nd index value:{hash.Get("2")}");
