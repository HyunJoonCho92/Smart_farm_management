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
    public partial class Form_update : Form
    {
        String ID;
        String name = "없다", PW = "", birthYear = "", address = "", mobile = "";
        public Form_update(String para)
        {
            ID = para;
            InitializeComponent();
        }

        // 전역 변수
        String connStr = "Server=127.0.0.1;Uid=root;Pwd=1234;Database=factorydb;Charset=UTF-8"; // 연결 문자열
        MySqlConnection conn; // 연결자(교량)
        MySqlCommand cmd; // 트럭
        String str; // 물건 박스(SQL)

        private void Form_update_Load(object sender, EventArgs e)
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

            name = "없다";
            PW = "";
            birthYear = "";
            address = "";
            mobile = "";
            while (reader.Read()) // 톡! 땡기기
            {
                ID = reader["ID"].ToString();
                name = reader["name"].ToString();
                PW = reader["PW"].ToString();
                birthYear = reader["birthYear"].ToString();
                address = reader["address"].ToString();
                mobile = reader["mobile"].ToString();
            }
            tb_update_ID.Text = ID;
            tb_update_name.Text = name;
            tb_update_PW.Text = PW;
            tb_update_birthYear.Text = birthYear;
            tb_update_address.Text = address;
            tb_update_mobile.Text = mobile;

            reader.Close();
        }

        private void Form_update_FormClosed(object sender, FormClosedEventArgs e)
        {
            // <4> 연결 해제
            conn.Close();
        }

        private void bt_update_update_Click(object sender, EventArgs e)
        {
            str = "UPDATE employeeTbl SET ID = '" + tb_update_ID.Text + "', name=N'" + tb_update_name.Text + "', PW=" + tb_update_PW.Text;
            str += ", birthYear = " + tb_update_birthYear.Text + ",address = N'" + tb_update_address.Text + "', mobile = '" + tb_update_mobile.Text + "' WHERE ID='" + ID + "';";

            //Console.WriteLine(str);

            cmd.CommandText = str;
            cmd.ExecuteNonQuery();

            this.DialogResult = DialogResult.OK;
        }
    }
}
