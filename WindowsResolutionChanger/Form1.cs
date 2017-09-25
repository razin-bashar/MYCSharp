using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
namespace Resolution
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;

        private int tempHeight=0,tempWidth=0;
        private int FixHeight=1024,FixWidth=768;
        private Button button4;
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			Screen Srn=Screen.PrimaryScreen;
			tempHeight=Srn.Bounds.Width;
			tempWidth=Srn.Bounds.Height;
			
			InitializeComponent();

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "Click Here To Get Resolution";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(40, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(208, 24);
            this.button2.TabIndex = 1;
            this.button2.Text = "Click Here To Change Resolution";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(40, 128);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(208, 24);
            this.button3.TabIndex = 2;
            this.button3.Text = "Click Here To Retaine Resolution";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(40, 171);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(208, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(312, 206);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			//here you will get your current resolution
			MessageBox.Show("User Resolution is "+tempHeight.ToString()+" X "+tempWidth.ToString());
			
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Resolution is going to change to "+tempHeight.ToString()+" X "+tempWidth.ToString());
			Resolution.CResolution ChangeRes=new Resolution.CResolution(tempHeight,tempWidth);
			
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Resolution is going to change to "+FixHeight.ToString()+" X "+FixWidth.ToString());
			Resolution.CResolution ChangeRes=new Resolution.CResolution(FixHeight,FixWidth);
			
		}

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Resolution is going to change to " + "max" + " X " + "max");
            Resolution.CResolution ChangeRes = new Resolution.CResolution();
            DEVMODE1 dm1 = ChangeRes.getCurrentResolution();
            DEVMODE1 dm =ChangeRes.getMaximumSupportedResolution();
           
            List<DEVMODE1> RL = ChangeRes.getSupportedResolutionList();

            for (int i = 0; i < RL.Count; i++)
            {
                Console.WriteLine("\t" +
                     "{0} by {1}, " +
                     "{2} bit, " +
                     "{3} degrees, " +
                     "{4} hertz," +
                     "{5} color",
                     RL[i].dmPelsWidth,
                     RL[i].dmPelsHeight,
                     RL[i].dmBitsPerPel,
                     RL[i].dmDisplayOrientation * 90,
                     RL[i].dmDisplayFrequency,
                     RL[i].dmYResolution);
            }

            ChangeRes.setSupportedResolution(RL[RL.Count-1]);
        }
	}
}
