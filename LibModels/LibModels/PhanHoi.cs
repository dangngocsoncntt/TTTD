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
    public class PhanHoi
    {
        private int _ID;
        private string _HoTen;
        private byte _Tuoi;
        private string _DiaChi;
        private string _TieuDe;
        private string _NoiDung;
        private string _IP;
        private bool _HienThi;
        private string _NgayDang;
        private DBAccess db;

        public PhanHoi()
        {
            db = new DBAccess();
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string HoTen
        {
            get { return _HoTen; }
            set { _HoTen = value; }
        }

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }

        public string TieuDe
        {
            get { return _TieuDe; }
            set { _TieuDe = value; }
        }

        public byte Tuoi
        {
            get { return _Tuoi; }
            set { _Tuoi = value; }
        }

        public string NoiDung
        {
            get { return _NoiDung; }
            set { _NoiDung = value; }
        }

        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }

        public string NgayDang
        {
            get { return _NgayDang; }
            set { _NgayDang = value; }
        }

        public bool HienThi
        {
            get { return _HienThi; }
            set { _HienThi = value; }
        }

        //===============================================================================

        public int Add()
        {
            int out0 = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("PhanHoi_tao");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@HoTen", this.HoTen));
                cmd.Parameters.Add(new SqlParameter("@Tuoi", this.Tuoi));
                cmd.Parameters.Add(new SqlParameter("@DiaChi", this.DiaChi));
                cmd.Parameters.Add(new SqlParameter("@TieuDe", this.TieuDe));
                cmd.Parameters.Add(new SqlParameter("@NoiDung", this.NoiDung));
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

        public int Update()
        {
            int out0 = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("PhanHoi_sua");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", this.ID));
                cmd.Parameters.Add(new SqlParameter("@HienThi", this.HienThi));
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
                SqlCommand cmd = new SqlCommand("PhanHoi_xoa");
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

        public List<PhanHoi> GetList(string IP, string HienThi)
        {
            SqlConnection con = db.getConnection();
            List<PhanHoi> l_PhanHoi = new List<PhanHoi>();
            try
            {
                SqlCommand cmd = new SqlCommand("PhanHoi_timkiem");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IP", IP));
                cmd.Parameters.Add(new SqlParameter("@HienThi", HienThi));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    PhanHoi ph = new PhanHoi();
                    ph.ID = smartReader.GetInt32("ID");
                    ph.HoTen = smartReader.GetString("HoTen");
                    ph.Tuoi = smartReader.GetByte("Tuoi");
                    ph.DiaChi = smartReader.GetString("DiaChi");
                    ph.TieuDe = smartReader.GetString("TieuDe");
                    ph.NoiDung = smartReader.GetString("NoiDung");
                    ph.HienThi = smartReader.GetBoolean("HienThi");
                    ph.IP = smartReader.GetString("IP");
                    ph.NgayDang = smartReader.GetString("NgayDang");
                    l_PhanHoi.Add(ph);
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
            return l_PhanHoi;
        }

        public PhanHoi FindByID(int ID)
        {
            PhanHoi ph = new PhanHoi();
            SqlConnection con = db.getConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("PhanHoi_chitiet");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", ID));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    ph.ID = smartReader.GetInt32("ID");
                    ph.HoTen = smartReader.GetString("HoTen");
                    ph.Tuoi = smartReader.GetByte("Tuoi");
                    ph.DiaChi = smartReader.GetString("DiaChi");
                    ph.TieuDe = smartReader.GetString("TieuDe");
                    ph.NoiDung = smartReader.GetString("NoiDung");
                    ph.HienThi = smartReader.GetBoolean("HienThi");
                    ph.IP = smartReader.GetString("IP");
                    ph.NgayDang = smartReader.GetString("NgayDang");
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
            return ph;
        }
    }
}
