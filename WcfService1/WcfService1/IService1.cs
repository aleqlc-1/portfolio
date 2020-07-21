﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IService1"을 변경할 수 있습니다.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string Insert(InsertUser user);
        [OperationContract]
        gettestdata GetInfo();
        [OperationContract]
        string Update(UpdateUser u);
        [OperationContract]
        string Delete(DeleteUser d);
        
    }

    [DataContract]
    public class gettestdata
    {
        [DataMember]
        public DataTable usertab
        {
            get;
            set;
        }
    }


    // 아래 샘플에 나타낸 것처럼 데이터 계약을 사용하여 복합 형식을 서비스 작업에 추가합니다.
    [DataContract]
    public class InsertUser
    {
        string name = string.Empty;
        string email = string.Empty;

        

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }

    [DataContract]
    public class UpdateUser
    {
        int uid;
        string name;
        string email;
        [DataMember]
        public int UID
        {
            get { return uid; }
            set { uid = value; }
        }
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }

    [DataContract]
    public class DeleteUser
    {
        int uid;
        [DataMember]
        public int UID
        {
            get { return uid; }
            set { uid = value; }
        }
    }
}
