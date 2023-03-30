using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientForm : Form
    {
        #region Variables
        static string remoteAddress = "127.0.0.1"; //адрес диспетчера
        static int remotePort = 8081; //порт диспетчера
        //конечная точка диспетчера
        static IPEndPoint DispatcherEndPoint = new IPEndPoint(IPAddress.Parse(remoteAddress), remotePort);
        static int localPort; //порт клиента
        static IPEndPoint ClientEndPoint; //конечная точка клиента
        UdpClient receiver; //UdpClient для принятия сообщений от диспетчера
        Thread recieveThread; //Поток принятия сообщений
        Random rnd = new Random(); //переменная для определения портов
        bool checkexit = false; //проверка закрытия формы
        #endregion

        #region Form

        public ClientForm() //инициализация формы
        {
            InitializeComponent();
        }

        private void ClentForm_Load(object sender, EventArgs e) //загрузка формы
        {
            FormLoad(); //вызов метода загрузки формы         
        }

        private void buttonPortSend_Click(object sender, EventArgs e) //Присоедение клиента к диспетчеру
        {
            SendPortandName(); //Вызов метода отправки порта

            void SendPortandName() //локальный метод отправка IP-адреса, порта и имена клиента
            {
                try
                {
                    if (!string.IsNullOrEmpty(textBoxName.Text)) //проверка на пустоту текстбокса с именем клиента
                    {
                        localPort = rnd.Next(1000, 30000); //определение локального порта
                                                           //Конечная точка клиента
                        ClientEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), localPort);
                        recieveThread = new Thread(new ThreadStart(ReceiveMessage));
                        recieveThread.Start(); //запуск потока приянтия сообщений
                        textBoxSend.ReadOnly = false;
                        textBoxName.ReadOnly = true;
                        buttonPortSend.Enabled = false;
                        buttonPortSend.Visible = false;
                        buttonSend.Enabled = true;
                        TextBox test = new TextBox();
                        test.Text = textBoxName.Text;
                        SendMessage(test); //отправка данных диспетчеру
                    }
                }
                catch (Exception)
                {
                    buttonPortSend_Click(sender, e);
                }
            }//локальный метод отправки IP-адреса, порта и имена клиента

            void ReceiveMessage() //локальный метод отправки сообщения
            {
                receiver = new UdpClient(ClientEndPoint);
                // Объект IPEndPoint представляет удаленную точку, с которой поступили данные
                // Адрес входящего подключения
                try
                {
                    while (true)
                    {
                        // Чтение сообщения
                        byte[] data = receiver.Receive(ref DispatcherEndPoint); //байтовое сообщение принятое от диспетчера
                        string message = Encoding.UTF8.GetString(data); //расшифровка сообщения
                        string[] messarr = message.Split(' ');
                        switch (messarr[0])
                        {
                            case "23464":
                                if (messarr[1] == "Класс:")
                                {
                                    textBoxOrder.Clear();
                                }
                                for (int i = 1; i < messarr.Length; i++)
                                {
                                    textBoxOrder.AppendText(messarr[i] + " ");
                                }
                                textBoxOrder.AppendText(Environment.NewLine);
                                break;
                            case "ConfirmOrder":
                                textBoxStatus.Text = "Выполняется";
                                buttonCompleteOrder.Visible = true;
                                break;
                            case "DispExit":
                                textBoxSend.ReadOnly = true;
                                buttonSend.Enabled = false;
                                buttonCompleteOrder.Visible = false;
                                textBoxChat.AppendText("Диспетчер: " + "Покинул чат");
                                textBoxChat.AppendText(Environment.NewLine);
                                textBoxChat.AppendText("Диспетчер: " + "Проблемы с сетью");
                                textBoxChat.AppendText(Environment.NewLine);
                                break;
                            default:
                                textBoxChat.AppendText("Диспетчер: " + message);
                                textBoxChat.AppendText(Environment.NewLine);
                                break;
                        }
                    }
                }
                catch (Exception)
                {
                    
                }
                finally
                {
                    receiver.Close();
                }
            } //локальный метод отправки сообщения
        }

        private void buttonSend_Click(object sender, EventArgs e)//кнопка отправки сообщения
        {
            SendMessage(textBoxSend); //Вызов метода для отправки сообщения
            textBoxChat.AppendText(textBoxSend.Text);
            textBoxChat.AppendText(Environment.NewLine);
            textBoxSend.Clear();           
        }

        private void buttonCompleteOrder_Click(object sender, EventArgs e)
        {
            CompleteOrder();
        }

        private void textBoxSend_KeyDown(object sender, KeyEventArgs e) //события нажатия кнопки при взаимодействии с текстбоксом для отправки сообщения
        {
            if (e.KeyData == Keys.Enter) //нажатие клавиши Enter
            {
                buttonSend_Click(sender, e); //отправка сообщения
            }
        }

        #endregion

        #region Form Methods

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e) //событие закрытия формы
        {
            FormClosedmethod(); //вызов метода закрытия формы                     
        }
                
        private void FormLoad() //метод загрузки формы
        {
            textBoxSend.ReadOnly = true; //текстбокс для отправки сообщения
            buttonSend.Enabled = false; //кнопка для отправки сообщения 
            buttonCompleteOrder.Visible = false;
        }

        private static void SendMessage(TextBox SendTextBox) //метод отправки сообщения
        {
            UdpClient sender = new UdpClient();
            try
            {
                string message = SendTextBox.Text; //Запись сообщения из текстбокса
                //конвертироввание в байты
                byte[] data = Encoding.UTF8.GetBytes(ClientEndPoint.ToString() + " : " + message);
                // Отправляем сообщение
                sender.Send(data, data.Length, remoteAddress, remotePort);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sender.Close();
            }
        }

        private void FormClosedmethod() //метод закрытия формы
        {
            try
            {
                if (!checkexit)
                {
                    checkexit = true;
                    recieveThread.Abort();
                    TextBox exittext = new TextBox();
                    exittext.Text = ("ClientOff Клиент покинул чат");
                    SendMessage(exittext); //отправка сообщения диспетчеру
                    receiver.Close();
                    Application.Exit();
                }
            }
            catch (Exception)
            {
                Application.Exit();
            }
        }

        private void CompleteOrder()
        {
            textBoxStatus.Text = "выполнен";
            textBoxSend.Enabled = false;
            buttonSend.Enabled = false;
            buttonCompleteOrder.Visible = false;
            TextBox mess = new TextBox();
            mess.Text = "OrderComplete заказ выполнен";
            SendMessage(mess);
        }
        
        #endregion
    }
}
