﻿using System.Runtime.InteropServices;
using System.Text;

namespace SuperSkill
{
    public class IniFile
    {
        public string path;             //INI文件名 

        //声明写INI文件的API函数
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        //声明读INI文件的API函数
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        //类的构造函数，传递INI文件的路径和文件名
        public IniFile(string INIPath)
        {
            path = INIPath;
        }

        //写INI文件
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, path);
        }

        //读取INI文件
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, path);
            return temp.ToString();
        }


    }

}
