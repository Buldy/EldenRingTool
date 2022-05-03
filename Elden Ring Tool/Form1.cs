using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.Collections.Generic;
using System.Data;
using System.Globalization;


namespace Elden_Ring_Tool {
    public partial class Form1 : Form {

        private Point mouseDownLocation;
        private int zoomFactor = 0;
        private int mapWidth = 0;
        private int mapHeight = 0;
        Image mapa;
        Image mapaPul;
        Image mapaCtvrt;
        Image mapaU;
        Image mapaUPul;
        Image mapaUCtvrt;
        Image x;

        bool typMapy = false;


        private DataSet dsBossList;
        private DataSet dsWpn;
        private DataSet dsFlask;

        public Form1() {
            InitializeComponent();
            mapBox.MouseWheel += new MouseEventHandler(mapBox_MouseWheel);
            mapBox.Controls.Add(xMark);
            xMark.BackColor = Color.Transparent;
            
        }

        private void mapBox_MouseWheel(object sender, MouseEventArgs e) {
            int VX, VY;
            int ow = mapBox.Width;
            int oh = mapBox.Height;

            if (e.Delta > 0) {
                zoomFactor -= 1;
                if (zoomFactor < -2) {
                    zoomFactor = -2;
                }
                else {
                    xMark.Top /= 2;
                    xMark.Left /= 2;
                }

            } else if (e.Delta < 0) {
                zoomFactor += 1;
                if (zoomFactor > 1) {
                    zoomFactor = 1;
                }
                else {
                    xMark.Top *= 2;
                    xMark.Left *= 2;
                }
            }

            // Step 1
            if (e.Delta != 0) {
                switch (zoomFactor) {
                    case -2:
                        mapBox.Width = mapWidth / 4;
                        mapBox.Height = mapHeight / 4;
                        if (typMapy) {
                            mapBox.Image = mapaUCtvrt;
                        } else {
                            mapBox.Image = mapaCtvrt;
                        }
                        break;
                    case -1:
                        mapBox.Width = mapWidth / 2;
                        mapBox.Height = mapHeight / 2;
                        if (typMapy) {
                            mapBox.Image = mapaUPul;
                        } else {
                            mapBox.Image = mapaPul;
                        }
                        break;
                    case 0:
                        mapBox.Width = mapWidth;
                        mapBox.Height = mapHeight;
                        if (typMapy) {
                            mapBox.Image = mapaU;
                        } else {
                            mapBox.Image = mapa;
                        }
                        break;
                    case 1:
                        mapBox.Width = mapWidth * 2;
                        mapBox.Height = mapHeight * 2;
                        if (typMapy) {
                            mapBox.Image = mapaU;
                        }
                        else {
                            mapBox.Image = mapa;
                        }
                        break;
                }
            }

            // Step 2
            PropertyInfo pInfo = mapBox.GetType().GetProperty("ImageRectangle", BindingFlags.Instance | BindingFlags.NonPublic);
            Rectangle rect = (Rectangle)pInfo.GetValue(mapBox, null);

            // Step 3
            mapBox.Width = rect.Width;
            mapBox.Height = rect.Height;

            int x = e.Location.X;
            int y = e.Location.Y;
            //int x = -mapBox.Left + panel1.Width / 2;
            //int y = -mapBox.Top + panel1.Height / 2;

            // Step 4
            VX = (int)((double)x * (ow - mapBox.Width) / ow);
            VY = (int)((double)y * (oh - mapBox.Height) / oh);
            mapBox.Location = new Point(mapBox.Location.X + VX, mapBox.Location.Y + VY);

            if (mapBox.Left > 0) {
                mapBox.Left = 0;
            }
            if (mapBox.Left < (panel1.Width - mapBox.Width)) {
                mapBox.Left = (panel1.Width - mapBox.Width);
            }
            if (mapBox.Top > 0) {
                mapBox.Top = 0;
            }
            if (mapBox.Top < (panel1.Height - mapBox.Height)) {
                mapBox.Top = (panel1.Height - mapBox.Height);
            }

        }

