﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dul
{
    public class FileUtility
    {
        #region 중복된 파일명 뒤에 번호 붙이는 메서드 : GetFileNameWithNumbering
        public static string GetFileNameWithNumbering(string dir, string name)
        {
            string strName = Path.GetFileNameWithoutExtension(name);
            string strExt = Path.GetExtension(name);
            bool blnExists = true;
            int i = 0;
            while (blnExists)
            {
                if (File.Exists(Path.Combine(dir, name)))
                {
                    name = strName + "(" + ++i + ")" + strExt;
                }
                else
                {
                    blnExists = false;
                }
            }
            return name;
        }
        #endregion
    }
}
