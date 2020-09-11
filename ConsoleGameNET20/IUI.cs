using System;

namespace ConsoleGameNET20
{
    public interface IUI
    {
        void AddMessage(string message);
        void Clear();
        void Draw(ConsoleMap map);
        ConsoleKey GetKey();
        void PrintLog();
        void PrintStats(string stats);
    }
}