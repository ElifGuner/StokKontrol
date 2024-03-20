namespace StokKontrol
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtCategory = new TextBox();
            txtProduct = new TextBox();
            cmbWarehouse = new ComboBox();
            txtAdet = new TextBox();
            txtFiyat = new TextBox();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnRemove = new Button();
            btnRetrieve = new Button();
            productBindingSource = new BindingSource(components);
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(32, 31);
            label1.Name = "label1";
            label1.Size = new Size(75, 21);
            label1.TabIndex = 0;
            label1.Text = "Kategori :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(32, 64);
            label2.Name = "label2";
            label2.Size = new Size(56, 21);
            label2.TabIndex = 1;
            label2.Text = "Ürün : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(32, 98);
            label3.Name = "label3";
            label3.Size = new Size(54, 21);
            label3.TabIndex = 2;
            label3.Text = "Depo :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(32, 130);
            label4.Name = "label4";
            label4.Size = new Size(49, 21);
            label4.TabIndex = 3;
            label4.Text = "Adet :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(32, 164);
            label5.Name = "label5";
            label5.Size = new Size(50, 21);
            label5.TabIndex = 4;
            label5.Text = "Fiyat :";
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(127, 35);
            txtCategory.Margin = new Padding(3, 2, 3, 2);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(133, 23);
            txtCategory.TabIndex = 5;
            // 
            // txtProduct
            // 
            txtProduct.Location = new Point(127, 68);
            txtProduct.Margin = new Padding(3, 2, 3, 2);
            txtProduct.Name = "txtProduct";
            txtProduct.Size = new Size(133, 23);
            txtProduct.TabIndex = 6;
            // 
            // cmbWarehouse
            // 
            cmbWarehouse.FormattingEnabled = true;
            cmbWarehouse.Location = new Point(127, 102);
            cmbWarehouse.Margin = new Padding(3, 2, 3, 2);
            cmbWarehouse.Name = "cmbWarehouse";
            cmbWarehouse.Size = new Size(133, 23);
            cmbWarehouse.TabIndex = 7;
            // 
            // txtAdet
            // 
            txtAdet.Location = new Point(127, 134);
            txtAdet.Margin = new Padding(3, 2, 3, 2);
            txtAdet.Name = "txtAdet";
            txtAdet.Size = new Size(133, 23);
            txtAdet.TabIndex = 8;
            // 
            // txtFiyat
            // 
            txtFiyat.Location = new Point(127, 166);
            txtFiyat.Margin = new Padding(3, 2, 3, 2);
            txtFiyat.Name = "txtFiyat";
            txtFiyat.Size = new Size(133, 23);
            txtFiyat.TabIndex = 9;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(37, 217);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(108, 22);
            btnInsert.TabIndex = 10;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(150, 217);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(108, 22);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(37, 243);
            btnRemove.Margin = new Padding(3, 2, 3, 2);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(108, 22);
            btnRemove.TabIndex = 12;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnRetrieve
            // 
            btnRetrieve.Location = new Point(150, 243);
            btnRetrieve.Margin = new Padding(3, 2, 3, 2);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new Size(108, 22);
            btnRetrieve.TabIndex = 13;
            btnRetrieve.Text = "Retrieve";
            btnRetrieve.UseVisualStyleBackColor = true;
            btnRetrieve.Click += btnRetrieve_Click;
            // 
            // productBindingSource
            // 
            productBindingSource.DataSource = typeof(Product);
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(37, 296);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(379, 150);
            dataGridView1.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(468, 491);
            Controls.Add(dataGridView1);
            Controls.Add(btnRetrieve);
            Controls.Add(btnRemove);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(txtFiyat);
            Controls.Add(txtAdet);
            Controls.Add(cmbWarehouse);
            Controls.Add(txtProduct);
            Controls.Add(txtCategory);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)productBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtCategory;
        private TextBox txtProduct;
        private ComboBox cmbWarehouse;
        private TextBox txtAdet;
        private TextBox txtFiyat;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnRemove;
        private Button btnRetrieve;
        private BindingSource productBindingSource;
        private DataGridView dataGridView1;
    }
}