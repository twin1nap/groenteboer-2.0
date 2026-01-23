using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace groenteboer_app.models
{
    public class TableSettings
    {   
        public object DataSource { get; set; }

        //other settings here
        public List<DataGridViewTextBoxColumn> Columns { get; set; }
        public bool readOnly { get; set; }
    }
}
