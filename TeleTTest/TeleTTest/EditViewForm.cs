using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using TeleTTest.Models;

namespace TeleTTest
{
    public partial class EditViewForm : Form
    {
        Symbol symbol;
        string sFileName;
        public List<Models.Type> typeList;
        public List<Exchange> exchangeList;
        public EditViewForm(Symbol symb, string sFileName)
        {
            InitializeComponent();

            this.sFileName = sFileName;
            exchangeList = new List<Exchange>();
            typeList = new List<Models.Type>();
            this.symbol = symb;
            FillTypeCombo();
            FillExchangeCombo();
            FillAllFields();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void FillAllFields()
        {
            tbName.Text = symbol.Name;
            tbIsin.Text = symbol.Isin;
            tbPrice.Text = symbol.Price.ToString();
            tbPriceDate.Text = symbol.PriceDate.ToString("dd.MM.yyyy");
            tbTicker.Text = symbol.Ticker;
            tbCurrencyCode.Text = symbol.CurrencyCode.ToString();
            tbDateAdded.Text = symbol.DateAdded.ToString("dd.MM.yyyy");
            Models.Type typ = symbol.Typ;
            int selectedTypIndex = typeList.FindIndex(obj => obj.TypeId == typ.TypeId);
            cbType.SelectedIndex = selectedTypIndex;
            Exchange exc = symbol.Exc;
            int selectedExcIndex = exchangeList.FindIndex(obj => obj.ExchangeId == exc.ExchangeId);
            cbExchange.SelectedIndex = selectedExcIndex;
            
        }

        public void FillTypeCombo()
        {
            using (SQLiteConnection con = new SQLiteConnection(@"Data Source=" + sFileName))
            {
                string query = "SELECT * From Type";
                try
                {
                    con.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, con);


                    DataTable dt = new DataTable();

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {


                        while (reader.Read())
                        {
                            Models.Type typ = new Models.Type
                            {
                                TypeId = Convert.ToInt32(reader["Id"].ToString()),
                                TypeName = reader["Name"].ToString()
                            };

                            typeList.Add(typ);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close();

                    cbType.DataSource = typeList;

                }

            }




        }

        private bool ValidateFields()
        {
            string pattern = @"^[0-9]{1,11}(?:\.[0-9]{1,3})?$";
            if (Regex.IsMatch(tbPrice.Text, pattern))
            {
                return true;
            }
            else { return false; }
        }
        public void FillExchangeCombo()
        {
            using (SQLiteConnection con = new SQLiteConnection(@"Data Source=" + sFileName))
            {
                string query = "SELECT * From Exchange";
                try
                {
                    con.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, con);



                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {


                        while (reader.Read())
                        {
                            Exchange exc = new Exchange
                            {
                                ExchangeId = Convert.ToInt32(reader["Id"].ToString()),
                                ExchangeName = reader["Name"].ToString()
                            };

                            exchangeList.Add(exc);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close();

                    cbExchange.DataSource = exchangeList;

                }

            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        MessageBox.Show("Please fill all text boxes before proceding!");
                        return;
                    }
                }
            }

            if(ValidateFields() != true)
            {
                MessageBox.Show("Price field accepts only numbers, please enter price in folowing format 45.45 or 45");
                return;
            }
            using (SQLiteConnection con = new SQLiteConnection(@"Data Source=" + sFileName))
            {
                try
                {
                    con.Open();
                    int id = symbol.Id;
                    string name = tbName.Text;
                    string ticker = tbTicker.Text;
                    string Isin = tbIsin.Text;
                    string CurrencyCode = tbCurrencyCode.Text;
                    float price = float.Parse(tbPrice.Text.ToString());

                    Models.Type selectedType = typeList?.FirstOrDefault(x => x.TypeName == cbType.SelectedItem.ToString());
                    int TypeId = selectedType.TypeId;

                    Exchange selectedExchange = exchangeList?.FirstOrDefault(x => x.ExchangeName == cbExchange.SelectedItem.ToString());
                    int ExcId = selectedExchange.ExchangeId;
                    string query = "UPDATE Symbol SET Name = @name ,Ticker = @ticker ,Isin = @isin ,CurrencyCode = @currencyCode ,DateAdded = @dateAdded ,Price = @price ,PriceDate = @priceDate,TypeId = @typeId ,ExchangeId = @exchangeId WHERE Id = @symbolId";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@symbolId", id);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@ticker", ticker);
                        cmd.Parameters.AddWithValue("@isin", Isin);
                        cmd.Parameters.AddWithValue("@currencyCode", CurrencyCode);
                        cmd.Parameters.AddWithValue("@dateAdded", DateTime.Now);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@priceDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@typeId", TypeId);
                        cmd.Parameters.AddWithValue("@exchangeId", ExcId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Symbol edited successfully!");
                            this.Close();
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }



            }
        }
    }
}
