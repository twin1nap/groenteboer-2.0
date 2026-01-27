using groenteboer_app.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Product_maneger_tool.Models
{
    public class DashboardComboBoxItem
    {
        public string ItemName { get; set; }
        
        public TableSettings TableSettings { get; set; } //could be a table itself

        public Chart Chartsettings { get; set; }

        //and here extra settings

    }
}
