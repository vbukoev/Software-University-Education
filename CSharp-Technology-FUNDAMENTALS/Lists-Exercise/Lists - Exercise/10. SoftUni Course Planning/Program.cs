using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> lessonsList = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();
            while (command != "course start")
            {
                List<string> manipulations = command.Split(":").ToList();
                string operation = manipulations[0];
                Operations(lessonsList, manipulations, operation);
                command = Console.ReadLine();
            }
            for (int i = 0; i < lessonsList.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessonsList[i]}");
            }
        }

        private static void Operations(List<string> lessonsList, List<string> manipulations, string operation)
        {
            switch (operation)
            {
                case "Add":
                    string lessonTitle = manipulations[1];
                    if (!lessonsList.Contains(lessonTitle))
                    {
                        lessonsList.Add(lessonTitle);
                    }
                    break;
                case "Insert":
                     lessonTitle = manipulations[1];
                    int index = int.Parse(manipulations[2]);
                    if (!lessonsList.Contains(lessonTitle))
                    {
                        lessonsList.Insert(index, lessonTitle);
                    }
                    break;
                case "Remove":
                    lessonTitle = manipulations[1];
                    int indexOfLesson = lessonsList.IndexOf(lessonTitle);
                    if (lessonsList.Contains($"{lessonTitle}-Exercise"))
                    {
                        lessonsList.RemoveAt(indexOfLesson + 1);
                        lessonsList.Remove(lessonTitle);
                    }
                    else
                    {
                        lessonsList.Remove(lessonTitle);
                    }
                    break;
                case "Swap":
                    string firstLessonName = manipulations[1];
                    string secondLessonName = manipulations[2];
                    if (lessonsList.Contains(firstLessonName) && lessonsList.Contains(secondLessonName))
                    {
                        SwappingLessons(lessonsList, firstLessonName, secondLessonName);
                    }
                    break;
                case "Exercise":
                    lessonTitle = manipulations[1];
                    int indexOfExer = lessonsList.IndexOf(lessonTitle);
                    if (lessonsList.Contains(lessonTitle))
                    {
                        if (!lessonsList.Contains($"{lessonTitle}-Exercise"))
                        {
                            lessonsList.Insert(indexOfExer + 1, $"{lessonTitle}-Exercise");
                        }
                    }
                    else
                    {
                        lessonsList.Add(lessonTitle);
                        lessonsList.Add($"{lessonTitle}-Exercise");
                    }
                    break;
            }
        }

        private static void SwappingLessons(List<string> lessonsList, string firstLessonTitle, string secondLessonTitle)
        {
            if (lessonsList.Contains($"{firstLessonTitle}-Exercise") &&
                 lessonsList.Contains($"{secondLessonTitle}-Exercise"))
            {
                for (int i = 0; i < lessonsList.Count; i++)
                {
                    if (lessonsList[i] == firstLessonTitle)
                    {
                        lessonsList[i] = secondLessonTitle;
                        lessonsList.Insert(i + 1, $"{secondLessonTitle}-Exercise");
                        lessonsList.RemoveAt(i + 2);
                    }
                    else if (lessonsList[i] == secondLessonTitle)
                    {
                        lessonsList[i] = firstLessonTitle;
                        lessonsList.Insert(i + 1, $"{firstLessonTitle}-Exercise");
                        lessonsList.RemoveAt(i + 2);
                    }
                }
            }
            else if (lessonsList.Contains($"{firstLessonTitle}-Exercise"))
            {
                for (int i = 0; i < lessonsList.Count; i++)
                {
                    if (lessonsList[i] == firstLessonTitle)
                    {
                        lessonsList[i] = secondLessonTitle;
                        lessonsList.RemoveAt(i + 1);
                    }
                    else if (lessonsList[i] == secondLessonTitle)
                    {
                        lessonsList[i] = firstLessonTitle;
                        lessonsList.Insert(i + 1, $"{firstLessonTitle}-Exercise");
                    }
                }
            }
            else if (lessonsList.Contains($"{secondLessonTitle}-Exercise"))
            {
                for (int i = 0; i < lessonsList.Count; i++)
                {
                    if (lessonsList[i] == firstLessonTitle)
                    {
                        lessonsList[i] = secondLessonTitle;
                        lessonsList.Insert(i + 1, $"{secondLessonTitle}-Exercise");
                    }
                    else if (lessonsList[i] == secondLessonTitle)
                    {
                        lessonsList[i] = firstLessonTitle;
                        lessonsList.RemoveAt(i + 1);
                    }
                }
            }
            else if ((!lessonsList.Contains($"{firstLessonTitle}-Exercise")) &&
                    (!lessonsList.Contains($"{secondLessonTitle}-Exercise")))
            {
                for (int i = 0; i < lessonsList.Count; i++)
                {
                    if (lessonsList[i] == firstLessonTitle)
                    {
                        lessonsList[i] = secondLessonTitle;
                    }
                    else if (lessonsList[i] == secondLessonTitle)
                    {
                        lessonsList[i] = firstLessonTitle;
                    }
                }
            }
        }
    }
}
