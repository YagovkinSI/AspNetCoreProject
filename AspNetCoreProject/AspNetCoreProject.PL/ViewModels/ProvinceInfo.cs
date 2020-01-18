using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspNetCoreProject.PL.ViewModels
{
    public class ProvinceInfo
    {
        [ScaffoldColumn(false)]
        public int ProvinceID { get; set; }

        [DisplayName("Название провинции")]
        public string Name { get; set; }       

        [DisplayName("Игрок")]
        public string User { get; set; }

        [ScaffoldColumn(false)]
        public bool AvailableForPlay { get; set; }
    }
}
