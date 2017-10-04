using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Feszbuk {
    public partial class HelpForm : Form {

        private string HelpText_HU = @"Fészbúk Súgó:

Jelenlegi verzió: " + MainForm.CURRENT_APP_VERSION + @"

A programom a 3. gyakolró feladatot tovább gondolva egy valóban működő mini-közösségi oldalt próbál megvalósítani.

Funkciók:
 - automata fájlbetöltés (MainForm-ban '// Debug options' alatt kikapcsolható)
 - bejelentkezés bármelyik felhasználóra, ekkor megjelenik a barátok listája (példa user: jani, 123)
 - a képekre vagy nevekre kattintva megtekinthető az adott személy adatlapja (nagyítható képpel)
 - az üzenet ikonra kattintva egy valóban funkcionáló chat ablak nyílik, a címzettre átjelentkezve is megtekinthető a beszélgetés (az ő szemszögéből)
 - az 'Emberek' menüpont alatt további személyek adhatóak az ismerős listához (a hozzáadás kölcsönös, azonban az egyszerűség kedvéért nem igényli a másik fél beleegyezését)
 - a Fájl mentése funkcióval (nem automatizált) tárolhatók az elküldött üzenetek, illetve újonnan létrejött kapcsolatok
 - a Fájl menü -> 'Memória ürítése' gomb törli a jelenleg betöltött adatokat, így lehetőséget ad egy teljesen új adatbázis betöltésére
 - nyelv váltás funkció

Ismert hibák:
 - a regisztráció implementálása a közelgő ZH-k miatt elmaradt
 - a nyelv választást valószínüleg sokkal szakszerűbben is meg lehet oldani a Resources használatával
 - a Chat automata görgetését nem tudtam megoldani (a 'pnlMsgs.VerticalScroll.Value = VerticalScroll.Maximum;' nem oldotta meg)
 - az általam fájlba írt ékezetekes karaktereket nem tudtam beolvasni, azonban valamilyen oknál fogva a program által mentett ékezetes üzenetek visszaolvasása nem jelent hasonló gondot

A program működése közben aktívan használja a konzolt, azonban erre csak a hibakeresés miatt volt szükség.
Utólag rájöttem, hogy a barátok kijelzésére egy saját Panel létrehozása nem volt a legjobb ötlet. A legnagyobb gondom az volt hogy sokkal nehezebbé tette az események kezelését, ami a végső megoldás inkonzisztenciájából is látszik. Azonban nem bántam meg, és nem is szerettem volna utólag más utat választani, mert rengeteget tanultam ennek a létrehozása során.
Felhasznált ikon csomag forrása: https://icons8.com/web-app/new-icons/ultraviolet

Used free sources:
https://www.flaticon.com/packs/kids-avatars
https://icons8.com/web-app/new-icons/ultraviolet

Készítette:
Dobszai János
I5D2TG
";


        private string HelpText_EN = @"Fészbúk Help:

Current version: " + MainForm.CURRENT_APP_VERSION + @"

This is a school project for practicing C#, and Object Orientated Programming.
The project is supposed to simulate a mini social-network, with working functions such as:
 - log in to distinct users (you can find them in the text file 'Feszbuk\bin\Debug\feszbuk_data.txt')
 - view profiles
 - sent messages
 - add other people (who are not your friends yet)
 - export data to a file
 - load data from file (although this happens automatically)
 - Select language (English or Hungarian)

Known bugs / not implemented features:
 - missing registration panel (you can only add users to the data file)
 - Chat scrolling is not automatic

Used free sources:
https://www.flaticon.com/packs/kids-avatars
https://icons8.com/web-app/new-icons/ultraviolet

Made by:
János Dobszai
https://github.com/dJani97/
";


        public HelpForm() {
            int LANG = MainForm.LANG;
            InitializeComponent();
            Icon = Icon.FromHandle(Properties.Resources.Logo.GetHicon());
            lblIndicator.BackColor = MainForm.DARK_BLUE;
            BackColor = MainForm.LIGHT_BLUE;
            btnClose.BackColor = MainForm.DARK_BLUE;
            btnClose.ForeColor = Color.White;
            btnClose.Left = this.ClientSize.Width / 2 - btnClose.Width / 2;

            rchTxtHelp.ForeColor = MainForm.DARK_BLUE;
            rchTxtHelp.Font = new Font("Microsoft Sans Serif", 12);

            if (LANG == 0) {
                rchTxtHelp.Text = HelpText_HU;
            }
            else {
                rchTxtHelp.Text = HelpText_EN;
            }

            
            this.Text = MainForm.textHelpFormTitle[LANG];
            btnClose.Text = MainForm.textCloseBtn[LANG];
            lblIndicator.Text = MainForm.textHelpFormTitle[LANG];
        }

        private void closeHelp_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
