
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace FactoryErpSupport
{
    public partial class StockMovementForm : Form
    {
        private bool _forceClose = false;

        private TabControl tabControl;
        private DataGridView dgvTransactionHistory;

        public StockMovementForm()
        {
            InitializeComponent();

            this.MinimumSize = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhập xuất kho";

            label1.Text = "QUẢN LÝ NHẬP XUẤT KHO";
            label2.Text = "Chọn vật tư";
            lblWarehouse.Text = "Chọn kho";
            label3.Text = "Số lượng";
            lblReferenceNo.Text = "Mã chứng từ";
            label4.Text = "Ghi chú";
            btnStockIn.Text = "Nhập kho";
            btnStockOut.Text = "Xuất kho";
            btnRefreshStock.Text = "Làm mới dữ liệu";
            lblStockBalance.Text = "Thông tin kho";

            SetupTabs();

          
            StyleGrid(dgvStockBalances);
            StyleGrid(dgvTransactionHistory);

           
            Control[] manualControls =
            {
                label2, lblWarehouse, label3, lblReferenceNo, label4,
                cboMaterial, cboWarehouse, txtStockQuantity,
                txtReferenceNo, txtStockNote,
                btnStockIn, btnStockOut, btnRefreshStock,
                lblStockBalance, tabControl
            };

            foreach (Control control in manualControls)
            {
                control.Anchor = AnchorStyles.None;
            }

            LayoutAll();
            this.Resize += (s, e) => LayoutAll();

         
            dgvStockBalances.DataBindingComplete += (s, e) =>
            {
                SetHeader(dgvStockBalances, "MATERIAL_CODE", "Mã vật tư");
                SetHeader(dgvStockBalances, "MATERIAL_NAME", "Tên vật tư");
                SetHeader(dgvStockBalances, "WAREHOUSE_CODE", "Mã kho");
                SetHeader(dgvStockBalances, "WAREHOUSE_NAME", "Tên kho");
                SetHeader(dgvStockBalances, "CURRENT_STOCK", "Tồn kho");
                SetHeader(dgvStockBalances, "UNIT", "Đơn vị");
                SetHeader(dgvStockBalances, "REORDER_LEVEL", "Định mức tồn");
                SetHeader(dgvStockBalances, "STOCK_STATUS", "Trạng thái");
            };

            dgvTransactionHistory.DataBindingComplete += (s, e) =>
            {
                SetHeader(dgvTransactionHistory, "TRANSACTION_DATE", "Ngày giờ");
                SetHeader(dgvTransactionHistory, "TRANSACTION_TYPE", "Loại giao dịch");
                SetHeader(dgvTransactionHistory, "MATERIAL_CODE", "Mã vật tư");
                SetHeader(dgvTransactionHistory, "MATERIAL_NAME", "Tên vật tư");
                SetHeader(dgvTransactionHistory, "WAREHOUSE_CODE", "Mã kho");
                SetHeader(dgvTransactionHistory, "QUANTITY", "Số lượng");
                SetHeader(dgvTransactionHistory, "REFERENCE_NO", "Mã chứng từ");
                SetHeader(dgvTransactionHistory, "NOTE", "Ghi chú");
                SetHeader(dgvTransactionHistory, "CREATED_BY", "Người thực hiện");
            };

       
            btnStockIn.Click += btnStockIn_Click;
            btnStockOut.Click += btnStockOut_Click;
            btnRefreshStock.Click += btnRefreshStock_Click;
        }

        private void SetupTabs()
        {
            tabControl = new TabControl
            {
                Font = new Font("Segoe UI", 10),
                Anchor = AnchorStyles.None
            };

            TabPage tabBalances = new TabPage("Tồn kho hiện tại");
            TabPage tabHistory = new TabPage("Lịch sử nhập/xuất");

            this.Controls.Remove(dgvStockBalances);
            dgvStockBalances.Dock = DockStyle.Fill;
            tabBalances.Controls.Add(dgvStockBalances);

           
            dgvTransactionHistory = new DataGridView
            {
                Dock = DockStyle.Fill
            };

            tabHistory.Controls.Add(dgvTransactionHistory);

            tabControl.TabPages.Add(tabBalances);
            tabControl.TabPages.Add(tabHistory);

            this.Controls.Add(tabControl);
        }

       

        private void LayoutAll()
        {
            if (WindowState == FormWindowState.Minimized ||
                ClientSize.Width <= 0)
            {
                return;
            }

            SuspendLayout();

            try
            {
                int width = ClientSize.Width;
                int height = ClientSize.Height;

                int leftMargin = 30;
                int rightMargin = 30;
                int gap = 8;

              
                int availableWidth = Math.Max(
                    420,
                    width - leftMargin - rightMargin - gap * 3
                );

                int w1 = (int)(availableWidth * 0.25);
                int w2 = (int)(availableWidth * 0.25);
                int w3 = (int)(availableWidth * 0.20);
                int w4 = availableWidth - w1 - w2 - w3;

                int x1 = leftMargin;
                int x2 = x1 + w1 + gap;
                int x3 = x2 + w2 + gap;
                int x4 = x3 + w3 + gap;

               
                label2.Location = new Point(x1, 48);
                cboMaterial.Location = new Point(x1, 71);
                cboMaterial.Width = w1;

                lblWarehouse.Location = new Point(x2, 48);
                cboWarehouse.Location = new Point(x2, 71);
                cboWarehouse.Width = w2;

                label3.Location = new Point(x3, 48);
                txtStockQuantity.Location = new Point(x3, 71);
                txtStockQuantity.Width = w3;

                lblReferenceNo.Location = new Point(x4, 48);
                txtReferenceNo.Location = new Point(x4, 71);
                txtReferenceNo.Width = w4;

               
                label4.Location = new Point(x1, 124);
                txtStockNote.Location = new Point(x1, 147);
                txtStockNote.Width = w1;

                btnStockIn.Location = new Point(x2, 147);
                btnStockOut.Location = new Point(x3, 147);
                btnRefreshStock.Location = new Point(x4, 145);

                lblStockBalance.Location = new Point(leftMargin, 196);

                tabControl.Location = new Point(leftMargin, 222);
                tabControl.Size = new Size(
                    Math.Max(400, width - leftMargin - rightMargin),
                    Math.Max(150, height - 242)
                );
            }
            finally
            {
                ResumeLayout(true);
            }
        }

        private void StyleGrid(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(230, 230, 230);
            dgv.RowTemplate.Height = 32;
            dgv.ColumnHeadersHeight = 36;
            dgv.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 73, 94);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(52, 73, 94);
            dgv.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgv.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(41, 128, 185);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);

            dgv.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 248, 248);
        }

        private void SetHeader(
            DataGridView dgv,
            string columnName,
            string headerText)
        {
            if (dgv.Columns.Contains(columnName))
            {
                dgv.Columns[columnName].HeaderText = headerText;
            }
        }

     
        private void StockMovementForm_Load(object sender, EventArgs e)
        {
            LoadMaterials();
            LoadWarehouses();
            LoadStockBalances();
            LoadTransactionHistory();
        }

        private void LoadMaterials()
        {
            try
            {
                using (OracleConnection connection = OracleDb.GetConnection())
                {
                    connection.Open();

                    string sql = @"
                        SELECT MATERIAL_ID,
                               MATERIAL_CODE || ' - ' || MATERIAL_NAME
                                   AS DISPLAY_NAME
                        FROM MATERIALS
                        WHERE STATUS = 'ACTIVE'
                        ORDER BY MATERIAL_CODE";

                    using (OracleDataAdapter adapter =
                           new OracleDataAdapter(sql, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        DataRow row = table.NewRow();
                        row["MATERIAL_ID"] = 0;
                        row["DISPLAY_NAME"] = "-- Chọn vật tư --";
                        table.Rows.InsertAt(row, 0);

                        cboMaterial.DataSource = table;
                        cboMaterial.DisplayMember = "DISPLAY_NAME";
                        cboMaterial.ValueMember = "MATERIAL_ID";
                        cboMaterial.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách vật tư.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadWarehouses()
        {
            try
            {
                using (OracleConnection connection = OracleDb.GetConnection())
                {
                    connection.Open();

                    string sql = @"
                        SELECT WAREHOUSE_ID,
                               WAREHOUSE_CODE || ' - ' || WAREHOUSE_NAME
                                   AS DISPLAY_NAME
                        FROM WAREHOUSES
                        ORDER BY WAREHOUSE_CODE";

                    using (OracleDataAdapter adapter =
                           new OracleDataAdapter(sql, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        DataRow row = table.NewRow();
                        row["WAREHOUSE_ID"] = 0;
                        row["DISPLAY_NAME"] = "-- Chọn kho --";
                        table.Rows.InsertAt(row, 0);

                        cboWarehouse.DataSource = table;
                        cboWarehouse.DisplayMember = "DISPLAY_NAME";
                        cboWarehouse.ValueMember = "WAREHOUSE_ID";
                        cboWarehouse.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách kho.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



        private void LoadStockBalances()
        {
            try
            {
                using (OracleConnection connection = OracleDb.GetConnection())
                {
                    connection.Open();

                    string sql = @"
                        SELECT
                            M.MATERIAL_CODE,
                            M.MATERIAL_NAME,
                            W.WAREHOUSE_CODE,
                            W.WAREHOUSE_NAME,
                            B.QUANTITY AS CURRENT_STOCK,
                            M.UNIT,
                            M.REORDER_LEVEL,
                            CASE
                                WHEN B.QUANTITY <= M.REORDER_LEVEL
                                    THEN 'Thiếu hàng'
                                ELSE 'Bình thường'
                            END AS STOCK_STATUS
                        FROM STOCK_BALANCES B
                        JOIN MATERIALS M
                            ON M.MATERIAL_ID = B.MATERIAL_ID
                        JOIN WAREHOUSES W
                            ON W.WAREHOUSE_ID = B.WAREHOUSE_ID
                        ORDER BY M.MATERIAL_CODE, W.WAREHOUSE_CODE";

                    using (OracleDataAdapter adapter =
                           new OracleDataAdapter(sql, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgvStockBalances.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải số dư tồn kho.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

     

        private void LoadTransactionHistory()
        {
            try
            {
                using (OracleConnection connection = OracleDb.GetConnection())
                {
                    connection.Open();

                    string sql = @"
                        SELECT
                            T.TRANSACTION_DATE,
                            CASE T.TRANSACTION_TYPE
                                WHEN 'IN' THEN 'Nhập kho'
                                WHEN 'OUT' THEN 'Xuất kho'
                                ELSE T.TRANSACTION_TYPE
                            END AS TRANSACTION_TYPE,
                            M.MATERIAL_CODE,
                            M.MATERIAL_NAME,
                            W.WAREHOUSE_CODE,
                            T.QUANTITY,
                            T.REFERENCE_NO,
                            T.NOTE,
                            T.CREATED_BY
                        FROM STOCK_TRANSACTIONS T
                        JOIN MATERIALS M
                            ON M.MATERIAL_ID = T.MATERIAL_ID
                        JOIN WAREHOUSES W
                            ON W.WAREHOUSE_ID = T.WAREHOUSE_ID
                        ORDER BY T.TRANSACTION_DATE DESC";

                    using (OracleDataAdapter adapter =
                           new OracleDataAdapter(sql, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dgvTransactionHistory.DataSource = table;
                    }
                }

                if (dgvTransactionHistory.Columns.Contains(
                    "TRANSACTION_DATE"))
                {
                    dgvTransactionHistory.Columns["TRANSACTION_DATE"]
                        .DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                }

                if (dgvTransactionHistory.Columns.Contains("QUANTITY"))
                {
                    dgvTransactionHistory.Columns["QUANTITY"]
                        .DefaultCellStyle.Format = "N2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải lịch sử nhập xuất kho.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

      
        private void ProcessStockMovement(string type)
        {
            if (cboMaterial.SelectedValue == null ||
                cboWarehouse.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn vật tư và kho.");
                return;
            }

            if (!int.TryParse(
                    cboMaterial.SelectedValue.ToString(),
                    out int materialId) ||
                materialId <= 0)
            {
                MessageBox.Show("Vui lòng chọn vật tư hợp lệ.");
                return;
            }

            if (!int.TryParse(
                    cboWarehouse.SelectedValue.ToString(),
                    out int warehouseId) ||
                warehouseId <= 0)
            {
                MessageBox.Show("Vui lòng chọn kho hợp lệ.");
                return;
            }

            if (!decimal.TryParse(
                    txtStockQuantity.Text.Trim(),
                    out decimal quantity) ||
                quantity <= 0)
            {
                MessageBox.Show(
                    "Số lượng phải là số lớn hơn 0.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string referenceNo = txtReferenceNo.Text.Trim();
            string note = txtStockNote.Text.Trim();

            if (referenceNo.Length > 50)
            {
                MessageBox.Show("Mã chứng từ không được vượt quá 50 ký tự.");
                return;
            }

            if (note.Length > 500)
            {
                MessageBox.Show("Ghi chú không được vượt quá 500 ký tự.");
                return;
            }

            try
            {
                using (OracleConnection connection = OracleDb.GetConnection())
                {
                    connection.Open();

                    using (OracleTransaction transaction =
                           connection.BeginTransaction())
                    {
                        try
                        {
                            using (OracleCommand command =
                                   new OracleCommand(
                                       "SP_STOCK_MOVEMENT", connection))
                            {
                                command.Transaction = transaction;
                                command.CommandType =
                                    CommandType.StoredProcedure;
                                command.BindByName = true;

                                command.Parameters.Add(
                                    "P_MATERIAL_ID",
                                    OracleDbType.Int32).Value = materialId;

                                command.Parameters.Add(
                                    "P_WAREHOUSE_ID",
                                    OracleDbType.Int32).Value = warehouseId;

                                command.Parameters.Add(
                                    "P_TYPE",
                                    OracleDbType.Varchar2).Value = type;

                                command.Parameters.Add(
                                    "P_QUANTITY",
                                    OracleDbType.Decimal).Value = quantity;

                                command.Parameters.Add(
                                    "P_REFERENCE_NO",
                                    OracleDbType.Varchar2).Value =
                                    string.IsNullOrWhiteSpace(referenceNo)
                                        ? DBNull.Value
                                        : (object)referenceNo;

                                command.Parameters.Add(
                                    "P_NOTE",
                                    OracleDbType.Varchar2).Value =
                                    string.IsNullOrWhiteSpace(note)
                                        ? DBNull.Value
                                        : (object)note;

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

                MessageBox.Show(
                    type == "IN"
                        ? "Nhập kho thành công!"
                        : "Xuất kho thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtStockQuantity.Clear();
                txtReferenceNo.Clear();
                txtStockNote.Clear();

                LoadStockBalances();
                LoadTransactionHistory();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(
                    "Giao dịch kho thất bại.\n" + ex.Message,
                    "Lỗi Oracle",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Có lỗi xảy ra.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



        private void btnStockIn_Click(object sender, EventArgs e)
        {
            ProcessStockMovement("IN");
        }

        private void btnStockOut_Click(object sender, EventArgs e)
        {
            ProcessStockMovement("OUT");
        }

        private void btnRefreshStock_Click(object sender, EventArgs e)
        {
            LoadStockBalances();
            LoadTransactionHistory();
        }

        private void dgvStockBalances_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void lblStockBalance_Click(object sender, EventArgs e)
        {
        }

       
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_forceClose)
            {
                if (e.CloseReason == CloseReason.WindowsShutDown ||
                    e.CloseReason == CloseReason.TaskManagerClosing)
                {
                    base.OnFormClosing(e);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    this,
                    "Bạn có chắc muốn đóng form này?",
                    "Xác nhận",
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
    }
}
