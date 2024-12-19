using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGiaoHang
{
    public class inforproduct
    {
        public int id { get; set; }
        public string img { get; set; }
        public int soluong { get; set; }

        public inforproduct() { }

        public inforproduct(int id, string img, int soluong)
        {
            this.id = id;
            this.img = img;
            this.soluong = soluong;
        }
    }
}