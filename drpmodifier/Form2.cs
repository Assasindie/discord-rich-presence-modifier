using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drpmodifier
{
    public partial class Form2 : Form
    {
        public Form2(string State, string Details, bool Timer)
        {
            InitializeComponent();
            stateLabelName.Text = State;
            stateLabelName2.Text = State;
            detailsLabelName.Text = Details;
            detailsLabelName2.Text = Details;
            timeLabelName.Text = Timer ? "00:00:00 Elapsed" : "00:00:00 Left";
            timeLabelName2.Text = Timer ? "00:00:00 Elapsed" : "00:00:00 Left";
        }
    }
}
