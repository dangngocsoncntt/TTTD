using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibModels.common;

namespace LibModels
{
    public class TaiKhoan
    {
        private byte _ID;
        private string _Username;
        private string _Password;
        private string _LastLogin;
        private string _IP;
        private DBAccess db;

        public TaiKhoan()
        {
            db = new DBAccess();
        }

        public byte ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string LastLogin
        {
            get { return _LastLogin; }
            set { _LastLogin = value; }
        }

        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }

        //===============================================================================

        public TaiKhoan Login(string username, string password)
        {
            TaiKhoan tk = new TaiKhoan();
            SqlConnection con = db.getConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("TaiKhoan_login");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Username", username));
                cmd.Parameters.Add(new SqlParameter("@Password", password));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    tk.ID = smartReader.GetByte("ID");
                    tk.Username = smartReader.GetString("Username");
                    tk.Password = smartReader.GetString("Password");
                    tk.LastLogin = smartReader.GetString("LastLogin");
                    tk.IP = smartReader.GetString("IP");
                }
                smartReader.disposeReader(reader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.closeConnection(con);
            }
            return tk;
        }

        public int Update()
        {
            int out0 = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("TaiKhoan_sua");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", this.ID));
                cmd.Parameters.Add(new SqlParameter("@Password", this.Password));
                cmd.Parameters.Add(new SqlParameter("@LastLogin", this.LastLogin));
                cmd.Parameters.Add(new SqlParameter("@IP", this.IP));
                cmd.Parameters.Add("@out", SqlDbType.Int).Direction = ParameterDirection.Output;
                db.ExecuteSQL(cmd);
                out0 = Convert.ToInt32(cmd.Parameters["@out"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return out0;
        }
    }
}
