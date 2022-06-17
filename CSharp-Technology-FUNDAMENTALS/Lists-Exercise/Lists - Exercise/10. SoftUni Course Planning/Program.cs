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
                default:
                    break;
            }


        }

        private static void SwappingLessons(List<string> lessonsList, string firstLessonName, string secondLessonName)
        {
            if (lessonsList.Contains($"{firstLessonName}-Exercise") && lessonsList.Contains($"{secondLessonName}-Exercise"))
            {
                for (int i = 0; i < lessonsList.Count; i++)
                {
                    if (lessonsList[i] == firstLessonName)
                    {
                        lessonsList[i] = secondLessonName;
                        lessonsList.Insert(i + 1, $"{secondLessonName}-Exercise");
                        lessonsList.RemoveAt(i + 2);
                    }
                    else if (lessonsList[i] == secondLessonName)
                    {
                        lessonsList[i] = firstLessonName;
                        lessonsList.Insert(i + 1, $"{firstLessonName}-Exercise");
                        lessonsList.RemoveAt(i + 2);
                    }
                }
            }
            else if (lessonsList.Contains($"{firstLessonName}-Exercise"))
            {
                for (int i = 0; i < lessonsList.Count; i++)
                {
                    if (lessonsList[i] == firstLessonName)
                    {
                        lessonsList[i] = secondLessonName;
                        lessonsList.RemoveAt(i + 1);
                    }
                    else if (lessonsList[i] == secondLessonName)
                    {
                        lessonsList[i] = firstLessonName;
                        lessonsList.RemoveAt(i + 1);
                    }
                }
            }
            else if (lessonsList.Contains($"{secondLessonName}-Exercise"))
            {
                for (int i = 0; i < lessonsList.Count; i++)
                {
                    if (lessonsList[i] == firstLessonName)
                    {
                        lessonsList[i] = secondLessonName;
                        lessonsList.Insert(i + 1, $"{secondLessonName}-Exercise");
                    }
                    else if (lessonsList[i] == secondLessonName)
                    {
                        lessonsList[i] = firstLessonName;
                        lessonsList.RemoveAt(i + 1);
                    }
                }
            }
        }
    }
}


