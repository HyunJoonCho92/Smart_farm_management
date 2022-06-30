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
using System.IO.Ports;
using System.Threading;

namespace _20220615_smart_parm_project
{
    public partial class Form_login : Form
    {
        //아두이노 연결 전역 변수
        SerialPort myport; // 시리얼포트
        string in_data; // 읽을 값을 저장하는 데이터
        string Humi; // 습도 변수생성
        string Temp; // 온도 변수생성
        string soilMoisture; //물 수위

        public Form_login()
        {
            InitializeComponent();
        }

        // 전역 변수
        String connStr = "Server=127.0.0.1;Uid=root;Pwd=1234;Database=factorydb;Charset=UTF-8"; // 연결 문자열
        MySqlConnection conn; // 연결자(교량)
        MySqlCommand cmd; // 트럭
        String str; // 물건 박스(SQL)

        private void Form_login_Load(object sender, EventArgs e)
        {
            // <1> 데이터베이스 연결
            conn = new MySqlConnection(connStr);
            conn.Open();
            // <2> 트럭 준비
            cmd = new MySqlCommand("", conn);
        }

        private void Form_login_FormClosed(object sender, FormClosedEventArgs e)
        {
            // <4> 연결 해제
            conn.Close();
            MessageBox.Show("bye");
        }

        const int ARY_SIZE = 20;
        int[] tempAry = new int[ARY_SIZE];
        int[] humiAry = new int[ARY_SIZE];
        ////수위 변수 추가
        


        private void timer1_Tick(object sender, EventArgs e)
        {
            String str = "SELECT f1_time, f1_temper, f1_humi FROM farm1Tbl ORDER BY f1_time DESC LIMIT 1;";
            cmd.CommandText = str;
            MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            int temper = (short)reader["f1_temper"];
            int humi = (short)reader["f1_humi"];

            reader.Close();

            //한칸씩 땡기기
            for (int i = 0; i < tempAry.Length - 1; i++)
            {
                tempAry[i] = tempAry[i + 1];
                humiAry[i] = humiAry[i + 1];
            }
            tempAry[tempAry.Length - 1] = temper;
            humiAry[humiAry.Length - 1] = humi;

            //차트 그리기 --> 구글링을 통해서 예쁘게 그리기
            chart1.Series[0].ChartType = //온도 그래프
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

            chart1.Series[1].ChartType = //습도 그래프
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            for (int i = 0; i < tempAry.Length; i++)
            {
                chart1.Series[0].Points.AddXY(i, tempAry[i]);
                chart1.Series[1].Points.AddXY(i, humiAry[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myport = new SerialPort();
            myport.BaudRate = 9600; //통신 속도를 지정해주고
            myport.PortName = textBox1.Text; //텍스트박스에 넣어줍니다.
            myport.Parity = Parity.None; //패리티 비트
            myport.DataBits = 8; //사용되는 비트수 8비트!
            myport.StopBits = StopBits.One; //비트정지는 1
            //myport.DataReceived += myport_DataReceived; //데이터 담을 연산자 사용
            try
            {
                myport.Open();
                Delay(1000);
                //Console.WriteLine("1\n");
                myport.DataReceived += myport_DataReceived; //데이터 담을 연산자 사용
                //Console.WriteLine("2\n");
                listView1.Items.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public void Delay(int ms)
        {
            DateTime dateTimeNow = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, ms);
            DateTime dateTimeAdd = dateTimeNow.Add(duration);
            while (dateTimeAdd >= dateTimeNow)
            {
                System.Windows.Forms.Application.DoEvents();
                dateTimeNow = DateTime.Now;
            }
            return;
        }

        private void myport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            in_data = myport.ReadLine(); // 출력되는 데이터를 읽어줍니다

            Temp = in_data.Substring(0, 2); // 온도값
            Humi = in_data.Substring(2, 2); // 습도값 읽은 string데이터를 잘라서 구분합시다.

            int check = 0;
            //for (int i = 0; i < Temp.Length; i++)
            //{
            //    if (Temp[i] == ',')
            //        check = 1;
            //}
            //for (int i = 0; i < Humi.Length; i++)
            //{
            //    if (Humi[i] == ',')
            //        check = 1;
            //}
            //Console.WriteLine("4\n");
            if (check == 0)
            {
                this.Invoke(new EventHandler(displaydata_event)); // 크로스 스레드 방지

                // <3> 트럭에 짐 탑재하고, 다리건너 부어넣기.
                //str = "UPDATE userTBL SET addr=N'미국' WHERE userID='LSG'";
                str = "INSERT INTO farm1Tbl(f1_time, f1_temper, f1_humi) "; //수위 추가
                str += "VALUES('" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "', " + Temp + ", " + Humi + ");";
                // <3-2> 짐을 탑재하기.
                cmd.CommandText = str;
                // <3-3> 트럭이 다리건너서 부어넣기
                try
                {
                    cmd.ExecuteNonQuery();
                    //this.DialogResult = DialogResult.OK;
                }
                catch
                {
                    //이거 열면 에러 계속 뜸
                    //MessageBox.Show("입력값이 틀렸습니다. 확인해보세요...");
                }

                //Console.WriteLine("5\n");

                ////////////온도 > 28 OR 습도 > 30 일 때 warningTbl에 INSERT
                int TempInt = Int32.Parse(Temp);
                int HumiInt = Int32.Parse(Humi);
                //int TempInt = Convert.ToInt32(Temp);
                //int HumiInt = Convert.ToInt32(Humi);
                //int TempInt = int.Parse(Temp);
                //int HumiInt = int.Parse(Humi);

                if ((TempInt < 18 || TempInt > 25) || (HumiInt < 45 || HumiInt > 80))
                {
                    str = "INSERT INTO warningTbl(w_time, farm, temper, humi) ";
                    str += "VALUES('" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "', " + 1 + ", " + Temp + ", " + Humi + ");";
                    // <3-2> 짐을 탑재하기.
                    cmd.CommandText = str;
                    // <3-3> 트럭이 다리건너서 부어넣기

                    try
                    {
                        cmd.ExecuteNonQuery();
                        //this.DialogResult = DialogResult.OK;
                    }
                    catch
                    {
                        //MessageBox.Show("입력값이 틀렸습니다. 확인해보세요...");
                    }

                }
            }

        }

        private void displaydata_event(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem(); //리스트뷰 생성자
            lvi.Text = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            lvi.SubItems.Add(Temp); // 습도 변수에 저장 컬럼단위로 추가하기위해 subItems 사용
            lvi.SubItems.Add(Humi); // 온도 변수에 저장
            listView1.Items.Add(lvi); // 변수 저장된 데이터 추가!
            listView1.EnsureVisible(listView1.Items.Count - 1); // 새로 받아오는 데이터가 넘쳐서 자동스크롤!
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                myport.Close();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message, "Error");
            }
        }
    }
}
