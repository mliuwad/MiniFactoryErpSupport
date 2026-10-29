using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace FactoryErpSupport
{
    public partial class Form1 : Form
    {
        private int selectedMaterialId = -1;
        private bool _forceClose = false;

        public Form1()
        {
            InitializeComponent();

            // Cấu hình form
            this.MinimumSize = new Size(800, 600);
            this.ClientSize = new Size(818, 672);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản lý vật tư";

            label1.Visible = false; 

            ConfigureResponsiveLayout();
            StyleGrid();
            LayoutAll();

            this.Resize += (s, e) => LayoutAll();

           
            dgvMaterials.DataBindingComplete += DgvMaterials_DataBindingComplete;
        }

       
        private void DgvMaterials_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvMaterials.Columns["MATERIAL_ID"] != null)
                dgvMaterials.Columns["MATERIAL_ID"].Visible = false;

            if (dgvMaterials.Columns["MATERIAL_CODE"] != null)
                dgvMaterials.Columns["MATERIAL_CODE"].HeaderText = "Mã vật tư";

            if (dgvMaterials.Columns["MATERIAL_NAME"] != null)
                dgvMaterials.Columns["MATERIAL_NAME"].HeaderText = "Tên vật tư";

            if (dgvMaterials.Columns["UNIT"] != null)
                dgvMaterials.Columns["UNIT"].HeaderText = "Đơn vị chính";

            if (dgvMaterials.Columns["REORDER_LEVEL"] != null)
                dgvMaterials.Columns["REORDER_LEVEL"].HeaderText = "Mức tồn kho tối thiểu";

            if (dgvMaterials.Columns["STATUS"] != null)
                dgvMaterials.Columns["STATUS"].HeaderText = "Trạng thái";
        }

        
        private void ConfigureResponsiveLayout()
        {
            label2.Text = "QUẢN LÝ VẬT TƯ";
            label3.Text = "Mã vật tư";
            label4.Text = "Tên vật tư";
            label5.Text = "Đơn vị chính";
            label6.Text = "Mức tồn kho tối thiểu";
            btnAddMaterial.Text = "Thêm vật tư";
            btnUpdateMaterial.Text = "Cập nhật vật tư";
            btnLoadMaterials.Text = "Tải danh sách vật tư";
            btnSearch.Text = "Tìm kiếm";
            btnOpenStockMovement.Text = "Mở nhập xuất kho";

          
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            Control[] manualControls = {
                label3, label4, label5, label6,
                txtMaterialCode, txtMaterialName, txtUnit, txtReorderLevel,
                btnAddMaterial, btnUpdateMaterial, btnLoadMaterials,
                txtSearch, btnSearch,
                btnOpenStockMovement,
                dgvMaterials
            };
            foreach (var c in manualControls) c.Anchor = AnchorStyles.None;
        }

        private void LayoutAll()
        {
            if (this.WindowState == FormWindowState.Minimized || this.ClientSize.Width <= 0)
                return;

            SuspendLayout();
            int W = this.ClientSize.Width;
            int H = this.ClientSize.Height;
            int leftMargin = 25;
            int rightMargin = 25;
            int gap = 16;

          
            btnOpenStockMovement.Left = W - rightMargin - btnOpenStockMovement.Width;
            btnOpenStockMovement.Top = 12;

         
            int availW = W - leftMargin - rightMargin - 3 * gap;
            int colW = Math.Max(100, availW / 4);
            int yLabel = 59;
            int yInput = 82;

            int x = leftMargin;

            label3.Location = new Point(x, yLabel);
            txtMaterialCode.Location = new Point(x, yInput);
            txtMaterialCode.Width = colW;

            x += colW + gap;
            label4.Location = new Point(x, yLabel);
            txtMaterialName.Location = new Point(x, yInput);
            txtMaterialName.Width = colW;

            x += colW + gap;
            label5.Location = new Point(x, yLabel);
            txtUnit.Location = new Point(x, yInput);
            txtUnit.Width = colW;

            x += colW + gap;
            label6.Location = new Point(x, yLabel);
            txtReorderLevel.Location = new Point(x, yInput);
            txtReorderLevel.Width = colW;

          
            btnAddMaterial.Location = new Point(25, 143);
            btnUpdateMaterial.Location = new Point(226, 143);
            btnLoadMaterials.Location = new Point(424, 143);

           
            int ySearch = 199;
            btnSearch.Left = W - rightMargin - btnSearch.Width;
            btnSearch.Top = ySearch;
            txtSearch.Left = leftMargin;
            txtSearch.Top = ySearch;
            txtSearch.Width = btnSearch.Left - gap - txtSearch.Left;

            // Lưới dữ liệu (chiếm toàn bộ phần còn lại)
            dgvMaterials.Left = leftMargin;
            dgvMaterials.Top = 251;
            dgvMaterials.Width = W - leftMargin - rightMargin;
            dgvMaterials.Height = H - dgvMaterials.Top - 20;

            ResumeLayout();
        }

       
        private void StyleGrid()
        {
            dgvMaterials.ReadOnly = true;
            dgvMaterials.AllowUserToAddRows = false;
            dgvMaterials.AllowUserToDeleteRows = false;
            dgvMaterials.AllowUserToResizeRows = false;
            dgvMaterials.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaterials.MultiSelect = false;
            dgvMaterials.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMaterials.RowHeadersVisible = false;
            dgvMaterials.BackgroundColor = Color.White;
            dgvMaterials.BorderStyle = BorderStyle.FixedSingle;
            dgvMaterials.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMaterials.GridColor = Color.FromArgb(230, 230, 230);
            dgvMaterials.RowTemplate.Height = 32;
            dgvMaterials.ColumnHeadersHeight = 36;
            dgvMaterials.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMaterials.EnableHeadersVisualStyles = false;

            dgvMaterials.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvMaterials.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvMaterials.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMaterials.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 73, 94);
            dgvMaterials.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvMaterials.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvMaterials.DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dgvMaterials.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvMaterials.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);

            dgvMaterials.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
        }

    
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_forceClose)
            {
                if (e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.TaskManagerClosing)
                {
                    base.OnFormClosing(e);
                    return;
                }

                var result = MessageBox.Show(
                    this,
                    "Bạn có chắc muốn thoát ứng dụng?",
                    "Xác nhận thoát",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
                _forceClose = true;
            }
            base.OnFormClosing(e);
        }

       
        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            bool success = OracleDb.TestConnection(out string message);
            MessageBox.Show(message, "Kết nối Oracle", MessageBoxButtons.OK,
                success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        private void LoadMaterials()
        {
            try
            {
                using (OracleConnection connection = OracleDb.GetConnection())
                {
                    connection.Open();
                    string sql = @"
                        SELECT MATERIAL_ID, MATERIAL_CODE, MATERIAL_NAME, UNIT, REORDER_LEVEL, STATUS
                        FROM MATERIALS
                        ORDER BY MATERIAL_ID";

                    using (OracleDataAdapter adapter = new OracleDataAdapter(sql, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgvMaterials.DataSource = table;
                        dgvMaterials.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                selectedMaterialId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách vật tư.\n" + ex.Message,
                    "Lỗi tải dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadMaterials_Click(object sender, EventArgs e) => LoadMaterials();
        private void button1_Click_1(object sender, EventArgs e) => LoadMaterials();

        private void AddMaterial()
        {
            string code = txtMaterialCode.Text.Trim();
            string name = txtMaterialName.Text.Trim();
            string unit = txtUnit.Text.Trim();

            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(unit))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã, tên và đơn vị vật tư.");
                return;
            }

            if (!decimal.TryParse(txtReorderLevel.Text.Trim(), out decimal reorderLevel) || reorderLevel < 0)
            {
                MessageBox.Show("Mức tồn kho tối thiểu phải là số không âm.");
                return;
            }

            try
            {
                using (OracleConnection connection = OracleDb.GetConnection())
                {
                    connection.Open();
                    using (OracleTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            int materialId;
                            string insertSql = @"
                                INSERT INTO MATERIALS (MATERIAL_CODE, MATERIAL_NAME, UNIT, REORDER_LEVEL, STATUS)
                                VALUES (:code, :name, :unit, :reorderLevel, 'ACTIVE')
                                RETURNING MATERIAL_ID INTO :materialId";

                            using (OracleCommand command = new OracleCommand(insertSql, connection))
                            {
                                command.Transaction = transaction;
                                command.BindByName = true;
                                command.Parameters.Add("code", OracleDbType.Varchar2).Value = code;
                                command.Parameters.Add("name", OracleDbType.Varchar2).Value = name;
                                command.Parameters.Add("unit", OracleDbType.Varchar2).Value = unit;
                                command.Parameters.Add("reorderLevel", OracleDbType.Decimal).Value = reorderLevel;

                                OracleParameter idParameter = command.Parameters.Add("materialId", OracleDbType.Int32);
                                idParameter.Direction = ParameterDirection.Output;
                                command.ExecuteNonQuery();
                                materialId = Convert.ToInt32(idParameter.Value.ToString());
                            }

                            string balanceSql = @"
                                INSERT INTO STOCK_BALANCES (MATERIAL_ID, WAREHOUSE_ID, QUANTITY)
                                SELECT :materialId, WAREHOUSE_ID, 0 FROM WAREHOUSES";

                            using (OracleCommand command = new OracleCommand(balanceSql, connection))
                            {
                                command.Transaction = transaction;
                                command.BindByName = true;
                                command.Parameters.Add("materialId", OracleDbType.Int32).Value = materialId;
                                command.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Thêm vật tư thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearMaterialInputs();
                LoadMaterials();
            }
            catch (OracleException ex)
            {
                if (ex.Number == 1)
                    MessageBox.Show("Mã vật tư đã tồn tại hoặc vi phạm ràng buộc duy nhất.");
                else
                    MessageBox.Show("Lỗi Oracle: " + ex.Message, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thêm vật tư: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddMaterial_Click(object sender, EventArgs e) => AddMaterial();
        private void button1_Click(object sender, EventArgs e) => AddMaterial();

        private void ClearMaterialInputs()
        {
            txtMaterialCode.Clear();
            txtMaterialName.Clear();
            txtUnit.Clear();
            txtReorderLevel.Text = "0";
            selectedMaterialId = -1;
            dgvMaterials.ClearSelection();
        }

        private void dgvMaterials_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvMaterials.Rows[e.RowIndex];
            if (row.Cells["MATERIAL_ID"].Value == null || row.Cells["MATERIAL_ID"].Value == DBNull.Value)
                return;

            selectedMaterialId = Convert.ToInt32(row.Cells["MATERIAL_ID"].Value);
            txtMaterialCode.Text = Convert.ToString(row.Cells["MATERIAL_CODE"].Value);
            txtMaterialName.Text = Convert.ToString(row.Cells["MATERIAL_NAME"].Value);
            txtUnit.Text = Convert.ToString(row.Cells["UNIT"].Value);
            txtReorderLevel.Text = Convert.ToString(row.Cells["REORDER_LEVEL"].Value);
        }

        private void btnUpdateMaterial_Click(object sender, EventArgs e)
        {
            if (selectedMaterialId == -1)
            {
                MessageBox.Show("Vui lòng chọn vật tư trên bảng trước khi cập nhật.");
                return;
            }

            string code = txtMaterialCode.Text.Trim();
            string name = txtMaterialName.Text.Trim();
            string unit = txtUnit.Text.Trim();

            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(unit))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã, tên và đơn vị vật tư.");
                return;
            }

            if (!decimal.TryParse(txtReorderLevel.Text.Trim(), out decimal reorderLevel) || reorderLevel < 0)
            {
                MessageBox.Show("Mức tồn kho tối thiểu phải là số không âm.");
                return;
            }

            try
            {
                using (OracleConnection connection = OracleDb.GetConnection())
                {
                    connection.Open();
                    string sql = @"
                        UPDATE MATERIALS
                        SET MATERIAL_CODE = :code,
                            MATERIAL_NAME = :name,
                            UNIT = :unit,
                            REORDER_LEVEL = :reorderLevel
                        WHERE MATERIAL_ID = :materialId";

                    using (OracleCommand command = new OracleCommand(sql, connection))
                    {
                        command.BindByName = true;
                        command.Parameters.Add("code", OracleDbType.Varchar2).Value = code;
                        command.Parameters.Add("name", OracleDbType.Varchar2).Value = name;
                        command.Parameters.Add("unit", OracleDbType.Varchar2).Value = unit;
                        command.Parameters.Add("reorderLevel", OracleDbType.Decimal).Value = reorderLevel;
                        command.Parameters.Add("materialId", OracleDbType.Int32).Value = selectedMaterialId;

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("Không tìm thấy vật tư cần cập nhật.");
                            selectedMaterialId = -1;
                            return;
                        }
                    }
                }

                MessageBox.Show("Cập nhật vật tư thành công!");
                ClearMaterialInputs();
                LoadMaterials();
            }
            catch (OracleException ex)
            {
                if (ex.Number == 1)
                    MessageBox.Show("Mã vật tư đã tồn tại.");
                else
                    MessageBox.Show("Lỗi Oracle: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể cập nhật: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection connection = OracleDb.GetConnection())
                {
                    connection.Open();
                    string sql = @"
                        SELECT MATERIAL_ID, MATERIAL_CODE, MATERIAL_NAME, UNIT, REORDER_LEVEL, STATUS
                        FROM MATERIALS
                        WHERE UPPER(MATERIAL_CODE) LIKE UPPER(:keyword)
                           OR UPPER(MATERIAL_NAME) LIKE UPPER(:keyword)
                        ORDER BY MATERIAL_ID";

                    using (OracleCommand command = new OracleCommand(sql, connection))
                    {
                        command.BindByName = true;
                        command.Parameters.Add("keyword", OracleDbType.Varchar2).Value = "%" + txtSearch.Text.Trim() + "%";

                        using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            dgvMaterials.DataSource = table;
                            dgvMaterials.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                }
                selectedMaterialId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tìm kiếm vật tư: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void btnOpenStockMovement_Click(object sender, EventArgs e)
        {
            this.Hide();
            try
            {
                using (StockMovementForm form = new StockMovementForm())
                {
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.ShowDialog();
                }
            }
            finally
            {
                if (!this.IsDisposed)
                {
                    this.Show();
                    this.Activate();
                    LoadMaterials();
                }
            }
        }
    }
}