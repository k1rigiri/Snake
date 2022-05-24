using System;
using System.Collections.Generic;
using PluginInterface;
using System.Drawing;

namespace AI_Logic
{
    public class logic : ISmartSnake
    {
        public Move Direction { get; set; }
        public bool Reverse { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }

        public List<Point> CStones { get; set; }
        public void Startup(Size size, List<Point> stones)
        {
            Name = "kirigiri";
            Color = Color.DarkViolet;
            CStones = stones;
        }

        public void Update(Snake snake, List<Snake> enemies, List<Point> food, List<Point> dead)
        {
            //If use System.Linq namespace then snake will eat the nearest food
            //var food = ffood.OrderBy(x => x.X).ThenBy(x => x.Y).FirstOrDefault();

            for (int i = 0; i < food.Count; i++)
            {
                if (snake.Position.X < food[i].X || snake.Position.Y < food[i].Y)
                {
                    if (snake.Position.X - food[i].X < snake.Position.Y - food[i].Y)
                    {
                        if (!CStones.Contains(new Point(snake.Position.X + 1, snake.Position.Y)) & !snake.Tail.Contains(new Point(snake.Position.X + 1, snake.Position.Y)))
                        {
                            Direction = Move.Right;
                        }
                        else if (!CStones.Contains(new Point(snake.Position.X, snake.Position.Y + 1)) & !snake.Tail.Contains(new Point(snake.Position.X, snake.Position.Y + 1)))
                        {
                            Direction = Move.Down;
                        }
                        else if (!CStones.Contains(new Point(snake.Position.X, snake.Position.Y - 1)) & !snake.Tail.Contains(new Point(snake.Position.X, snake.Position.Y - 1)))
                        {
                            Direction = Move.Up;
                        }
                        else
                        {
                            Reverse = true;
                            Direction = Move.Up;
                        }
                    }
                    else if (snake.Position.X - food[i].X > snake.Position.Y - food[i].Y)
                    {
                        if (!CStones.Contains(new Point(snake.Position.X, snake.Position.Y + 1)) & !snake.Tail.Contains(new Point(snake.Position.X, snake.Position.Y + 1)))
                        {
                            Direction = Move.Down;
                        }
                        else if (!CStones.Contains(new Point(snake.Position.X - 1, snake.Position.Y)) & !snake.Tail.Contains(new Point(snake.Position.X - 1, snake.Position.Y)))
                        {
                            Direction = Move.Left;
                        }
                        else if (!CStones.Contains(new Point(snake.Position.X + 1, snake.Position.Y)) & !snake.Tail.Contains(new Point(snake.Position.X + 1, snake.Position.Y)))
                        {
                            Direction = Move.Right;
                        }
                        else
                        {
                            Reverse = true;
                            Direction = Move.Right;
                        }
                    }
                }

                if (snake.Position.X > food[i].X || snake.Position.Y > food[i].Y)
                {
                    if (snake.Position.X - food[i].X > snake.Position.Y - food[i].Y)
                    {
                        if (!CStones.Contains(new Point(snake.Position.X - 1, snake.Position.Y)) & !snake.Tail.Contains(new Point(snake.Position.X - 1, snake.Position.Y)))
                        {
                            Direction = Move.Left;
                        }
                        else if (!CStones.Contains(new Point(snake.Position.X, snake.Position.Y - 1)) & !snake.Tail.Contains(new Point(snake.Position.X, snake.Position.Y - 1)))
                        {
                            Direction = Move.Up;
                        }
                        else if (!CStones.Contains(new Point(snake.Position.X, snake.Position.Y + 1)) & !snake.Tail.Contains(new Point(snake.Position.X, snake.Position.Y + 1)))
                        {
                            Direction = Move.Down;
                        }
                        else
                        {
                            Reverse = true;
                            Direction = Move.Down;
                        }
                    }
                    else if (snake.Position.X - food[i].X < snake.Position.Y - food[i].Y)
                    {
                        if (!CStones.Contains(new Point(snake.Position.X, snake.Position.Y - 1)) & !snake.Tail.Contains(new Point(snake.Position.X, snake.Position.Y - 1)))
                        {
                            Direction = Move.Up;
                        }
                        else if (!CStones.Contains(new Point(snake.Position.X + 1, snake.Position.Y)) & !snake.Tail.Contains(new Point(snake.Position.X + 1, snake.Position.Y)))
                        {
                            Direction = Move.Right;
                        }
                        else if (!CStones.Contains(new Point(snake.Position.X - 1, snake.Position.Y)) & !snake.Tail.Contains(new Point(snake.Position.X - 1, snake.Position.Y)))
                        {
                            Direction = Move.Left;
                        }
                        else
                        {
                            Reverse = true;
                            Direction = Move.Left;
                        }
                    }
                }
            }
        }
    }
}
