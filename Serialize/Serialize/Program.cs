using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Serialize
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name :");
            string name = Console.ReadLine();
            User user = new User(name);
            List<User> listOfUsers = new List<User>();
            List<string> usersNames = new List<string>();
            listOfUsers.Add(user);
            usersNames.Add(name);
            string jsonPath = @"C:\JsonStorage",
                usersPath = @"C:\Users\edemc\source\repos\Serialize\Serialize\bin\Debug\users.xml",
                figuresPath = @"C:\Users\edemc\source\repos\Serialize\Serialize\bin\Debug\figures.dat";
            DirectoryInfo directory = new DirectoryInfo(jsonPath);

            int figureId = 0;
            bool isWorking = true;
            while (isWorking)
            {
                Console.WriteLine("Choose your action:");
                Console.WriteLine("1 - Add a figure");
                Console.WriteLine("2 - Print figures");
                Console.WriteLine("3 - Clear canvas");
                Console.WriteLine("4 - Exit");
                Console.WriteLine("5 - Change user");
                Console.WriteLine("6 - Serialize all figures");
                Console.WriteLine("7 - Serialize all users");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("1 - Point");
                        Console.WriteLine("2 - Line");
                        Console.WriteLine("3 - Circle");
                        Console.WriteLine("4 - Ring");
                        int figureChoice = int.Parse(Console.ReadLine());
                        switch (figureChoice)
                        {
                            case 1:
                                Console.Write("Please enter the coordinates of point, {0}: \nx: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double xPoint = double.Parse(Console.ReadLine());
                                Console.Write("y: ");
                                double yPoint = double.Parse(Console.ReadLine());
                                PointPlane point = new PointPlane(xPoint, yPoint);
                                figureId++;
                                point.id = figureId;
                                user.AddFigure(point);
                                break;
                            case 2:
                                Console.Write("Please enter the coordinates of line, {0}: \nx1: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double x1Line = double.Parse(Console.ReadLine());
                                Console.Write("y1: ");
                                double y1Line = double.Parse(Console.ReadLine());
                                Console.Write("Please enter the coordinates of line, {0}: \nx2: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double x2Line = double.Parse(Console.ReadLine());
                                Console.Write("y2: ");
                                double y2Line = double.Parse(Console.ReadLine());
                                Line line = new Line(x1Line, y1Line, x2Line, y2Line);
                                figureId++;
                                line.id = figureId;
                                user.AddFigure(line);
                                break;
                            case 3:
                                Console.Write("Please enter the coordinates of circle, {0}: \nx1: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double x1Circle = double.Parse(Console.ReadLine());
                                Console.Write("y1: ");
                                double y1Circle = double.Parse(Console.ReadLine());
                                Console.Write("Please enter the radius, {0}: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double radiusCircle = double.Parse(Console.ReadLine());
                                Circle circle = new Circle(x1Circle, y1Circle, radiusCircle);
                                figureId++;
                                circle.id = figureId;
                                user.AddFigure(circle);
                                break;
                            case 4:
                                Console.Write("Please enter the coordinates of ring, {0}: \nx1: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double x1Ring = double.Parse(Console.ReadLine());
                                Console.Write("y1: ");
                                double y1Ring = double.Parse(Console.ReadLine());
                                Console.Write("Please enter the radius, {0}: ", listOfUsers[listOfUsers.Count - 1].Name);
                                double radiusRing = double.Parse(Console.ReadLine());
                                Ring ring = new Ring(x1Ring, y1Ring, radiusRing);
                                figureId++;
                                ring.id = figureId;
                                user.AddFigure(ring);
                                break;
                        }
                        break;
                    case 2:
                        foreach (string info in user.ListOfFigures)
                        {
                            Console.WriteLine(info);
                        }
                        break;
                    case 3:
                        user.ClearCanvas();
                        Console.WriteLine("Canvas has been cleared!");
                        figureId = 0;
                        break;
                    case 4:
                        isWorking = false;
                        Console.WriteLine("Goodbye, {0}!", user.Name);
                        if (directory.Exists)
                        {
                            foreach (var figureFile in directory.GetFiles())
                            {
                                figureFile.Delete();
                            }
                        }

                        File.Delete(figuresPath);
                        File.Delete(usersPath);
                        user.ListOfObjects.Clear();
                        user.ListOfFigures.Clear();


                        Console.WriteLine("Please press any key to exit");
                        break;
                    case 5:
                        Console.WriteLine("Please enter your name: ");
                        string anothername = Console.ReadLine();
                        User anotherUser = new User(anothername);
                        listOfUsers.Add(anotherUser);
                        usersNames.Add(anothername);
                        Console.WriteLine("Welcome, " + anothername + "!");
                        break;
                    case 6:
                        if (user.ListOfObjects.Count != 0)
                        {
                            Console.WriteLine("Выбирите тип сериализации:");
                            Console.WriteLine("1 - Binary");
                            Console.WriteLine("2 - Json");
                            int serChoice = int.Parse(Console.ReadLine());
                            switch (serChoice)
                            {
                                case 1:
                                    // создаем объект BinaryFormatter
                                    BinaryFormatter formatter = new BinaryFormatter();
                                    using (FileStream fs = new FileStream("figures.dat", FileMode.OpenOrCreate))
                                    {
                                        // сериализуем весь массив фигур
                                        formatter.Serialize(fs, user.ListOfObjects);

                                        Console.WriteLine("Объекты сериализованы");
                                    }
                                    Console.WriteLine("Произвести десериализацию?");
                                    Console.WriteLine("1 - Да");
                                    Console.WriteLine("2 - Нет");
                                    int deserChoice = int.Parse(Console.ReadLine());
                                    if (deserChoice == 1)
                                    {
                                        using (FileStream fs = new FileStream("figures.dat", FileMode.OpenOrCreate))
                                        {
                                            List<PointPlane> deserilizeFigure = (List<PointPlane>)formatter.Deserialize(fs);

                                            foreach (PointPlane p in deserilizeFigure)
                                            {
                                                p.GetInfo();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Выберите дальнейшее действие");
                                    }

                                    break;
                                case 2:
                                    if (!directory.Exists)
                                    {
                                        directory.Create();
                                    }
                                    foreach (var figure in user.ListOfObjects)
                                    {
                                        string figureName = jsonPath + "\\" + figure.id + ".json";
                                        using (StreamWriter writer = new StreamWriter(figureName))
                                        {
                                            writer.Write(JsonConvert.SerializeObject(figure));
                                        }
                                    }
                                    Console.WriteLine("Объекты сериализованы");
                                    Console.WriteLine("Произвести десериализацию?");
                                    Console.WriteLine("1 - Да");
                                    Console.WriteLine("2 - Нет");
                                    int jsondeserChoice = int.Parse(Console.ReadLine());
                                    if (jsondeserChoice == 1)
                                    {
                                        if (directory.Exists)
                                        {
                                            List<Object> list = new List<Object>();
                                            foreach (var figure in directory.GetFiles())
                                            {
                                                using (StreamReader reader = new StreamReader(figure.FullName))
                                                {
                                                    list.Add(JsonConvert.DeserializeObject<Object>(reader.ReadToEnd()));
                                                }
                                            }
                                            foreach (var figure in list)
                                            {
                                                Console.WriteLine(figure);
                                            }
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Выберите дальнейшее действие");
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Фигуры еще не были добавлены!");
                        }
                        break;
                    case 7:
                        // передаем в конструктор тип класса
                        XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<string>));

                        // получаем поток, куда будем записывать сериализованный объект
                        using (FileStream fs = new FileStream("users.xml", FileMode.OpenOrCreate))
                        {
                            xmlFormatter.Serialize(fs, usersNames);
                        }
                        Console.WriteLine("Объекты сериализованы");
                        Console.WriteLine("Произвести десериализацию?");
                        Console.WriteLine("1 - Да");
                        Console.WriteLine("2 - Нет");
                        int xmldeserChoice = int.Parse(Console.ReadLine());
                        if (xmldeserChoice == 1)
                        {
                            using (FileStream fs = new FileStream("users.xml", FileMode.OpenOrCreate))
                            {
                                List<string> newUsers = (List<string>)xmlFormatter.Deserialize(fs);
                                foreach (string u in newUsers)
                                {
                                    Console.WriteLine("Имя пользователя : " + u);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Выберите дальнейшее действие");
                        }
                        break;
                }


                Console.ReadLine();
            }
        }
    }
}
