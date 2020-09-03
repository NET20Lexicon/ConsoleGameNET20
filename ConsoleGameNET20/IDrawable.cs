using System;

namespace ConsoleGameNET20
{
    public interface IDrawable
    {
        ConsoleColor Color { get; set; }
        string Symbol { get; }
    }
}