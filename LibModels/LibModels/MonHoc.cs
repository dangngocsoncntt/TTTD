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
    public class MonHoc
    {
        private byte _ID;
        private string _TenMonHoc;
        private string _MoTa;
        private DBAccess db;

        public MonHoc()
        {
            db = new DBAccess();
        }

        public byte ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string TenMonHoc
        {
            get { return _TenMonHoc; }
            set { _TenMonHoc = value; }
        }

        public string MoTa
        {
            get { return _MoTa; }
            set { _MoTa = value; }
        }

        //===============================================================================

        public List<MonHoc> GetList()
        {
            SqlConnection con = db.getConnection();
            List<MonHoc> l_MonHoc = new List<MonHoc>();
            try
            {
                SqlCommand cmd = new SqlCommand("MonHoc_timkiem");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    MonHoc mh = new MonHoc();
                    mh.ID = smartReader.GetByte("ID");
                    mh.TenMonHoc = smartReader.GetString("TenMonHoc");
                    mh.MoTa = smartReader.GetString("MoTa");
                    l_MonHoc.Add(mh);
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
            return l_MonHoc;
        }

        public List<MonHoc> GetListByGiaoVien(short GiaoVienID)
        {
            SqlConnection con = db.getConnection();
            List<MonHoc> l_MonHoc = new List<MonHoc>();
            try
            {
                SqlCommand cmd = new SqlCommand("MonHoc_timkiemByGiaoVien");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@GiaoVienID", GiaoVienID));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    MonHoc mh = new MonHoc();
                    mh.ID = smartReader.GetByte("ID");
                    mh.TenMonHoc = smartReader.GetString("TenMonHoc");
                    mh.MoTa = smartReader.GetString("MoTa");
                    l_MonHoc.Add(mh);
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
            return l_MonHoc;
        }
    }
}
