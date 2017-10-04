using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Feszbuk {
    class CustomPanel : Panel {
        public Person Person { get; private set; }

        private PictureBox Pic { get; set; }
        private Label Lbl { get; set; }
        private Button Btn { get; set; }
        private EventHandler MessagesClickHandler { get; set; }
        private Image ButtonImage { get; set; }
        
        int marginX = 5;
        int marginY = 5;


        public CustomPanel(Person person, int height, int width, EventHandler messagesClickHandler, Image buttonImage) {
            this.Person = person;
            this.Height = height;
            this.Width = width;
            this.MessagesClickHandler = messagesClickHandler;
            this.ButtonImage = buttonImage;
            this.Init();
        }


        private void Init() {
            int imageWidth, imageHeight; ;

            //Random r = new Random(Person.ID);
            //this.BackColor = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
            this.BackColor = Color.White;
            

            Pic = new PictureBox();
            Pic.Image = Image.FromFile("../pictures/" + Person.Picture);
            Pic.SizeMode = PictureBoxSizeMode.StretchImage;
            imageHeight = this.Height - 2 * marginY;
            imageWidth = MainForm.ScaleImageWidth(Pic.Image.Height, Pic.Image.Width, imageHeight);
            Pic.Size = new Size(imageWidth, imageHeight);
            Pic.Location = new Point(marginX, (this.Height - Pic.Height) / 2);
            Pic.Click += new EventHandler(message_Click);
            this.Controls.Add(Pic);


            Lbl = new Label();
            Lbl.Text = Person.FullName;
            Lbl.ForeColor = Color.Black;
            Lbl.Font = new Font("Segoe UI", Height / 5);
            Lbl.AutoSize = true;
            Lbl.Location = new Point((int)(this.Height*1.1), (this.Height - Lbl.Height) / 2);
            Lbl.Click += new EventHandler(message_Click);
            this.Controls.Add(Lbl);

            Btn = new CustomButton(Person);
            Btn.Text = "";
            Btn.Image = ButtonImage;
            Btn.Size = new Size(Btn.Image.Size.Width+10, Btn.Image.Size.Height+5);
            Btn.Location = new Point(this.Width - Btn.Width - marginX, (this.Height - Btn.Height) / 2);
            Btn.Click += MessagesClickHandler;
            this.Controls.Add(Btn);
        }


        private void message_Click(object sender, EventArgs e) {
            this.OnClick(EventArgs.Empty);
        }

    }
}
