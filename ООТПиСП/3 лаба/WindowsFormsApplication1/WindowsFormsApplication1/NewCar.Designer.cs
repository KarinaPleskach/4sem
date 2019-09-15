namespace WindowsFormsApplication1
{
    partial class NewCar
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
            this.ok = new System.Windows.Forms.Button();
            this.canel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.wheels = new System.Windows.Forms.NumericUpDown();
            this.fuel = new System.Windows.Forms.ListBox();
            this.brand = new System.Windows.Forms.ListBox();
            this.speed = new System.Windows.Forms.NumericUpDown();
            this.speedfsdf = new System.Windows.Forms.Label();
            this.plus = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.minus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.wheels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).BeginInit();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(44, 227);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 0;
            this.ok.Text = "ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // canel
            // 
            this.canel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.canel.Location = new System.Drawing.Point(171, 227);
            this.canel.Name = "canel";
            this.canel.Size = new System.Drawing.Size(75, 23);
            this.canel.TabIndex = 1;
            this.canel.Text = "canel";
            this.canel.UseVisualStyleBackColor = true;
            this.canel.Click += new System.EventHandler(this.canel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "number of wheels";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "car brand";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "fuel type";
            // 
            // wheels
            // 
            this.wheels.Location = new System.Drawing.Point(137, 32);
            this.wheels.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.wheels.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.wheels.Name = "wheels";
            this.wheels.Size = new System.Drawing.Size(42, 20);
            this.wheels.TabIndex = 5;
            this.wheels.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // fuel
            // 
            this.fuel.FormattingEnabled = true;
            this.fuel.Items.AddRange(new object[] {
            "petrol",
            "diesel",
            "electricity"});
            this.fuel.Location = new System.Drawing.Point(137, 58);
            this.fuel.Name = "fuel";
            this.fuel.Size = new System.Drawing.Size(74, 43);
            this.fuel.TabIndex = 6;
            // 
            // brand
            // 
            this.brand.FormattingEnabled = true;
            this.brand.Items.AddRange(new object[] {
            "peel",
            "audi",
            "nissan",
            "tesla"});
            this.brand.Location = new System.Drawing.Point(137, 107);
            this.brand.Name = "brand";
            this.brand.Size = new System.Drawing.Size(74, 56);
            this.brand.TabIndex = 7;
            // 
            // speed
            // 
            this.speed.Location = new System.Drawing.Point(137, 169);
            this.speed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(42, 20);
            this.speed.TabIndex = 9;
            this.speed.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // speedfsdf
            // 
            this.speedfsdf.AutoSize = true;
            this.speedfsdf.Location = new System.Drawing.Point(29, 164);
            this.speedfsdf.Name = "speedfsdf";
            this.speedfsdf.Size = new System.Drawing.Size(58, 13);
            this.speedfsdf.TabIndex = 8;
            this.speedfsdf.Text = "max speed";
            // 
            // plus
            // 
            this.plus.Location = new System.Drawing.Point(220, 113);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(26, 23);
            this.plus.TabIndex = 10;
            this.plus.Text = "+";
            this.plus.UseVisualStyleBackColor = true;
            this.plus.Click += new System.EventHandler(this.plus_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // minus
            // 
            this.minus.Location = new System.Drawing.Point(252, 113);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(26, 23);
            this.minus.TabIndex = 11;
            this.minus.Text = "-";
            this.minus.UseVisualStyleBackColor = true;
            this.minus.Click += new System.EventHandler(this.minus_Click);
            // 
            // NewCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.minus);
            this.Controls.Add(this.plus);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.speedfsdf);
            this.Controls.Add(this.brand);
            this.Controls.Add(this.fuel);
            this.Controls.Add(this.wheels);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.canel);
            this.Controls.Add(this.ok);
            this.Name = "NewCar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add new car";
            ((System.ComponentModel.ISupportInitialize)(this.wheels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button canel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown wheels;
        private System.Windows.Forms.ListBox fuel;
        private System.Windows.Forms.ListBox brand;
        private System.Windows.Forms.NumericUpDown speed;
        private System.Windows.Forms.Label speedfsdf;
        private System.Windows.Forms.Button plus;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button minus;
    }
}