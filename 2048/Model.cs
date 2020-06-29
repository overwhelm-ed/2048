using System;
using System.Data;
using System.Drawing;

namespace _2048
{
    public class Model
    {
        Map map;
        Random random = new Random();

        public int points;

        public Model(int size)
        {
            map = new Map(size);
        }

        public int size
        { 
            get 
            {
                return map.size;
            }
        }

        internal void Start()
        {
            for (var x = 0; x < size; x++)
                for (var y = 0; y < size; y++)
                    map.Set(x, y, 0);
            AddRandomNumber(2);
        }

        private void AddRandomNumber(int times)
        {
            var n = 0;
            while (n < times)
            {
                int x = random.Next(0, size);
                int y = random.Next(0, size);
                if (map.Get(x, y) == 0)
                {
                    map.Set(x, y, random.Next(1, 3) * 2);
                    n++;
                }
            }
        }

        internal void Up()
        {
            for (var x = 0; x < size; x++)
                for (var y = 0; y < size; y++) { }
        }

        internal void Down()
        {
            throw new NotImplementedException();
        }

        internal void Left()
        {
            throw new NotImplementedException();
        }

        internal void Right()
        {
            throw new NotImplementedException();
        }

        internal bool IsGameOver()
        {
            return true;
        }

        public int GetMap(int x, int y)
        {
            return map.Get(x, y);
        }
    }
}
