using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THWEB_KimNgan.Models
{
    public class bookModels
    {
        private int id;
        private string titel;
        private string author;
        private string img;

        public bookModels(int id, string titel, string author, string img)
        {
            this.id = id;
            this.titel = titel;
            this.author = author;
            this.img = img;
        }
        public bookModels()
        {
          
        }

        public int Id { get => id; set => id = value; }
        [Required(ErrorMessage = "Vui long nhap Title")]
        public string Titel { get => titel; set => titel = value; }
        [Required(ErrorMessage = "Vui long nhap tac gia")]
        [StringLength(50, ErrorMessage = "Ten tac gia khong qua 50 ky tu")]
        public string Author { get => author; set => author = value; }
        public string Img { get => img; set => img = value; }
    }
}