// ---------------------------- W03 Project: Scripture Memorizer Program ----------------------------
// ---------------------------- Student: John Peter Joseph ----------------------------
// ---------------------------- Course: CSE 210: Programming with Classes ----------------------------

using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Psalms", 16, 5);
        string text = "The Lord is the portion of mine inheritance and of my cup: thou maintainest my lot.";

        Scripture scripture = new Scripture(reference, text);
    }
}