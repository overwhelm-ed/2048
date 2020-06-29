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
        public bool isMove = true;

        public Model(int size)
        {
            map = new Map(size);
            points = 0;
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
            if (isMove)
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
            isMove = false;
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
                    isMove = true;
                }
        }

        public void Join(int x, int y, int dx, int dy)
        {
            if (map.Get(x, y) > 0)
                if (map.Get(x, y) == map.Get(x + dx, y + dy))
                {
                    map.Set(x + dx, y + dy, map.Get(x, y) * 2);
                    points += map.Get(x, y);
                    while (map.Get(x - dx, y - dy) > 0)
                    {
                        map.Set(x, y, map.Get(x - dx, y - dy));
                        x -= dx;
                        y -= dy;
                    }
                    isMove = true;
                    map.Set(x, y, 0);
                }
        }

        public void Up()
        {
            for (var x = 1; x < size; x++)
            {
                for (var y = 0; y < size; y++)
                    Move(x, y, -1, 0);
                for (var y = 0; y < size; y++)
                    Join(x, y, -1, 0);
            }
            AddRandomNumber(1);
        }

        public void Down()
        {
            for (var x = size - 2; x >= 0; x--)
            {
                for (var y = 0; y < size; y++)
                    Move(x, y, 1, 0);
                for (var y = 0; y < size; y++)
                    Join(x, y, 1, 0);
            }
            AddRandomNumber(1);
        }

        public void Left()
        {
            for (var y = 1; y < size; y++)
            {
                for (var x = 0; x < size; x++)
                    Move(x, y, 0, -1);
                for (var x = 0; x < size; x++)
                    Join(x, y, 0, -1);
            }
            AddRandomNumber(1);
        }

        public void Right()
        {
            for (var y = size - 2; y >= 0; y--)
            {
                for (var x = 0; x < size; x++)
                    Move(x, y, 0, 1);
                for (var x = 0; x < size; x++)
                    Join(x, y, 0, 1);
            }
            AddRandomNumber(1);
        }

        public bool IsGameOver()
        {
            return false;
        }

        public int GetMap(int x, int y)
        {
            return map.Get(x, y);
        }
    }
}
