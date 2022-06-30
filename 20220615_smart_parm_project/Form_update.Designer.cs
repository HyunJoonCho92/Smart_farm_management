namespace _20220615_smart_parm_project
{
    partial class Form_update
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
            this.tb_update_mobile = new System.Windows.Forms.TextBox();
            this.tb_update_address = new System.Windows.Forms.TextBox();
            this.tb_update_birthYear = new System.Windows.Forms.TextBox();
            this.tb_update_PW = new System.Windows.Forms.TextBox();
            this.tb_update_name = new System.Windows.Forms.TextBox();
            this.tb_update_ID = new System.Windows.Forms.TextBox();
            this.bt_update_update = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_update_mobile
            // 
            this.tb_update_mobile.Location = new System.Drawing.Point(137, 296);
            this.tb_update_mobile.Name = "tb_update_mobile";
            this.tb_update_mobile.Size = new System.Drawing.Size(100, 25);
            this.tb_update_mobile.TabIndex = 27;
            // 
            // tb_update_address
            // 
            this.tb_update_address.Location = new System.Drawing.Point(137, 256);
            this.tb_update_address.Name = "tb_update_address";
            this.tb_update_address.Size = new System.Drawing.Size(100, 25);
            this.tb_update_address.TabIndex = 26;
            // 
            // tb_update_birthYear
            // 
            this.tb_update_birthYear.Location = new System.Drawing.Point(137, 216);
            this.tb_update_birthYear.Name = "tb_update_birthYear";
            this.tb_update_birthYear.Size = new System.Drawing.Size(100, 25);
            this.tb_update_birthYear.TabIndex = 25;
            // 
            // tb_update_PW
            // 
            this.tb_update_PW.Location = new System.Drawing.Point(137, 175);
            this.tb_update_PW.Name = "tb_update_PW";
            this.tb_update_PW.Size = new System.Drawing.Size(100, 25);
            this.tb_update_PW.TabIndex = 24;
            // 
            // tb_update_name
            // 
            this.tb_update_name.Location = new System.Drawing.Point(137, 135);
            this.tb_update_name.Name = "tb_update_name";
            this.tb_update_name.Size = new System.Drawing.Size(100, 25);
            this.tb_update_name.TabIndex = 23;
            // 
            // tb_update_ID
            // 
            this.tb_update_ID.Location = new System.Drawing.Point(137, 98);
            this.tb_update_ID.Name = "tb_update_ID";
            this.tb_update_ID.Size = new System.Drawing.Size(100, 25);
            this.tb_update_ID.TabIndex = 22;
            // 
            // bt_update_update
            // 
            this.bt_update_update.Location = new System.Drawing.Point(104, 346);
            this.bt_update_update.Name = "bt_update_update";
            this.bt_update_update.Size = new System.Drawing.Size(75, 23);
            this.bt_update_update.TabIndex = 21;
            this.bt_update_update.Text = "수정";
            this.bt_update_update.UseVisualStyleBackColor = true;
            this.bt_update_update.Click += new System.EventHandler(this.bt_update_update_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 299);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 20;
            this.label7.Text = "전화번호";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "주소";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "출생연도";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "PW";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "이름";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(80, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 28);
            this.label1.TabIndex = 14;
            this.label1.Text = "사원 수정";
            // 
            // Form_update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 413);
            this.Controls.Add(this.tb_update_mobile);
            this.Controls.Add(this.tb_update_address);
            this.Controls.Add(this.tb_update_birthYear);
            this.Controls.Add(this.tb_update_PW);
            this.Controls.Add(this.tb_update_name);
            this.Controls.Add(this.tb_update_ID);
            this.Controls.Add(this.bt_update_update);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_update";
            this.Text = "Form_update";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_update_FormClosed);
            this.Load += new System.EventHandler(this.Form_update_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_update_mobile;
        private System.Windows.Forms.TextBox tb_update_address;
        private System.Windows.Forms.TextBox tb_update_birthYear;
        private System.Windows.Forms.TextBox tb_update_PW;
        private System.Windows.Forms.TextBox tb_update_name;
        private System.Windows.Forms.TextBox tb_update_ID;
        private System.Windows.Forms.Button bt_update_update;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}