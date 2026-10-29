namespace FactoryErpSupport
{
    partial class StockMovementForm
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
            cboMaterial = new ComboBox();
            cboWarehouse = new ComboBox();
            txtStockQuantity = new TextBox();
            txtReferenceNo = new TextBox();
            txtStockNote = new TextBox();
            btnStockIn = new Button();
            btnStockOut = new Button();
            dgvStockBalances = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            lblWarehouse = new Label();
            label3 = new Label();
            lblReferenceNo = new Label();
            label4 = new Label();
            btnRefreshStock = new Button();
            lblStockBalance = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvStockBalances).BeginInit();
            SuspendLayout();
            // 
            // cboMaterial
            // 
            cboMaterial.FormattingEnabled = true;
            cboMaterial.Location = new Point(40, 71);
            cboMaterial.Name = "cboMaterial";
            cboMaterial.Size = new Size(151, 28);
            cboMaterial.TabIndex = 0;
            cboMaterial.Text = "Chọn vật tư";
            // 
            // cboWarehouse
            // 
            cboWarehouse.FormattingEnabled = true;
            cboWarehouse.Location = new Point(223, 71);
            cboWarehouse.Name = "cboWarehouse";
            cboWarehouse.Size = new Size(151, 28);
            cboWarehouse.TabIndex = 1;
            cboWarehouse.Text = "Chọn kho";
            // 
            // txtStockQuantity
            // 
            txtStockQuantity.Location = new Point(400, 71);
            txtStockQuantity.Name = "txtStockQuantity";
            txtStockQuantity.Size = new Size(125, 27);
            txtStockQuantity.TabIndex = 2;
            // 
            // txtReferenceNo
            // 
            txtReferenceNo.Location = new Point(554, 72);
            txtReferenceNo.Name = "txtReferenceNo";
            txtReferenceNo.Size = new Size(125, 27);
            txtReferenceNo.TabIndex = 3;
            // 
            // txtStockNote
            // 
            txtStockNote.Location = new Point(40, 147);
            txtStockNote.Name = "txtStockNote";
            txtStockNote.Size = new Size(151, 27);
            txtStockNote.TabIndex = 4;
            // 
            // btnStockIn
            // 
            btnStockIn.Location = new Point(223, 147);
            btnStockIn.Name = "btnStockIn";
            btnStockIn.Size = new Size(94, 29);
            btnStockIn.TabIndex = 5;
            btnStockIn.Text = "Nhập kho";
            btnStockIn.UseVisualStyleBackColor = true;
            // 
            // btnStockOut
            // 
            btnStockOut.Location = new Point(351, 147);
            btnStockOut.Name = "btnStockOut";
            btnStockOut.Size = new Size(94, 29);
            btnStockOut.TabIndex = 6;
            btnStockOut.Text = "Xuất kho";
            btnStockOut.UseVisualStyleBackColor = true;
            // 
            // dgvStockBalances
            // 
            dgvStockBalances.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStockBalances.Location = new Point(40, 222);
            dgvStockBalances.Name = "dgvStockBalances";
            dgvStockBalances.RowHeadersWidth = 51;
            dgvStockBalances.Size = new Size(711, 299);
            dgvStockBalances.TabIndex = 8;
            dgvStockBalances.CellContentClick += dgvStockBalances_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(40, 9);
            label1.Name = "label1";
            label1.Size = new Size(269, 28);
            label1.TabIndex = 9;
            label1.Text = "QUẢN LÝ NHẬP XUẤT KHO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 48);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 10;
            label2.Text = "Chọn vật tư";
            // 
            // lblWarehouse
            // 
            lblWarehouse.AutoSize = true;
            lblWarehouse.Location = new Point(223, 48);
            lblWarehouse.Name = "lblWarehouse";
            lblWarehouse.Size = new Size(71, 20);
            lblWarehouse.TabIndex = 11;
            lblWarehouse.Text = "Chọn kho";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(400, 48);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 12;
            label3.Text = "Số lượng";
            // 
            // lblReferenceNo
            // 
            lblReferenceNo.AccessibleRole = AccessibleRole.Sound;
            lblReferenceNo.AutoSize = true;
            lblReferenceNo.Location = new Point(554, 48);
            lblReferenceNo.Name = "lblReferenceNo";
            lblReferenceNo.Size = new Size(93, 20);
            lblReferenceNo.TabIndex = 13;
            lblReferenceNo.Text = "Mã chứng từ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 124);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 14;
            label4.Text = "Ghi chú";
            // 
            // btnRefreshStock
            // 
            btnRefreshStock.Location = new Point(472, 145);
            btnRefreshStock.Name = "btnRefreshStock";
            btnRefreshStock.Size = new Size(135, 29);
            btnRefreshStock.TabIndex = 15;
            btnRefreshStock.Text = "Làm mới tồn kho";
            btnRefreshStock.UseVisualStyleBackColor = true;
            // 
            // lblStockBalance
            // 
            lblStockBalance.AutoSize = true;
            lblStockBalance.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStockBalance.Location = new Point(40, 196);
            lblStockBalance.Name = "lblStockBalance";
            lblStockBalance.Size = new Size(258, 23);
            lblStockBalance.TabIndex = 16;
            lblStockBalance.Text = "Số lượng nhập xuất kho hiện tại";
            lblStockBalance.Click += lblStockBalance_Click;
            // 
            // StockMovementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 544);
            Controls.Add(lblStockBalance);
            Controls.Add(btnRefreshStock);
            Controls.Add(label4);
            Controls.Add(lblReferenceNo);
            Controls.Add(label3);
            Controls.Add(lblWarehouse);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvStockBalances);
            Controls.Add(btnStockOut);
            Controls.Add(btnStockIn);
            Controls.Add(txtStockNote);
            Controls.Add(txtReferenceNo);
            Controls.Add(txtStockQuantity);
            Controls.Add(cboWarehouse);
            Controls.Add(cboMaterial);
            Name = "StockMovementForm";
            Text = "StockMovementForm";
            Load += StockMovementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStockBalances).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboMaterial;
        private ComboBox cboWarehouse;
        private TextBox txtStockQuantity;
        private TextBox txtReferenceNo;
        private TextBox txtStockNote;
        private Button btnStockIn;
        private Button btnStockOut;
        private Button button3;
        private DataGridView dgvStockBalances;
        private Label label1;
        private Label label2;
        private Label lblWarehouse;
        private Label label3;
        private Label lblReferenceNo;
        private Label label4;
        private Button btnRefreshStock;
        private Label lblStockBalance;
    }
}