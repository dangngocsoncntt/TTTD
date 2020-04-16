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
    public class ChuDe
    {
        private byte _ID;
        private string _TenChuDe;
        private string _MoTa;
        private DBAccess db;

        public ChuDe()
        {
            db = new DBAccess();
        }

        public byte ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string TenChuDe
        {
            get { return _TenChuDe; }
            set { _TenChuDe = value; }
        }

        public string MoTa
        {
            get { return _MoTa; }
            set { _MoTa = value; }
        }

        //===============================================================================

        public int Add()
        {
            int out0 = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("ChuDe_tao");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TenChuDe", this.TenChuDe));
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
                SqlCommand cmd = new SqlCommand("ChuDe_sua");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", this.ID));
                cmd.Parameters.Add(new SqlParameter("@TenChuDe", this.TenChuDe));
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
                SqlCommand cmd = new SqlCommand("ChuDe_xoa");
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

        public List<ChuDe> GetList(string TenChuDe)
        {
            SqlConnection con = db.getConnection();
            List<ChuDe> l_ChuDe = new List<ChuDe>();
            try
            {
                SqlCommand cmd = new SqlCommand("ChuDe_timkiem");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TenChuDe", TenChuDe));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    ChuDe cd = new ChuDe();
                    cd.ID = smartReader.GetByte("ID");
                    cd.TenChuDe = smartReader.GetString("TenChuDe");
                    cd.MoTa = smartReader.GetString("MoTa");
                    l_ChuDe.Add(cd);
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
            return l_ChuDe;
        }

        public ChuDe FindByID(byte ID)
        {
            ChuDe cd = new ChuDe();
            SqlConnection con = db.getConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("ChuDe_chitiet");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", ID));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    cd.ID = smartReader.GetByte("ID");
                    cd.TenChuDe = smartReader.GetString("TenChuDe");
                    cd.MoTa = smartReader.GetString("MoTa");
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
            return cd;
        }
    }
}
