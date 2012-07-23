namespace QLPhongMachTu.Presentation
{
    partial class frmquanlynguoidung
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lvNguoiDung = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cbquyen = new System.Windows.Forms.ComboBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnreset = new DevComponents.DotNetBar.ButtonX();
            this.txttennguoidung = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnxoa = new DevComponents.DotNetBar.ButtonX();
            this.btnthem = new DevComponents.DotNetBar.ButtonX();
            this.btnCapNhat = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.lvNguoiDung);
            this.groupPanel1.Controls.Add(this.groupPanel2);
            this.groupPanel1.Location = new System.Drawing.Point(0, 2);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(507, 275);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel1.TabIndex = 2;
            // 
            // lvNguoiDung
            // 
            this.lvNguoiDung.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvNguoiDung.FullRowSelect = true;
            this.lvNguoiDung.GridLines = true;
            this.lvNguoiDung.Location = new System.Drawing.Point(209, 8);
            this.lvNguoiDung.Name = "lvNguoiDung";
            this.lvNguoiDung.Size = new System.Drawing.Size(289, 258);
            this.lvNguoiDung.TabIndex = 13;
            this.lvNguoiDung.UseCompatibleStateImageBehavior = false;
            this.lvNguoiDung.View = System.Windows.Forms.View.Details;
            this.lvNguoiDung.SelectedIndexChanged += new System.EventHandler(this.lvNguoiDung_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STT";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên người dùng";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 122;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Quyền";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 80;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btnCapNhat);
            this.groupPanel2.Controls.Add(this.labelX3);
            this.groupPanel2.Controls.Add(this.cbquyen);
            this.groupPanel2.Controls.Add(this.labelX2);
            this.groupPanel2.Controls.Add(this.btnreset);
            this.groupPanel2.Controls.Add(this.txttennguoidung);
            this.groupPanel2.Controls.Add(this.btnxoa);
            this.groupPanel2.Controls.Add(this.btnthem);
            this.groupPanel2.Location = new System.Drawing.Point(3, 8);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(200, 257);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel2.TabIndex = 12;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            this.labelX3.Location = new System.Drawing.Point(3, 80);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(61, 23);
            this.labelX3.TabIndex = 14;
            this.labelX3.Text = "Quyền :";
            // 
            // cbquyen
            // 
            this.cbquyen.FormattingEnabled = true;
            this.cbquyen.Location = new System.Drawing.Point(91, 80);
            this.cbquyen.Name = "cbquyen";
            this.cbquyen.Size = new System.Drawing.Size(100, 21);
            this.cbquyen.TabIndex = 13;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Location = new System.Drawing.Point(3, 30);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(89, 23);
            this.labelX2.TabIndex = 5;
            this.labelX2.Text = "Tên người dùng  :";
            // 
            // btnreset
            // 
            this.btnreset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnreset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnreset.Location = new System.Drawing.Point(103, 178);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(75, 23);
            this.btnreset.TabIndex = 11;
            this.btnreset.Text = "Cấp Lại Mật Khẩu";
            this.btnreset.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // txttennguoidung
            // 
            // 
            // 
            // 
            this.txttennguoidung.Border.Class = "TextBoxBorder";
            this.txttennguoidung.Location = new System.Drawing.Point(91, 30);
            this.txttennguoidung.Name = "txttennguoidung";
            this.txttennguoidung.Size = new System.Drawing.Size(100, 20);
            this.txttennguoidung.TabIndex = 1;
            // 
            // btnxoa
            // 
            this.btnxoa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnxoa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnxoa.Location = new System.Drawing.Point(103, 149);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(75, 23);
            this.btnxoa.TabIndex = 8;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnthem
            // 
            this.btnthem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnthem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnthem.Location = new System.Drawing.Point(17, 149);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(75, 23);
            this.btnthem.TabIndex = 9;
            this.btnthem.Text = "Thêm ";
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCapNhat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCapNhat.Location = new System.Drawing.Point(17, 178);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 15;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // frmquanlynguoidung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 277);
            this.Controls.Add(this.groupPanel1);
            this.MaximizeBox = false;
            this.Name = "frmquanlynguoidung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý người dùng";
            this.Load += new System.EventHandler(this.frmquanlynguoidung_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.ComboBox cbquyen;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btnreset;
        private DevComponents.DotNetBar.Controls.TextBoxX txttennguoidung;
        private DevComponents.DotNetBar.ButtonX btnxoa;
        private DevComponents.DotNetBar.ButtonX btnthem;
        private System.Windows.Forms.ListView lvNguoiDung;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private DevComponents.DotNetBar.ButtonX btnCapNhat;
    }
}