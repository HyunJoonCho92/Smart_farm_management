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
    
    public partial class Form_delete : Form
    {
        String ID;
        public Form_delete(String para)
        {
            ID = para;
            InitializeComponent();
        }

        // 전역 변수
        String connStr = "Server=127.0.0.1;Uid=root;Pwd=1234;Database=factorydb;Charset=UTF-8"; // 연결 문자열
        MySqlConnection conn; // 연결자(교량)
        MySqlCommand cmd; // 트럭
        String str; // 물건 박스(SQL)

        private void Form_delete_Load(object sender, EventArgs e)
        {
            // <1> 데이터베이스 연결
            conn = new MySqlConnection(connStr);
            conn.Open();
            // <2> 트럭 준비
            cmd = new MySqlCommand("", conn);

            // <3> 트럭에 짐 탑재하고, 다리건너 부어넣기.
            str = "SELECT ID, name, PW, birthYear, address, mobile FROM employeeTbl WHERE ID='";
            str += ID + "';";
            // <3-2> 짐을 탑재하기.
            cmd.CommandText = str;
            // <3-3> 트럭이 다리건너서 부어넣고, 끈만 가져오기
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();

            String name = "없다", PW = "", birthYear = "", address = "", mobile = "";
            while (reader.Read()) // 톡! 땡기기
            {
                ID = reader["ID"].ToString();
                name = reader["name"].ToString();
                PW = reader["PW"].ToString();
                birthYear = reader["birthYear"].ToString();
                address = reader["address"].ToString();
                mobile = reader["mobile"].ToString();
            }
            tb_delete_ID.Text = ID;
            tb_delete_name.Text = name;
            tb_delete_PW.Text = PW;
            tb_delete_birthYear.Text = birthYear;
            tb_delete_address.Text = address;
            tb_delete_mobile.Text = mobile;

            reader.Close();
        }

        private void Form_delete_FormClosed(object sender, FormClosedEventArgs e)
        {
            // <4> 연결 해제
            conn.Close();
        }

        private void bt_delete_delete_Click(object sender, EventArgs e)
        {
            str = "DELETE FROM employeeTbl WHERE ID='" + ID + "'";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();

            this.DialogResult = DialogResult.OK;
        }


    }
}
