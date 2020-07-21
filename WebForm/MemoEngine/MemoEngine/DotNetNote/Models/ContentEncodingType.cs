﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetNote.Models
{
    public enum ContentEncodingType
    {
        Text, //입력한소스 그대로 표시(태그 실행하지 않음)
        Html, //HTML로 실행
        Mixed //HTML로 실행 + 엔터키(\r\n)적용됨
    }
}