namespace Ziemiecki_42601_projekt7
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.iz_lblWspolzednaY = new System.Windows.Forms.Label();
            this.iz_lblWspolzednaX = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.iz_GroupBox = new System.Windows.Forms.GroupBox();
            this.iz_rdbGumka = new System.Windows.Forms.RadioButton();
            this.iz_rbOlowek = new System.Windows.Forms.RadioButton();
            this.iz_rdbLiniaProsta = new System.Windows.Forms.RadioButton();
            this.iz_rdbProstokąt = new System.Windows.Forms.RadioButton();
            this.iz_rdbElipsa = new System.Windows.Forms.RadioButton();
            this.iz_rdbKwadrat = new System.Windows.Forms.RadioButton();
            this.iz_rdbOkrąg = new System.Windows.Forms.RadioButton();
            this.iz_btnWczytajMapęBitową = new System.Windows.Forms.Button();
            this.iz_trbSuwakGrubościLinii = new System.Windows.Forms.TrackBar();
            this.iz_cmbStylLinii = new System.Windows.Forms.ComboBox();
            this.iz_btnZapiszMapęBitową = new System.Windows.Forms.Button();
            this.iz_imgRysownica = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.colorDialog3 = new System.Windows.Forms.ColorDialog();
            this.colorDialog4 = new System.Windows.Forms.ColorDialog();
            this.colorDialog5 = new System.Windows.Forms.ColorDialog();
            this.colorDialog6 = new System.Windows.Forms.ColorDialog();
            this.colorDialog7 = new System.Windows.Forms.ColorDialog();
            this.iz_chbWypelnij = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.iz_lblKolorTla = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.iz_lblKolorPdst = new System.Windows.Forms.Label();
            this.iz_lblKolorWypel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.iz_btnRemove = new System.Windows.Forms.Button();
            this.iz_numDelete = new System.Windows.Forms.NumericUpDown();
            this.iz_btnMoveAll = new System.Windows.Forms.Button();
            this.iz_btnRoll = new System.Windows.Forms.Button();
            this.iz_btnMoveAndRoll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.iz_GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iz_trbSuwakGrubościLinii)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iz_imgRysownica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iz_numDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // iz_lblWspolzednaY
            // 
            this.iz_lblWspolzednaY.AutoSize = true;
            this.iz_lblWspolzednaY.Location = new System.Drawing.Point(695, 9);
            this.iz_lblWspolzednaY.Name = "iz_lblWspolzednaY";
            this.iz_lblWspolzednaY.Size = new System.Drawing.Size(0, 13);
            this.iz_lblWspolzednaY.TabIndex = 37;
            // 
            // iz_lblWspolzednaX
            // 
            this.iz_lblWspolzednaX.AutoSize = true;
            this.iz_lblWspolzednaX.Location = new System.Drawing.Point(645, 9);
            this.iz_lblWspolzednaX.Name = "iz_lblWspolzednaX";
            this.iz_lblWspolzednaX.Size = new System.Drawing.Size(0, 13);
            this.iz_lblWspolzednaX.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(504, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Współrzędne kursora:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(622, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(672, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Y:";
            // 
            // iz_GroupBox
            // 
            this.iz_GroupBox.Controls.Add(this.iz_rdbGumka);
            this.iz_GroupBox.Controls.Add(this.iz_rbOlowek);
            this.iz_GroupBox.Controls.Add(this.iz_rdbLiniaProsta);
            this.iz_GroupBox.Controls.Add(this.iz_rdbProstokąt);
            this.iz_GroupBox.Controls.Add(this.iz_rdbElipsa);
            this.iz_GroupBox.Controls.Add(this.iz_rdbKwadrat);
            this.iz_GroupBox.Controls.Add(this.iz_rdbOkrąg);
            this.iz_GroupBox.Location = new System.Drawing.Point(12, 72);
            this.iz_GroupBox.Name = "iz_GroupBox";
            this.iz_GroupBox.Size = new System.Drawing.Size(110, 178);
            this.iz_GroupBox.TabIndex = 55;
            this.iz_GroupBox.TabStop = false;
            this.iz_GroupBox.Text = "Wybierz narzędzie:";
            // 
            // iz_rdbGumka
            // 
            this.iz_rdbGumka.AutoSize = true;
            this.iz_rdbGumka.Location = new System.Drawing.Point(6, 157);
            this.iz_rdbGumka.Name = "iz_rdbGumka";
            this.iz_rdbGumka.Size = new System.Drawing.Size(59, 17);
            this.iz_rdbGumka.TabIndex = 16;
            this.iz_rdbGumka.TabStop = true;
            this.iz_rdbGumka.Text = "Gumka";
            this.iz_rdbGumka.UseVisualStyleBackColor = true;
            this.iz_rdbGumka.CheckedChanged += new System.EventHandler(this.iz_rdbGumka_CheckedChanged);
            // 
            // iz_rbOlowek
            // 
            this.iz_rbOlowek.AutoSize = true;
            this.iz_rbOlowek.Location = new System.Drawing.Point(6, 19);
            this.iz_rbOlowek.Name = "iz_rbOlowek";
            this.iz_rbOlowek.Size = new System.Drawing.Size(63, 17);
            this.iz_rbOlowek.TabIndex = 9;
            this.iz_rbOlowek.TabStop = true;
            this.iz_rbOlowek.Text = "Ołówek";
            this.iz_rbOlowek.UseVisualStyleBackColor = true;
            // 
            // iz_rdbLiniaProsta
            // 
            this.iz_rdbLiniaProsta.AutoSize = true;
            this.iz_rdbLiniaProsta.Location = new System.Drawing.Point(6, 42);
            this.iz_rdbLiniaProsta.Name = "iz_rdbLiniaProsta";
            this.iz_rdbLiniaProsta.Size = new System.Drawing.Size(55, 17);
            this.iz_rdbLiniaProsta.TabIndex = 11;
            this.iz_rdbLiniaProsta.TabStop = true;
            this.iz_rdbLiniaProsta.Text = "Prosta";
            this.iz_rdbLiniaProsta.UseVisualStyleBackColor = true;
            // 
            // iz_rdbProstokąt
            // 
            this.iz_rdbProstokąt.AutoSize = true;
            this.iz_rdbProstokąt.Location = new System.Drawing.Point(6, 134);
            this.iz_rdbProstokąt.Name = "iz_rdbProstokąt";
            this.iz_rdbProstokąt.Size = new System.Drawing.Size(70, 17);
            this.iz_rdbProstokąt.TabIndex = 15;
            this.iz_rdbProstokąt.TabStop = true;
            this.iz_rdbProstokąt.Text = "Prostokąt";
            this.iz_rdbProstokąt.UseVisualStyleBackColor = true;
            // 
            // iz_rdbElipsa
            // 
            this.iz_rdbElipsa.AutoSize = true;
            this.iz_rdbElipsa.Location = new System.Drawing.Point(6, 88);
            this.iz_rdbElipsa.Name = "iz_rdbElipsa";
            this.iz_rdbElipsa.Size = new System.Drawing.Size(53, 17);
            this.iz_rdbElipsa.TabIndex = 13;
            this.iz_rdbElipsa.TabStop = true;
            this.iz_rdbElipsa.Text = "Elipsa";
            this.iz_rdbElipsa.UseVisualStyleBackColor = true;
            // 
            // iz_rdbKwadrat
            // 
            this.iz_rdbKwadrat.AutoSize = true;
            this.iz_rdbKwadrat.Location = new System.Drawing.Point(6, 111);
            this.iz_rdbKwadrat.Name = "iz_rdbKwadrat";
            this.iz_rdbKwadrat.Size = new System.Drawing.Size(64, 17);
            this.iz_rdbKwadrat.TabIndex = 14;
            this.iz_rdbKwadrat.TabStop = true;
            this.iz_rdbKwadrat.Text = "Kwadrat";
            this.iz_rdbKwadrat.UseVisualStyleBackColor = true;
            // 
            // iz_rdbOkrąg
            // 
            this.iz_rdbOkrąg.AutoSize = true;
            this.iz_rdbOkrąg.Location = new System.Drawing.Point(6, 65);
            this.iz_rdbOkrąg.Name = "iz_rdbOkrąg";
            this.iz_rdbOkrąg.Size = new System.Drawing.Size(48, 17);
            this.iz_rdbOkrąg.TabIndex = 12;
            this.iz_rdbOkrąg.TabStop = true;
            this.iz_rdbOkrąg.Text = "Koło";
            this.iz_rdbOkrąg.UseVisualStyleBackColor = true;
            // 
            // iz_btnWczytajMapęBitową
            // 
            this.iz_btnWczytajMapęBitową.Location = new System.Drawing.Point(12, 42);
            this.iz_btnWczytajMapęBitową.Name = "iz_btnWczytajMapęBitową";
            this.iz_btnWczytajMapęBitową.Size = new System.Drawing.Size(54, 24);
            this.iz_btnWczytajMapęBitową.TabIndex = 54;
            this.iz_btnWczytajMapęBitową.Text = "Wczytaj";
            this.iz_btnWczytajMapęBitową.UseVisualStyleBackColor = true;
            this.iz_btnWczytajMapęBitową.Click += new System.EventHandler(this.iz_btnWczytaj_Click);
            // 
            // iz_trbSuwakGrubościLinii
            // 
            this.iz_trbSuwakGrubościLinii.Location = new System.Drawing.Point(12, 288);
            this.iz_trbSuwakGrubościLinii.Minimum = 1;
            this.iz_trbSuwakGrubościLinii.Name = "iz_trbSuwakGrubościLinii";
            this.iz_trbSuwakGrubościLinii.Size = new System.Drawing.Size(110, 45);
            this.iz_trbSuwakGrubościLinii.TabIndex = 53;
            this.iz_trbSuwakGrubościLinii.Value = 1;
            this.iz_trbSuwakGrubościLinii.ValueChanged += new System.EventHandler(this.iz_trbSuwakGrubościLinii_ValueChanged);
            // 
            // iz_cmbStylLinii
            // 
            this.iz_cmbStylLinii.FormattingEnabled = true;
            this.iz_cmbStylLinii.Items.AddRange(new object[] {
            "Kreskowa (Dash)",
            "Kreskowo-kropkowa (DashDot)",
            "Kreskowa-kopkowo-kropkowa (DashDotDot)",
            "Kropkowa (Dot)",
            "Ciągła(Solid)"});
            this.iz_cmbStylLinii.Location = new System.Drawing.Point(12, 352);
            this.iz_cmbStylLinii.Name = "iz_cmbStylLinii";
            this.iz_cmbStylLinii.Size = new System.Drawing.Size(110, 21);
            this.iz_cmbStylLinii.TabIndex = 52;
            this.iz_cmbStylLinii.SelectedIndexChanged += new System.EventHandler(this.iz_cmbStylLinii_SelectedIndexChanged);
            // 
            // iz_btnZapiszMapęBitową
            // 
            this.iz_btnZapiszMapęBitową.Location = new System.Drawing.Point(12, 12);
            this.iz_btnZapiszMapęBitową.Name = "iz_btnZapiszMapęBitową";
            this.iz_btnZapiszMapęBitową.Size = new System.Drawing.Size(54, 24);
            this.iz_btnZapiszMapęBitową.TabIndex = 50;
            this.iz_btnZapiszMapęBitową.Text = "Zapisz";
            this.iz_btnZapiszMapęBitową.UseVisualStyleBackColor = true;
            this.iz_btnZapiszMapęBitową.Click += new System.EventHandler(this.iz_btnZapisz_Click);
            // 
            // iz_imgRysownica
            // 
            this.iz_imgRysownica.Location = new System.Drawing.Point(128, 25);
            this.iz_imgRysownica.Name = "iz_imgRysownica";
            this.iz_imgRysownica.Size = new System.Drawing.Size(871, 599);
            this.iz_imgRysownica.TabIndex = 46;
            this.iz_imgRysownica.TabStop = false;
            this.iz_imgRysownica.MouseDown += new System.Windows.Forms.MouseEventHandler(this.iz_imgRysownica_MouseDown);
            this.iz_imgRysownica.MouseMove += new System.Windows.Forms.MouseEventHandler(this.iz_imgRysownica_MouseMove);
            this.iz_imgRysownica.MouseUp += new System.Windows.Forms.MouseEventHandler(this.iz_imgRysownica_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 336);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "Wybierz styl linii";
            // 
            // iz_chbWypelnij
            // 
            this.iz_chbWypelnij.AutoSize = true;
            this.iz_chbWypelnij.Location = new System.Drawing.Point(12, 252);
            this.iz_chbWypelnij.Name = "iz_chbWypelnij";
            this.iz_chbWypelnij.Size = new System.Drawing.Size(92, 17);
            this.iz_chbWypelnij.TabIndex = 63;
            this.iz_chbWypelnij.Text = "Wypełnienie?";
            this.iz_chbWypelnij.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 64;
            this.label5.Text = "Kolor tła:";
            // 
            // iz_lblKolorTla
            // 
            this.iz_lblKolorTla.Location = new System.Drawing.Point(129, 9);
            this.iz_lblKolorTla.Name = "iz_lblKolorTla";
            this.iz_lblKolorTla.Size = new System.Drawing.Size(51, 13);
            this.iz_lblKolorTla.TabIndex = 65;
            this.iz_lblKolorTla.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(186, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 66;
            this.label7.Text = "Kolor podstawowy:";
            // 
            // iz_lblKolorPdst
            // 
            this.iz_lblKolorPdst.Location = new System.Drawing.Point(288, 9);
            this.iz_lblKolorPdst.Name = "iz_lblKolorPdst";
            this.iz_lblKolorPdst.Size = new System.Drawing.Size(51, 13);
            this.iz_lblKolorPdst.TabIndex = 67;
            this.iz_lblKolorPdst.Click += new System.EventHandler(this.iz_lblKolorPdst_Click);
            // 
            // iz_lblKolorWypel
            // 
            this.iz_lblKolorWypel.Location = new System.Drawing.Point(447, 9);
            this.iz_lblKolorWypel.Name = "iz_lblKolorWypel";
            this.iz_lblKolorWypel.Size = new System.Drawing.Size(51, 13);
            this.iz_lblKolorWypel.TabIndex = 69;
            this.iz_lblKolorWypel.Click += new System.EventHandler(this.iz_lblKolorWypel_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(345, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 13);
            this.label10.TabIndex = 68;
            this.label10.Text = "Kolor wypełnienia:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 70;
            this.label6.Text = "Rozmiar kreski";
            // 
            // iz_btnRemove
            // 
            this.iz_btnRemove.Location = new System.Drawing.Point(12, 390);
            this.iz_btnRemove.Name = "iz_btnRemove";
            this.iz_btnRemove.Size = new System.Drawing.Size(110, 23);
            this.iz_btnRemove.TabIndex = 71;
            this.iz_btnRemove.Text = "Usuń figurę";
            this.iz_btnRemove.UseVisualStyleBackColor = true;
            this.iz_btnRemove.Click += new System.EventHandler(this.iz_btnRemove_Click);
            // 
            // iz_numDelete
            // 
            this.iz_numDelete.Location = new System.Drawing.Point(12, 419);
            this.iz_numDelete.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.iz_numDelete.Name = "iz_numDelete";
            this.iz_numDelete.Size = new System.Drawing.Size(110, 20);
            this.iz_numDelete.TabIndex = 73;
            this.iz_numDelete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // iz_btnMoveAll
            // 
            this.iz_btnMoveAll.Location = new System.Drawing.Point(12, 445);
            this.iz_btnMoveAll.Name = "iz_btnMoveAll";
            this.iz_btnMoveAll.Size = new System.Drawing.Size(110, 37);
            this.iz_btnMoveAll.TabIndex = 74;
            this.iz_btnMoveAll.Text = "Przesuń figury w losowe miejsca";
            this.iz_btnMoveAll.UseVisualStyleBackColor = true;
            this.iz_btnMoveAll.Click += new System.EventHandler(this.iz_btnMoveAll_Click);
            // 
            // iz_btnRoll
            // 
            this.iz_btnRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.iz_btnRoll.Location = new System.Drawing.Point(12, 488);
            this.iz_btnRoll.Name = "iz_btnRoll";
            this.iz_btnRoll.Size = new System.Drawing.Size(110, 49);
            this.iz_btnRoll.TabIndex = 75;
            this.iz_btnRoll.Text = "Wylosuj właściwości graficzne dla wszystkich figur";
            this.iz_btnRoll.UseVisualStyleBackColor = true;
            this.iz_btnRoll.Click += new System.EventHandler(this.iz_btnRoll_Click);
            // 
            // iz_btnMoveAndRoll
            // 
            this.iz_btnMoveAndRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.iz_btnMoveAndRoll.Location = new System.Drawing.Point(12, 543);
            this.iz_btnMoveAndRoll.Name = "iz_btnMoveAndRoll";
            this.iz_btnMoveAndRoll.Size = new System.Drawing.Size(110, 69);
            this.iz_btnMoveAndRoll.TabIndex = 76;
            this.iz_btnMoveAndRoll.Text = "Wylosuj położenie i właściwości graficzne dla wszystkich figur";
            this.iz_btnMoveAndRoll.UseVisualStyleBackColor = true;
            this.iz_btnMoveAndRoll.Click += new System.EventHandler(this.iz_btnMoveAndRoll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 636);
            this.Controls.Add(this.iz_btnMoveAndRoll);
            this.Controls.Add(this.iz_btnRoll);
            this.Controls.Add(this.iz_btnMoveAll);
            this.Controls.Add(this.iz_numDelete);
            this.Controls.Add(this.iz_btnRemove);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.iz_lblKolorWypel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.iz_lblKolorPdst);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.iz_lblKolorTla);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.iz_chbWypelnij);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.iz_GroupBox);
            this.Controls.Add(this.iz_btnWczytajMapęBitową);
            this.Controls.Add(this.iz_trbSuwakGrubościLinii);
            this.Controls.Add(this.iz_cmbStylLinii);
            this.Controls.Add(this.iz_btnZapiszMapęBitową);
            this.Controls.Add(this.iz_imgRysownica);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.iz_lblWspolzednaY);
            this.Controls.Add(this.iz_lblWspolzednaX);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Paint";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.iz_GroupBox.ResumeLayout(false);
            this.iz_GroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iz_trbSuwakGrubościLinii)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iz_imgRysownica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iz_numDelete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label iz_lblWspolzednaY;
        private System.Windows.Forms.Label iz_lblWspolzednaX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox iz_GroupBox;
        private System.Windows.Forms.RadioButton iz_rdbGumka;
        private System.Windows.Forms.RadioButton iz_rbOlowek;
        private System.Windows.Forms.RadioButton iz_rdbLiniaProsta;
        private System.Windows.Forms.RadioButton iz_rdbOkrąg;
        private System.Windows.Forms.RadioButton iz_rdbElipsa;
        private System.Windows.Forms.RadioButton iz_rdbKwadrat;
        private System.Windows.Forms.RadioButton iz_rdbProstokąt;
        private System.Windows.Forms.Button iz_btnWczytajMapęBitową;
        private System.Windows.Forms.TrackBar iz_trbSuwakGrubościLinii;
        private System.Windows.Forms.ComboBox iz_cmbStylLinii;
        private System.Windows.Forms.Button iz_btnZapiszMapęBitową;
        private System.Windows.Forms.PictureBox iz_imgRysownica;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.ColorDialog colorDialog3;
        private System.Windows.Forms.ColorDialog colorDialog4;
        private System.Windows.Forms.ColorDialog colorDialog5;
        private System.Windows.Forms.ColorDialog colorDialog6;
        private System.Windows.Forms.ColorDialog colorDialog7;
        private System.Windows.Forms.CheckBox iz_chbWypelnij;
        private System.Windows.Forms.Label iz_lblKolorTla;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label iz_lblKolorPdst;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label iz_lblKolorWypel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button iz_btnRemove;
        private System.Windows.Forms.NumericUpDown iz_numDelete;
        private System.Windows.Forms.Button iz_btnMoveAndRoll;
        private System.Windows.Forms.Button iz_btnRoll;
        private System.Windows.Forms.Button iz_btnMoveAll;
    }
}

