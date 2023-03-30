using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Dispatcher
{
    public partial class DispatcherForm : Form
    {
        #region Goals
        //!!!!!!!!!!!!!!!!!!!!
        //нерпавильно введенное имя сопровождать MessageBox в ClientForm
        #endregion

        #region Variables
        static List<IPEndPoint> ClientIpEndPoint = new List<IPEndPoint>(); //список всех подключений
        static int remotePort; //удаленный порт для обработки принятых сообщений
        static int localPort = 8081; //порт к которому подключаются клиенты
        static Thread recieveThread; //переменная для создания потока принятия сообщения
        static List<List<string>> chatlist = new List<List<string>>(); //полный список всех чатов с клиентами
        static List<List<string>> nameslist = new List<List<string>>(); //список IP-адресов и ФИО всех подключенных клиентов
        UdpClient receiver; //переменная принимающая сообщения
        string TaxiPath = @"Taxi_List.txt";
        string PricePath = @"Price_List.txt";
        string ArchivePath = @"Archive.txt";
        StreamWriter Archive;
        string MinPricePath = @"Min_Price_List.txt";
        string[,] Taxiarr;
        string[] Pricearrfor1km;
        string[] MinPricearr;
        double avspeed = 30; //средняя скорость движения автомобиля в черте города
        double distance = 0;
        double traveltime = 0;
        bool checkexit = false; //проверка закрытия приложения
        #endregion

        #region Form

        public DispatcherForm() //инициализация формы, происходит при запуске
        {
            InitializeComponent();
        }

        private void DispatcherForm_Load(object sender, EventArgs e) //загрузка формы
        {
            FormLoad();

            void FormLoad() //локальный метод запуска формы
            {
                try
                {
                    recieveThread = new Thread(new ThreadStart(ReceiveMessage)); //создается поток принятия сообщений
                    recieveThread.Start(); //запуск потока принятия сообщений
                    ReadAllFiles();
                    comboBoxTaxi.SelectedItem = "Эконом";
                    comboBoxTaxi_SelectedIndexChanged(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            void ReceiveMessage() //локальный метод для принятия сообщений
            {
                bool newcl = true; //переменная для проверки новый клиент подключился или нет
                receiver = new UdpClient(localPort); //создания UdpClient для принятия сообщений
                // Объект IPEndPoint представляет удаленную точку, с которой поступили данные
                // Адрес входящего подключения
                IPEndPoint remoteEndPoint = null; //удаленный порт для принятия сообщений
                //Диспетчер принимает все сообщения от всех клиентов
                try
                {
                    while (true) //Бесконечный цикл принятия сообщений
                    {
                        // Чтение сообщения
                        byte[] data = receiver.Receive(ref remoteEndPoint); //запись сообщения в байтах
                        remotePort = remoteEndPoint.Port;
                        string message = Encoding.UTF8.GetString(data); //расшифровка сообщения

                        string[] endpointarr = message.Split(' ');
                        string endpoint = endpointarr[0];
                        string[] endportarr = endpoint.Split(':');
                        int endport = Convert.ToInt32(endportarr[1]);
                        string endipaddress = endportarr[0];
                        //bool chkname = false;

                        //определение IP-адреса клиента
                        var ClientEndPOint = new IPEndPoint(IPAddress.Parse(endipaddress), endport);
                        bool chck = ClientIpEndPoint.Contains(ClientEndPOint);

                        if (!chck) //проверка новый клиент
                        {
                            newcl = true;
                            ClientIpEndPoint.Add(ClientEndPOint);
                            MessageBox.Show("Новый клиент: " + message);

                            nameslist.Add(new List<string>());
                            nameslist[nameslist.Count - 1].Add(endpointarr[0]);
                            nameslist[nameslist.Count - 1].Add("");
                            //добавление элементов в список IP-адресов и ФИО
                            for (int i = 2; i < endpointarr.Length; i++)
                            {
                                nameslist[nameslist.Count - 1][1] += endpointarr[i] + " ";
                            }
                            nameslist[nameslist.Count - 1].Add("Не заказано"); //добавление статуса заказа клиенту
                            chatlist.Add(new List<string>());
                            chatlist[chatlist.Count - 1].Add(ClientEndPOint.ToString());
                            //добавление элемента в бокс на форме, хранящий список клиентов
                            comboBoxClients.Items.Add(nameslist[nameslist.Count - 1][1]);

                            if (string.IsNullOrEmpty(comboBoxClients.Text)) //если клиент первый
                            {
                                comboBoxClients.Text = nameslist[nameslist.Count - 1][1];
                                //comboBoxClients_SelectedIndexChanged(sender, e);
                            }
                        }
                        var nameclind = 0; //нахождение клиента отправивщего сообщения в списке клиентов
                        for (int i = 0; i < nameslist.Count; i++)
                        {
                            if (nameslist[i][0] == ClientEndPOint.ToString())
                            {
                                nameclind = i;
                                break;
                            }
                        }
                        if (endpointarr[2] == "ClientOff" && nameslist[nameclind][2] != "выполнен")
                        {
                            nameslist[nameclind][2] = "отменен";
                            if (nameslist[nameclind].Count == 4)
                            {
                                var taxiind = FindTaxi(nameclind);
                                ArchiveWrite(nameslist[nameclind][2], nameslist[nameclind][1], Taxiarr[taxiind, 0], Taxiarr[taxiind, 1] + " " + Taxiarr[taxiind, 2]);
                                TaxiFree(nameclind);
                            }
                            else ArchiveWrite(nameslist[nameclind][2], nameslist[nameclind][1], "-", "-");
                            ClientClose();
                        }
                        if (endpointarr[2] == "OrderComplete")
                        {
                            nameslist[nameclind][2] = "выполнен";
                            var taxiind = FindTaxi(nameclind);
                            ArchiveWrite(nameslist[nameclind][2], nameslist[nameclind][1], Taxiarr[taxiind, 0], Taxiarr[taxiind, 1] + " " + Taxiarr[taxiind, 2]);
                            TaxiFree(nameclind);
                            ClientClose();
                        }
                        //Добавление новых сообщений от выбранного клиента в текстбокс на форме
                        if (nameslist[nameclind][1] == comboBoxClients.Text)
                        {
                            string[] messagefinal = message.Split(' ');
                            messagefinal[0] = nameslist[nameclind][1];
                            textBoxChat.AppendText(AssemblyMessage(messagefinal));
                            textBoxChat.AppendText(Environment.NewLine);
                            textBoxStatus.Text = nameslist[nameclind][2];
                        }
                        else //система оповещения о новых сообщениях в неактивных чатах
                        {
                            if (!newcl) //только если клиент не новый
                            {
                                MessageBox.Show("У вас новое сообщение в чате: " + nameslist[nameclind][1]);
                            }
                            else newcl = false;
                        }
                        for (int i = 0; i < chatlist.Count; i++) //доваление сообщения в список чатов
                        {
                            if (chatlist[i][0] == ClientEndPOint.ToString())
                            {
                                chatlist[i].Add(message);
                            }
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
            } //локальный метод для принятия сообщений
        }

        private void buttonSend_Click(object sender, EventArgs e) //кнопка для отправки сообщения
        {
            SendMessage(textBoxSend, comboBoxClients); //Вызов метода отправки сообщения
            textBoxChat.AppendText(textBoxSend.Text);
            textBoxChat.AppendText(Environment.NewLine);
            AddMessageOnChat(textBoxSend.Text);
            textBoxSend.Clear();
        }

        private void DispatcherForm_FormClosing(object sender, FormClosingEventArgs e) //закрытие формы
        {
            FormClosedMethod(); //вызов метода закрытия формы                     
        }       

        private void comboBoxClients_SelectedIndexChanged(object sender, EventArgs e) //выбор клиента
        {
            SelectClient(); //вызов метода выбора клиента           
        }
        
        private void textBoxSend_KeyDown(object sender, KeyEventArgs e) //событие нажатие кнопки при использовании текстбокса отправки
        {
            if (e.KeyData == Keys.Enter) //если нажат Enter отправлять сообщение
            {
                buttonSend_Click(sender, e);
            }
        }

        private void comboBoxTaxi_SelectedIndexChanged(object sender, EventArgs e) //выбор типа такси
        {
            SelectTaxiType(); //вызов метода выбора типа такси
        }

        private void textBoxDistance_KeyPress(object sender, KeyPressEventArgs e) //Цифр и "," и клавиша Backspace
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e) //подтверждения расстояния
        {
            ConfirmDistance(); //вызов метода подтверждения расстояния
        }

        private void buttonSendOrder_Click(object sender, EventArgs e) //отправка заказа
        {
            SendOrderforbutton(); //вызов метода отправки заказа
        }

        private void buttonConfirmOrder_Click(object sender, EventArgs e) //метод подтверждения заказа
        {
            ConfirmOrder();
        }

        private void buttonSendPrice_Click(object sender, EventArgs e) //отправить данные о цене за километр и минимальной цене
        {
            SendPrice();
        }

        #endregion

        #region Form Methods

        private void FormClosedMethod() //Метод при закрытии формы
        {
            if (!checkexit)
            {
                TextBox exittext = new TextBox();
                exittext.Text = "DispExit Покинул чат";
                ComboBox Clients = new ComboBox();
                for (int i = 0; i < nameslist.Count; i++) //Отправка всем клиентам сообщения
                {
                    Clients.Items.Add(nameslist[i][1]); //?
                    Clients.SelectedItem = nameslist[i][1];
                    SendMessage(exittext, Clients);
                }
                checkexit = true;
                recieveThread.Abort();
                receiver.Close();
                Application.Exit();
            }
        }

        private void SelectClient() //метод выбора клиента
        {
            textBoxChat.Clear();
            var chatind = 0;
            var nameclind = 0;
            for (int i = 0; i < nameslist.Count; i++) //определение выбранного клиента в списке
            {
                if (nameslist[i][1] == comboBoxClients.Text)
                {
                    nameclind = i;
                    break;
                }
            }
            if (nameslist[nameclind][2] == "выполнен" || nameslist[nameclind][2] == "отменен")
            {
                ClientClose();
            }
            else ClientOpen();

            for (int findindex = 0; findindex < chatlist.Count; findindex++) //определение клиента в списке чатов
            {
                if (chatlist[findindex][0] == nameslist[nameclind][0])
                {
                    chatind = findindex;
                    break;
                }
            }
            textBoxStatus.Text = nameslist[nameclind][2];
            textBoxChat.AppendText(nameslist[chatind][0] + " " + nameslist[chatind][1]);
            textBoxChat.AppendText(Environment.NewLine);
            if (chatlist[chatind].Count > 1) //вывод чата с выбранным клиентов
            {
                for (int indmess = 2; indmess < chatlist[chatind].Count; indmess++)
                {
                    string[] test = chatlist[chatind][indmess].Split(' ');
                    if (test[0] == nameslist[chatind][0])
                    {
                        string[] messagefinal = chatlist[chatind][indmess].Split(' ');
                        messagefinal[0] = nameslist[chatind][1];
                        textBoxChat.AppendText(AssemblyMessage(messagefinal));
                        textBoxChat.AppendText(Environment.NewLine);
                    }
                    else
                    {
                        textBoxChat.AppendText(chatlist[chatind][indmess]);
                        textBoxChat.AppendText(Environment.NewLine);
                    }
                }
            }
        }

        private void SelectTaxiType() //метод для выбора типа такси
        {
            var taxiclass = 0;
            switch (comboBoxTaxi.Text)
            {
                case "Эконом":
                    taxiclass = 0;
                    break;
                case "Комфорт":
                    taxiclass = 1;
                    break;
                case "Бизнес":
                    taxiclass = 2;
                    break;
                default:
                    break;
            }
            textBoxPrice.Text = Pricearrfor1km[taxiclass];
            textBoxMinPrice.Text = MinPricearr[taxiclass];
            TaxiListAssembly();
        }

        private void ConfirmDistance() //метод для подтверждения расстояния
        {
            if (!string.IsNullOrEmpty(textBoxDistance.Text))
            {
                try
                {
                    var minprice = double.Parse(textBoxMinPrice.Text);
                    var pricefor1km = double.Parse(textBoxPrice.Text);
                    var avspeedmin = avspeed / 60;
                    distance = double.Parse(textBoxDistance.Text);
                    traveltime = distance / avspeedmin;
                    textBoxTravelTime.Text = traveltime.ToString();
                    if (distance > 3)
                    {
                        var lastprice = minprice + pricefor1km * (distance - 3);
                        textBoxCalculatePrice.Text = lastprice.ToString();
                    }
                    else textBoxCalculatePrice.Text = minprice.ToString();
                    buttonSendOrder.Enabled = true;
                    buttonConfirmOrder.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Проверьте ввод расстояния");
                }
            }
        }

        private void SendOrderforbutton() //метод отправки заказа
        {
            if (!string.IsNullOrEmpty(comboBoxCar.Text))
            {
                string testmessage = "";
                testmessage = "Класс: " + comboBoxTaxi.Text;
                SendOrder(testmessage);
                AddMessageOnChat(testmessage);
                ChatBoxAddMessage(testmessage);
                testmessage = "Автомобиль: " + comboBoxCar.Text;
                SendOrder(testmessage);
                AddMessageOnChat(testmessage);
                ChatBoxAddMessage(testmessage);
                testmessage = "Расстояние: " + distance.ToString() + " км";
                SendOrder(testmessage);
                AddMessageOnChat(testmessage);
                ChatBoxAddMessage(testmessage);
                testmessage = "Время в пути: " + textBoxTravelTime.Text + " мин";
                SendOrder(testmessage);
                AddMessageOnChat(testmessage);
                ChatBoxAddMessage(testmessage);
                testmessage = "Стоимость: " + textBoxCalculatePrice.Text + " руб.";
                SendOrder(testmessage);
                AddMessageOnChat(testmessage);
                ChatBoxAddMessage(testmessage);

                TextBox text = new TextBox();
                text.Text = "подтвердить заказ?";
                SendMessage(text, comboBoxClients);
                ChatBoxAddMessage(text.Text);
                AddMessageOnChat(text.Text);

                buttonSendOrder.Enabled = false;
                buttonConfirmOrder.Enabled = true;
            }
            else
            {
                MessageBox.Show("Проверьте наличие машин выбранного класса");
            }
        }

        private void ConfirmOrder()
        {
            var clind = 0;
            for (int i = 0; i < nameslist.Count; i++)
            {
                if (nameslist[i][1] == comboBoxClients.Text)
                {
                    clind = i;
                }
            }
            nameslist[clind][2] = "Выполняется";
            nameslist[clind].Add(comboBoxCar.Text);
            textBoxStatus.Text = nameslist[clind][2];
            TextBox text = new TextBox();
            text.Text = "ConfirmOrder";
            SendMessage(text, comboBoxClients);
            buttonConfirmOrder.Enabled = false;

            for (int i = 0; i < Taxiarr.GetLength(0); i++)
            {
                if (Taxiarr[i, 1] + " " + Taxiarr[i, 2] == comboBoxCar.Text)
                {
                    Taxiarr[i, 3] = "Заказано";
                    TaxiOrder(i);
                    break;
                }
            }
        }

        private void SendPrice()
        {
            if (comboBoxClients.Items.Count >= 1)
            {
                TextBox mess = new TextBox();
                mess.Text = "Класс: " + comboBoxTaxi.Text;
                SendMessage(mess, comboBoxClients);
                AddMessageOnChat(mess.Text);
                ChatBoxAddMessage(mess.Text);
                mess.Text = "цена за километр: " + textBoxPrice.Text;
                SendMessage(mess, comboBoxClients);
                AddMessageOnChat(mess.Text);
                ChatBoxAddMessage(mess.Text);
                mess.Text = "минимальная цена (включает 3 км): " + textBoxMinPrice.Text;
                SendMessage(mess, comboBoxClients);
                AddMessageOnChat(mess.Text);
                ChatBoxAddMessage(mess.Text);
            }
        }

        #endregion

        #region Utilitarian Methods

        private void AddMessageOnChat(string text) //метод для добавления сообщения в список чатов
        {
            for (int chatind = 0; chatind < chatlist.Count; chatind++) //Цикл для записи сообщения в список чатов
            {
                if (nameslist[chatind][1] == comboBoxClients.Text)
                {
                    chatlist[chatind].Add(text);
                }
            }
        }

        static void SendMessage(TextBox Sendtextbox, ComboBox Clients) //Метод отправки сообщения
        {
            UdpClient sender = new UdpClient(); //создание UdpClient для 
            try
            {
                var ipclind = 0;
                for (int i = 0; i < nameslist.Count; i++) //Ищем клиента в списке
                {
                    if (nameslist[i][1] == Clients.Text)
                    {
                        ipclind = i;
                    }
                }
                string message = Sendtextbox.Text; //считываем сообщение
                byte[] data = Encoding.UTF8.GetBytes(message); //конвертируем в байты
                // Отправляем сообщение
                string[] Endpointstring = nameslist[ipclind][0].Split(':'); //определение конечной точки
                IPEndPoint clientIP = new IPEndPoint(IPAddress.Parse(Endpointstring[0]), int.Parse(Endpointstring[1]));
                sender.Send(data, data.Length, clientIP); //отправка сообщения выбранному клиенту
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

        private string AssemblyMessage(string[] messarr) //метод для сборки сообщения из массива
        {
            string mess = "";
            for (int i = 0; i < messarr.Length; i++)
            {
                mess += messarr[i] + " ";
            }
            return mess;
        }

        private void TaxiListAssembly() //метод для вывода всех такси определенного класса
        {
            comboBoxCar.Items.Clear();
            for (int carcount = 0; carcount < Taxiarr.GetLength(0); carcount++)
            {
                if (comboBoxTaxi.Text == Taxiarr[carcount, 0] && Taxiarr[carcount, 3] == "Свободно")
                {
                    comboBoxCar.Items.Add(Taxiarr[carcount, 1] + " " + Taxiarr[carcount, 2]);
                }
            }
            comboBoxCar.SelectedItem = comboBoxCar.Items[0];
        }

        private void SendOrder(string text) //метод для отправки определенного шаблона о заказе
        {
            TextBox orderTB = new TextBox();
            orderTB.Text = "23464 " + text;
            SendMessage(orderTB, comboBoxClients);
        }

        private void ChatBoxAddMessage(string text)
        {
            textBoxChat.AppendText(text);
            textBoxChat.AppendText(Environment.NewLine);
        }

        private void ClientClose()
        {
            textBoxDistance.Enabled = false;
            buttonConfirm.Enabled = false;
            buttonConfirmOrder.Enabled = false;
            buttonSendOrder.Enabled = false;
            textBoxSend.Enabled = false;
            buttonSend.Enabled = false;
        }

        private void ClientOpen()
        {
            textBoxDistance.Enabled = true;
            buttonConfirm.Enabled = true;
            buttonConfirmOrder.Enabled = true;
            buttonSendOrder.Enabled = true;
            textBoxSend.Enabled = true;
            buttonSend.Enabled = true;
        }

        private void TaxiOrder(int taxiind)
        {
            listBoxOrderedTaxi.Items.Add(Taxiarr[taxiind, 1] + " " + Taxiarr[taxiind, 2]);
            comboBoxCar.Items.Remove(Taxiarr[taxiind, 1] + " " + Taxiarr[taxiind, 2]);
            SelectTaxiType();
        }

        private void TaxiFree(int clind)
        {
            for (int i = 0; i < Taxiarr.GetLength(0); i++)
            {
                if (Taxiarr[i, 1] + " " + Taxiarr[i, 2] == nameslist[clind][3])
                {
                    Taxiarr[i, 3] = "Свободно";
                    listBoxOrderedTaxi.Items.Remove(Taxiarr[i, 1] + " " + Taxiarr[i, 2]);
                    if (Taxiarr[i, 0] == comboBoxTaxi.Text)
                    {
                        SelectTaxiType();
                    }
                }
            }
        }

        private int FindTaxi(int nameclind)
        {
            var taxiind = 0;
            for (int i = 0; i < Taxiarr.GetLength(0); i++)
            {
                if (Taxiarr[i, 1] + " " + Taxiarr[i, 2] == nameslist[nameclind][3])
                {
                    taxiind = i;
                }
            }
            return taxiind;
        }

        #endregion

        #region Read/Write Files Methods

        private string[] ReadFile(string filename) //метод для чтения файлов
        {
            string[] filearr;
            filearr = File.ReadAllLines(filename);
            return filearr;
        }

        private string[] ReadPriceFile(string filename) //метод чтения файлов с ценой
        {
            string[] PriceTest = ReadFile(filename);
            string[] Pricearr = new string[3];
            for (int rows = 0; rows < Pricearr.Length; rows++)
            {
                string[] row = PriceTest[rows].Split(' ');
                switch (row[0])
                {
                    case "Эконом":
                        Pricearr[0] = row[1];
                        break;
                    case "Комфорт":
                        Pricearr[1] = row[1];
                        break;
                    case "Бизнес":
                        Pricearr[2] = row[1];
                        break;
                    default:
                        break;
                }
            }
            return Pricearr;
        }

        private void ReadAllFiles() //метод для чтения всех файлов и записи в список
        {
            string[] Taxitest = ReadFile(TaxiPath);
            Taxiarr = new string[Taxitest.Length, 4];
            for (int rows = 0; rows < Taxitest.Length; rows++)
            {
                string[] row = Taxitest[rows].Split(' ');
                if (row[0] == "Эконом" || row[0] == "Комфорт" || row[0] == "Бизнес")
                {
                    for (int columns = 0; columns < 4; columns++)
                    {
                        Taxiarr[rows, columns] = row[columns];
                    }
                }
            }
            Pricearrfor1km = ReadPriceFile(PricePath);
            MinPricearr = ReadPriceFile(MinPricePath);
        }

        private void ArchiveWrite(string Status, string login, string carclass, string car)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-UV6LNDF;Initial Catalog=TaxiArchive;Integrated Security=true";
                string sqlExpression = "Insert into TableArchive(Date, Orders, Login_Clients, Class, TaxiCar) " +
                    "values('" + DateTime.Now.ToString() + "', '" + Status + "', '" + login + "', '" + carclass + "', '" + car + "')";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        #endregion
    }
}
