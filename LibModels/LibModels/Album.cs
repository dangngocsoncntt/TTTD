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
    public class Album
    {
        private short _ID;
        private string _TenAlbum;
        private string _MoTa;
        private string _NgayTao;
        private DBAccess db;

        public Album()
        {
            db = new DBAccess();
        }

        public short ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string TenAlbum
        {
            get { return _TenAlbum; }
            set { _TenAlbum = value; }
        }

        public string MoTa
        {
            get { return _MoTa; }
            set { _MoTa = value; }
        }

        public string NgayTao
        {
            get { return _NgayTao; }
            set { _NgayTao = value; }
        }

        //===============================================================================

        public int Add()
        {
            int out0 = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("Album_tao");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TenAlbum", this.TenAlbum));
                cmd.Parameters.Add(new SqlParameter("@MoTa", this.MoTa));
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

        public int Update()
        {
            int out0 = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("Album_sua");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", this.ID));
                cmd.Parameters.Add(new SqlParameter("@TenAlbum", this.TenAlbum));
                cmd.Parameters.Add(new SqlParameter("@MoTa", this.MoTa));
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
                SqlCommand cmd = new SqlCommand("Album_xoa");
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

        public Album FindByID(short ID)
        {
            Album al = new Album();
            SqlConnection con = db.getConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("Album_chitiet");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", ID));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    al.ID = smartReader.GetInt16("ID");
                    al.TenAlbum = smartReader.GetString("TenAlbum");
                    al.MoTa = smartReader.GetString("MoTa");
                    al.NgayTao = smartReader.GetString("NgayTao");
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
            return al;
        }

        public List<Album> GetList(string TenAlbum)
        {
            SqlConnection con = db.getConnection();
            List<Album> l_Album = new List<Album>();
            try
            {
                SqlCommand cmd = new SqlCommand("Album_timkiem");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TenAlbum", TenAlbum));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    Album al = new Album();
                    al.ID = smartReader.GetInt16("ID");
                    al.TenAlbum = smartReader.GetString("TenAlbum");
                    al.MoTa = smartReader.GetString("MoTa");
                    al.NgayTao = smartReader.GetString("NgayTao");
                    l_Album.Add(al);
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
            return l_Album;
        }
    }
}
