namespace TeleTTest
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dodajBazuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.openFileChoseDb = new System.Windows.Forms.OpenFileDialog();
            this.cmbExchangeFilter = new System.Windows.Forms.ComboBox();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnConfirmFilter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTypeFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddSymbol = new System.Windows.Forms.Button();
            this.btnEditSymbol = new System.Windows.Forms.Button();
            this.btnDeleteSymbol = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajBazuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dodajBazuToolStripMenuItem
            // 
            this.dodajBazuToolStripMenuItem.Name = "dodajBazuToolStripMenuItem";
            this.dodajBazuToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.dodajBazuToolStripMenuItem.Text = "Dodaj Bazu";
            this.dodajBazuToolStripMenuItem.Click += new System.EventHandler(this.dodajBazuToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 124);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(776, 264);
            this.dataGridView1.TabIndex = 1;
            // 
            // openFileChoseDb
            // 
            this.openFileChoseDb.FileName = "openFileDialog1";
            // 
            // cmbExchangeFilter
            // 
            this.cmbExchangeFilter.FormattingEnabled = true;
            this.cmbExchangeFilter.Location = new System.Drawing.Point(105, 36);
            this.cmbExchangeFilter.Name = "cmbExchangeFilter";
            this.cmbExchangeFilter.Size = new System.Drawing.Size(138, 23);
            this.cmbExchangeFilter.TabIndex = 2;
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnConfirmFilter);
            this.gbFilter.Controls.Add(this.label2);
            this.gbFilter.Controls.Add(this.cmbTypeFilter);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Controls.Add(this.cmbExchangeFilter);
            this.gbFilter.Enabled = false;
            this.gbFilter.Location = new System.Drawing.Point(12, 27);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(776, 79);
            this.gbFilter.TabIndex = 3;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter by";
            // 
            // btnConfirmFilter
            // 
            this.btnConfirmFilter.Location = new System.Drawing.Point(695, 36);
            this.btnConfirmFilter.Name = "btnConfirmFilter";
            this.btnConfirmFilter.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmFilter.TabIndex = 6;
            this.btnConfirmFilter.Text = "Filter";
            this.btnConfirmFilter.UseVisualStyleBackColor = true;
            this.btnConfirmFilter.Click += new System.EventHandler(this.btnConfirmFilter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Type";
            // 
            // cmbTypeFilter
            // 
            this.cmbTypeFilter.FormattingEnabled = true;
            this.cmbTypeFilter.Location = new System.Drawing.Point(286, 36);
            this.cmbTypeFilter.Name = "cmbTypeFilter";
            this.cmbTypeFilter.Size = new System.Drawing.Size(144, 23);
            this.cmbTypeFilter.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Exchange Name";
            // 
            // btnAddSymbol
            // 
            this.btnAddSymbol.Enabled = false;
            this.btnAddSymbol.Location = new System.Drawing.Point(12, 394);
            this.btnAddSymbol.Name = "btnAddSymbol";
            this.btnAddSymbol.Size = new System.Drawing.Size(99, 23);
            this.btnAddSymbol.TabIndex = 4;
            this.btnAddSymbol.Text = "Add Symbol";
            this.btnAddSymbol.UseVisualStyleBackColor = true;
            this.btnAddSymbol.Click += new System.EventHandler(this.btnAddSymbol_Click);
            // 
            // btnEditSymbol
            // 
            this.btnEditSymbol.Enabled = false;
            this.btnEditSymbol.Location = new System.Drawing.Point(117, 394);
            this.btnEditSymbol.Name = "btnEditSymbol";
            this.btnEditSymbol.Size = new System.Drawing.Size(121, 23);
            this.btnEditSymbol.TabIndex = 5;
            this.btnEditSymbol.Text = "Edit/View Symbol";
            this.btnEditSymbol.UseVisualStyleBackColor = true;
            this.btnEditSymbol.Click += new System.EventHandler(this.btnEditSymbol_Click);
            // 
            // btnDeleteSymbol
            // 
            this.btnDeleteSymbol.Enabled = false;
            this.btnDeleteSymbol.Location = new System.Drawing.Point(244, 394);
            this.btnDeleteSymbol.Name = "btnDeleteSymbol";
            this.btnDeleteSymbol.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteSymbol.TabIndex = 6;
            this.btnDeleteSymbol.Text = "Delete Symbol";
            this.btnDeleteSymbol.UseVisualStyleBackColor = true;
            this.btnDeleteSymbol.Click += new System.EventHandler(this.btnDeleteSymbol_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDeleteSymbol);
            this.Controls.Add(this.btnEditSymbol);
            this.Controls.Add(this.btnAddSymbol);
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "TeleTrader ProjectTask";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem dodajBazuToolStripMenuItem;
        private DataGridView dataGridView1;
        private OpenFileDialog openFileChoseDb;
        private ComboBox cmbExchangeFilter;
        private GroupBox gbFilter;
        private Label label1;
        private Button btnConfirmFilter;
        private Label label2;
        private ComboBox cmbTypeFilter;
        private Button btnAddSymbol;
        private Button btnEditSymbol;
        private Button btnDeleteSymbol;
    }
}