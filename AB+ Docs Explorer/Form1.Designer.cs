namespace AB__Docs_Explorer
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.btnMine = new System.Windows.Forms.Button();
            this.workerMine = new System.ComponentModel.BackgroundWorker();
            this.lbClasses = new System.Windows.Forms.ListBox();
            this.lvMembers = new System.Windows.Forms.ListView();
            this.colKind = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReturn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDefinition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colParameters = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.lblMemName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbFunction = new System.Windows.Forms.GroupBox();
            this.txtEditParamComm = new System.Windows.Forms.TextBox();
            this.lvParameters = new ListViewEx.ListViewEx();
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colComm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblRetType = new AB__Docs_Explorer.Controls.RichTextLabel();
            this.lblParameters = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbVariable = new System.Windows.Forms.GroupBox();
            this.lblVarType = new AB__Docs_Explorer.Controls.RichTextLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbFunction.SuspendLayout();
            this.gbVariable.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(510, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Tag = "Path";
            this.label1.Text = "TBOI Installation Path";
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(621, 8);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(318, 20);
            this.txtPath.TabIndex = 1;
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // pbProgress
            // 
            this.pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProgress.Location = new System.Drawing.Point(12, 479);
            this.pbProgress.MarqueeAnimationSpeed = 10;
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(927, 23);
            this.pbProgress.TabIndex = 2;
            // 
            // btnMine
            // 
            this.btnMine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMine.Location = new System.Drawing.Point(12, 450);
            this.btnMine.Name = "btnMine";
            this.btnMine.Size = new System.Drawing.Size(153, 23);
            this.btnMine.TabIndex = 3;
            this.btnMine.Text = "Mine";
            this.btnMine.UseVisualStyleBackColor = true;
            this.btnMine.Click += new System.EventHandler(this.button1_Click);
            // 
            // workerMine
            // 
            this.workerMine.WorkerReportsProgress = true;
            this.workerMine.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerMine_DoWork);
            this.workerMine.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerMine_RunWorkerCompleted);
            // 
            // lbClasses
            // 
            this.lbClasses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbClasses.FormattingEnabled = true;
            this.lbClasses.Location = new System.Drawing.Point(12, 34);
            this.lbClasses.Name = "lbClasses";
            this.lbClasses.Size = new System.Drawing.Size(153, 407);
            this.lbClasses.TabIndex = 4;
            this.lbClasses.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // lvMembers
            // 
            this.lvMembers.BackColor = System.Drawing.SystemColors.Window;
            this.lvMembers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colKind,
            this.colReturn,
            this.colDefinition,
            this.colParameters});
            this.lvMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMembers.Font = new System.Drawing.Font("Courier New", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvMembers.FullRowSelect = true;
            this.lvMembers.Location = new System.Drawing.Point(0, 0);
            this.lvMembers.MultiSelect = false;
            this.lvMembers.Name = "lvMembers";
            this.lvMembers.Size = new System.Drawing.Size(768, 270);
            this.lvMembers.SmallImageList = this.imageList1;
            this.lvMembers.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvMembers.TabIndex = 5;
            this.lvMembers.UseCompatibleStateImageBehavior = false;
            this.lvMembers.View = System.Windows.Forms.View.Details;
            this.lvMembers.SelectedIndexChanged += new System.EventHandler(this.lblFuncRet_SelectedIndexChanged);
            this.lvMembers.DoubleClick += new System.EventHandler(this.lvMembers_DoubleClick);
            // 
            // colKind
            // 
            this.colKind.Text = "";
            this.colKind.Width = 20;
            // 
            // colReturn
            // 
            this.colReturn.Text = "Return type";
            this.colReturn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colReturn.Width = 156;
            // 
            // colDefinition
            // 
            this.colDefinition.Text = "Name";
            this.colDefinition.Width = 167;
            // 
            // colParameters
            // 
            this.colParameters.Text = "Parameters";
            this.colParameters.Width = 416;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icon_method.png");
            this.imageList1.Images.SetKeyName(1, "icon_attribute.png");
            this.imageList1.Images.SetKeyName(2, "icon_class.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(171, 34);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvMembers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.txtComments);
            this.splitContainer1.Panel2.Controls.Add(this.lblMemName);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.gbFunction);
            this.splitContainer1.Panel2.Controls.Add(this.gbVariable);
            this.splitContainer1.Size = new System.Drawing.Size(768, 438);
            this.splitContainer1.SplitterDistance = 270;
            this.splitContainer1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(611, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Comments";
            // 
            // txtComments
            // 
            this.txtComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComments.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComments.Location = new System.Drawing.Point(614, 31);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(150, 126);
            this.txtComments.TabIndex = 4;
            this.txtComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComments_KeyPress);
            // 
            // lblMemName
            // 
            this.lblMemName.AutoSize = true;
            this.lblMemName.Font = new System.Drawing.Font("Courier New", 10F);
            this.lblMemName.Location = new System.Drawing.Point(89, 7);
            this.lblMemName.Name = "lblMemName";
            this.lblMemName.Size = new System.Drawing.Size(144, 17);
            this.lblMemName.TabIndex = 1;
            this.lblMemName.Text = "                 ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 0;
            this.label2.Tag = "pene";
            this.label2.Text = "Member name:";
            // 
            // gbFunction
            // 
            this.gbFunction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFunction.Controls.Add(this.txtEditParamComm);
            this.gbFunction.Controls.Add(this.lvParameters);
            this.gbFunction.Controls.Add(this.lblRetType);
            this.gbFunction.Controls.Add(this.lblParameters);
            this.gbFunction.Controls.Add(this.label4);
            this.gbFunction.Location = new System.Drawing.Point(5, 29);
            this.gbFunction.Name = "gbFunction";
            this.gbFunction.Size = new System.Drawing.Size(603, 128);
            this.gbFunction.TabIndex = 3;
            this.gbFunction.TabStop = false;
            this.gbFunction.Text = "Function";
            // 
            // txtEditParamComm
            // 
            this.txtEditParamComm.Location = new System.Drawing.Point(310, 84);
            this.txtEditParamComm.Name = "txtEditParamComm";
            this.txtEditParamComm.Size = new System.Drawing.Size(100, 20);
            this.txtEditParamComm.TabIndex = 6;
            this.txtEditParamComm.Visible = false;
            // 
            // lvParameters
            // 
            this.lvParameters.AllowColumnReorder = true;
            this.lvParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colType,
            this.colName,
            this.colComm});
            this.lvParameters.DoubleClickActivation = false;
            this.lvParameters.Font = new System.Drawing.Font("Courier New", 9.5F);
            this.lvParameters.FullRowSelect = true;
            this.lvParameters.Location = new System.Drawing.Point(75, 46);
            this.lvParameters.Name = "lvParameters";
            this.lvParameters.Size = new System.Drawing.Size(521, 76);
            this.lvParameters.TabIndex = 5;
            this.lvParameters.UseCompatibleStateImageBehavior = false;
            this.lvParameters.View = System.Windows.Forms.View.Details;
            this.lvParameters.SubItemEndEditing += new ListViewEx.SubItemEndEditingEventHandler(this.lvParameters_SubItemEndEditing);
            this.lvParameters.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvParameters_MouseDoubleClick);
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 148;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 145;
            // 
            // colComm
            // 
            this.colComm.Text = "Comment";
            this.colComm.Width = 223;
            // 
            // lblRetType
            // 
            this.lblRetType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRetType.Font = new System.Drawing.Font("Courier New", 9.5F);
            this.lblRetType.Location = new System.Drawing.Point(75, 21);
            this.lblRetType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblRetType.Name = "lblRetType";
            this.lblRetType.Size = new System.Drawing.Size(521, 21);
            this.lblRetType.TabIndex = 4;
            // 
            // lblParameters
            // 
            this.lblParameters.AutoSize = true;
            this.lblParameters.Location = new System.Drawing.Point(6, 43);
            this.lblParameters.Name = "lblParameters";
            this.lblParameters.Size = new System.Drawing.Size(63, 13);
            this.lblParameters.TabIndex = 3;
            this.lblParameters.Text = "Parameters:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Return type:";
            // 
            // gbVariable
            // 
            this.gbVariable.Controls.Add(this.lblVarType);
            this.gbVariable.Controls.Add(this.label3);
            this.gbVariable.Location = new System.Drawing.Point(5, 29);
            this.gbVariable.Name = "gbVariable";
            this.gbVariable.Size = new System.Drawing.Size(268, 128);
            this.gbVariable.TabIndex = 2;
            this.gbVariable.TabStop = false;
            this.gbVariable.Text = "Variable";
            // 
            // lblVarType
            // 
            this.lblVarType.Font = new System.Drawing.Font("Courier New", 9.5F);
            this.lblVarType.Location = new System.Drawing.Point(47, 20);
            this.lblVarType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblVarType.Name = "lblVarType";
            this.lblVarType.Size = new System.Drawing.Size(189, 19);
            this.lblVarType.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Type:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(900, 502);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "by pipe01";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(57, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(108, 20);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 514);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lbClasses);
            this.Controls.Add(this.btnMine);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "frmMain";
            this.Text = "Afterbirth+ Documentation Explorer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbFunction.ResumeLayout(false);
            this.gbFunction.PerformLayout();
            this.gbVariable.ResumeLayout(false);
            this.gbVariable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Button btnMine;
        private System.ComponentModel.BackgroundWorker workerMine;
        private System.Windows.Forms.ListBox lbClasses;
        private System.Windows.Forms.ListView lvMembers;
        private System.Windows.Forms.ColumnHeader colReturn;
        private System.Windows.Forms.ColumnHeader colDefinition;
        private System.Windows.Forms.ColumnHeader colParameters;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblMemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbVariable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbFunction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblParameters;
        private System.Windows.Forms.ColumnHeader colKind;
        private System.Windows.Forms.ImageList imageList1;
        private Controls.RichTextLabel lblVarType;
        private Controls.RichTextLabel lblRetType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtComments;
        private ListViewEx.ListViewEx lvParameters;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colComm;
        private System.Windows.Forms.TextBox txtEditParamComm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSearch;
    }
}

