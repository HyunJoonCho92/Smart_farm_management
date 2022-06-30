namespace _20220615_smart_parm_project
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_Main_manageMode = new System.Windows.Forms.Button();
            this.bt_Main_signUp = new System.Windows.Forms.Button();
            this.bt_Main_login = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Main_PW = new System.Windows.Forms.TextBox();
            this.Main_ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_Main_manageMode
            // 
            this.bt_Main_manageMode.Location = new System.Drawing.Point(239, 36);
            this.bt_Main_manageMode.Name = "bt_Main_manageMode";
            this.bt_Main_manageMode.Size = new System.Drawing.Size(111, 23);
            this.bt_Main_manageMode.TabIndex = 15;
            this.bt_Main_manageMode.Text = "관리자 모드";
            this.bt_Main_manageMode.UseVisualStyleBackColor = true;
            this.bt_Main_manageMode.Click += new System.EventHandler(this.bt_Main_manageMode_Click);
            // 
            // bt_Main_signUp
            // 
            this.bt_Main_signUp.Location = new System.Drawing.Point(178, 239);
            this.bt_Main_signUp.Name = "bt_Main_signUp";
            this.bt_Main_signUp.Size = new System.Drawing.Size(75, 23);
            this.bt_Main_signUp.TabIndex = 14;
            this.bt_Main_signUp.Text = "회원가입";
            this.bt_Main_signUp.UseVisualStyleBackColor = true;
            this.bt_Main_signUp.Click += new System.EventHandler(this.bt_Main_signUp_Click);
            // 
            // bt_Main_login
            // 
            this.bt_Main_login.Location = new System.Drawing.Point(63, 239);
            this.bt_Main_login.Name = "bt_Main_login";
            this.bt_Main_login.Size = new System.Drawing.Size(75, 23);
            this.bt_Main_login.TabIndex = 13;
            this.bt_Main_login.Text = "로그인";
            this.bt_Main_login.UseVisualStyleBackColor = true;
            this.bt_Main_login.Click += new System.EventHandler(this.bt_Main_login_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "PW";
            // 
            // Main_PW
            // 
            this.Main_PW.Location = new System.Drawing.Point(128, 177);
            this.Main_PW.Name = "Main_PW";
            this.Main_PW.Size = new System.Drawing.Size(100, 25);
            this.Main_PW.TabIndex = 11;
            // 
            // Main_ID
            // 
            this.Main_ID.Location = new System.Drawing.Point(128, 139);
            this.Main_ID.Name = "Main_ID";
            this.Main_ID.Size = new System.Drawing.Size(100, 25);
            this.Main_ID.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(34, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "공장 관리 사원 로그인";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 318);
            this.Controls.Add(this.bt_Main_manageMode);
            this.Controls.Add(this.bt_Main_signUp);
            this.Controls.Add(this.bt_Main_login);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Main_PW);
            this.Controls.Add(this.Main_ID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Main_manageMode;
        private System.Windows.Forms.Button bt_Main_signUp;
        private System.Windows.Forms.Button bt_Main_login;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Main_PW;
        private System.Windows.Forms.TextBox Main_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

