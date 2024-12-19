using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGiaoHang
{
    public class Member
    {
        public string username;
        public string password;

        public Member() { }

        public Member(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}