        private void Form1_Shown(object sender, EventArgs e) {
            this.Cursor = Cursors.WaitCursor;

            // Map init
            x = Image.FromFile("x.png");
            xMark.Image = x;
            mapa = Image.FromFile("m0-overworld.png");
            mapWidth = mapa.Width;
            mapHeight = mapa.Height;

            mapaPul = (Image)(new Bitmap(mapa, mapWidth / 2, mapHeight / 2));
            mapaCtvrt = (Image)(new Bitmap(mapa, mapWidth / 4, mapHeight / 4));

            mapaU = Image.FromFile("m1-underground.png");
            mapaUPul = (Image)(new Bitmap(mapaU, mapWidth / 2, mapHeight / 2));
            mapaUCtvrt = (Image)(new Bitmap(mapaU, mapWidth / 2, mapHeight / 2));

            mapBox.Width = mapWidth;
            mapBox.Height = mapHeight;
            mapBox.Image = mapa;

            xMark.Top = -panel1.Height / 2;
            xMark.Left = -panel1.Width / 2;


            // Boss List init
            dsBossList = new DataSet("BossList");
            dsBossList.ReadXml(@"Boss List.xml");
            dgvBossList.Columns.Add(new DataGridViewCheckBoxColumn());
            dgvBossList.Columns[0].HeaderText = "Killed";
            dgvBossList.Columns[0].DataPropertyName = "Killed";
            dgvBossList.DataSource = dsBossList.Tables[0];

            for (int i = 1; i < dgvBossList.Columns.Count; i++) {
                dgvBossList.Columns[i].ReadOnly = true;
            }

            paintCells();
            

            // Weapon Upgrades Init
            dsWpn = new DataSet("WeaponUpgrades");
            dsWpn.ReadXml("Weapon Upgrades.xml");
            dgvWpn.Columns.Add(new DataGridViewCheckBoxColumn());
            dgvWpn.Columns[0].HeaderText = "Collected";
            dgvWpn.Columns[0].DataPropertyName = "Collected";
            dgvWpn.DataSource = dsWpn.Tables[0];

            for (int i = 1; i < dgvWpn.Columns.Count; i++) {
                dgvWpn.Columns[i].ReadOnly = true;
            }

            foreach  (DataGridViewColumn col in dgvWpn.Columns) {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // Flask Upgrades Init
            dsFlask = new DataSet("FlaskUpgrades");
            dsFlask.ReadXml("Flask Upgrades.xml");
            dgvFlask.Columns.Add(new DataGridViewCheckBoxColumn());
            dgvFlask.Columns[0].HeaderText = "Collected";
            dgvFlask.Columns[0].DataPropertyName = "Collected";
            dgvFlask.DataSource = dsFlask.Tables[0];

            for (int i = 1; i < dgvFlask.Columns.Count; i++) {
                dgvFlask.Columns[i].ReadOnly = true;
            }

            foreach (DataGridViewColumn col in dgvFlask.Columns) {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // Monitor CB Init
            foreach (var scr in Screen.AllScreens) {
                cbMonitor.Items.Add(new ScreenObj(scr));
            }
            cbMonitor.SelectedIndex = 0;

            this.Cursor = Cursors.Default;
        }

        private void mapBox_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                mouseDownLocation = e.Location;
            }
        }

