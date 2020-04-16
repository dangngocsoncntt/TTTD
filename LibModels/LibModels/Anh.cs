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
    public class Anh
    {
        private int _ID;
        private string _TenFile;
        private string _KieuAnh;
        private string _URL;
        private byte _LoaiAnhID;
        private string _NgayUpload;
        private short _AlbumID;
        private string _TenAlbum;
        private DBAccess db;

        public Anh()
        {
            db = new DBAccess();
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string TenAlbum
        {
            get { return _TenAlbum; }
            set { _TenAlbum = value; }
        }

        public string TenFile
        {
            get { return _TenFile; }
            set { _TenFile = value; }
        }

        public string KieuAnh
        {
            get { return _KieuAnh; }
            set { _KieuAnh = value; }
        }

        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }

        public byte LoaiAnhID
        {
            get { return _LoaiAnhID; }
            set { _LoaiAnhID = value; }
        }

        public string NgayUpload
        {
            get { return _NgayUpload; }
            set { _NgayUpload = value; }
        }

        public short AlbumID
        {
            get { return _AlbumID; }
            set { _AlbumID = value; }
        }

        //===============================================================================

        public int Add(DataTable list, short AlbumID, string TenAlbum, string MoTa)
        {
            int out0 = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("Anh_taohl");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@list", list));
                cmd.Parameters.Add(new SqlParameter("@AlbumID", AlbumID));
                cmd.Parameters.Add(new SqlParameter("@TenAlbum", TenAlbum));
                cmd.Parameters.Add(new SqlParameter("@MoTa", MoTa));
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

        public int Delete(string list)
        {
            int out0 = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("Anh_xoa");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@list", list));
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

        public List<string> GetPath(string listID)
        {
            SqlConnection con = db.getConnection();
            List<string> l_str = new List<string>();
            try
            {
                SqlCommand cmd = new SqlCommand("Anh_timkiemurl");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@list", listID));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    string s = smartReader.GetString("URL");
                    l_str.Add(s);
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
            return l_str;
        }

        public List<string> GetPath2(string listID)
        {
            SqlConnection con = db.getConnection();
            List<string> l_str = new List<string>();
            try
            {
                SqlCommand cmd = new SqlCommand("Anh_timkiemurl2");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@list", listID));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    string s = smartReader.GetString("URL");
                    l_str.Add(s);
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
            return l_str;
        }

        public List<string> GetPath3(string listID)
        {
            SqlConnection con = db.getConnection();
            List<string> l_str = new List<string>();
            try
            {
                SqlCommand cmd = new SqlCommand("Anh_timkiemurl3");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@list", listID));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    string s = smartReader.GetString("URL");
                    l_str.Add(s);
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
            return l_str;
        }

        public List<Anh> GetList(byte LoaiAnhID, short AlbumID)
        {
            SqlConnection con = db.getConnection();
            List<Anh> l_Anh = new List<Anh>();
            try
            {
                SqlCommand cmd = new SqlCommand("Anh_timkiem");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@LoaiAnhID", LoaiAnhID));
                cmd.Parameters.Add(new SqlParameter("@AlbumID", AlbumID));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    Anh a = new Anh();
                    a.ID = smartReader.GetInt16("ID");
                    a.TenFile = smartReader.GetString("TenFile");
                    a.KieuAnh = smartReader.GetString("KieuAnh");
                    a.URL = smartReader.GetString("URL");
                    a.NgayUpload = smartReader.GetString("NgayUpload");
                    a.TenAlbum = smartReader.GetString("TenAlbum");
                    a.AlbumID = smartReader.GetInt16("AlbumID");
                    l_Anh.Add(a);
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
            return l_Anh;
        }
    }
}
