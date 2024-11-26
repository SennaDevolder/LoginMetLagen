using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

//we gebruiken hetgene die in deze mappen zit (klassen Database en Login)
using prjloginmetlagenoefenenenenenen.Helper;
using prjloginmetlagenoefenenenenenen.Model;

namespace prjloginmetlagenoefenenenenenen.DA
{
    //alles programmeren van onze klasse login (we gebruiken daarvoor onze klasse Database, onze klasse Login
    public class LoginDA
    {

        //we bekijken of de logingegevens correct zijn yesir
        //boolean om te controleren of ze correct zijn --> True // anders Fale
        public static void LoginValidation(Login L)
        {
            //sqlconnection aanmaken --> verbinding met de databank te maken
            MySqlConnection conn = Databank.MakeConnection();

            string query = "SELECT COUNT(1) FROM login.tbllogin WHERE Username=@Username AND Password=@Password";
            //commando maken --> zorgt ervoor dat de sql statement wordt ingezet
            MySqlCommand sqlcmd = new MySqlCommand(query, conn);
            //welk soort commando is dat?
            sqlcmd.Parameters.AddWithValue("@Username", L.Username);
            sqlcmd.Parameters.AddWithValue("@Password", L.Password);

            //tellen van het aantal gevonden gegevens
            int count = Convert.ToInt32(sqlcmd.ExecuteScalar());

            if (count == 1)
            {
                MessageBox.Show("Uw ben ingelogd!");
            }
            else
            {
                MessageBox.Show("Wachtwoord en gebruikersnaam komen niet overeen!");
            }
        }

        public static void AddUser(Login L)
        {
            MySqlConnection conn = Databank.MakeConnection();

            string query = "INSERT INTO login.tbllogin(Username, Password) VALUES (@Username, @Password)";
            MySqlCommand sqlcmd = new MySqlCommand(query, conn);
            sqlcmd.Parameters.AddWithValue("@Username", L.Username);
            sqlcmd.Parameters.AddWithValue("@Password", L.Password);

            sqlcmd.ExecuteScalar();


            MessageBox.Show("Gebruiker succesvol toegevoegd!");
        }

        public static void ChangePass(Login L, string NewPass)
        {
            MySqlConnection conn = Databank.MakeConnection();

            string query = "UPDATE login.tbllogin SET Password=@NewPass WHERE Username=@Username AND Password=@Password";
            MySqlCommand sqlcmd = new MySqlCommand(query, conn);
            sqlcmd.Parameters.AddWithValue("@Username", L.Username);
            sqlcmd.Parameters.AddWithValue("@Password", L.Password);
            sqlcmd.Parameters.AddWithValue("@NewPass", NewPass);

            sqlcmd.ExecuteScalar();


            MessageBox.Show("Wachtwoord werd gewijzigd!");
        }

        public static void Delete(Login L)
        {
            MySqlConnection conn = Databank.MakeConnection();

            string query = "DELETE FROM login.tbllogin WHERE Username=@Username AND Password=@Password";
            MySqlCommand sqlcmd = new MySqlCommand(query, conn);
            sqlcmd.Parameters.AddWithValue("@Username", L.Username);
            sqlcmd.Parameters.AddWithValue("@Password", L.Password);

            sqlcmd.ExecuteScalar();

            MessageBox.Show("Gebruiker werd verwijderd!");
        }
    }
}
