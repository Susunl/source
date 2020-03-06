using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSkill
{
    class 转换
    {
        public static byte[] 到字节集(uint 整数)
        {
            byte[] shi = BitConverter.GetBytes(整数);
            return shi;
        }
        public static byte[] 数组加法(byte[] array1, byte[] array2 , byte[] array3 , byte[] array4 , byte[] array5 )
        {
            byte[] arrayC;
            List<byte> tempList = new List<byte>();
            tempList.AddRange(array1);
            tempList.AddRange(array2);
            tempList.AddRange(array3);
            tempList.AddRange(array4);
            tempList.AddRange(array5);
            arrayC = tempList.ToArray();
            return arrayC;
        }
        public static byte[] 数组加法(byte[] array1 , byte[] array2 , byte[] array3 , byte[] array4)
        {
            byte[] arrayC;
            List<byte> tempList = new List<byte>();
            tempList.AddRange(array1);
            tempList.AddRange(array2);
            tempList.AddRange(array3);
            tempList.AddRange(array4);
            arrayC = tempList.ToArray();
            return arrayC;
        }
        public static byte[] 数组加法(byte[] array1 , byte[] array2 , byte[] array3)
        {
            byte[] arrayC;
            List<byte> tempList = new List<byte>();
            tempList.AddRange(array1);
            tempList.AddRange(array2);
            tempList.AddRange(array3);
            arrayC = tempList.ToArray();
            return arrayC;
        }
        public static byte[] 数组加法(byte[] array1 , byte[] array2)
        {
            byte[] arrayC;
            List<byte> tempList = new List<byte>();
            tempList.AddRange(array1);
            tempList.AddRange(array2);
            arrayC = tempList.ToArray();
            return arrayC;
        }
        public static byte[] 数组加法(byte[] array1 , byte[] array2 , byte[] array3 , byte[] array4 , byte[] array5,byte[] array6)
        {
            byte[] arrayC;
            List<byte> tempList = new List<byte>();
            tempList.AddRange(array1);
            tempList.AddRange(array2);
            tempList.AddRange(array3);
            tempList.AddRange(array4);
            tempList.AddRange(array5);
            tempList.AddRange(array6);
            arrayC = tempList.ToArray();
            return arrayC;
        }




    }
    
}
