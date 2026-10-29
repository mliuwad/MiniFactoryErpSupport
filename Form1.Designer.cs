namespace FactoryErpSupport
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
            btnLoadMaterials = new Button();
            label1 = new Label();
            label2 = new Label();
            dgvMaterials = new DataGridView();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnAddMaterial = new Button();
            txtMaterialCode = new TextBox();
            txtMaterialName = new TextBox();
            txtUnit = new TextBox();
            txtReorderLevel = new TextBox();
            btnUpdateMaterial = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            btnOpenStockMovement = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMaterials).BeginInit();
            SuspendLayout();
            // 
            // btnLoadMaterials
            // 
            btnLoadMaterials.Location = new Point(424, 143);
            btnLoadMaterials.Name = "btnLoadMaterials";
            btnLoadMaterials.Size = new Size(118, 29);
            btnLoadMaterials.TabIndex = 0;
            btnLoadMaterials.Text = "Tải danh sách vật tư";
            btnLoadMaterials.UseVisualStyleBackColor = true;
            btnLoadMaterials.Click += btnLoadMaterials_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(342, 152);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 13);
            label2.Name = "label2";
            label2.Size = new Size(177, 28);
            label2.TabIndex = 2;
            label2.Text = "QUẢN LÝ VẬT TƯ";
            label2.Click += label2_Click;
            // 
            // dgvMaterials
            // 
            dgvMaterials.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaterials.Location = new Point(25, 251);
            dgvMaterials.Name = "dgvMaterials";
            dgvMaterials.RowHeadersWidth = 51;
            dgvMaterials.Size = new Size(762, 349);
            dgvMaterials.TabIndex = 3;
            dgvMaterials.CellClick += dgvMaterials_CellClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 59);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 4;
            label3.Text = "Mã vật tư";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(226, 59);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 5;
            label4.Text = "Tên vật tư";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(424, 59);
            label5.Name = "label5";
            label5.Size = new Size(91, 20);
            label5.TabIndex = 6;
            label5.Text = "Đơn vị chính";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(618, 59);
            label6.Name = "label6";
            label6.Size = new Size(155, 20);
            label6.TabIndex = 7;
            label6.Text = "Mức tồn kho tốn thiểu";
            // 
            // btnAddMaterial
            // 
            btnAddMaterial.Location = new Point(25, 143);
            btnAddMaterial.Name = "btnAddMaterial";
            btnAddMaterial.Size = new Size(127, 29);
            btnAddMaterial.TabIndex = 8;
            btnAddMaterial.Text = "Thêm vật tư";
            btnAddMaterial.UseVisualStyleBackColor = true;
            btnAddMaterial.Click += button1_Click;
            // 
            // txtMaterialCode
            // 
            txtMaterialCode.Location = new Point(24, 82);
            txtMaterialCode.Name = "txtMaterialCode";
            txtMaterialCode.Size = new Size(183, 27);
            txtMaterialCode.TabIndex = 9;
            // 
            // txtMaterialName
            // 
            txtMaterialName.Location = new Point(226, 82);
            txtMaterialName.Name = "txtMaterialName";
            txtMaterialName.Size = new Size(183, 27);
            txtMaterialName.TabIndex = 10;
            // 
            // txtUnit
            // 
            txtUnit.Location = new Point(424, 82);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(183, 27);
            txtUnit.TabIndex = 11;
            // 
            // txtReorderLevel
            // 
            txtReorderLevel.Location = new Point(618, 82);
            txtReorderLevel.Name = "txtReorderLevel";
            txtReorderLevel.Size = new Size(183, 27);
            txtReorderLevel.TabIndex = 12;
            // 
            // btnUpdateMaterial
            // 
            btnUpdateMaterial.Location = new Point(226, 143);
            btnUpdateMaterial.Name = "btnUpdateMaterial";
            btnUpdateMaterial.Size = new Size(126, 29);
            btnUpdateMaterial.TabIndex = 13;
            btnUpdateMaterial.Text = "Cập nhật vật tư";
            btnUpdateMaterial.UseVisualStyleBackColor = true;
            btnUpdateMaterial.Click += btnUpdateMaterial_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(424, 199);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 14;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(25, 199);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(384, 27);
            txtSearch.TabIndex = 15;
            // 
            // btnOpenStockMovement
            // 
            btnOpenStockMovement.Location = new Point(651, 12);
            btnOpenStockMovement.Name = "btnOpenStockMovement";
            btnOpenStockMovement.Size = new Size(150, 29);
            btnOpenStockMovement.TabIndex = 16;
            btnOpenStockMovement.Text = "Mở nhập xuất kho";
            btnOpenStockMovement.UseVisualStyleBackColor = true;
            btnOpenStockMovement.Click += btnOpenStockMovement_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(818, 672);
            Controls.Add(btnOpenStockMovement);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnUpdateMaterial);
            Controls.Add(txtReorderLevel);
            Controls.Add(txtUnit);
            Controls.Add(txtMaterialName);
            Controls.Add(txtMaterialCode);
            Controls.Add(btnAddMaterial);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dgvMaterials);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLoadMaterials);
            Name = "Form1";
            Text = "Quản lý vật tư";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMaterials).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoadMaterials;
        private Label label1;
        private Label label2;
        private DataGridView dgvMaterials;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnAddMaterial;
        private TextBox txtMaterialCode;
        private TextBox txtMaterialName;
        private TextBox txtUnit;
        private TextBox txtReorderLevel;
        private Button btnUpdateMaterial;
        private Button btnSearch;
        private TextBox txtSearch;
        private Button btnOpenStockMovement;
    }
}