        private void mapBox_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                int newLeft = e.X + mapBox.Left - mouseDownLocation.X;
                if (newLeft > 0)
                    newLeft = 0;
                if (newLeft < (panel1.Width - mapBox.Width))
                    newLeft = (panel1.Width - mapBox.Width);
                int newTop = e.Y + mapBox.Top - mouseDownLocation.Y;
                if (newTop > 0)
                    newTop = 0;
                if (newTop < (panel1.Height - mapBox.Height))
                    newTop = (panel1.Height - mapBox.Height);
                mapBox.Left = newLeft;
                mapBox.Top = newTop;
            }
        }

        private void xMark_MouseDown(object sender, MouseEventArgs e) {
            mapBox_MouseDown(sender, e);
        }

        private void xMark_MouseMove(object sender, MouseEventArgs e) {
            mapBox_MouseMove(sender, e);
        }

        private void dgvBossList_CellClick(object sender, DataGridViewCellEventArgs e) {
            if ((e.RowIndex > -1) && (e.RowIndex < dgvBossList.RowCount)) {
                int xMap, yMap;

                xMap = Convert.ToInt32((double.Parse(dgvBossList.Rows[e.RowIndex].Cells[19].Value.ToString(), CultureInfo.InvariantCulture) - 11) * 41.22 * Math.Pow(2, zoomFactor));
                yMap = -Convert.ToInt32((double.Parse(dgvBossList.Rows[e.RowIndex].Cells[18].Value.ToString(), CultureInfo.InvariantCulture) + 18) * 41.45 * Math.Pow(2, zoomFactor));
                mapBox.Top = (-yMap + panel1.Height / 2);
                mapBox.Left = (-xMap + panel1.Width / 2);
                if (mapBox.Left > 0) {
                    mapBox.Left = 0;
                }
                if (mapBox.Left < (panel1.Width - mapBox.Width)) {
                    mapBox.Left = (panel1.Width - mapBox.Width);
                }
                if (mapBox.Top > 0) {
                    mapBox.Top = 0;
                }
                if (mapBox.Top < (panel1.Height - mapBox.Height)) {
                    mapBox.Top = (panel1.Height - mapBox.Height);
                }
                xMark.Top = yMap;
                xMark.Left = xMap;

                string loc = dgvBossList.Rows[e.RowIndex].Cells[2].Value.ToString();
                if ((String.Equals(loc, "Siofra River", StringComparison.InvariantCultureIgnoreCase)) || (String.Equals(loc, "Ainsel River", StringComparison.InvariantCultureIgnoreCase)) || (String.Equals(loc, "Deeproot Depths", StringComparison.InvariantCultureIgnoreCase))
                    || (String.Equals(loc, "Lake of Rot", StringComparison.InvariantCultureIgnoreCase)) || (String.Equals(loc, "Mohgwyn Dynasty Mausoleum", StringComparison.InvariantCultureIgnoreCase)) || (String.Equals(loc, "Nokron", StringComparison.InvariantCultureIgnoreCase))) {
                    if (typMapy == false) {
                        switch (zoomFactor) {
                            case -2:
                                mapBox.Image = mapaUCtvrt;
                                break;
                            case -1:
                                mapBox.Image = mapaUPul;
                                break;
                            case 0:
                            case 1:
                                mapBox.Image = mapaU;
                                break;
                        }
                        typMapy = true;
                    }
                }
                else {
                    if (typMapy == true) {
                        switch (zoomFactor) {
                            case -2:
                                mapBox.Image = mapaCtvrt;
                                break;
                            case -1:
                                mapBox.Image = mapaPul;
                                break;
                            case 0:
                            case 1:
                                mapBox.Image = mapa;
                                break;
                        }
                        typMapy = false;
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            dsBossList.WriteXml("Boss List.xml");
            dsWpn.WriteXml("Weapon Upgrades.xml");
            dsFlask.WriteXml("Flask Upgrades.xml");
        }

        private void dgvWpn_CellClick(object sender, DataGridViewCellEventArgs e) {
            if ((e.RowIndex > -1) && (e.RowIndex < dgvWpn.RowCount)) {
                int xMap, yMap;

                xMap = Convert.ToInt32((double.Parse(dgvWpn.Rows[e.RowIndex].Cells[5].Value.ToString(), CultureInfo.InvariantCulture) - 11) * 41.22 * Math.Pow(2, zoomFactor));
                yMap = -Convert.ToInt32((double.Parse(dgvWpn.Rows[e.RowIndex].Cells[4].Value.ToString(), CultureInfo.InvariantCulture) + 18) * 41.45 * Math.Pow(2, zoomFactor));
                mapBox.Top = (-yMap + panel1.Height / 2);
                mapBox.Left = (-xMap + panel1.Width / 2);
                if (mapBox.Left > 0) {
                    mapBox.Left = 0;
                }
                if (mapBox.Left < (panel1.Width - mapBox.Width)) {
                    mapBox.Left = (panel1.Width - mapBox.Width);
                }
                if (mapBox.Top > 0) {
                    mapBox.Top = 0;
                }
                if (mapBox.Top < (panel1.Height - mapBox.Height)) {
                    mapBox.Top = (panel1.Height - mapBox.Height);
                }
                xMark.Top = yMap;
                xMark.Left = xMap;

                string loc = dgvWpn.Rows[e.RowIndex].Cells[2].Value.ToString();
                if ((String.Equals(loc, "Nokron", StringComparison.InvariantCultureIgnoreCase)) || (String.Equals(loc, "Nokstella", StringComparison.InvariantCultureIgnoreCase)) || (String.Equals(loc, "Mohgwyn Palace", StringComparison.InvariantCultureIgnoreCase))
                    || (String.Equals(loc, "Ainsel River", StringComparison.InvariantCultureIgnoreCase)) || (String.Equals(loc, "Night's Sacred Grounds", StringComparison.InvariantCultureIgnoreCase)) || (String.Equals(loc, "Mohgwyn Dynasty Mausoleum", StringComparison.InvariantCultureIgnoreCase))) {
                    if (typMapy == false) {
                        switch (zoomFactor) {
                            case -2:
                                mapBox.Image = mapaUCtvrt;
                                break;
                            case -1:
                                mapBox.Image = mapaUPul;
                                break;
                            case 0:
                            case 1:
                                mapBox.Image = mapaU;
                                break;
                        }
                        typMapy = true;
                    }
                }
                else {
                    if (typMapy == true) {
                        switch (zoomFactor) {
                            case -2:
                                mapBox.Image = mapaCtvrt;
                                break;
                            case -1:
                                mapBox.Image = mapaPul;
                                break;
                            case 0:
                            case 1:
                                mapBox.Image = mapa;
                                break;
                        }
                        typMapy = false;
                    }
                }
            }
        }

        private void dgvFlask_CellClick(object sender, DataGridViewCellEventArgs e) {
            if ((e.RowIndex > -1) && (e.RowIndex < dgvFlask.RowCount)) {
                int xMap, yMap;

                xMap = Convert.ToInt32((double.Parse(dgvFlask.Rows[e.RowIndex].Cells[5].Value.ToString(), CultureInfo.InvariantCulture) - 11) * 41.22 * Math.Pow(2, zoomFactor));
                yMap = -Convert.ToInt32((double.Parse(dgvFlask.Rows[e.RowIndex].Cells[4].Value.ToString(), CultureInfo.InvariantCulture) + 18) * 41.45 * Math.Pow(2, zoomFactor));
                mapBox.Top = (-yMap + panel1.Height / 2);
                mapBox.Left = (-xMap + panel1.Width / 2);
                if (mapBox.Left > 0) {
                    mapBox.Left = 0;
                }
                if (mapBox.Left < (panel1.Width - mapBox.Width)) {
                    mapBox.Left = (panel1.Width - mapBox.Width);
                }
                if (mapBox.Top > 0) {
                    mapBox.Top = 0;
                }
                if (mapBox.Top < (panel1.Height - mapBox.Height)) {
                    mapBox.Top = (panel1.Height - mapBox.Height);
                }
                xMark.Top = yMap;
                xMark.Left = xMap;

                string loc = dgvFlask.Rows[e.RowIndex].Cells[2].Value.ToString();
                if ((String.Equals(loc, "Nokstella", StringComparison.InvariantCultureIgnoreCase)) || (String.Equals(loc, "Siofra", StringComparison.InvariantCultureIgnoreCase)) || (String.Equals(loc, "Lake of Rot", StringComparison.InvariantCultureIgnoreCase))
                    || (String.Equals(loc, "Mohgwyn Palace", StringComparison.InvariantCultureIgnoreCase))) {
                    if (typMapy == false) {
                        switch (zoomFactor) {
                            case -2:
                                mapBox.Image = mapaUCtvrt;
                                break;
                            case -1:
                                mapBox.Image = mapaUPul;
                                break;
                            case 0:
                            case 1:
                                mapBox.Image = mapaU;
                                break;
                        }
                        typMapy = true;
                    }
                }
                else {
                    if (typMapy == true) {
                        switch (zoomFactor) {
                            case -2:
                                mapBox.Image = mapaCtvrt;
                                break;
                            case -1:
                                mapBox.Image = mapaPul;
                                break;
                            case 0:
                            case 1:
                                mapBox.Image = mapa;
                                break;
                        }
                        typMapy = false;
                    }
                }
            }
        }

        private void btnAbout_Click(object sender, EventArgs e) {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void cbMonitor_SelectionChangeCommitted(object sender, EventArgs e) {
            object o = cbMonitor.SelectedItem;
            if (o == null) {
                return;
            }

            ScreenObj scrObj = o as ScreenObj;
            if (scrObj == null) {
                return;
            }

            Point p = new Point();
            p.X = scrObj.screen.WorkingArea.Left + scrObj.screen.WorkingArea.Width/2 - this.Width/2;
            p.Y = scrObj.screen.WorkingArea.Top + scrObj.screen.WorkingArea.Height/2 - this.Height/2;

            this.Location = p;
            
        }

        private void btnReset_Click(object sender, EventArgs e) {
            this.Cursor = Cursors.WaitCursor;
            for (int i = 0; i < dgvBossList.RowCount; i++) {
                dgvBossList.Rows[i].Cells[0].Value = false;
            }
            for (int i = 0; i < dgvWpn.RowCount; i++) {
                dgvWpn.Rows[i].Cells[0].Value = false;
            }
            for (int i = 0; i < dgvFlask.RowCount; i++) {
                dgvFlask.Rows[i].Cells[0].Value = false;
            }
            this.Cursor = Cursors.Default;
        }

        private void paintCells() {
            for (int j = 5; j < 13; j++) {
                for (int i = 0; i < dgvBossList.RowCount; i++) {
                    switch (Convert.ToInt32(dgvBossList.Rows[i].Cells[j].Value)) {
                        case -3:
                            dgvBossList.Rows[i].Cells[j].Style.BackColor = Color.Lime;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionBackColor = Color.Lime;
                            dgvBossList.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionForeColor = Color.Black;
                            break;
                        case -2:
                            dgvBossList.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionBackColor = Color.LightGreen;
                            dgvBossList.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionForeColor = Color.Black;
                            break;
                        case -1:
                            dgvBossList.Rows[i].Cells[j].Style.BackColor = Color.MediumAquamarine;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionBackColor = Color.MediumAquamarine;
                            dgvBossList.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionForeColor = Color.Black;
                            break;
                        case 0:
                            dgvBossList.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionBackColor = Color.LightGray;
                            dgvBossList.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionForeColor = Color.Black;
                            break;
                        case 1:
                            dgvBossList.Rows[i].Cells[j].Style.BackColor = Color.DarkSalmon;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionBackColor = Color.DarkSalmon;
                            dgvBossList.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionForeColor = Color.Black;
                            break;
                        case 2:
                            dgvBossList.Rows[i].Cells[j].Style.BackColor = Color.OrangeRed;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionBackColor = Color.OrangeRed;
                            dgvBossList.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionForeColor = Color.Black;
                            break;
                        case 3:
                            dgvBossList.Rows[i].Cells[j].Style.BackColor = Color.Red;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionBackColor = Color.Red;
                            dgvBossList.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionForeColor = Color.Black;
                            break;
                    }
                }
                dgvBossList.Columns[j].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }

            for (int j = 13; j < 18; j++) {
                for (int i = 0; i < dgvBossList.RowCount; i++) {
                    switch (Convert.ToInt32(dgvBossList.Rows[i].Cells[j].Value)) {
                        case 0:
                            dgvBossList.Rows[i].Cells[j].Style.BackColor = Color.Black;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionBackColor = Color.Black;
                            dgvBossList.Rows[i].Cells[j].Style.ForeColor = Color.White;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionForeColor = Color.White;
                            break;
                        case 1:
                            dgvBossList.Rows[i].Cells[j].Style.BackColor = Color.Green;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionBackColor = Color.Green;
                            dgvBossList.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionForeColor = Color.Black;
                            break;
                        case 2:
                            dgvBossList.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionBackColor = Color.Yellow;
                            dgvBossList.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionForeColor = Color.Black;
                            break;
                        case 3:
                            dgvBossList.Rows[i].Cells[j].Style.BackColor = Color.Red;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionBackColor = Color.Red;
                            dgvBossList.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionForeColor = Color.Black;
                            break;
                        case 4:
                            dgvBossList.Rows[i].Cells[j].Style.BackColor = Color.Violet;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionBackColor = Color.Violet;
                            dgvBossList.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                            dgvBossList.Rows[i].Cells[j].Style.SelectionForeColor = Color.Black;
                            break;
                    }
                }
                dgvBossList.Columns[j].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
        }

        private void dgvBossList_Sorted(object sender, EventArgs e) {
            paintCells();
        }
    }
}
