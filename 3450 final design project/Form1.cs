using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3450_final_design_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static class tabPageinfo
        {
            public static int prevpage; //keeps track of most recent page
            public static int access; //0 is admin , 1 is user-->used to determine which mode we're in
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //login button
        {
            string username = "admin";
            string password = "password"; //default username and password for admin entry
            string connetionString = "";
            tabPageinfo.access = 0; //admin mode
            lblplayermode.Text = "ADMIN INTERFACE";
            lblclubmode.Text = "ADMIN INTERFACE";
            lblnatmode.Text = "ADMIN INTERFACE";
            lblhismode.Text = "ADMIN INTERFACE";
            lblmanmode.Text = "ADMIN INTERFACE";
            lblcompmode.Text = "ADMIN INTERFACE";
            if (txtusername.Text == username && txtpassword.Text == password) //if correct credentials are typed
            {
                //switch tab to display database
                tabswitch.SelectedTab = tabPage2; //player page
                tabPageinfo.prevpage = 2;
                                                                         connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
                MySqlConnection cnn = new MySqlConnection(connetionString);
                cnn.Open();
                string query = "SELECT * FROM player";
                MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
                DataTable table = new DataTable();
                pshow.Fill(table);
                gridadminplayer.DataSource = table;
                cnn.Close();

            }
            else //invalid login
            {
                string fail = "INVALID CREDENTIALS";
                MessageBox.Show(fail);

            }
        }


        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnnormaluser_Click(object sender, EventArgs e)
        {
            btnadminplayeradd.Visible = false;
            btnadminplayerdelete.Visible = false;
            btnadminplayerupdate.Visible = false;
            tabPageinfo.access = 1; // user mode
            lblplayermode.Text = "USER INTERFACE";
            lblclubmode.Text = "USER INTERFACE";
            lblnatmode.Text = "USER INTERFACE";
            lblhismode.Text = "USER INTERFACE";
            lblmanmode.Text = "USER INTERFACE";
            lblcompmode.Text = "USER INTERFACE";
            tabswitch.SelectedTab = tabPage2; //player page in user view
            tabPageinfo.prevpage = 2;
            string connetionString;
                                                                     connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM player";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridadminplayer.DataSource = table;
            cnn.Close();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.playerTableAdapter.FillBy1(this.pldataDataSet.player);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.playerTableAdapter.FillBy(this.pldataDataSet.player);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        private void btnadminplayer_Click(object sender, EventArgs e)
        {

        }

        private void btnadminclub_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage6; //go to club page
            tabPageinfo.prevpage = 2;
            if (tabPageinfo.access == 1)
            {
                btnclubadd.Visible = false;
                btnclubupdate.Visible = false;
                btnclubdelete.Visible = false;
            }
            string connetionString;
                                                                         connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM club";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridclub.DataSource = table;
            cnn.Close();
        }
        private void btnadmincomp_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage10; //go to comp page
            tabPageinfo.prevpage = 2;
            if (tabPageinfo.access == 1)
            {
                btncompadd.Visible = false;
                btncompupdate.Visible = false;
                btncompdelete.Visible = false;
            }
            string connetionString;
                                                                    connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM comp_view";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridcomp.DataSource = table;
            cnn.Close();
        }
        private void btnadminmanager_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage7; //go to manager page
            tabPageinfo.prevpage = 2;
            if (tabPageinfo.access == 1)
            {
                btnmanadd.Visible = false;
                btnmanupdate.Visible = false;
                btnmandelete.Visible = false;
            }
            string connetionString;
                                                                         connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM manager";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridman.DataSource = table;
            cnn.Close();
        }
        private void btnadminrecord_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage9; //go to player history page
            tabPageinfo.prevpage = 2;
            if (tabPageinfo.access == 1)
            {
                btnhisadd.Visible = false;
                btnhisupdate.Visible = false;
                btnhisdelete.Visible = false;
            }
            string connetionString;
                                                                 connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM player_record_view1";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridhis.DataSource = table;
            cnn.Close();
        }
        private void btnadminnational_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage8; //go to national team page
            tabPageinfo.prevpage = 2;
            if (tabPageinfo.access == 1)
            {
                btnnatadd.Visible = false;
                btnnatupdate.Visible = false;
                btnnatdelete.Visible = false;
            }
            string connetionString;
                                                                          connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM national_team";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridnat.DataSource = table;
            cnn.Close();
        }
        private void cbadminnamefilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbadmingoalfilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbadminvaluefilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public DataTable searchDB(string tableName, string search, string condition1, string condition2, string condition3)
        {
                                                                      string connetionString; connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query;
            if (condition2 == "NULL")
            {
                query = "SELECT * FROM " + tableName + " WHERE " + condition1 + " LIKE " + "'%" + search + "%'";

            }
            else if (condition3 == "NULL")
            {
                query = "SELECT * FROM " + tableName + " WHERE " + condition1 + " LIKE " + "'%" + search + "%'"
                   + " OR " + condition2 + " LIKE " + "'%" + search + "%'";
            }
            else
            {
                query = "SELECT * FROM " + tableName + " WHERE " + condition1 + " LIKE " + "'%" + search + "%'"
              + " OR " + condition2 + " LIKE " + "'%" + search + "%'" + " OR " + condition3 + " LIKE " + "'%" + search + "%'";

            }
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            cnn.Close();
            return table;
        }
        public DataTable sortDB(string tableName, string criteria, string aord)
        {
                                                              string connetionString; connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query;
            query = "SELECT * FROM " + tableName + " ORDER BY " + criteria + " " + aord;
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            cnn.Close();
            return table;
        }
        public DataTable deleteRow(string tableName, string criteria, string value)
        {
                                                            string connetionString; connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query;
            query = "DELETE FROM " + tableName + " WHERE " + criteria + "='" + value + "';"
                + "SELECT * FROM " + tableName + ";";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            cnn.Close();
            return table;
        }
        public DataTable deleteRowHis(string tableName, string criteria1, string criteria2, string value1, string value2)
        {           //criteria1 can be player id, criteria2 can be start date
                                                             string connetionString; connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query;
            query = "DELETE FROM " + tableName + " WHERE " + criteria1 + "='" + value1 + "', " + criteria2 + "='" + value2 + "';"
                + "SELECT * FROM player_record_view1;";

            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            cnn.Close();
            return table;
        }
        public DataTable updateEntry(string tableName, string changeField, string newvalue, string criteria, string val)
        {
                                                                       string connetionString; connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query;
            query = "UPDATE " + tableName + " SET " + changeField + "='" + newvalue + "'"
                + " WHERE " + criteria + "=" + val + ";" + "SELECT * FROM " + tableName + ";";

            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            cnn.Close();
            return table;
        }
        public DataTable updateEntryHis(string tableName, string changeField, string newvalue, string criteria, string criteria1, string val, string val1)
        {
                                                         string connetionString; connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query;
            query = "UPDATE " + tableName + " SET " + changeField + "='" + newvalue + "'"
                + " WHERE " + criteria + "='" + val + "', " + criteria1 + "='" + val1 + "';" + "SELECT * FROM player_record_view1;";

            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            cnn.Close();
            return table;
        }
        public DataTable updateEntryComp(string tableName, string changeField, string newvalue, string criteria, string val)
        {
                                                                            string connetionString; connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query;
            query = "UPDATE " + tableName + " SET " + changeField + "='" + newvalue + "'"
                + " WHERE " + criteria + "=" + val + ";" + "SELECT * FROM comp_view ;";

            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            cnn.Close();
            return table;
        }
        public DataTable addRowPlayer(string tableName, string pid, string pj, string pln, string pfn,
            string pnat, string pdob, string height, string weight, string goals, string assists, string ppos
            , string pval, string pcountry, string pclub) //function to add row to player page
        {
                                                 string connetionString; connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query;
            query = "INSERT INTO " + tableName + " VALUES('" + pid + "'," + "'" + pj + "'," + "'" + pln + "'," + "'" + pfn
              + "'," + "'" + pnat + "'," + "'" + pdob + "'," + "'" + height + "'," + "'" + weight + "'," + "'" + goals
              + "'," + "'" + assists + "'," + "'" + ppos + "'," + "'" + pval + "'," + "'" + pcountry + "'," + "'" + pclub + "')" + ";" +
              "SELECT * FROM PLAYER;";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            cnn.Close();
            return table;
        }

        public DataTable addRowClub(string tablename, string cid, string cname, string cstad, string ccity, string ccap, string manid)//function to add row to club page
        {
                                                             string connetionString; connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query;
            query = "INSERT INTO " + tablename + " VALUES('" + cid + "'," + "'" + cname + "'," + "'" + cstad + "'," + "'" + ccity
              + "'," + "'" + ccap + "'," + "'" + manid + "'" + ")" + ";" +
              "SELECT * FROM CLUB;";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            cnn.Close();
            return table;

        }
        public DataTable addRowMan(string tablename, string mid, string mlname, string mfname, string mnat, string mandob)//function to add row to manager page
        {
                                                     string connetionString; connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query;
            query = "INSERT INTO " + tablename + " VALUES('" + mid + "'," + "'" + mlname + "'," + "'" + mfname + "'," + "'" + mnat
              + "'," + "'" + mandob + "'" + ")" + ";" +
              "SELECT * FROM MANAGER;";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            cnn.Close();
            return table;

        }
        public DataTable addRowNat(string tablename, string ntc, string nts, string ntcity, string ntcap)//function to add row to national team table
        {
                                     string connetionString; connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query;
            query = "INSERT INTO " + tablename + " VALUES('" + ntc + "'," + "'" + nts + "'," + "'" + ntcity + "'," + "'" + ntcap
              + "'" + ")" + ";" +
              "SELECT * FROM NATIONAL_TEAM;";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            cnn.Close();
            return table;
        }
        public DataTable addRowHis(string tablename, string ppid, string tsd, string ccid) //function to add row to player history table
        {
                                                             string connetionString; connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query;
            query = "INSERT INTO " + tablename + " VALUES('" + ppid + "'," + "'" + tsd + "'," + "'" + ccid + "'" + ")" + ";"
                + "SELECT * FROM player_record_view1;";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            cnn.Close();
            return table;
        }
        public DataTable addRowComp(string tablename, string sid, string cname, string sname, string sdes)//function to add row to competition table
        {
                                                         string connetionString; connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query;
            query = "INSERT INTO " + tablename + " VALUES('" + sid + "'," + "'" + cname + "'," + "'" + sname + "'," + "'" + sdes
               + "'" + ")" + ";" +
              "SELECT * FROM comp_view;";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            cnn.Close();
            return table;

        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {

        }

        private void btnadminfilter_Click(object sender, EventArgs e)
        {
            if (txtadminplayer.Text == "")
            {
                if (cbadminnamefilter.Text == "Last Name: A-Z")
                {
                    gridadminplayer.DataSource = sortDB("player", "player_lname", "ASC");
                }

                else if (cbadminnamefilter.Text == "Last Name: Z-A")
                {
                    gridadminplayer.DataSource = sortDB("player", "player_lname", "DESC");
                }

                else if (cbadmingoalfilter.Text == "Least Goals")
                {
                    gridadminplayer.DataSource = sortDB("player", "player_goals", "ASC");
                }
                else if (cbadmingoalfilter.Text == "Most Goals")
                {
                    gridadminplayer.DataSource = sortDB("player", "player_goals", "DESC");
                }
                else if (cbadminvaluefilter.Text == "Lowest to Highest")
                {
                    gridadminplayer.DataSource = sortDB("player", "player_val_usd", "ASC");
                }
                else
                {
                    gridadminplayer.DataSource = sortDB("player", "player_val_usd", "DESC");
                }
            }     // if both sort and search is being done, search will be the last thing to execute

            else
            {

                gridadminplayer.DataSource = searchDB("player", txtadminplayer.Text, "Player_Fname", "Player_Lname", "Player_Nat");
            }

        }

        private void btnadminplayeradd_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage3; //go to add page
            tabPageinfo.prevpage = 2;
            //clear whatever is in textboxes already
            txtat1.Clear(); txtat2.Clear(); txtat3.Clear(); txtat4.Clear(); txtat5.Clear(); txtat6.Clear(); txtat7.Clear();
            txtat8.Clear(); txtat9.Clear(); txtat10.Clear(); txtat11.Clear(); txtat12.Clear(); txtat13.Clear(); txtat14.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnaddplayer_Click(object sender, EventArgs e)
        {
            if (tabPageinfo.prevpage == 2) //if you came from player page
            {
                gridadminplayer.DataSource = addRowPlayer("player", txtat1.Text, txtat2.Text, txtat3.Text, txtat4.Text,
               txtat5.Text, txtat6.Text, txtat7.Text, txtat8.Text, txtat9.Text, txtat10.Text, txtat11.Text, txtat12.Text,
               txtat13.Text, txtat14.Text);
                tabswitch.SelectedTab = tabPage2; //go back to player page
                tabPageinfo.prevpage = 3;
            }
            else if (tabPageinfo.prevpage == 6) //if you came from club page
            {
                gridclub.DataSource = addRowClub("club", txtat1.Text, txtat2.Text, txtat3.Text, txtat4.Text,
               txtat5.Text, txtat6.Text);
                tabswitch.SelectedTab = tabPage6; //go back to club page
                tabPageinfo.prevpage = 3;
            }
            else if (tabPageinfo.prevpage == 7) //if you came from manager page
            {
                gridman.DataSource = addRowMan("manager", txtat1.Text, txtat2.Text, txtat3.Text, txtat4.Text,
               txtat5.Text);
                tabswitch.SelectedTab = tabPage7; //go back to manager page
                tabPageinfo.prevpage = 3;
            }
            else if (tabPageinfo.prevpage == 8) //if you came from national team page
            {
                gridnat.DataSource = addRowNat("national_team", txtat1.Text, txtat2.Text, txtat3.Text, txtat4.Text);
                tabswitch.SelectedTab = tabPage8; //go back to national team page
                tabPageinfo.prevpage = 3;
            }
            else if (tabPageinfo.prevpage == 9) //if you came from player history page
            {
                gridhis.DataSource = addRowHis("player_record", txtat1.Text, txtat2.Text, txtat3.Text);
                tabswitch.SelectedTab = tabPage9; //go back to player history page
                tabPageinfo.prevpage = 3;
            }
            else if (tabPageinfo.prevpage == 10) //if you came from competition page
            {
                gridcomp.DataSource = addRowComp("competition_status", txtat1.Text, txtat2.Text, txtat3.Text, txtat4.Text);
                tabswitch.SelectedTab = tabPage10; //go back to competition page
                tabPageinfo.prevpage = 3;
            }

        }

        private void btndeleteplayer_Click(object sender, EventArgs e) //page where you can only delete a row
        {
            if (tabPageinfo.prevpage == 2) //if we came from the player page
            {
                gridadminplayer.DataSource = deleteRow("player", "player_ID", txtdelete.Text);
                tabswitch.SelectedTab = tabPage2;  //go back to player page
                tabPageinfo.prevpage = 4;

            }
            else if (tabPageinfo.prevpage == 6) //if you came from club page
            {
                gridclub.DataSource = deleteRow("club", "club_ID", txtdelete.Text);
                tabswitch.SelectedTab = tabPage6; //go back to club page
                tabPageinfo.prevpage = 4;
            }
            else if (tabPageinfo.prevpage == 7) //if you came from manager page
            {
                gridman.DataSource = deleteRow("manager", "man_ID", txtdelete.Text);
                tabswitch.SelectedTab = tabPage7; //go back to manager page
                tabPageinfo.prevpage = 4;
            }
            else if (tabPageinfo.prevpage == 8) //if you came from national team page
            {
                gridnat.DataSource = deleteRow("national_team", "nat_team_country", txtdelete.Text);
                tabswitch.SelectedTab = tabPage8; //go back to national team page
                tabPageinfo.prevpage = 4;
            }
            else if (tabPageinfo.prevpage == 9) //if you came from player history page
            {
                gridhis.DataSource = deleteRowHis("player_record", "player_player_id", "team_start_date", txtdelete.Text, txtdelete1.Text);
                tabswitch.SelectedTab = tabPage9; //go back to player history page
                tabPageinfo.prevpage = 4;
            }
            else if (tabPageinfo.prevpage == 10) //if you came from competition page
            {
                gridcomp.DataSource = deleteRow("competition_status", "status_id", txtdelete.Text);
                tabswitch.SelectedTab = tabPage10; //go back to competition page
                tabPageinfo.prevpage = 4;
            }
        }

        private void btnadminplayerdelete_Click(object sender, EventArgs e) 
        {
            tabswitch.SelectedTab = tabPage4;
            tabPageinfo.prevpage = 2;
            lbldelete1.Visible = false;
            txtdelete1.Visible = false;
        }

        private void btnadminplayerupdate_Click(object sender, EventArgs e)
        {
            label2.Text = "PREMIER LEAGUE PLAYER DATABASE";
            lblupdateID.Text = "PLAYER ID:";
            tabswitch.SelectedTab = tabPage5;
            txtupdatestart.Visible = false;
            lblupdatestart.Visible = false;
            tabPageinfo.prevpage = 2;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        { if (tabPageinfo.prevpage == 2) { //if we came from the player page
                gridadminplayer.DataSource = updateEntry("player", txtupdateatt.Text, txtvalupdate.Text, "player_id", txtupdateID.Text);
                tabswitch.SelectedTab = tabPage2;  //go back to player page
                tabPageinfo.prevpage = 5; //prev page is now update page
            }
            else if (tabPageinfo.prevpage == 6) { //if we came from club table

                gridclub.DataSource = updateEntry("club", txtupdateatt.Text, txtvalupdate.Text, "club_id", txtupdateID.Text);
                tabswitch.SelectedTab = tabPage6;  //go back to club page
                tabPageinfo.prevpage = 5; 

            }
            else if (tabPageinfo.prevpage == 7)//if we came from manager table
            { 
                gridman.DataSource = updateEntry("manager", txtupdateatt.Text, txtvalupdate.Text, "man_id", txtupdateID.Text);
                tabswitch.SelectedTab = tabPage7;  //go back to manager page
                tabPageinfo.prevpage = 5; 

            }
            else if (tabPageinfo.prevpage == 8)
            { //if we came from national team table

                gridnat.DataSource = updateEntry("national_team", txtupdateatt.Text, txtvalupdate.Text, "nat_team_country", txtupdateID.Text);
                tabswitch.SelectedTab = tabPage8;  //go back to national team page
                tabPageinfo.prevpage = 5; 

            }
            else if (tabPageinfo.prevpage == 9)
            { //if we came from player history table
              
                gridhis.DataSource = updateEntryHis("player_history", txtupdateatt.Text, txtvalupdate.Text, "player_player_id", "team_start_date", txtupdateID.Text, txtupdatestart.Text);
                tabswitch.SelectedTab = tabPage9;  //go back to player history page
                tabPageinfo.prevpage = 5; 
            }
            else if (tabPageinfo.prevpage == 10)
            { //if we came from competition table

                gridcomp.DataSource = updateEntryComp("competition_status", txtupdateatt.Text, txtvalupdate.Text, "status_id", txtupdateID.Text);
                tabswitch.SelectedTab = tabPage10;  //go back to competition page
                tabPageinfo.prevpage = 5; 

            }

        }

        private void btnfilterclub_Click(object sender, EventArgs e)
        {
            if (txtsearchclub.Text == "")
            {

                if (clubfiltername.Text == "Club Name: A-Z")
                {
                    gridclub.DataSource = sortDB("club", "club_name", "ASC");
                }

                else if (clubfiltername.Text == "Club Name: Z-A")
                {
                    gridclub.DataSource = sortDB("club", "club_name", "DESC");
                }

                else if (clubfiltercity.Text == "City Name: A-Z")
                {
                    gridclub.DataSource = sortDB("club", "club_city", "ASC");
                }
                else if (clubfiltercity.Text == "City Name: Z-A")
                {
                    gridclub.DataSource = sortDB("club", "club_city", "DESC");
                }
                else if (clubfiltercap.Text == "Lowest to Highest")
                {
                    gridclub.DataSource = sortDB("club", "club_capacity", "ASC");
                }
                else
                {
                    gridclub.DataSource = sortDB("club", "club_capacity", "DESC");
                }
            }     // if both sort and search is being done, search will be the last thing to execute

            else
            {

                gridclub.DataSource = searchDB("club", txtsearchclub.Text, "Club_Name", "Club_Stadium", "Club_City");
            }
        }

        private void btnclubadd_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage3; //go to add entry page
            tabPageinfo.prevpage = 6;
            //clear whatever is in textboxes already
            txtat1.Clear(); txtat2.Clear(); txtat3.Clear(); txtat4.Clear(); txtat5.Clear(); txtat6.Clear();
            txtat7.Visible = false; txtat8.Visible = false; txtat9.Visible = false; txtat10.Visible = false; txtat11.Visible = false; txtat12.Visible = false;
            txtat13.Visible = false; txtat14.Visible = false;
            lblat1.Text = "CLUB ID:"; lblat2.Text = "CLUB NAME:"; lblat3.Text = "CLUB STADIUM:"; lblat4.Text = "CLUB CITY:"; lblat5.Text = "CLUB STADIUM CAPACITY:"; lblat6.Text = "MANAGER:";
            lblat7.Visible = false; lblat8.Visible = false; lblat9.Visible = false; lblat10.Visible = false; lblat11.Visible = false; lblat12.Visible = false; lblat13.Visible = false; lblat14.Visible = false;
        }

        private void btnclubupdate_Click(object sender, EventArgs e)
        {
            label2.Text = "PREMIER LEAGUE CLUB DATABASE"; label2.Refresh();
            lblupdateID.Text = "CLUB ID:"; lblupdateID.Refresh();
            tabswitch.SelectedTab = tabPage5; //go to update page
            tabPageinfo.prevpage = 6;
            txtupdatestart.Visible = false;
            lblupdatestart.Visible = false;
        }

        private void btndeleteclub_Click(object sender, EventArgs e)
        {
            label3.Text = "PREMIER LEAGUE CLUB DATABASE"; 
            lbldelete.Text = "CLUB ID:"; lblupdateID.Refresh();
            tabswitch.SelectedTab = tabPage4; //go to delete page
            tabPageinfo.prevpage = 6;
            lbldelete1.Visible = false;
            txtdelete1.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e) 
        {

        }

        private void btnclub2player_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage2; //go to player page
            tabPageinfo.prevpage = 6; //prev page is club page
            if (tabPageinfo.access == 1)
            {
                btnclubadd.Visible = false;
                btnclubupdate.Visible = false;
                btnclubdelete.Visible = false;
            }
            string connetionString;
                                                                                             connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM club";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridclub.DataSource = table;
            cnn.Close();       
    }

        private void btnman2player_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage2; //go to player page
            tabPageinfo.prevpage = 7; //prev page is manager page
            if (tabPageinfo.access == 1)
            {
                btnclubadd.Visible = false;
                btnclubupdate.Visible = false;
                btnclubdelete.Visible = false;
            }
            string connetionString;
                                                                                                 connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM player";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridadminplayer.DataSource = table;
            cnn.Close();     
    }

        private void btnman2club_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage6; //go to club page
            tabPageinfo.prevpage = 7; //prev page is manager page
            if (tabPageinfo.access == 1)
            {
                btnclubadd.Visible = false;
                btnclubupdate.Visible = false;
                btnclubdelete.Visible = false;
            }
            string connetionString;
                                                                                     connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM club";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridclub.DataSource = table;
            cnn.Close();     
    }

        private void btnmanfilter_Click(object sender, EventArgs e)
        {
            if (txtsearchman.Text == "")
            {

                if (ma.Text == "Alphabetical: A-Z")
                {
                    gridman.DataSource = sortDB("manager", "man_lname", "ASC");
                }

                else if (ma.Text == "Alphabetical: Z-A")
                {
                    gridman.DataSource = sortDB("manager", "man_lname", "DESC");
                }

                else if (comboBox3.Text == "Youngest to Oldest")
                {
                    gridman.DataSource = sortDB("manager", "man_dob", "ASC");
                }
                else if (comboBox3.Text == "Oldest to Youngest")
                {
                    gridman.DataSource = sortDB("manager", "man_dob", "DESC");
                }
                else if (comboBox1.Text == "Alphabetical: A-Z")
                {
                    gridman.DataSource = sortDB("manager", "man_nat", "ASC");
                }
                else
                {
                    gridman.DataSource = sortDB("manager", "man_nat", "DESC");
                }
            }     // if both sort and search is being done, search will be the last thing to execute

            else
            {

                gridman.DataSource = searchDB("manager", txtsearchman.Text, "Man_lname", "man_fname", "man_nat");
            }
        }

        private void btnmanadd_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage3; //go to add entry page
            tabPageinfo.prevpage = 7;
            //clear whatever is in textboxes already
            txtat1.Clear(); txtat2.Clear(); txtat3.Clear(); txtat4.Clear(); txtat5.Clear(); txtat6.Visible = false;
            txtat7.Visible = false; txtat8.Visible = false; txtat9.Visible = false; txtat10.Visible = false; txtat11.Visible = false; txtat12.Visible = false;
            txtat13.Visible = false; txtat14.Visible = false;
            lblat1.Text = "MANAGER ID:"; lblat2.Text = "MANAGER LAST NAME:"; lblat3.Text = "MANAGER FIRST NAME:"; lblat4.Text = "MANAGER NATIONALITY:"; lblat5.Text = "MANAGER DOB:"; lblat6.Visible = false;
            lblat7.Visible = false; lblat8.Visible = false; lblat9.Visible = false; lblat10.Visible = false; lblat11.Visible = false; lblat12.Visible = false; lblat13.Visible = false; lblat14.Visible = false;

        }

        private void btnmanupdate_Click(object sender, EventArgs e)
        {
            label2.Text = "PREMIER LEAGUE MANAGER DATABASE"; label2.Refresh();
            lblupdateID.Text = "MANAGER ID:"; lblupdateID.Refresh();
            tabswitch.SelectedTab = tabPage5; //go to update page
            tabPageinfo.prevpage = 7;
            txtupdatestart.Visible = false;
            lblupdatestart.Visible = false;
        }

        private void btnmandelete_Click(object sender, EventArgs e)
        {
            label3.Text = "PREMIER LEAGUE MANAGER DATABASE"; 
            lbldelete.Text = "MANAGER ID:"; lblupdateID.Refresh();
            tabswitch.SelectedTab = tabPage4; //go to delete page
            tabPageinfo.prevpage = 7;
            lbldelete1.Visible = false;
            txtdelete1.Visible = false;
        }

        private void btnclub2man_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage7; //go to manager page
            tabPageinfo.prevpage = 6; //prev page is club page
            if (tabPageinfo.access == 1)
            {
                btnmanadd.Visible = false;
                btnmanupdate.Visible = false;
                btnmandelete.Visible = false;
            }
            string connetionString;
                                                                                 connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM manager";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridman.DataSource = table;
            cnn.Close();
        }

        private void btnnat2player_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage2; //go to player page
            tabPageinfo.prevpage = 8; //prev page is national team page
            if (tabPageinfo.access == 1)
            {
                btnadminplayeradd.Visible = false;
                btnadminplayerupdate.Visible = false;
                btnadminplayerdelete.Visible = false;
            }
            string connetionString;
                                                                                                         connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM player";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridadminplayer.DataSource = table;
            cnn.Close();
        }

        private void btnnat2club_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage6; //go to club page
            tabPageinfo.prevpage = 8; //prev page is national team page
            if (tabPageinfo.access == 1)
            {
                btnclubadd.Visible = false;
                btnclubupdate.Visible = false;
                btnclubdelete.Visible = false;
            }
            string connetionString;
                                                                              connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM club";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridclub.DataSource = table;
            cnn.Close();
        }

        private void btnnat2man_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage7; //go to manager page
            tabPageinfo.prevpage = 8; //prev page is national team page
            if (tabPageinfo.access == 1)
            {
                btnmanadd.Visible = false;
                btnmanupdate.Visible = false;
                btnmandelete.Visible = false;
            }
            string connetionString;
                                                                                             connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM manager";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridman.DataSource = table;
            cnn.Close();
        }

        private void btnnatadd_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage3; //go to add entry page
            tabPageinfo.prevpage = 8;
            btnaddplayer.Text = "ADD COUNTRY";
            txtat1.Clear(); txtat2.Clear(); txtat3.Clear(); txtat4.Clear(); txtat5.Visible = false; txtat6.Visible = false;
            txtat7.Visible = false; txtat8.Visible = false; txtat9.Visible = false; txtat10.Visible = false; txtat11.Visible = false; txtat12.Visible = false;
            txtat13.Visible = false; txtat14.Visible = false;
            lblat1.Text = "NATIONAL TEAM COUNTRY:"; lblat2.Text = "NATIONAL TEAM STADIUM:"; lblat3.Text = "NATIONAL TEAM CITY:"; lblat4.Text = "NATIONAL TEAM STADIUM CAPACITY:"; lblat5.Visible = false; lblat6.Visible = false;
            lblat7.Visible = false; lblat8.Visible = false; lblat9.Visible = false; lblat10.Visible = false; lblat11.Visible = false; lblat12.Visible = false; lblat13.Visible = false; lblat14.Visible = false;

        }

        private void btnnatupdate_Click(object sender, EventArgs e)
        {
            label2.Text = "PREMIER LEAGUE NATIONAL TEAM DATABASE"; label2.Refresh();
            lblupdateID.Text = "NATIONAL TEAM COUNTRY:"; lblupdateID.Refresh();
            tabswitch.SelectedTab = tabPage5; //go to update page
            tabPageinfo.prevpage = 8;
            txtupdatestart.Visible = false;
            lblupdatestart.Visible = false;
        }

        private void btnnatdelete_Click(object sender, EventArgs e)
        {
            label3.Text = "PREMIER LEAGUE NATIONAL TEAM DATABASE"; 
            lbldelete.Text = "NATIONAL TEAM COUNTRY:"; lblupdateID.Refresh();
            tabswitch.SelectedTab = tabPage4; //go to delete page
            tabPageinfo.prevpage = 8;
            lbldelete1.Visible = false;
            txtdelete1.Visible = false;
        }

        private void btnnatfilter_Click(object sender, EventArgs e)
        {
            if (txtsearchnat.Text == "")
            {

                if (natfiltername.Text == "National Team Name: A-Z")
                {
                    gridnat.DataSource = sortDB("national_team", "nat_team_country", "ASC");
                }

                else if (natfiltername.Text == "National Team Name: Z-A")
                {
                    gridnat.DataSource = sortDB("national_team", "nat_team_country", "DESC");
                }

                else if (natteamcity.Text == "City Name: A-Z")
                {
                    gridnat.DataSource = sortDB("national_team", "nat_team_city", "ASC");
                }
                else if (natteamcity.Text == "City Name: Z-A")
                {
                    gridnat.DataSource = sortDB("national_team", "nat_team_city", "DESC");
                }
                else if (natteamcap.Text == "Lowest to Highest")
                {
                    gridnat.DataSource = sortDB("national_team", "nat_team_capacity", "ASC");
                }
                else
                {
                    gridnat.DataSource = sortDB("national_team", "nat_team_capacity", "DESC");
                }
            }     // if both sort and search is being done, search will be the last thing to execute

            else
            {

                gridnat.DataSource = searchDB("national_team", txtsearchnat.Text, "nat_team_country", "nat_team_stadium", "nat_team_city");
            }
        }

        private void btnhis2player_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage2; //go to player page
            tabPageinfo.prevpage = 9; //prev page is player history page
            if (tabPageinfo.access == 1)
            {
                btnadminplayeradd.Visible = false;
                btnadminplayerupdate.Visible = false;
                btnadminplayerdelete.Visible = false;
            }
            string connetionString;
                                                                     connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM player";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridadminplayer.DataSource = table;
            cnn.Close();
        }

        private void btnhis2man_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage7; //go to manager page
            tabPageinfo.prevpage = 9; //prev page is player history page
            if (tabPageinfo.access == 1)
            {
                btnmanadd.Visible = false;
                btnmanupdate.Visible = false;
                btnmandelete.Visible = false;
            }
            string connetionString;
                                                                             connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM manager";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridman.DataSource = table;
            cnn.Close();
        }

        private void btnhis2club_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage6; //go to club page
            tabPageinfo.prevpage = 9; //prev page is player history page
            if (tabPageinfo.access == 1)
            {
                btnclubadd.Visible = false;
                btnclubupdate.Visible = false;
                btnclubdelete.Visible = false;
            }
            string connetionString;
                                                                                          connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM club";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridclub.DataSource = table;
            cnn.Close();
        }
        private void btnhist2comp_Click(object sender, EventArgs e) //competition to history page(btnhis2comp)
        {//this button makes no sense rn
            tabswitch.SelectedTab = tabPage10; //go to comp page
            tabPageinfo.prevpage = 9; //prev page is player history page
            if (tabPageinfo.access == 1)
            {
                btncompadd.Visible = false;
                btncompupdate.Visible = false;
                btncompdelete.Visible = false;
            }
            string connetionString;
                                                                                          connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM comp_view";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridcomp.DataSource = table;
            cnn.Close();
            }
        private void button18_Click(object sender, EventArgs e) 
        {
            
   
        }
        private void btnhisupdate_Click(object sender, EventArgs e)
            {
                label2.Text = "PREMIER LEAGUE PLAYER HISTORY DATABASE"; label2.Refresh();
                lblupdateID.Text = "PLAYER ID:"; lblupdateID.Refresh(); 
                tabswitch.SelectedTab = tabPage5; //go to update page
                tabPageinfo.prevpage = 9;
                txtupdatestart.Visible = true;
                lblupdatestart.Visible = true;
            }

            private void btnhisdelete_Click(object sender, EventArgs e)
            {
                label3.Text = "PREMIER LEAGUE PLAYER HISTORY DATABASE"; 
                lbldelete.Text = "PLAYER ID:"; lblupdateID.Refresh();
                txtdelete1.Visible = true;
                lbldelete1.Visible = true;
                tabswitch.SelectedTab = tabPage4; //go to delete page
                tabPageinfo.prevpage = 9;
                txtupdatestart.Visible = true;
                lblupdatestart.Visible = true;
            }

            private void btnhisfilter_Click(object sender, EventArgs e)
            {
                if (txtsearchhis.Text == "")
                {

                    if (hisfiltername.Text == "Alphabetical: A-Z") //last name
                    {
                        gridhis.DataSource = sortDB("player_record_view1", "player_lname", "ASC");
                    }

                    else if (hisfiltername.Text == "Alphabetical: Z-A")
                    {
                        gridhis.DataSource = sortDB("player_record_view1", "player_lname", "DESC");
                    }

                    else if (hisfilterclub.Text == "Club Name: A-Z")
                    {
                        gridhis.DataSource = sortDB("player_record_view1", "club_name", "ASC");
                    }
                    else if (hisfilterclub.Text == "Club Name: Z-A")
                    {
                        gridhis.DataSource = sortDB("player_record_view1", "club_name", "DESC");
                    }
                    else if (hisfilterdate.Text == "Earliest to Most Recent")
                    {
                        gridhis.DataSource = sortDB("player_record_view1", "team_start_date", "ASC");
                    }
                    else
                    {
                        gridhis.DataSource = sortDB("player_record_view1", "team_start_date", "DESC");
                    }
                }     // if both sort and search is being done, search will be the last thing to execute

                else
                {

                    gridhis.DataSource = searchDB("player_record_view1", txtsearchhis.Text, "player_lname", "player_fname", "club_name");
                }
            }

            private void btncompfilter_Click(object sender, EventArgs e)
            {
                if (txtsearchcomp.Text == "")
                {

                    if (compfilterclub.Text == "Club Name: A-Z")
                    {
                        gridcomp.DataSource = sortDB("comp_view", "club_name", "ASC");
                    }

                    else if (compfilterclub.Text == "Club Name: Z-A")
                    {
                        gridcomp.DataSource = sortDB("comp_view", "club_name", "DESC");
                    }

                    else if (compfiltcomp.Text == "Alphabetical: A-Z")
                    {
                        gridcomp.DataSource = sortDB("comp_view", "comp_name", "ASC");
                    }
                    else if (compfiltcomp.Text == "Alphabetical: Z-A")
                    {
                        gridcomp.DataSource = sortDB("comp_view", "comp_name", "DESC");
                    }
                    else if (compfiltstat.Text == "Alphabetical: A-Z")
                    {
                        gridcomp.DataSource = sortDB("comp_view", "status_name", "ASC");
                    }
                    else
                    {
                        gridcomp.DataSource = sortDB("comp_view", "status_name", "DESC");
                    }
                }     // if both sort and search is being done, search will be the last thing to execute

                else
                {

                    gridcomp.DataSource = searchDB("comp_view", txtsearchcomp.Text, "club_name", "comp_name", "status_name");
                }
            }

            private void btncompadd_Click(object sender, EventArgs e)
            {
                tabswitch.SelectedTab = tabPage3; //go to add entry page
                tabPageinfo.prevpage = 10;
                btnaddplayer.Text = "ADD COMPETITION";
                txtat1.Clear(); txtat2.Clear(); txtat3.Clear(); txtat4.Clear(); txtat5.Visible = false; txtat6.Visible = false;
                txtat7.Visible = false; txtat8.Visible = false; txtat9.Visible = false; txtat10.Visible = false; txtat11.Visible = false; txtat12.Visible = false;
                txtat13.Visible = false; txtat14.Visible = false;
                lblat1.Text = "STATUS ID:"; lblat2.Text = "COMPETITION NAME:"; lblat3.Text = "STATUS NAME:"; lblat4.Text = "STATUS DESCRIPTION:"; lblat5.Visible = false; lblat6.Visible = false;
                lblat7.Visible = false; lblat8.Visible = false; lblat9.Visible = false; lblat10.Visible = false; lblat11.Visible = false; lblat12.Visible = false; lblat13.Visible = false; lblat14.Visible = false;
            }

            private void btncompupdate_Click(object sender, EventArgs e)
            {
                label2.Text = "PREMIER LEAGUE COMPETITION DATABASE"; label2.Refresh();
                lblupdateID.Text = "STATUS ID:"; lblupdateID.Refresh();
                tabswitch.SelectedTab = tabPage5; //go to update page
                tabPageinfo.prevpage = 10;
                txtupdatestart.Visible = false;
                lblupdatestart.Visible = false;
            }

            private void btncompdelete_Click(object sender, EventArgs e)
            {
                label3.Text = "PREMIER LEAGUE COMPETITON INFO DATABASE"; 
                lbldelete.Text = "STATUS ID:"; lblupdateID.Refresh();
                tabswitch.SelectedTab = tabPage4; //go to delete page
                tabPageinfo.prevpage = 10;
                lbldelete1.Visible = false;
                txtdelete1.Visible = false;
            }

            private void btnhisadd_Click(object sender, EventArgs e)
            {
                tabswitch.SelectedTab = tabPage3; //go to add entry page
                tabPageinfo.prevpage = 9;
                btnaddplayer.Text = "ADD PLAYER HISTORY";
                txtat1.Clear(); txtat2.Clear(); txtat3.Clear(); txtat4.Visible = false; txtat5.Visible = false; txtat6.Visible = false;
                txtat7.Visible = false; txtat8.Visible = false; txtat9.Visible = false; txtat10.Visible = false; txtat11.Visible = false; txtat12.Visible = false;
                txtat13.Visible = false; txtat14.Visible = false;
                lblat1.Text = "PLAYER ID:"; lblat2.Text = "TEAM START DATE:"; lblat3.Text = "CLUB ID:"; lblat4.Visible = false; lblat5.Visible = false; lblat6.Visible = false;
                lblat7.Visible = false; lblat8.Visible = false; lblat9.Visible = false; lblat10.Visible = false; lblat11.Visible = false; lblat12.Visible = false; lblat13.Visible = false; lblat14.Visible = false;
            }

            private void btncomp2play_Click(object sender, EventArgs e)
            {
                tabswitch.SelectedTab = tabPage2; //go to player page
                tabPageinfo.prevpage = 10; //prev page is competition page
                if (tabPageinfo.access == 1)
                {
                    btnadminplayeradd.Visible = false;
                    btnadminplayerupdate.Visible = false;
                    btnadminplayerdelete.Visible = false;
                }
                string connetionString;
                                                                              connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
                MySqlConnection cnn = new MySqlConnection(connetionString);
                cnn.Open();
                string query = "SELECT * FROM player";
                MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
                DataTable table = new DataTable();
                pshow.Fill(table);
                gridadminplayer.DataSource = table;
                cnn.Close();
            }

            private void btncomp2man_Click(object sender, EventArgs e)
            {

                tabswitch.SelectedTab = tabPage7; //go to manager page
                tabPageinfo.prevpage = 10; //prev page is competition page
                if (tabPageinfo.access == 1)
                {
                    btnmanadd.Visible = false;
                    btnmanupdate.Visible = false;
                    btnmandelete.Visible = false;
                }
                string connetionString;
                                                                                      connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
                MySqlConnection cnn = new MySqlConnection(connetionString);
                cnn.Open();
                string query = "SELECT * FROM manager";
                MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
                DataTable table = new DataTable();
                pshow.Fill(table);
                gridman.DataSource = table;
                cnn.Close();
            }

            private void btncomp2club_Click(object sender, EventArgs e)
            {
                tabswitch.SelectedTab = tabPage6; //go to club page
                tabPageinfo.prevpage = 10; //prev page is competition page
                if (tabPageinfo.access == 1)
                {
                    btnclubadd.Visible = false;
                    btnclubupdate.Visible = false;
                    btnclubdelete.Visible = false;
                }
                string connetionString;
                                                                                 connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
                MySqlConnection cnn = new MySqlConnection(connetionString);
                cnn.Open();
                string query = "SELECT * FROM club";
                MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
                DataTable table = new DataTable();
                pshow.Fill(table);
                gridclub.DataSource = table;
                cnn.Close();
            }

            private void btncomp2his_Click(object sender, EventArgs e)
            {
                tabswitch.SelectedTab = tabPage9; //go to history page
                tabPageinfo.prevpage = 10; //prev page is comp page
                if (tabPageinfo.access == 1)
                {
                    btnhisadd.Visible = false;
                    btnhisupdate.Visible = false;
                    btnhisdelete.Visible = false;
                }
                string connetionString;
                                                                                 connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
                   MySqlConnection cnn = new MySqlConnection(connetionString);
                cnn.Open();
                string query = "SELECT * FROM player_record_view1";
                MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
                DataTable table = new DataTable();
                pshow.Fill(table);
                gridhis.DataSource = table;
                cnn.Close();
            }
            private void btncomp2nat_Click(object sender, EventArgs e)
            {
                tabswitch.SelectedTab = tabPage8; //go to national team page
                tabPageinfo.prevpage = 10; //prev page is competition page
                if (tabPageinfo.access == 1)
                {
                    btnnatadd.Visible = false;
                    btnnatupdate.Visible = false;
                    btnnatdelete.Visible = false;
                }
                string connetionString;
                                                                                 connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
                MySqlConnection cnn = new MySqlConnection(connetionString);
                cnn.Open();
                string query = "SELECT * FROM national_team";
                MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
                DataTable table = new DataTable();
                pshow.Fill(table);
                gridnat.DataSource = table;
                cnn.Close();
            }

        private void button6_Click(object sender, EventArgs e) //club to history button
        {
            tabswitch.SelectedTab = tabPage9; //go to player history page
            tabPageinfo.prevpage = 6; //prev page is club page
            if (tabPageinfo.access == 1)
            {
                btnhisadd.Visible = false;
                btnhisupdate.Visible = false;
                btnhisdelete.Visible = false;
            }
            string connetionString;
                                                                       connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM player_record_view1";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridhis.DataSource = table;
            cnn.Close();
        }

        private void btnclub2comp_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage10; //go to competition page
            tabPageinfo.prevpage = 6; //prev page is club page
            if (tabPageinfo.access == 1)
            {
                btncompadd.Visible = false;
                btncompupdate.Visible = false;
                btncompdelete.Visible = false;
            }
            string connetionString;
                                                                              connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM comp_view";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridcomp.DataSource = table;
            cnn.Close();
        }

        private void btnclub2nat_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage8; //go to national team page
            tabPageinfo.prevpage = 6; //prev page is club page
            if (tabPageinfo.access == 1)
            {
                btnnatadd.Visible = false;
                btnnatupdate.Visible = false;
                btnnatdelete.Visible = false;
            }
            string connetionString;
                                                                          connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM national_team";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridnat.DataSource = table;
            cnn.Close();
        }

        private void button12_Click(object sender, EventArgs e) //btnman2hist
        {
            tabswitch.SelectedTab = tabPage9; //go to player history page
            tabPageinfo.prevpage = 7; //prev page is manager page
            if (tabPageinfo.access == 1)
            {
                btnhisadd.Visible = false;
                btnhisupdate.Visible = false;
                btnhisdelete.Visible = false;
            }
            string connetionString;
                                                         connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM player_record_view1";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridhis.DataSource = table;
            cnn.Close();
        }

        private void btnman2nat_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage8; //go to national team page
            tabPageinfo.prevpage = 7; //prev page is manager page
            if (tabPageinfo.access == 1)
            {
                btnnatadd.Visible = false;
                btnnatupdate.Visible = false;
                btnnatdelete.Visible = false;
            }
            string connetionString;
                                                                             connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM national_team";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridnat.DataSource = table;
            cnn.Close();
        }

        private void btnman2comp_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage10; //go to competition page
            tabPageinfo.prevpage = 7; //prev page is manager page
            if (tabPageinfo.access == 1)
            {
                btncompadd.Visible = false;
                btncompupdate.Visible = false;
                btncompdelete.Visible = false;
            }
            string connetionString;
                                                                connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM comp_view";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridcomp.DataSource = table;
            cnn.Close();
        }

        private void btnnat2hist_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage9; //go to player history page
            tabPageinfo.prevpage = 7; //prev page is manager page
            if (tabPageinfo.access == 1)
            {
                btnhisadd.Visible = false;
                btnhisupdate.Visible = false;
                btnhisdelete.Visible = false;
            }
            string connetionString;
            connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM player_record_view1";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridhis.DataSource = table;
            cnn.Close();
        }

        private void btnnat2comp_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage10; //go to competition page
            tabPageinfo.prevpage = 8; //prev page is national team page
            if (tabPageinfo.access == 1)
            {
                btncompadd.Visible = false;
                btncompupdate.Visible = false;
                btncompdelete.Visible = false;
            }
            string connetionString;
            connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM comp_view";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridcomp.DataSource = table;
            cnn.Close();
        }

        private void btnhisttonat_Click(object sender, EventArgs e)
        {
            tabswitch.SelectedTab = tabPage8; //go to national team page
            tabPageinfo.prevpage = 9; //prev page is player history page
            if (tabPageinfo.access == 1)
            {
                btnnatadd.Visible = false;
                btnnatupdate.Visible = false;
                btnnatdelete.Visible = false;
            }
            string connetionString;
            connetionString = @"Data Source=localhost;Initial Catalog=pldata;User ID=root;Password=password;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "SELECT * FROM national_team";
            MySqlDataAdapter pshow = new MySqlDataAdapter(query, cnn);
            DataTable table = new DataTable();
            pshow.Fill(table);
            gridnat.DataSource = table;
            cnn.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}

