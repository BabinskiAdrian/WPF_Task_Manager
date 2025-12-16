using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB_Task_Manager
{
    // MODEL
    // To jest zwykła klasa (POCO - Plain Old CLR Object).
    // Reprezentuje ona nasze dane, np. rekord z bazy danych.
    internal class TodoItem
    {
        public string Title { get; set; } = string.Empty;
        public bool IsDone { get; set; }
    }
}
