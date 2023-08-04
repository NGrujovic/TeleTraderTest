using System;
using System.Data;
using System.Data.SQLite;
using TeleTTest.Models;

namespace TeleTTest
{
    public partial class Form1 : Form
    {
        public List<Symbol> symbolList;
        public List<Models.Type> typeList;
        public List<Exchange> exchangeList;
        public string sFileName;
        public Form1()
        {
            InitializeComponent();
            symbolList = new List<Symbol>();
            typeList = new List<Models.Type>();
            typeList.Add(new Models.Type { TypeName = "All"});
            exchangeList = new List<Exchange>();
            exchangeList.Add(new Exchange { ExchangeName = "All"});

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Ticker", "Ticker");
            dataGridView1.Columns.Add("Price", "Price");
            dataGridView1.Columns.Add("ExchangeName", "ExchangeName");
            dataGridView1.Columns.Add("TypeName", "TypeName");

            dataGridView1.Columns["Name"].DataPropertyName = "Name";
            dataGridView1.Columns["Ticker"].DataPropertyName = "Ticker";
            dataGridView1.Columns["Price"].DataPropertyName = "Price";
            dataGridView1.Columns["ExchangeName"].DataPropertyName = "Exc";

            dataGridView1.Columns["TypeName"].DataPropertyName = "Typ";
        }

        public void FillSymbolList(string fileName)
        {
            symbolList.Clear();
            dataGridView1.Refresh();
            using (SQLiteConnection con = new SQLiteConnection(@"Data Source=" + fileName))
            {
                string query = "SELECT *, Exchange.Name AS ExchangeName, Type.Name as TypeName From Symbol INNER JOIN Exchange ON Symbol.ExchangeId = Exchange.Id " +
                           "INNER JOIN Type ON Symbol.TypeId = Type.Id ORDER BY ExchangeName ASC";



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
                                TypeId = Convert.ToInt32(reader["TypeId"].ToString()),
                                TypeName = reader["TypeName"].ToString()
                            };
                            Exchange exc = new Exchange
                            {
                                ExchangeId = Convert.ToInt32(reader["ExchangeId"].ToString()),
                                ExchangeName = reader["ExchangeName"].ToString()
                            };
                            Symbol obj = new Symbol
                            {
                                Id = Convert.ToInt32(reader["Id"].ToString()),
                                Name = reader["Name"].ToString(),
                                Ticker = reader["Ticker"].ToString(),
                                Isin = reader["Isin"].ToString(),
                                CurrencyCode = reader["CurrencyCode"].ToString(),
                                DateAdded = Convert.ToDateTime(reader["DateAdded"].ToString()),
                                Price = float.Parse(reader["Price"].ToString()),
                                PriceDate = Convert.ToDateTime(reader["PriceDate"].ToString()),
                                Typ = typ,
                                Exc = exc


                            };

                            symbolList.Add(obj);


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
                    
                    
                    gbFilter.Enabled = true;
                    dataGridView1.DataSource = symbolList;
                    btnAddSymbol.Enabled = true;
                    btnDeleteSymbol.Enabled = true;
                    btnEditSymbol.Enabled = true;
                }

            }
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

                    cmbTypeFilter.DataSource = typeList;

                }

            }

              

            
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

                    cmbExchangeFilter.DataSource = exchangeList;

                }

            }

            
        }

        public void ConfirmFilter()
        {
            string TypeFilter = cmbTypeFilter.SelectedItem.ToString();
            string ExchangeFilter = cmbExchangeFilter.SelectedItem.ToString();
            if (ExchangeFilter == "All" && TypeFilter == "All")
            {
                
                FillSymbolList(sFileName);
            }else if(ExchangeFilter != "All" || TypeFilter != "All")
            {
                
                if (ExchangeFilter != "All" && TypeFilter != "All")
                {
                    dataGridView1.DataSource = symbolList.Where(x => x.Typ.TypeName == TypeFilter && x.Exc.ExchangeName == ExchangeFilter).ToList();

                }else if(ExchangeFilter != "All" && TypeFilter == "All")
                {
                    dataGridView1.DataSource = symbolList.Where(x => x.Exc.ExchangeName == ExchangeFilter).ToList();
                }
                else if(TypeFilter != "All"  && ExchangeFilter == "All")
                {
                    dataGridView1.DataSource = symbolList.Where(x => x.Typ.TypeName == TypeFilter).ToList();
                }
            }

        }
        private void dodajBazuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog();

            if(result == DialogResult.OK)
            {
                sFileName = ofd.FileName;

                string ext = Path.GetExtension(sFileName);

                if(ext == ".s3db")
                {
                    //Puni grid view
                    FillSymbolList(sFileName);
                    FillTypeCombo();
                    FillExchangeCombo();
                }
                else
                {
                    //Poruka o neuspesnosti, pogresna ekstenzija fajla(Prihvata samo sqllite)
                    MessageBox.Show("This app only accepts .s3db files.");
                }
            }
        }

        private void btnConfirmFilter_Click(object sender, EventArgs e)
        {
            ConfirmFilter();
        }

        private void btnDeleteSymbol_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this Symbol?", "Confirm Delete", MessageBoxButtons.OKCancel);
                if(result == DialogResult.OK)
                {
                    string shearchParam = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
                   Symbol symb = symbolList?.FirstOrDefault(x => x.Name == shearchParam);

                    using (SQLiteConnection con = new SQLiteConnection(@"Data Source=" + sFileName))
                    {
                        string query = "DELETE FROM Symbol WHERE Id =" + symb.Id;

                        try
                        {
                            con.Open();
                            SQLiteCommand cmd = new SQLiteCommand(query, con);
                            cmd.ExecuteNonQuery();
                            int indexToDelete = symbolList.FindIndex(x => x.Id == symb.Id );
                            if (indexToDelete != -1)
                            {
                                // The item with the given ID and Name was found, remove it from the list
                                symbolList.RemoveAt(indexToDelete);
                                
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("There was an error" + ex.ToString());
                        }
                        finally
                        {
                            con.Close();
                            FillSymbolList(sFileName);
                            MessageBox.Show("You deleted Symbol successfully");
                            

                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Please select row to delete!");
            }
        }

        private void btnAddSymbol_Click(object sender, EventArgs e)
        {
            var addSymbolForm = new AddSymbolForm(sFileName);
            DialogResult dr = addSymbolForm.ShowDialog();
            if(dr == DialogResult.OK)
            {
                dataGridView1.Refresh();
                FillSymbolList(sFileName);
            }
            
        }

        private void btnEditSymbol_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                string shearchParam = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
                Symbol symb = symbolList?.FirstOrDefault(x => x.Name == shearchParam);

                var editSymbolForm = new EditViewForm(symb,sFileName);
                DialogResult dr = editSymbolForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    dataGridView1.Refresh();
                    FillSymbolList(sFileName);
                }

            }
            else
            {
                MessageBox.Show("Please select row to edit!");
            }
           
        }
    }
}