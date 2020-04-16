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
    public class BaiViet
    {
        private int _ID;
        private string _TieuDe;
        private string _SoLuoc;
        private string _NoiDung;
        private string _NgayDang;
        private string _IP;
        private int _LuotXem;
        private byte _ChuDeID;
        private string _TenChuDe;
        private int _AnhID;
        private string _URL;
        private int _LopHocID;
        private DBAccess db;

        public BaiViet()
        {
            db = new DBAccess();
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string TieuDe
        {
            get { return _TieuDe; }
            set { _TieuDe = value; }
        }

        public string SoLuoc
        {
            get { return _SoLuoc; }
            set { _SoLuoc = value; }
        }

        public string NoiDung
        {
            get { return _NoiDung; }
            set { _NoiDung = value; }
        }

        public string NgayDang
        {
            get { return _NgayDang; }
            set { _NgayDang = value; }
        }

        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }

        public byte ChuDeID
        {
            get { return _ChuDeID; }
            set { _ChuDeID = value; }
        }

        public string TenChuDe
        {
            get { return _TenChuDe; }
            set { _TenChuDe = value; }
        }

        public int LuotXem
        {
            get { return _LuotXem; }
            set { _LuotXem = value; }
        }

        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }

        public int AnhID
        {
            get { return _AnhID; }
            set { _AnhID = value; }
        }

        public int LopHocID
        {
            get { return _LopHocID; }
            set { _LopHocID = value; }
        }

        //===============================================================================

        public int Add()
        {
            int out0 = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("BaiViet_tao");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TieuDe", this.TieuDe));
                cmd.Parameters.Add(new SqlParameter("@SoLuoc", this.SoLuoc));
                cmd.Parameters.Add(new SqlParameter("@NoiDung", this.NoiDung));
                cmd.Parameters.Add(new SqlParameter("@IP", this.IP));
                cmd.Parameters.Add(new SqlParameter("@ChuDeID", this.ChuDeID));
                cmd.Parameters.Add(new SqlParameter("@URL", this.URL));
                // cmd.Parameters.Add(new SqlParameter("@lophocid", this.LopHocID));
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
                SqlCommand cmd = new SqlCommand("BaiViet_sua");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", this.ID));
                cmd.Parameters.Add(new SqlParameter("@TieuDe", this.TieuDe));
                cmd.Parameters.Add(new SqlParameter("@SoLuoc", this.SoLuoc));
                cmd.Parameters.Add(new SqlParameter("@NoiDung", this.NoiDung));
                cmd.Parameters.Add(new SqlParameter("@LuotXem", this.LuotXem));
                cmd.Parameters.Add(new SqlParameter("@ChuDeID", this.ChuDeID));
                cmd.Parameters.Add(new SqlParameter("@AnhID", this.AnhID));
                cmd.Parameters.Add(new SqlParameter("@URL", this.URL));
                cmd.Parameters.Add(new SqlParameter("@lophocid", this.LopHocID));
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
                SqlCommand cmd = new SqlCommand("BaiViet_xoa");
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

        public BaiViet FindByID(int ID)
        {
            BaiViet bv = new BaiViet();
            SqlConnection con = db.getConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("BaiViet_chitiet");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", ID));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    bv.ID = smartReader.GetInt32("ID");
                    bv.TieuDe = smartReader.GetString("TieuDe");
                    bv.SoLuoc = smartReader.GetString("SoLuoc");
                    bv.NoiDung = smartReader.GetString("NoiDung");
                    bv.NgayDang = smartReader.GetString("NgayDang");
                    bv.IP = smartReader.GetString("IP");
                    bv.LuotXem = smartReader.GetInt32("LuotXem");
                    bv.TenChuDe = smartReader.GetString("TenChuDe");
                    bv.URL = smartReader.GetString("URL");
                    bv.ChuDeID = smartReader.GetByte("ChuDeID");
                    bv.AnhID = smartReader.GetInt32("AnhID");
                    bv.LopHocID = smartReader.GetInt32("lophocid");
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
            return bv;
        }

        public List<BaiViet> GetList(string TieuDe, string NgayDangMin, string NgayDangMax, byte ChuDeID)
        {
            SqlConnection con = db.getConnection();
            List<BaiViet> l_BaiViet = new List<BaiViet>();
            try
            {
                SqlCommand cmd = new SqlCommand("BaiViet_timkiem");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TieuDe", TieuDe));
                cmd.Parameters.Add(new SqlParameter("@NgayDangMin", NgayDangMin));
                cmd.Parameters.Add(new SqlParameter("@NgayDangMax", NgayDangMax));
                cmd.Parameters.Add(new SqlParameter("@ChuDeID", ChuDeID));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    BaiViet bv = new BaiViet();
                    bv.ID = smartReader.GetInt32("ID");
                    bv.TieuDe = smartReader.GetString("TieuDe");
                    bv.NgayDang = smartReader.GetString("NgayDang");
                    bv.LuotXem = smartReader.GetInt32("LuotXem");
                    bv.TenChuDe = smartReader.GetString("TenChuDe");
                    bv.URL = smartReader.GetString("URL");
                    bv.IP = smartReader.GetString("IP");
                    bv.LopHocID = smartReader.GetInt32("lophocid");
                    l_BaiViet.Add(bv);
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
            return l_BaiViet;
        }

        public List<BaiViet> GetList(string TieuDe, string NgayDangMin, string NgayDangMax, byte ChuDeID, int LopHocID)
        {
            SqlConnection con = db.getConnection();
            List<BaiViet> l_BaiViet = new List<BaiViet>();
            try
            {
                SqlCommand cmd = new SqlCommand("BaiViet_timkiem");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TieuDe", TieuDe));
                cmd.Parameters.Add(new SqlParameter("@NgayDangMin", NgayDangMin));
                cmd.Parameters.Add(new SqlParameter("@NgayDangMax", NgayDangMax));
                cmd.Parameters.Add(new SqlParameter("@ChuDeID", ChuDeID));
                cmd.Parameters.Add(new SqlParameter("@lophocid", LopHocID));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    BaiViet bv = new BaiViet();
                    bv.ID = smartReader.GetInt32("ID");
                    bv.TieuDe = smartReader.GetString("TieuDe");
                    bv.NgayDang = smartReader.GetString("NgayDang");
                    bv.LuotXem = smartReader.GetInt32("LuotXem");
                    bv.TenChuDe = smartReader.GetString("TenChuDe");
                    bv.URL = smartReader.GetString("URL");
                    bv.IP = smartReader.GetString("IP");
                    bv.LopHocID = smartReader.GetInt32("lophocid");
                    l_BaiViet.Add(bv);
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
            return l_BaiViet;
        }

        public List<BaiViet> GetRecentList()
        {
            SqlConnection con = db.getConnection();
            List<BaiViet> l_BaiViet = new List<BaiViet>();
            try
            {
                SqlCommand cmd = new SqlCommand("BaiViet_timKiemGanNhat");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    BaiViet bv = new BaiViet();
                    bv.ID = smartReader.GetInt32("ID");
                    bv.TieuDe = smartReader.GetString("TieuDe");
                    bv.NgayDang = smartReader.GetString("NgayDang");
                    bv.SoLuoc = smartReader.GetString("SoLuoc");
                    bv.URL = smartReader.GetString("URL");
                    bv.LopHocID = smartReader.GetInt32("lophocid");
                    l_BaiViet.Add(bv);
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
            return l_BaiViet;
        }

        public List<BaiViet> GetPaginationList(short pageNum, short limitPerPage, byte ChuDeID, int LopHocID)
        {
            SqlConnection con = db.getConnection();
            List<BaiViet> l_BaiViet = new List<BaiViet>();
            try
            {
                SqlCommand cmd = new SqlCommand("BaiViet_timKiemPhanTrang");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Page", pageNum));
                cmd.Parameters.Add(new SqlParameter("@Limit", limitPerPage));
                cmd.Parameters.Add(new SqlParameter("@ChuDeID", ChuDeID));
                cmd.Parameters.Add(new SqlParameter("@lophocid", LopHocID));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    BaiViet bv = new BaiViet();
                    bv.ID = smartReader.GetInt32("ID");
                    bv.TieuDe = smartReader.GetString("TieuDe");
                    bv.SoLuoc = smartReader.GetString("SoLuoc");
                    bv.URL = smartReader.GetString("URL");
                    bv.LopHocID = smartReader.GetInt32("lophocid");
                    l_BaiViet.Add(bv);
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
            return l_BaiViet;
        }

        public int GetTotalPage(short limitPerPage, byte ChuDeID, int lophocid)
        {
            int out0 = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("BaiViet_totalPage");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Limit", limitPerPage));
                cmd.Parameters.Add(new SqlParameter("@ChuDeID", ChuDeID));
                cmd.Parameters.Add(new SqlParameter("@lophocid", lophocid));
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
