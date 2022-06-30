using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace _20220615_smart_parm_project
{
    public partial class Form_signUp : Form
    {
        public Form_signUp()
        {
            InitializeComponent();
        }

        //전역 변수
        String connStr = "Server=127.0.0.1;Uid=root;Pwd=1234;Database=factorydb;CHARSET = UTF-8"; //연결 문자열
        MySqlConnection conn; // 연결자(교량)
        MySqlCommand cmd; //트럭
        String str; //짐(박스)(SQL)

        private void Form_signUp_Load(object sender, EventArgs e)
        {
            // <1>데이터베이스 연결
            conn = new MySqlConnection(connStr);
            conn.Open();

            // <2>트럭 준비
            cmd = new MySqlCommand("", conn);
        }

        private void Form_signUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            // <4> 연결 해제
            conn.Close();
            MessageBox.Show("ByeBye");
        }

        private void bt_signUp_signUp_Click(object sender, EventArgs e)
        {
            String ID, name, PW, birthYear, address, mobile;
            ID = tb_signUp_ID.Text.ToString();
            name = tb_signUp_name.Text.ToString();
            PW = tb_signUp_PW.Text.ToString();
            birthYear = tb_signUp_birthYear.Text.ToString();
            address = tb_signUp_address.Text.ToString();
            mobile = tb_signUp_mobile.Text.ToString();

            // <3> 트럭에 짐 탑재하고, 다리건너 부어넣기.
            //str = "UPDATE userTBL SET addr=N'미국' WHERE userID='LSG'";
            str = "INSERT INTO employeeTbl(ID, name, PW, birthYear, address, mobile) ";
            str += "VALUES('" + ID + "', N'" + name + "', '" + PW + "', " + birthYear + ", N'" + address + "', " + mobile + ");";
            // <3-2> 짐을 탑재하기.
            cmd.CommandText = str;
            // <3-3> 트럭이 다리건너서 부어넣기
            try
            {
                cmd.ExecuteNonQuery();
                tb_signUp_ID.Text = tb_signUp_name.Text = tb_signUp_PW.Text = tb_signUp_birthYear.Text = tb_signUp_address.Text = tb_signUp_mobile.Text = "";

                this.DialogResult = DialogResult.OK;
            }
            catch
            {
                MessageBox.Show("입력값이 틀렸습니다. 확인해보세요...");
            }
        }
    }
}
