using UnityEngine;

namespace FireAndWater.Utils
{
    public static class DirectionUtil
    {
        public static Vector2 ToVector2(this Direction direction)
        {
            switch (direction)
            {
                case Direction.Up: return Vector2.up;
                case Direction.Right: return Vector2.right;
                case Direction.Down: return Vector2.down;
                case Direction.Left: return Vector2.left;
                default: return Vector2.zero;
            }
        }

        public static Vector2 ToVector2(this string direction)
        {
            switch (direction.ToUpper())
            {
                case "UP": return Vector2.up;
                case "RIGHT": return Vector2.right;
                case "DOWN": return Vector2.down;
                case "LEFT": return Vector2.left;
                default: return Vector2.zero;
            }
        }

        public static Direction ToDirection(this Vector2 direction)
        {
            if (direction == Vector2.up) return Direction.Up;
            else if (direction == Vector2.right) return Direction.Right;
            else if (direction == Vector2.down) return Direction.Down;
            else if (direction == Vector2.left) return Direction.Left;
            else return Direction.Zero;
        }

        public static Direction ToDirection(this string direction)
        {
            switch (direction.ToUpper())
            {
                case "UP": return Direction.Up;
                case "RIGHT": return Direction.Right;
                case "DOWN": return Direction.Down;
                case "LEFT": return Direction.Left;
                default: return Direction.Zero;
            }
        }
    }
}