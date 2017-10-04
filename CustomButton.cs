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
    class CustomButton : Button {
        public Person Person { get; set; }

        public CustomButton(Person person) {
            this.Person = person;
        }
    }
}
