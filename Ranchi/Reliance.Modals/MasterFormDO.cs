using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
    public class MasterFormDO
    {
        [Key]
        public int FormId { get; set; }
        public string EId { get; set; }

        [DisplayName("Form Name")]
        [Required(ErrorMessage = "Please enter Form Name")]
        public string FormName { get; set; }

        [DisplayName("Form Layout")]
        [Required(ErrorMessage = "Please Select Form Layout")]
        public string FormLayOut { get; set; }

        [DisplayName("Form Description")]
        [Required(ErrorMessage = "Please enter Form Description")]
        public string FormDescription { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? lastModified { get; set; }

    }
}