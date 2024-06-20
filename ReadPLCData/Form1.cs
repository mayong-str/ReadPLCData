using HslCommunication;
using HslCommunication.LogNet;
using HslCommunication.Profinet.Melsec;
using System;
using System.Configuration;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadPLCData
{
    public partial class Form1 : Form
    {
        private static readonly string Ip = ConfigurationManager.ConnectionStrings["Ip"].ConnectionString; //PLC_Ip
        private static readonly string Port = ConfigurationManager.ConnectionStrings["Port"].ConnectionString; //PLC_Port
        private static readonly string address_D10000 = ConfigurationManager.ConnectionStrings["address_D10000"].ConnectionString; //D10000
        private static readonly string address_D10001 = ConfigurationManager.ConnectionStrings["address_D10001"].ConnectionString; //D10001
        private static readonly string address_D10002 = ConfigurationManager.ConnectionStrings["address_D10002"].ConnectionString; //D10002
        private static readonly string address_D4114 = ConfigurationManager.ConnectionStrings["address_D4114"].ConnectionString; //D4114
        private static readonly string address_D31 = ConfigurationManager.ConnectionStrings["address_D31"].ConnectionString; //D31
        private static readonly ILogNet logNet = new LogNetSingle(Application.StartupPath + "\\Logs\\log.txt"); //日志
        private static readonly string xmlPath = System.Environment.CurrentDirectory + "\\address.xml"; //PLC软元件地址

        //存放PLC地址
        private DataAddress dataAddress;

        //存放从PLC读取的值
        private DataValue dataValue;

        public Form1()
        {
            InitializeComponent();

            InitializeClass();

            DataTable dt = Utility.stam(xmlPath);
            dGV.DataSource = dt;
        }

        /// <summary>
        /// 初始化类
        /// </summary>
        public void InitializeClass()
        {
            dataAddress = new DataAddress
            {
                Work_duration_address = new string[20],
                Hold_duration_address = new string[20],
                Transport_duration_address = new string[20],
                Thd_product_id_address = new string[20],
                Device_id_address = new string[20],
                Work_duration_address_s = new string[20],
                Hold_duration_address_s = new string[20],
                Transport_duration_address_s = new string[20],
            };
            dataValue = new DataValue
            {
                Work_duration = new short[20],
                Hold_duration = new short[20],
                Transport_duration = new short[20],
                Thd_product_id = new short[20],
                Device_id = new short[20],
                Work_duration_s = new short[20],
                Hold_duration_s = new short[20],
                Transport_duration_s = new short[20],
            };
        }

        /// <summary>
        /// 拆分DataGridView
        /// </summary>
        /// <param name="dt"></param>
        public void Split(DataTable dt)
        {
            for (int i = 0; i < 20; i++)
            {
                dataAddress.Work_duration_address[i] = dt.Rows[i][0].ToString();
                dataAddress.Hold_duration_address[i] = dt.Rows[i][1].ToString();
                dataAddress.Transport_duration_address[i] = dt.Rows[i][2].ToString();
                dataAddress.Thd_product_id_address[i] = dt.Rows[i][3].ToString();
                dataAddress.Device_id_address[i] = dt.Rows[i][4].ToString();
                dataAddress.Work_duration_address_s[i] = dt.Rows[i][5].ToString();
                dataAddress.Hold_duration_address_s[i] = dt.Rows[i][6].ToString();
                dataAddress.Transport_duration_address_s[i] = dt.Rows[i][7].ToString();
            }
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private CancellationTokenSource ts;
        private ManualResetEvent ManualReset;
        private MelsecMcNet melsec_net;

        /// <summary>
        /// 开始读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Start_Click(object sender, EventArgs e)
        {
            ts = new CancellationTokenSource();
            ManualReset = new ManualResetEvent(true);
            melsec_net = new MelsecMcNet(Ip, Convert.ToInt32(Port));
            OperateResult operateResult = melsec_net.ConnectServer();
            if (operateResult.IsSuccess)
            {
                Task task = new Task(Test, ts.Token);
                task.Start();
                DialogResult dialogResult = MessageBox.Show("开始读取成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    btn_Start.Enabled = false;
                    btn_Pause.Enabled = true;
                    btn_Contiue.Enabled = true;
                    btn_Stop.Enabled = true;
                    Btn_Edit.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("开始读取失败：" + operateResult.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 开始读取
        /// </summary>
        public void Start()
        {
            ts = new CancellationTokenSource();
            ManualReset = new ManualResetEvent(true);
            melsec_net = new MelsecMcNet(Ip, Convert.ToInt32(Port));
            OperateResult operateResult = melsec_net.ConnectServer();
            if (operateResult.IsSuccess)
            {
                Task task = new Task(Test, ts.Token);
                task.Start();
                btn_Start.Enabled = false;
                btn_Pause.Enabled = true;
                btn_Contiue.Enabled = true;
                btn_Stop.Enabled = true;
                Btn_Edit.Enabled = false;
                //timer1.Enabled = false;
                logNet.WriteInfo("开始读取成功！");
            }
            else
            {
                btn_Start.Enabled = true;
                btn_Pause.Enabled = false;
                btn_Contiue.Enabled = false;
                btn_Stop.Enabled = false;
                Btn_Edit.Enabled = true;
                //timer1.Enabled = false;
                logNet.WriteInfo("开始读取失败！");
                MessageBox.Show("开始读取失败：" + operateResult.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private readonly Trigger.UpTrigger tD100000 = new Trigger.UpTrigger(); //上升沿
        private readonly Trigger.UpTrigger tD100002 = new Trigger.UpTrigger();

        private void Test()
        {
            while (!ts.Token.IsCancellationRequested)
            {
                ManualReset.WaitOne(); //阻塞当前线程

                #region //读PLC数据 2024-06-11 17:00:00

                OperateResult<byte[]> operate1 = melsec_net.ReadRandom(dataAddress.Work_duration_address);
                OperateResult<byte[]> operate2 = melsec_net.ReadRandom(dataAddress.Hold_duration_address);
                OperateResult<byte[]> operate3 = melsec_net.ReadRandom(dataAddress.Transport_duration_address);
                OperateResult<byte[]> operate4 = melsec_net.ReadRandom(dataAddress.Thd_product_id_address);
                OperateResult<byte[]> operate5 = melsec_net.ReadRandom(dataAddress.Device_id_address);
                OperateResult<byte[]> operate6 = melsec_net.ReadRandom(dataAddress.Work_duration_address_s);
                OperateResult<byte[]> operate7 = melsec_net.ReadRandom(dataAddress.Hold_duration_address_s);
                OperateResult<byte[]> operate8 = melsec_net.ReadRandom(dataAddress.Transport_duration_address_s);
                if (operate1.IsSuccess)
                {
                    for (int i = 0; i < 40; i += 2)
                    {
                        dataValue.Work_duration[i / 2] = melsec_net.ByteTransform.TransInt16(operate1.Content, i);
                        dataValue.Hold_duration[i / 2] = melsec_net.ByteTransform.TransInt16(operate2.Content, i);
                        dataValue.Transport_duration[i / 2] = melsec_net.ByteTransform.TransInt16(operate3.Content, i);
                        dataValue.Thd_product_id[i / 2] = melsec_net.ByteTransform.TransInt16(operate4.Content, i);
                        dataValue.Device_id[i / 2] = melsec_net.ByteTransform.TransInt16(operate5.Content, i);
                        dataValue.Work_duration_s[i / 2] = melsec_net.ByteTransform.TransInt16(operate6.Content, i);
                        dataValue.Hold_duration_s[i / 2] = melsec_net.ByteTransform.TransInt16(operate7.Content, i);
                        dataValue.Transport_duration_s[i / 2] = melsec_net.ByteTransform.TransInt16(operate8.Content, i);
                    }
                }
                else
                {
                    GlobalLog.WriteInfoLog("melsec_net.ReadRandom：" + "ErrorCode:" + operate1.ErrorCode + " " + ":Message：" + operate1.Message);
                }
                short thd_product_kind = melsec_net.ReadInt16(address_D31).Content;  //D31 //产品品类

                #endregion //读PLC数据 2024-06-11 17:00:00

                #region //阶段性上传数据

                Int16 D10000 = melsec_net.ReadInt16(address_D10000).Content; //读触发位 D10000
                tD100000.Now = Convert.ToBoolean(D10000);
                if (tD100000.OutPut == true)
                {
                    logNet.WriteInfo("tD100000.OutPut：" + tD100000.OutPut);

                    #region //上传数据

                    //int number = DataBaseHandle.Select(); //获取最新Id
                    //DataBaseHandle.Insert(work_duration, hold_duration, transport_duration, thd_product_id, device_id, number, thd_product_kind);

                    #endregion //上传数据

                    #region //累积工时 2024-06-11 17:00:00

                    DataBaseHandle.Insert_L(dataValue.Work_duration, dataValue.Hold_duration, dataValue.Transport_duration, dataValue.Thd_product_id, dataValue.Device_id, thd_product_kind);

                    #endregion //累积工时 2024-06-11 17:00:00

                    melsec_net.Write(address_D10001, Convert.ToInt16(1)); //置1
                }
                else
                {
                    melsec_net.Write(address_D10001, Convert.ToInt16(0));//复位
                }

                #endregion //阶段性上传数据

                #region //更新计划产量

                Int16 D10002 = melsec_net.ReadInt16(address_D10002).Content; //读触发位 D10002
                tD100002.Now = Convert.ToBoolean(D10002);
                if (tD100002.OutPut == true)
                {
                    logNet.WriteInfo("tD100002.OutPut：" + tD100002.OutPut);
                    short D4114 = melsec_net.ReadInt16(address_D4114).Content;
                    DataBaseHandle.Update(D4114);

                    melsec_net.Write(address_D10002, Convert.ToInt16(0)); //复位
                }

                #endregion //更新计划产量

                #region //实时上传 2024-06-11 17:00:00

                DataBaseHandle.Insert_S(dataValue.Work_duration_s, dataValue.Hold_duration_s, dataValue.Transport_duration_s);

                #endregion //实时上传 2024-06-11 17:00:00

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 暂停读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Pause_Click(object sender, EventArgs e)
        {
            try
            {
                ManualReset.Reset();
                MessageBox.Show("暂停读取成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("暂停读取失败：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 继续读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Contiue_Click(object sender, EventArgs e)
        {
            try
            {
                ManualReset.Set();
                MessageBox.Show("继续读取成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("继续读取失败：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 停止读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                ts.Cancel();
                melsec_net.ConnectClose();
                btn_Start.Enabled = true;
                btn_Pause.Enabled = false;
                btn_Contiue.Enabled = false;
                btn_Stop.Enabled = false;
                Btn_Edit.Enabled = true;
                MessageBox.Show("停止读取成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("停止续读取失败：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dGV.DataSource;
            dt.WriteXml(xmlPath);
            Split(dt);
            string Auto_Read = ConfigurationManager.ConnectionStrings["Auto_Read"].ConnectionString; //是否启动自动读取
            if (Auto_Read == "true")
            {
                Start();
            }
            else
            {
                btn_Start.Enabled = true;
                btn_Pause.Enabled = false;
                btn_Contiue.Enabled = false;
                btn_Stop.Enabled = false;
                Btn_Edit.Enabled = true;
            }
        }

        /// <summary>
        /// 编辑PLC软元件地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dGV.DataSource;
                dt.WriteXml(xmlPath);
                Split(dt);
                MessageBox.Show("编辑保存地址完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("编辑保存地址失败：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string Auto_Read = ConfigurationManager.ConnectionStrings["Auto_Read"].ConnectionString; //是否启动自动读取
            if (Auto_Read == "true")
            {
                Start();
            }
        }
    }
}