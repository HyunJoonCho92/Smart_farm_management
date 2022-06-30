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
    public partial class Form_manageMode : Form
    {
        public Form_manageMode()
        {
            InitializeComponent();
        }

        //전역 변수
        String connStr = "Server=127.0.0.1;Uid=root;Pwd=1234;Database=factorydb;CHARSET = UTF-8"; //연결 문자열
        MySqlConnection conn; // 연결자(교량)
        MySqlCommand cmd; //트럭
        String str; //짐(박스)(SQL)

        private void Form_manageMode_Load(object sender, EventArgs e)
        {
            // <1>데이터베이스 연결
            conn = new MySqlConnection(connStr);
            conn.Open();

            // <2>트럭 준비
            cmd = new MySqlCommand("", conn);
        }

        private void Form_manageMode_FormClosed(object sender, FormClosedEventArgs e)
        {
            // <4> 연결 해제
            conn.Close();
            MessageBox.Show("ByeBye");
        }

        private void bt_manageMode_update_Click(object sender, EventArgs e)
        {
            String ID;
            ID = tb_manageMode_updateID.Text.ToString();

            Form_update frm = new Form_update(ID);
            if (frm.ShowDialog() == DialogResult.OK)
                MessageBox.Show("정상");
        }

        private void bt_manageMode_delete_Click(object sender, EventArgs e)
        {
            String ID;
            ID = tb_manageMode_deleteID.Text.ToString();

            Form_delete frm = new Form_delete(ID);
            if (frm.ShowDialog() == DialogResult.OK)
                MessageBox.Show(ID + "가 정상 삭제됨");
        }

        private void bt_manageMode_select_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            // <3> 트럭에 짐 탑재하고, 다리건너 부어넣기.
            str = "SELECT ID, name, PW, birthYear, address, mobile FROM employeeTbl";
            // <3-2> 짐을 탑재하기.
            cmd.CommandText = str;
            // <3-3> 트럭이 다리건너서 부어넣고, 끈만 가져오기
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();

            listView1.View = View.Details; //엑셀 시트 모양

            //제목
            listView1.Columns.Add("ID");
            listView1.Columns.Add("이름");
            listView1.Columns.Add("비밀번호");
            listView1.Columns.Add("출생연도");
            listView1.Columns.Add("주소");
            listView1.Columns.Add("전화번호");


            String ID, name, PW, birthYear, address, mobile;
            ListViewItem item; //리스트 뷰의 한 행의 값

            while (reader.Read()) // 톡! 땡기기
            {
                ID = reader["ID"].ToString();
                name = reader["name"].ToString();
                PW = reader["PW"].ToString();
                birthYear = reader["birthYear"].ToString();
                address = reader["address"].ToString();
                mobile = reader["mobile"].ToString();

                item = new ListViewItem(ID);
                item.SubItems.Add(name);
                item.SubItems.Add(PW);
                item.SubItems.Add(birthYear);
                item.SubItems.Add(address);
                item.SubItems.Add(mobile);

                listView1.Items.Add(item);
            }
            reader.Close();
        }
    }
}
