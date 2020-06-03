using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks.Engine.Math
{
    public class Vector
    {
        public double[] Data;
        public Vector()
        {

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
