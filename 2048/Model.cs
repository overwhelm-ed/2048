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

        public void Start()
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

        public void Move(int x, int y, int dx, int dy)
        {
            if (map.Get(x, y) > 0)
                while (map.Get(x + dx, y + dy) == 0)
                {
                    map.Set(x + dx, y + dy, map.Get(x, y));
                    map.Set(x, y, 0);
                    x += dx;
                    y += dy;
                }
        }

        public void Join(int x, int y, int dx, int dy)
        {
            if (map.Get(x, y) > 0)
                if (map.Get(x + dx, y + dy) == map.Get(x, y))
                {
                    map.Set(x + dx, y + dy, map.Get(x, y));
                    points += map.Get(x, y);
                    while (map.Get(x - dx, y - dy) > 0)
                    {
                        map.Set(x, y, map.Get(x - dx, y - dy));
                        x -= dx;
                        y -= dy;
                    }
                    map.Set(x, y, 0);
                }
        }

        public void Up()
        {
            for (var x = 0; x < size; x++)
                for (var y = 0; y < size; y++) { }
        }

        public void Down()
        {
            throw new NotImplementedException();
        }

        public void Left()
        {
            throw new NotImplementedException();
        }

        public void Right()
        {
            throw new NotImplementedException();
        }

        public bool IsGameOver()
        {
            return true;
        }

        public int GetMap(int x, int y)
        {
            return map.Get(x, y);
        }
    }
}
