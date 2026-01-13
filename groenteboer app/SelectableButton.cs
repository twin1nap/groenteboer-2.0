using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace groenteboer_app
{
    public partial class SelectableButton : UserControl
    {
        public List<string> Buttons
        {
            get
            {
                List<Button> _buttons = FlpButtons.Controls.OfType<Button>().ToList();
                List<string> _text = new List<string>();
                foreach (Button btn  in _buttons)
                {
                    _text.Add(btn.Text);
                }
                return _text;
            }
            set
            {
                foreach (string text in value )
                {
                    Button btn = new Button();
                    btn.Font = new Font("Microsoft Sans Serif", 13.8f);
                    btn.Size = new Size(115, 53);
                    btn.Text = text;
                    btn.Click += button_Click;
                    FlpButtons.Controls.Add(btn);
                }
                ResetButtons();
            }
        }

        public Button SelectedButton
        {
            get; 
            set;
        }
        public SelectableButton()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button clicked = sender as Button;

            foreach (Button btn in FlpButtons.Controls)
            {
                btn.BackColor = SystemColors.Control;
            }
            SelectedButton = clicked;
            SelectedButton.BackColor = SystemColors.ActiveCaption;
        }

        public void ResetButtons()
        {
            SelectedButton = FlpButtons.Controls.OfType<Button>().FirstOrDefault();
            if (SelectedButton != null)
            {
                foreach (Button btn in FlpButtons.Controls)
                {
                    btn.BackColor = SystemColors.Control;
                }
                SelectedButton.BackColor = SystemColors.ActiveCaption;
                SelectedButton.Focus();
            }
        }

        private void SelectableButton_Load(object sender, EventArgs e)
        {
            ResetButtons();
        }
    }
}
