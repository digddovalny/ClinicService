namespace ClinicDesctop
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listViewClients = new ListView();
            columnHeaderId = new ColumnHeader();
            columnHeaderSurName = new ColumnHeader();
            columnHeaderFirstName = new ColumnHeader();
            columnHeaderPatronymic = new ColumnHeader();
            columnHeaderDocument = new ColumnHeader();
            columnHeaderBrd = new ColumnHeader();
            buttonLoadClients = new Button();
            DeleteClient = new Button();
            Id = new Label();
            txtId = new TextBox();
            txtSurName = new TextBox();
            label1 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtPatronymic = new TextBox();
            label3 = new Label();
            txtDocum = new TextBox();
            label4 = new Label();
            AddClient = new Button();
            label5 = new Label();
            txtBirthday = new TextBox();
            UpdateClient = new Button();
            txtUpdatePatronymic = new TextBox();
            label6 = new Label();
            txtUpdateName = new TextBox();
            label7 = new Label();
            txtUpdateSurName = new TextBox();
            label8 = new Label();
            txtupdateBrd = new TextBox();
            label9 = new Label();
            txtUpdateDoc = new TextBox();
            label10 = new Label();
            label11 = new Label();
            txtGetClientById = new TextBox();
            GetClientById = new Button();
            SuspendLayout();
            // 
            // listViewClients
            // 
            listViewClients.Columns.AddRange(new ColumnHeader[] { columnHeaderId, columnHeaderSurName, columnHeaderFirstName, columnHeaderPatronymic, columnHeaderDocument, columnHeaderBrd });
            listViewClients.FullRowSelect = true;
            listViewClients.GridLines = true;
            listViewClients.Location = new Point(12, 12);
            listViewClients.MultiSelect = false;
            listViewClients.Name = "listViewClients";
            listViewClients.Size = new Size(854, 297);
            listViewClients.TabIndex = 0;
            listViewClients.UseCompatibleStateImageBehavior = false;
            listViewClients.View = View.Details;
            listViewClients.SelectedIndexChanged += listViewClients_SelectedIndexChanged;
            // 
            // columnHeaderId
            // 
            columnHeaderId.Text = "#";
            columnHeaderId.Width = 50;
            // 
            // columnHeaderSurName
            // 
            columnHeaderSurName.Text = "Фамилия";
            columnHeaderSurName.Width = 100;
            // 
            // columnHeaderFirstName
            // 
            columnHeaderFirstName.Text = "Имя";
            columnHeaderFirstName.Width = 80;
            // 
            // columnHeaderPatronymic
            // 
            columnHeaderPatronymic.Text = "Отчетсво";
            columnHeaderPatronymic.Width = 100;
            // 
            // columnHeaderDocument
            // 
            columnHeaderDocument.Text = "Документ";
            columnHeaderDocument.Width = 75;
            // 
            // columnHeaderBrd
            // 
            columnHeaderBrd.Text = "Дата рождения";
            columnHeaderBrd.Width = 110;
            // 
            // buttonLoadClients
            // 
            buttonLoadClients.BackColor = Color.Lime;
            buttonLoadClients.Location = new Point(740, 430);
            buttonLoadClients.Name = "buttonLoadClients";
            buttonLoadClients.Size = new Size(126, 38);
            buttonLoadClients.TabIndex = 1;
            buttonLoadClients.Text = "Загрузить всех клиентов";
            buttonLoadClients.UseVisualStyleBackColor = false;
            buttonLoadClients.Click += buttonLoadClients_Click;
            // 
            // DeleteClient
            // 
            DeleteClient.BackColor = Color.IndianRed;
            DeleteClient.BackgroundImageLayout = ImageLayout.None;
            DeleteClient.Location = new Point(740, 472);
            DeleteClient.Name = "DeleteClient";
            DeleteClient.Size = new Size(126, 37);
            DeleteClient.TabIndex = 3;
            DeleteClient.Text = "Удалить запись";
            DeleteClient.UseVisualStyleBackColor = false;
            DeleteClient.Click += DeleteClient_Click;
            // 
            // Id
            // 
            Id.AutoSize = true;
            Id.Location = new Point(121, 347);
            Id.Name = "Id";
            Id.Size = new Size(17, 15);
            Id.TabIndex = 4;
            Id.Text = "Id";
            // 
            // txtId
            // 
            txtId.Location = new Point(144, 339);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 5;
            // 
            // txtSurName
            // 
            txtSurName.Location = new Point(144, 368);
            txtSurName.Name = "txtSurName";
            txtSurName.Size = new Size(100, 23);
            txtSurName.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(80, 372);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 6;
            label1.Text = "Фамилия";
            // 
            // txtName
            // 
            txtName.Location = new Point(144, 397);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(107, 401);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 8;
            label2.Text = "Имя";
            // 
            // txtPatronymic
            // 
            txtPatronymic.Location = new Point(144, 427);
            txtPatronymic.Name = "txtPatronymic";
            txtPatronymic.Size = new Size(100, 23);
            txtPatronymic.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(80, 430);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 10;
            label3.Text = "Отчество";
            // 
            // txtDocum
            // 
            txtDocum.Location = new Point(144, 457);
            txtDocum.Name = "txtDocum";
            txtDocum.Size = new Size(100, 23);
            txtDocum.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(77, 460);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 12;
            label4.Text = "Документ";
            // 
            // AddClient
            // 
            AddClient.BackColor = Color.GreenYellow;
            AddClient.Location = new Point(250, 335);
            AddClient.Name = "AddClient";
            AddClient.Size = new Size(106, 176);
            AddClient.TabIndex = 14;
            AddClient.Text = "Добавить клиента";
            AddClient.UseVisualStyleBackColor = false;
            AddClient.Click += AddClient_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(48, 489);
            label5.Name = "label5";
            label5.Size = new Size(90, 15);
            label5.TabIndex = 15;
            label5.Text = "Дата рождения";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtBirthday
            // 
            txtBirthday.Location = new Point(144, 486);
            txtBirthday.Name = "txtBirthday";
            txtBirthday.Size = new Size(100, 23);
            txtBirthday.TabIndex = 16;
            // 
            // UpdateClient
            // 
            UpdateClient.BackColor = Color.Aquamarine;
            UpdateClient.Location = new Point(614, 337);
            UpdateClient.Name = "UpdateClient";
            UpdateClient.Size = new Size(106, 172);
            UpdateClient.TabIndex = 17;
            UpdateClient.Text = "Обновить клиента";
            UpdateClient.UseVisualStyleBackColor = false;
            UpdateClient.Click += UpdateClient_Click;
            // 
            // txtUpdatePatronymic
            // 
            txtUpdatePatronymic.Location = new Point(508, 406);
            txtUpdatePatronymic.Name = "txtUpdatePatronymic";
            txtUpdatePatronymic.Size = new Size(100, 23);
            txtUpdatePatronymic.TabIndex = 23;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(444, 409);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 22;
            label6.Text = "Отчество";
            // 
            // txtUpdateName
            // 
            txtUpdateName.Location = new Point(508, 379);
            txtUpdateName.Name = "txtUpdateName";
            txtUpdateName.Size = new Size(100, 23);
            txtUpdateName.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(471, 384);
            label7.Name = "label7";
            label7.Size = new Size(31, 15);
            label7.TabIndex = 20;
            label7.Text = "Имя";
            // 
            // txtUpdateSurName
            // 
            txtUpdateSurName.Location = new Point(508, 352);
            txtUpdateSurName.Name = "txtUpdateSurName";
            txtUpdateSurName.Size = new Size(100, 23);
            txtUpdateSurName.TabIndex = 19;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(444, 355);
            label8.Name = "label8";
            label8.Size = new Size(58, 15);
            label8.TabIndex = 18;
            label8.Text = "Фамилия";
            // 
            // txtupdateBrd
            // 
            txtupdateBrd.Location = new Point(508, 466);
            txtupdateBrd.Name = "txtupdateBrd";
            txtupdateBrd.Size = new Size(100, 23);
            txtupdateBrd.TabIndex = 27;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(412, 468);
            label9.Name = "label9";
            label9.Size = new Size(90, 15);
            label9.TabIndex = 26;
            label9.Text = "Дата рождения";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtUpdateDoc
            // 
            txtUpdateDoc.Location = new Point(508, 437);
            txtUpdateDoc.Name = "txtUpdateDoc";
            txtUpdateDoc.Size = new Size(100, 23);
            txtUpdateDoc.TabIndex = 25;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(441, 440);
            label10.Name = "label10";
            label10.Size = new Size(61, 15);
            label10.TabIndex = 24;
            label10.Text = "Документ";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(726, 342);
            label11.Name = "label11";
            label11.Size = new Size(146, 15);
            label11.TabIndex = 28;
            label11.Text = "Получение клиента по Id";
            // 
            // txtGetClientById
            // 
            txtGetClientById.Location = new Point(740, 360);
            txtGetClientById.Name = "txtGetClientById";
            txtGetClientById.Size = new Size(126, 23);
            txtGetClientById.TabIndex = 29;
            // 
            // GetClientById
            // 
            GetClientById.BackColor = Color.Bisque;
            GetClientById.Location = new Point(740, 390);
            GetClientById.Name = "GetClientById";
            GetClientById.Size = new Size(126, 36);
            GetClientById.TabIndex = 30;
            GetClientById.Text = "Получить";
            GetClientById.UseVisualStyleBackColor = false;
            GetClientById.Click += GetClientById_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 532);
            Controls.Add(GetClientById);
            Controls.Add(txtGetClientById);
            Controls.Add(label11);
            Controls.Add(txtupdateBrd);
            Controls.Add(label9);
            Controls.Add(txtUpdateDoc);
            Controls.Add(label10);
            Controls.Add(txtUpdatePatronymic);
            Controls.Add(label6);
            Controls.Add(txtUpdateName);
            Controls.Add(label7);
            Controls.Add(txtUpdateSurName);
            Controls.Add(label8);
            Controls.Add(UpdateClient);
            Controls.Add(txtBirthday);
            Controls.Add(label5);
            Controls.Add(AddClient);
            Controls.Add(txtDocum);
            Controls.Add(label4);
            Controls.Add(txtPatronymic);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(txtSurName);
            Controls.Add(label1);
            Controls.Add(txtId);
            Controls.Add(Id);
            Controls.Add(DeleteClient);
            Controls.Add(buttonLoadClients);
            Controls.Add(listViewClients);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Моя клиника";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listViewClients;
        private ColumnHeader columnHeaderId;
        private ColumnHeader columnHeaderSurName;
        private ColumnHeader columnHeaderFirstName;
        private ColumnHeader columnHeaderPatronymic;
        private ColumnHeader columnHeaderDocument;
        private Button buttonLoadClients;
        private Button DeleteClient;
        private Label Id;
        private TextBox txtId;
        private TextBox txtSurName;
        private Label label1;
        private TextBox txtName;
        private Label label2;
        private TextBox txtPatronymic;
        private Label label3;
        private TextBox txtDocum;
        private Label label4;
        private Button AddClient;
        private ColumnHeader columnHeaderBrd;
        private Label label5;
        private TextBox txtBirthday;
        private Button UpdateClient;
        private TextBox txtUpdatePatronymic;
        private Label label6;
        private TextBox txtUpdateName;
        private Label label7;
        private TextBox txtUpdateSurName;
        private Label label8;
        private TextBox txtupdateBrd;
        private Label label9;
        private TextBox txtUpdateDoc;
        private Label label10;
        private Label label11;
        private TextBox txtGetClientById;
        private Button GetClientById;
    }
}