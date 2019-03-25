using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Bootcamp
{
    public partial class MainForm : Form
    {
        #region variables and structers
        // Variables used for save selected file paths
        private string selectedPathToData;
        private string selectedNameOfData;

        // List stores every file path with data
        List<string> pathsToAllFiles = new List<string>();

        // List with valid data 
        List<RequestDb> data = new List<RequestDb>();

        // Variables used to read data from files
        XmlDocument xDoc = new XmlDocument();
        DataSet dataSet;
        DataTable dataTable;

        // variables that store individual data from files
        private string client_Id;
        private long request_Id;
        private string name;
        private int quantity;
        private double price;

        // variable used to write data to datagridview
        private int column;
        private int row;

        // variable used to count something in functions 
        private int counter;

        //temporary variable used in several functions
        private long temp;

        #endregion

        public MainForm()
        {
            InitializeComponent();

            ReportscomvoBoxProperties();
            DeletePathcomboBoxProperties();
            SelectedFilesrichTextBox.ReadOnly = true;
        }

        #region Functions with properties of comboboxes
        /// <summary>
        /// Function that sets parameters of comboBox 
        /// </summary>
        private void ReportscomvoBoxProperties()
        {
            ReportscomboBox.Items.Add("Ilość zamówień");
            ReportscomboBox.Items.Add("Ilość zamówień dla klienta o wskazanym identyfikatorze");
            ReportscomboBox.Items.Add("Łączna kwota zamówień");
            ReportscomboBox.Items.Add("Łączna kwota zamówień dla klienta o wskazanym identyfikatorze");
            ReportscomboBox.Items.Add("Lista wszystkich zamówień");
            ReportscomboBox.Items.Add("Lista zamówień dla klienta o wskazanym identyfikatorze");
            ReportscomboBox.Items.Add("Średnia wartość zamówienia");
            ReportscomboBox.Items.Add("Średnia wartość zamówienia dla klienta o wskazanym identyfikatorze");
            ReportscomboBox.Items.Add("Ilość zamówień pogrupowanych po nazwie");
            ReportscomboBox.Items.Add("Ilość zamówień pogrupowanych po nazwie dla klienta o wskazanym identyfikatorze");
            ReportscomboBox.Items.Add("Zamówienia w podanym przedziale cenowym");

            ReportscomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Function with properties for comboBox used to delete paths to file
        /// </summary>
        private void DeletePathcomboBoxProperties()
        {
            for (int i = 1; i <= 100; i++)
                DeletePathcomboBox.Items.Add(i);
            DeletePathcomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        #endregion

        #region Functions handling click of buttons
        /// <summary>
        /// Button responsible for open file dialog to select file with data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFilesbutton_Click(object sender, EventArgs e)
        {

            ChoiceFileOpenFileDialog.Filter = "Pliki csv(*.csv)|*.csv|Pliki xml(*.xml)|*.xml|Pliki json(*.json)|*.json";

            if (ChoiceFileOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedPathToData = ChoiceFileOpenFileDialog.FileName;
                selectedNameOfData = ChoiceFileOpenFileDialog.SafeFileName;
                if (Path.GetExtension(selectedPathToData) == ".json" ||
                    Path.GetExtension(selectedPathToData) == ".csv" ||
                    Path.GetExtension(selectedPathToData) == ".xml")
                {

                    pathsToAllFiles.Add(selectedPathToData);
                    WritePathToTextBox();
                }
                else
                {
                    MessageBox.Show("Wybrano niepoprawny format! Dozwolone są tylko pliki o rozszerzeniu .json, .csv oraz .xml");
                }
            }

        }

        /// <summary>
        /// Button creates a raport
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateReportbutton_Click(object sender, EventArgs e)
        {
            data.Clear();
            DownloadDataAndUploadToDatabase();

            if (CheckIfPathListIsNotEmpty() == true)
            {
                if (CheckIfTypeOfReportHasBeenSelected() == true)
                {
                    switch (ReportscomboBox.Text)
                    {
                        case ("Ilość zamówień"):
                            AmountOfRequest();
                            break;
                        case ("Ilość zamówień dla klienta o wskazanym identyfikatorze"):
                            if (CheckIfSelectedClientIDIsCorrect())
                                AmountOfRequestOfSelectedClientId();
                            else
                                MessageBox.Show("Wskaż identyfikator klienta.", "Brak wybranego identyfikatora", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case ("Łączna kwota zamówień"):
                            TotalPriceOfRequests();
                            break;
                        case ("Łączna kwota zamówień dla klienta o wskazanym identyfikatorze"):
                            if (CheckIfSelectedClientIDIsCorrect())
                                TotalAmountOfRequestsForSelectedClientId();
                            else
                                MessageBox.Show("Wskaż identyfikator klienta.", "Brak wybranego identyfikatora", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case ("Lista wszystkich zamówień"):
                            ListOfAllRequests();
                            break;
                        case ("Lista zamówień dla klienta o wskazanym identyfikatorze"):
                            if (CheckIfSelectedClientIDIsCorrect())
                                ListOfRequestsOfSelectedClientId();
                            else
                                MessageBox.Show("Wskaż identyfikator klienta.", "Brak wybranego identyfikatora", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case ("Średnia wartość zamówienia"):
                            AverageValueOfTheRequest();
                            break;
                        case ("Średnia wartość zamówienia dla klienta o wskazanym identyfikatorze"):
                            if (CheckIfSelectedClientIDIsCorrect())
                                AverageValueOfTheRequestsForSelectedClientId();
                            else
                                MessageBox.Show("Wskaż identyfikator klienta.", "Brak wybranego identyfikatora", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case ("Ilość zamówień pogrupowanych po nazwie"):
                            AmountOfRequestsGroupedByName();
                            break;
                        case ("Ilość zamówień pogrupowanych po nazwie dla klienta o wskazanym identyfikatorze"):
                            if (CheckIfSelectedClientIDIsCorrect())
                                AmountOfRequestsGropuedByNameForSelectedClientID();
                            else
                                MessageBox.Show("Wskaż identyfikator klienta.", "Brak wybranego identyfikatora", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case ("Zamówienia w podanym przedziale cenowym"):
                            if (CheckIfRangeTextBoxesAreNotEmpty())
                                RequestsInThePriceRange();
                            else
                                MessageBox.Show("Uzupełnij przedział cenowy.", "Pusty przedział cenowy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Wybierz jaki raport chcesz sporzadzić.", "Brak wybranego raportu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Aby sporządzić raport dodaj pliki o rozszerzeniu xml/jsosn/csv!", "Brak wybranego pliku", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Function responsible for removing paths from textbox and list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeletePathbutton_Click(object sender, EventArgs e)
        {
            if (DeletePathcomboBox.Text != "" && int.Parse(DeletePathcomboBox.Text) <= pathsToAllFiles.Count())
            {
                pathsToAllFiles.RemoveAt(int.Parse(DeletePathcomboBox.Text) - 1);
                WritePathToTextBox();
            }
            else
            {
                MessageBox.Show("Wybierz numer pliku do usunięcia");
            }
        }
        #endregion

        #region Single function that carring about correct write path to the textBox
        private void WritePathToTextBox()
        {
            SelectedFilesrichTextBox.Clear();
            counter = 1;
            foreach (var path in pathsToAllFiles)
            {
                SelectedFilesrichTextBox.Text += "(" + counter + ") " + path + "\n";
                counter++;
            }
        }
        #endregion

        #region functions downloading data from files .csv / .xml / .json

        /// <summary>
        /// Function calls specific functions to download data from files
        /// </summary>
        private void DownloadDataAndUploadToDatabase()
        {
            foreach (var path in pathsToAllFiles)
            {
                if (path.Substring(path.Length - 4) == ".xml")
                {
                    DownloadDataFromXML(path);
                }
                if (path.Substring(path.Length - 4) == ".csv")
                {
                    DownloadDataFromCSV(path);
                }
                if (path.Substring(path.Length - 4) == "json")
                {
                    DownloadDataFromJSON(path);
                }
            }
        }

        /// <summary>
        /// Function gets data from XML file and create object of RequestDb and add it to list 
        /// </summary>
        /// <param name="path"></param>
        private void DownloadDataFromXML(string path)
        {
            try
            {
                path = path.Replace("\\x", "/x");
                xDoc.Load(path);

                foreach (XmlNode node in xDoc.SelectNodes("requests/request"))
                {
                    CheckThecorrectnessOfTheData("XML", node.SelectSingleNode("clientId").InnerText, node.SelectSingleNode("requestId").InnerText,
                        node.SelectSingleNode("name").InnerText.ToString(), node.SelectSingleNode("quantity").InnerText, node.SelectSingleNode("price").InnerText);
                }

            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("Nie znaleziono pliku o rozszerzeniu xml!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Function gets data from CSV file and create object of RequestDb and add it to list 
        /// </summary>
        /// <param name="path"></param>
        private void DownloadDataFromCSV(string path)
        {
            StreamReader streamReader = new StreamReader(path);

            string strline = "";
            string[] singleValues = null;
            counter = 0;
            while (!streamReader.EndOfStream)
            {
                strline = streamReader.ReadLine();

                // to skip first line with headers
                if (counter > 0)
                {
                    if (Regex.Matches(strline, ",").Count == 4)
                    {
                        singleValues = strline.Split(',');
                        CheckThecorrectnessOfTheData("CSV", singleValues[0].ToString(), singleValues[1].ToString(), singleValues[2].ToString(), singleValues[3].ToString(), singleValues[4].ToString());
                    }
                    else
                        MessageBox.Show("W jednej z lini W pliku o rozszerzeniu CSV istnieje nieodpowiednia liczba przecinków co uniemożliwa poprawny odczyt danych", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }

                counter++;
            }
            streamReader.Close();
        }

        /// <summary>
        /// Function checks if data in file are correct
        /// </summary>
        /// <param name="extensionArg"></param>
        /// <param name="clientIDArg"></param>
        /// <param name="requestIDArg"></param>
        /// <param name="nameArg"></param>
        /// <param name="quanityArg"></param>
        /// <param name="priceArg"></param>
        private void CheckThecorrectnessOfTheData(string extensionArg, string clientIDArg, string requestIDArg, string nameArg, string quanityArg, string priceArg)
        {
            if (long.TryParse(requestIDArg, out request_Id) && int.TryParse(quanityArg, out quantity) &&
                    double.TryParse(priceArg, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out price))
            {

                if (clientIDArg.Contains(" ") == false && clientIDArg.Length > 0 && clientIDArg.Length <= 6 && nameArg.Length <= 255 && nameArg.Length > 0)
                {
                    RequestDb request = new RequestDb(clientIDArg, request_Id, nameArg, quantity, price);
                    data.Add(request);
                }
                else
                {
                    MessageBox.Show("W pliku o rozszerzeniu " + extensionArg + " istnieje niepoprawnie zapisana dana - clientId/name", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("W pliku o rozszerzeniu " + extensionArg + " istnieje niepoprawnie zapisana dana - requestId/quantity/price", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


        /// <summary>
        /// Function gets data from JSON file and create object of RequestDb and add it to list 
        /// </summary>
        /// <param name="path"></param>
        private void DownloadDataFromJSON(string path)
        {
            string strJson;
            strJson = File.ReadAllText(path);

            try
            {
                dataSet = JsonConvert.DeserializeObject<DataSet>(strJson);

                dataTable = dataSet.Tables["requests"];

                foreach (DataRow row in dataTable.Rows)
                {
                    CheckThecorrectnessOfTheData("JSON", row["clientId"].ToString(), row["requestId"].ToString(), row["name"].ToString(), row["quantity"].ToString(), row["price"].ToString());
                }
            }
            catch
            {
                MessageBox.Show("Błąd w pliku!", "Błąd", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region Functions that validating

        /// <summary>
        /// Function checks if pathList is not empty
        /// </summary>
        /// <returns></returns>
        private bool CheckIfPathListIsNotEmpty()
        {
            if (pathsToAllFiles.Count == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Function checks if rangeTextBoxes are not empty
        /// </summary>
        /// <returns></returns>
        private bool CheckIfRangeTextBoxesAreNotEmpty()
        {
            if (RangeUpPricetextBox.Text == "" && RangeDownPricetextBox.Text == "")
                return false;
            else
                return true;
        }
        /// <summary>
        /// Function checks if Type of Report Has been selected
        /// </summary>
        /// <returns></returns>
        private bool CheckIfTypeOfReportHasBeenSelected()
        {
            if (ReportscomboBox.Text == "")
                return false;
            else
                return true;
        }


        /// <summary>
        /// Function checks if Selected by user ClientID is correct 
        /// </summary>
        /// <returns></returns>
        private bool CheckIfSelectedClientIDIsCorrect()
        {
            if (SelectIdtextBox.Text.Contains(" ") || SelectIdtextBox.Text.Length > 6 || SelectIdtextBox.Text == "")
                return false;
            else
                return true;
        }

        /// <summary>
        /// Function sets parameters for textBoxes
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="e"></param>
        private void RangeTextBoxesParameters(TextBox textbox, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',' && textbox.Text.Contains(",") || e.KeyChar != ',')
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        /// <summary>
        /// Function responsibles for typing Range (lower limit) in textBox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RangeDownPricetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            RangeTextBoxesParameters(RangeDownPricetextBox, e);
        }
        /// <summary>
        /// Function responsibles for typing Range (upper limit) in textBox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RangeUpPricetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            RangeTextBoxesParameters(RangeUpPricetextBox, e);
        }

        /// <summary>
        /// Function responsibles for typing CientID in textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectIdtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' || SelectIdtextBox.Text.Length >= 6)
                e.Handled = !char.IsControl(e.KeyChar);
        }
        #endregion

        #region Functions carring about dataGridView
        /// <summary>
        /// Function clear the DataGridView
        /// </summary>
        private void ClearReportDataGridView()
        {
            ReportdataGridView.DataSource = null;
            ReportdataGridView.Refresh();
            ReportdataGridView.Columns.Clear();
        }

        /// <summary>
        /// Function adds columns to ReportDataGridView
        /// </summary>
        /// <param name="column"></param>
        private void AddColumnsToReportDataGridView(params string[] column)
        {
            counter = 0;
            foreach (var col in column)
            {
                ReportdataGridView.Columns.Add("col" + counter, col);
            }
            //columns stretching
            foreach (DataGridViewColumn col in ReportdataGridView.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }
        #endregion

        #region Functions that create raports
        /// <summary>
        /// Function couns total amount of all requests and displays it in datagridview
        /// </summary>
        /// <returns></returns>
        private void AmountOfRequest()
        {
            ClearReportDataGridView();
            AddColumnsToReportDataGridView("Total Amount Of All Requests");
            ReportdataGridView[0, 0].Value = data.Select(x => x.Request_Id).Distinct().Count();
        }

        /// <summary>
        /// Function couns amount of requests for selected client_id and displays it in datagridview
        /// </summary>
        /// <returns></returns>
        private void AmountOfRequestOfSelectedClientId()
        {
            ClearReportDataGridView();
            AddColumnsToReportDataGridView("Client_Id", "Amount Of Requests");

            ReportdataGridView[0, 0].Value = SelectIdtextBox.Text;
            ReportdataGridView[1, 0].Value = data.Where(c => c.Client_Id == SelectIdtextBox.Text).GroupBy(x => x.Request_Id).Count();
        }

        /// <summary>
        /// Function counts the sum of prices and displays it in datagridview
        /// </summary>
        /// <returns></returns>
        private void TotalPriceOfRequests()
        {
            ClearReportDataGridView();
            AddColumnsToReportDataGridView("Total Price Of Requests");

            ReportdataGridView[0, 0].Value = data.Sum(s => s.Price * s.Quantity);
        }

        /// <summary>
        /// Function counts the sum of requests for selected clientID and displays it in datagridview
        /// </summary>
        private void TotalAmountOfRequestsForSelectedClientId()
        {
            ClearReportDataGridView();
            AddColumnsToReportDataGridView("Client_Id", "Total Amount Of Requests For Selected ClientID");
            ReportdataGridView[0, 0].Value = SelectIdtextBox.Text;
            ReportdataGridView[1, 0].Value = data.Where(i => i.Client_Id == SelectIdtextBox.Text).Sum(s => s.Price * s.Quantity);
        }

        /// <summary>
        /// Function displays in datagridview a list of Requests 
        /// </summary>
        private void ListOfAllRequests()
        {
            ClearReportDataGridView();
            AddColumnsToReportDataGridView("Client_Id", "Request_Id", "Name", "Quantity", "Price");

            column = 0;
            row = 0;
            foreach (var request in data)
            {
                ReportdataGridView.Rows.Add();
                ReportdataGridView[column, row].Value = request.Client_Id;
                ReportdataGridView[column + 1, row].Value = request.Request_Id;
                ReportdataGridView[column + 2, row].Value = request.Name;
                ReportdataGridView[column + 3, row].Value = request.Quantity;
                ReportdataGridView[column + 4, row].Value = request.Price;
                row++;
            }

        }

        /// <summary>
        /// Function displays a list of requests for selected ClientId in datagridview
        /// </summary>
        private void ListOfRequestsOfSelectedClientId()
        {
            ClearReportDataGridView();
            AddColumnsToReportDataGridView("Client_Id", "Request_Id", "Name", "Quantity", "Price");

            column = 0;
            row = 0;
            foreach (var request in data)
            {
                if (request.Client_Id == SelectIdtextBox.Text)
                {
                    ReportdataGridView.Rows.Add();
                    ReportdataGridView[column, row].Value = request.Client_Id;
                    ReportdataGridView[column + 1, row].Value = request.Request_Id;
                    ReportdataGridView[column + 2, row].Value = request.Name;
                    ReportdataGridView[column + 3, row].Value = request.Quantity;
                    ReportdataGridView[column + 4, row].Value = request.Price;
                    row++;
                }
            }

        }

        /// <summary>
        /// Function counts average value of the request and display it in datagridview
        /// </summary>
        private void AverageValueOfTheRequest()
        {
            ClearReportDataGridView();
            AddColumnsToReportDataGridView("Average Value Of the Request");
            ReportdataGridView[0, 0].Value = double.Parse(data.Select(p => p.Price * p.Quantity).Sum().ToString())
                                           / double.Parse(data.Select(x => x.Request_Id).Distinct().Count().ToString());
        }

        /// <summary>
        /// Function counts average value of the request for selected clientId and display it in datagridview
        /// </summary>
        private void AverageValueOfTheRequestsForSelectedClientId()
        {
            ClearReportDataGridView();
            AddColumnsToReportDataGridView("ClientID", "Average Value Of the Request");
            ReportdataGridView[0, 0].Value = SelectIdtextBox.Text;
            ReportdataGridView[1, 0].Value = double.Parse(data.Where(i => i.Client_Id == SelectIdtextBox.Text).Select(p => p.Price * p.Quantity).Sum().ToString())
                                           / double.Parse(data.Select(x => x.Request_Id).Distinct().Count().ToString());
        }

        /// <summary>
        /// Function counts amount of requestes grouped by name and display it in datagridview
        /// </summary>
        private void AmountOfRequestsGroupedByName()
        {
            ClearReportDataGridView();
            AddColumnsToReportDataGridView("Name", "Amount");

            temp = 0;

            column = 0;
            row = 0;
            IEnumerable<IGrouping<string, RequestDb>> groupedData = data.GroupBy(x => x.Name);
            var groupetData = data.GroupBy(x => x.Request_Id);
            foreach (IGrouping<string, RequestDb> request in groupedData)
            {
                ReportdataGridView.Rows.Add();
                ReportdataGridView[column, row].Value = request.Key;

                counter = 1;
                foreach (RequestDb request2 in request)
                {
                    if (counter == 1)
                    {
                        temp = request2.Request_Id;
                        ReportdataGridView[column + 1, row].Value = 1;
                        counter++;
                    }
                    else if (temp != request2.Request_Id)
                    {
                        ReportdataGridView[column + 1, row].Value = counter;
                        counter++;
                    }
                }
                row++;
            }

        }

        /// <summary>
        /// Function counts amount of requestes grouped by name for selected clienID and display it in datagridview
        /// </summary>
        private void AmountOfRequestsGropuedByNameForSelectedClientID()
        {
            ClearReportDataGridView();
            AddColumnsToReportDataGridView("Selected ClientID", "Name", "Amount");

            data = data.Where(i => i.Client_Id == SelectIdtextBox.Text).ToList();
            IEnumerable<IGrouping<string, RequestDb>> groupedData = data.GroupBy(x => x.Name);

            row = 0;
            column = 0;
            foreach (IGrouping<string, RequestDb> request in groupedData)
            {
                ReportdataGridView.Rows.Add();
                ReportdataGridView[column, row].Value = SelectIdtextBox.Text;
                ReportdataGridView[column + 1, row].Value = request.Key;

                counter = 1;
                temp = 0;
                foreach (RequestDb request2 in request)
                {
                    if (counter == 1)
                    {
                        temp = request2.Request_Id;
                        ReportdataGridView[column + 2, row].Value = 1;
                        counter++;
                    }
                    else if (temp != request2.Request_Id)
                    {
                        ReportdataGridView[column + 2, row].Value = counter;
                        counter++;
                    }
                }
                row++;
            }
        }

        /// <summary>
        /// Function select requests in the selected by user price range
        /// </summary>
        private void RequestsInThePriceRange()
        {
            ClearReportDataGridView();
            AddColumnsToReportDataGridView("Request_Id", "Price");

            var groupedData = data.GroupBy(x => x.Request_Id);

            row = 0;
            column = 0;
            foreach (var request in groupedData)
            {
                ReportdataGridView.Rows.Add();
                ReportdataGridView[column + 0, row].Value = request.Key;

                ReportdataGridView[column + 1, row].Value = data.Where(i => i.Request_Id == request.Key).Sum(s => s.Price * s.Quantity);

                counter = 1;
                temp = 0;
                row++;
            }

        }


        #endregion

    }

}