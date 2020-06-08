using System;

namespace Tanks.Engine.Math
{
    public class Vector
    {
        public double[] Data { get; set; }
        public Vector()
        {
            //в перегрузке оператора + создаётся объект result типа veсtor, т.к данных в нём нет изначально, необходим конструктор, чтобы инициализировать этот вектор
        }
        public Vector(double[] data)
        {
            Data = data;
        }
        public static Vector operator +(Vector Vector1, Vector Vector2)
        {
            Vector result= new Vector();
            if (Vector1.Data.Length == Vector2.Data.Length)
            {
                result.Data = new double[Vector2.Data.Length];
                for (int i = 0; i < result.Data.Length; i++)
                {
                    result.Data[i] = Vector1.Data[i] + Vector2.Data[i];
                }
            }
            else
                throw new Exception("Разные размерности"); 
            return result;
        }
    }
}
