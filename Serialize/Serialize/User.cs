using System.Collections.Generic;
using System;

namespace Serialize
{
    [Serializable]
    public class User
    {
        public string name;
        public List<string> listOfFigures = new List<string>();
        public List<PointPlane> listOfObjects = new List<PointPlane>();

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public List<string> ListOfFigures
        {
            get
            {
                return listOfFigures;
            }
        }
        public List<PointPlane> ListOfObjects
        {
            get
            {
                return listOfObjects;
            }
        }

        public User(string name)
        {
            this.name = name;
        }

        public User() { }

        public static User ChangeUser(string name)
        {
            return new User(name);
        }

        public void AddFigure(PointPlane figure)
        {
            listOfFigures.Add(figure.GetInfo());
            listOfObjects.Add(figure);
        }

        public void ClearCanvas()
        {
            this.listOfFigures.Clear();
            this.listOfObjects.Clear();
        }
    }
}
