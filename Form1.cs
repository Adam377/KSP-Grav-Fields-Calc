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

            tempBody = getBodyFromAVLTree(tempBody);

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
                        b.SolarDay = double.Parse(bodyData[3]);

                        //Fill combo box with moon and planet names
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

            temp = getBodyFromAVLTree(temp);

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

        private Body getBodyFromAVLTree(Body b)
        {
            //search AVL Tree for Body object with same name
            try
            {
                //If the user has chosen an option from the combo box
                b.Name = bodyComboBox.SelectedItem.ToString();
                b = bodies.GetBodyFromTree(b);
                return b;
            }
            catch(NullReferenceException nre)
            {
                gravFieldAnswerTextBox.Text = "Null Reference Exception";
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Calculates geostationary height above service of planet
            // Geostationary height above moon would be outside of it's
            // gravitational field

            Body temp = new Body();

            // Getting data about the planet from the binary search tree
            // to calculate geostationary orbit height
            temp = getBodyFromAVLTree(temp);

            if(temp != null)
            {
                // If body has been found, we can calculate geostationary height

                if(temp.calcGeoHeight() != 0)
                {
                    gravFieldAnswerTextBox.Text = Math.Round(temp.calcGeoHeight(),0).ToString() + "m";
                }
                else
                {
                    gravFieldAnswerTextBox.Text = "Cannot calculate height above moon";
                }
            }
        }
    }
}