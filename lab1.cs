/*
Описать класс «записная книжка». 
Предусмотреть возможность работы с произвольным числом 
записей, поиска записи по какому-либо признаку (например, по ФИО, дате рождения, номеру
телефона), добавления и удаления записей, сортировки по ФИО. Программа должна содержать
меню, позволяющее осуществлять проверку всех методов.
*/
 
using System;
using System.Collections.Generic;
using System.Collections;

namespace labs {
    
    class lab1 {
        public void Main1() {
            Notebook notebook = new Notebook();
            // Меню
            while (true) {
                Console.WriteLine("FUNCTION: add, remove, find, sort and print");
                string func = Console.ReadLine();
                if (func == "add") {
                    Note note = InputNote();
                    notebook.AddNote(note);
                    Console.WriteLine("Note added");
                } else if (func == "remove") {
                    Note note = InputNote();
                    notebook.RemoveNote(note);
                    Console.WriteLine("Note deleted");
                } else if (func == "find") {
                    Console.WriteLine("Enter name");
                    string name = Console.ReadLine();
                    List<Note> FindNotes = notebook.FindNote(name);
                    foreach (Note note in FindNotes) {
                        Console.WriteLine("{0} - {1} - {2}", note.GetName(), 
                        note.GetDate().ToString("d"), note.GetNumber());
                    }
                    if (FindNotes.Count == 0) {
                        Console.WriteLine("Not found");
                    }
                } else if (func == "sort") {
                    notebook.SortByName();
                    Console.WriteLine("Notebook sorted");
                } else if (func == "print") {
                    foreach (Note note in notebook.GetNotebook()) {
                    Console.WriteLine("{0} - {1} - {2}", note.GetName(), 
                    note.GetDate().ToString("d"), note.GetNumber());
                    }
                }
                Console.WriteLine("DO YOU WANT TO CONTINUE? y or n");
                string cont = Console.ReadLine();
                if (cont == "n") {
                    break;
                }
            }
            foreach (Note note in notebook.GetNotebook()) {
                Console.WriteLine("{0} - {1} - {2}", note.GetName(), 
                note.GetDate().ToString("d"), note.GetNumber());
            }
        }

        static Note InputNote() {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter date of birth");
            DateTime date = DateTime.Parse(Console.ReadLine()).Date; // Jan 1, 2009 to 1/1/2009
            Console.WriteLine("Enter number phone");
            string number = Console.ReadLine();
            Note note = new Note(name, date, number);
            return note;
        }
    }

    class NoteCompare : IComparer<Note> {

        public int Compare(Note x, Note y) {
            if (x == null || y == null) return -1;
            return x.GetName().CompareTo(y.GetName());
        }
    }
    class Note {
        private string Name;
        private DateTime Date;
        private string Number;

        public Note() {  }
        public Note(string name, DateTime date, string number) {
            Name = name;
            Date = date;
            Number = number;
        }
        public string GetName() {
            return Name;
        }
        public DateTime GetDate() {
            return Date;
        }
        public string GetNumber() {
            return Number;
        }
    }
    class Notebook {
        private List<Note> notebook = new List<Note>();

        public List<Note> GetNotebook() {
            return notebook;
        }

        public List<Note> FindNote(string name) {
            Note note = new Note(name, new DateTime(2001, 1, 1) , "80000000000") {  };
            notebook.Sort((x, y) => string.Compare(x.GetName(), y.GetName()));
            List<Note> notebook_fake = notebook;
            List<Note> findNotes = new List<Note>();
            int index = 0;
            while (index >= 0) {
                index = notebook_fake.BinarySearch(note, new NoteCompare());
                if (index >= 0) {
                    findNotes.Add(notebook_fake[index]);
                    notebook_fake.Remove(notebook_fake[index]);
                } 
            }
            return findNotes;
            //return notebook.FindAll(x => x.GetName() == name);
        }

        public void AddNote(Note note) {
            notebook.Add(note);
        }

        public void RemoveNote(Note note) {
            notebook.RemoveAll(x => x.GetNumber() == note.GetNumber());
        }

        public List<Note> SortByName() { 
            notebook.Sort((x, y) => string.Compare(x.GetName(), y.GetName()));
            return notebook;
        }
    }
}
