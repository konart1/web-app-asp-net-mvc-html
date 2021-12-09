using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace web_app_asp_net_mvc_html.Models
{
    public class Product
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование товара
        /// </summary>
        [Display(Name ="Наименование")]
        public string Name { get; set; }

        /// <summary>
        /// Артикул
        /// </summary>
        [Display(Name = "Артикул")]
        public int Code { get; set; }

        /// <summary>
        /// Размер
        /// </summary>
        [Display(Name = "Размер")]
        public int? SizeId { get; set; }
        public virtual Size Size { get; set; }

        /// <summary>
        /// Бренд (Производитель)
        /// </summary>
        [Display(Name = "Бренд")]
        public int? BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [Display(Name = "Описание")]
        public string Description { get; set; }

        /// <summary>
        /// Цвет
        /// </summary>
        [Display(Name ="Цвет")]
        public string Color { get; set; }

        [Display(Name = "Раздел")]
        public int? TagId { get; set; }
        public virtual Tag Tag { get; set; }



        [Display(Name = "Стоймость")]
        public int Price { get; set; }

        [Display(Name = "Изображение")]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }


    }
}