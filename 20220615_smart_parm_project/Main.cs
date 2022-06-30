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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        //전역 변수
        String connStr = "Server=127.0.0.1;Uid=root;Pwd=1234;Database=factorydb;CHARSET = UTF-8"; //연결 문자열
        MySqlConnection conn; // 연결자(교량)
        MySqlCommand cmd; //트럭
        String str; //짐(박스)(SQL)

        private void Main_Load(object sender, EventArgs e)
        {
            // <1>데이터베이스 연결
            conn = new MySqlConnection(connStr);
            conn.Open();

            // <2>트럭 준비
            cmd = new MySqlCommand("", conn);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            // <4> 연결 해제
            conn.Close();
            MessageBox.Show("Bye");
        }

        private void bt_Main_login_Click(object sender, EventArgs e)
        {
            // <3> 트럭에 짐 탑재하고, 다리건너 부어넣기.
            //ID, PW 만 SELECT
            str = "SELECT ID, name, PW FROM employeeTbl WHERE ID='";
            str += Main_ID.Text + "';";
            // <3-2> 짐을 탑재하기.
            cmd.CommandText = str;
            // <3-3> 트럭이 다리건너서 부어넣고, 끈만 가져오기
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();

            String ID = "없다", name = "", PW = "";
            while (reader.Read()) // 톡! 땡기기
            {
                ID = reader["ID"].ToString();
                name = reader["Name"].ToString();
                PW = reader["PW"].ToString();
            }

            reader.Close();

            ///폼 만들고 주석 해제
            if (Main_PW.Text == PW)
            {
                MessageBox.Show(name + "님 환영합니다.");
                Console.WriteLine("play");
                Form_login frm = new Form_login(); //로그인 되면 공장 온습도 조절 창으로
                if (frm.ShowDialog() == DialogResult.OK)
                    MessageBox.Show("정상 입력됨");
            }
            else
            {
                MessageBox.Show("아이디나 비밀번호가 틀렸습니다.");
            }
        }

        private void bt_Main_signUp_Click(object sender, EventArgs e)
        {
            //////윈도우 폼
            Form_signUp frm = new Form_signUp(); //로그인 되면 공장 온습도 조절 창으로
            if (frm.ShowDialog() == DialogResult.OK)
                MessageBox.Show("정상 입력됨");
        }

        private void bt_Main_manageMode_Click(object sender, EventArgs e)
        {
            ////윈도우폼
            Form_manageMode frm = new Form_manageMode();
            if (frm.ShowDialog() == DialogResult.OK)
                MessageBox.Show("정상");
        }
    }
}
