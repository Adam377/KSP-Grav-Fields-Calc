using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSPGravFieldV2
{
    public partial class Form1 : Form
    {
        //members
        private AVLTree<Body> bodies = new AVLTree<Body>();

        //constructor
        public Form1()
        {
            InitializeComponent();
        }

        //methods
        private void MainForm_Load(object sender, EventArgs e)
        {
            loadBodyData();
        }

        private void CalcGFSButton_Click(object sender, EventArgs e)
        {
            Body tempBody = new Body();

            tempBody = getBodyFromAVLTree(tempBody, 0);

            if(tempBody != null)
            {
                try
                {
                    gravFieldAnswerTextBox.Text = Math.Round(tempBody.calcGFS(tempBody, double.Parse(heightTextBox.Text)), 2) + " m/s/s";
                }
                catch (FormatException fe)
                {
                    gravFieldAnswerTextBox.Text = "Check the height value";
                }
            }
        }

        public void loadBodyData()
        {
            //load csv file
            string[] data = File.ReadAllLines(@"BodyInfoCSV.csv");

            foreach (string line in data)
            {
                string[] bodyData = line.Split(',');
                foreach (string word in bodyData)
                {
                    if (word != "")
                    {
                        Body b = new Body();
                        b.Name = bodyData[0];
                        b.Mass = double.Parse(bodyData[1]);
                        b.Radius = double.Parse(bodyData[2]);

                        //Fill combo box with planet names
                        bodyComboBox.Items.Add(b.Name);

                        bodies.InsertItem(b);

                        break;
                    }
                }
            }
        }

        private void bodyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bodyComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void calcSpeedButton_Click(object sender, EventArgs e)
        {
            Body temp = new Body();

            temp = getBodyFromAVLTree(temp, 1);

            if(temp != null)
            {
                try
                {
                    gravFieldAnswerTextBox.Text = Math.Round(temp.calcSpeed(temp, double.Parse(heightTextBox.Text)), 0).ToString() + " m/s";
                }
                catch (FormatException fe)
                {
                    gravFieldAnswerTextBox.Text = "Check the height value";
                }
            }
        }

        private Body getBodyFromAVLTree(Body b, int operation)
        {
            //search AVL Tree for Body object with same name
            try
            {
                //If the user has chosen an option from the combo box
                b.Name = bodyComboBox.SelectedItem.ToString();
                b = bodies.GetBodyFromTree(b);
                if((b.Name.CompareTo("Jool") == 0) || (b.Name.CompareTo("Sun") == 0))
                {
                    gravFieldAnswerTextBox.Text = "The Sun and Jool have no solid surfaces";
                    return null;
                }
                else
                {
                    gravFieldAnswerTextBox.Text = "Could not find body in AVL tree";
                    return b;
                }
            }
            catch(NullReferenceException nre)
            {
                gravFieldAnswerTextBox.Text = "Null Reference Exception";
                return null;
            }
        }
    }
}