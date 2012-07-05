using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MontyHallParadox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Check theory start");
            CheckTheories();
            Console.ReadLine();
        }

        public static void CheckTheories()
        {
            int maxRound= 1000000;
            int runer = 0;
            var results = new List<bool>();
            int countHaveCar=0;
            int countHaveGoat=0;
            while (runer < maxRound)
            {
                var room = new Room();
                room.SelectFirstDoor();
                room.OpenDoorWithGoat();
                if (room.GetResultWhenChangeSelected()) {
                    countHaveCar++;
                }
                else {
                    countHaveGoat++;
                }

                runer++;
            }

            Console.WriteLine(string.Format("Result when change selected: Have a car: {0}, Have a goat: {1}", countHaveCar, countHaveGoat));
            
            runer = 0;
            countHaveCar = 0;
            countHaveGoat = 0;
            while (runer < maxRound)
            {
                var room = new Room();
                room.SelectFirstDoor();
                room.OpenDoorWithGoat();
                if (room.GetResultWhenNoChangeSelected())
                {
                    countHaveCar++;
                }
                else
                {
                    countHaveGoat++;
                }
                runer++;
            }
            Console.WriteLine(string.Format("Result when no! change selected: Have a car: {0}, Have a goat: {1}", countHaveCar, countHaveGoat));

        }

    }

    public class Room {
        Random random = new Random();
        

        /// <summary>
        /// Выбраная комната
        /// </summary>

       
        public List<Door> Doors = new List<Door>(3); 

        public Room()
        {
             Doors = new List<Door>(3);
             Doors.Add(new Door());
             Doors.Add(new Door());
             Doors.Add(new Door());
             Doors[random.Next(2)].Inside = true;
        }

        public void SelectFirstDoor()
        {
            Doors[random.Next(3)].IsSelected = true;
        }

        public void OpenDoorWithGoat()
        {
            Doors.First(s => s.Inside == false && !s.IsSelected).IsOpen = true;
        }

        public bool GetResultWhenChangeSelected()
        {
            return Doors.Single(s => !s.IsOpen && !s.IsSelected).Open();

        }

        public bool GetResultWhenNoChangeSelected()
        {
            return Doors.Single(s => s.IsSelected).Open();
        }

    }

    public class Door
    {
        /// <summary>
        /// Дверь выбрана
        /// </summary>
        public bool IsSelected { get; set; }
        /// <summary>
        /// Дверь открыта
        /// </summary>
        public bool IsOpen { get; set; }
        /// <summary>
        /// Коза ли внутри.
        /// </summary>
        public bool Inside { get; set; }
        public bool Open()
        {
            return Inside;
        }
    }
}
