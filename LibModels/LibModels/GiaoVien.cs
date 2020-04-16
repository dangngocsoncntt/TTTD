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
    public class GiaoVien
    {
        private short _ID;
        private string _HoTen;
        private byte _Tuoi;
        private string _HocVi;
        private string _NoiCongTac;
        private string _SoLuoc;
        private string _ChiTiet;
        private int _AnhID;
        private string _URL;
        private string _TenFile;
        private string _Facebook;
        private string _Twitter;
        private DBAccess db;

        public GiaoVien()
        {
            db = new DBAccess();
        }

        public short ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string HoTen
        {
            get { return _HoTen; }
            set { _HoTen = value; }
        }

        public string HocVi
        {
            get { return _HocVi; }
            set { _HocVi = value; }
        }

        public string NoiCongTac
        {
            get { return _NoiCongTac; }
            set { _NoiCongTac = value; }
        }

        public byte Tuoi
        {
            get { return _Tuoi; }
            set { _Tuoi = value; }
        }

        public string SoLuoc
        {
            get { return _SoLuoc; }
            set { _SoLuoc = value; }
        }

        public string ChiTiet
        {
            get { return _ChiTiet; }
            set { _ChiTiet = value; }
        }

        public int AnhID
        {
            get { return _AnhID; }
            set { _AnhID = value; }
        }

        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }

        public string TenFile
        {
            get { return _TenFile; }
            set { _TenFile = value; }
        }

        public string Facebook
        {
            get { return _Facebook; }
            set { _Facebook = value; }
        }

        public string Twitter
        {
            get { return _Twitter; }
            set { _Twitter = value; }
        }

        //===============================================================================

        public int Add(DataTable list)
        {
            int out0 = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("GiaoVien_tao");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@HoTen", this.HoTen));
                cmd.Parameters.Add(new SqlParameter("@Tuoi", this.Tuoi));
                cmd.Parameters.Add(new SqlParameter("@HocVi", this.HocVi));
                cmd.Parameters.Add(new SqlParameter("@NoiCongTac", this.NoiCongTac));
                cmd.Parameters.Add(new SqlParameter("@SoLuoc", this.SoLuoc));
                cmd.Parameters.Add(new SqlParameter("@ChiTiet", this.ChiTiet));
                cmd.Parameters.Add(new SqlParameter("@URL", this.URL));
                cmd.Parameters.Add(new SqlParameter("@Facebook", this.Facebook));
                cmd.Parameters.Add(new SqlParameter("@Twitter", this.Twitter));
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

        public int Update(DataTable list)
        {
            int out0 = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("GiaoVien_sua");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", this.ID));
                cmd.Parameters.Add(new SqlParameter("@HoTen", this.HoTen));
                cmd.Parameters.Add(new SqlParameter("@Tuoi", this.Tuoi));
                cmd.Parameters.Add(new SqlParameter("@HocVi", this.HocVi));
                cmd.Parameters.Add(new SqlParameter("@NoiCongTac", this.NoiCongTac));
                cmd.Parameters.Add(new SqlParameter("@SoLuoc", this.SoLuoc));
                cmd.Parameters.Add(new SqlParameter("@ChiTiet", this.ChiTiet));
                cmd.Parameters.Add(new SqlParameter("@AnhID", this.AnhID));
                cmd.Parameters.Add(new SqlParameter("@URL", this.URL));
                cmd.Parameters.Add(new SqlParameter("@Facebook", this.Facebook));
                cmd.Parameters.Add(new SqlParameter("@Twitter", this.Twitter));
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

        public int Delete(string list)
        {
            int out0 = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("GiaoVien_xoa");
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

        public GiaoVien FindByID(short ID)
        {
            GiaoVien gv = new GiaoVien();
            SqlConnection con = db.getConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("GiaoVien_chitiet");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", ID));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    gv.ID = smartReader.GetInt16("ID");
                    gv.HoTen = smartReader.GetString("HoTen");
                    gv.HocVi = smartReader.GetString("HocVi");
                    gv.NoiCongTac = smartReader.GetString("NoiCongTac");
                    gv.SoLuoc = smartReader.GetString("SoLuoc");
                    gv.Tuoi = smartReader.GetByte("Tuoi");
                    gv.ChiTiet = smartReader.GetString("ChiTiet");
                    gv.URL = smartReader.GetString("URL");
                    gv.Facebook = smartReader.GetString("Facebook");
                    gv.Twitter = smartReader.GetString("Twitter");
                    gv.AnhID = smartReader.GetInt32("AnhID");
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
            return gv;
        }

        public List<GiaoVien> GetList(string HoTen, byte MonHocID)
        {
            SqlConnection con = db.getConnection();
            List<GiaoVien> l_GiaoVien = new List<GiaoVien>();
            try
            {
                SqlCommand cmd = new SqlCommand("GiaoVien_timkiem");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@HoTen", HoTen));
                cmd.Parameters.Add(new SqlParameter("@MonHocID", MonHocID));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    GiaoVien gv = new GiaoVien();
                    gv.ID = smartReader.GetInt16("ID");
                    gv.HoTen = smartReader.GetString("HoTen");
                    gv.HocVi = smartReader.GetString("HocVi");
                    gv.NoiCongTac = smartReader.GetString("NoiCongTac");
                    gv.SoLuoc = smartReader.GetString("SoLuoc");
                    gv.Tuoi = smartReader.GetByte("Tuoi");
                    gv.AnhID = smartReader.GetInt32("AnhID");
                    gv.URL = smartReader.GetString("URL");
                    l_GiaoVien.Add(gv);
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
            return l_GiaoVien;
        }

        public List<GiaoVien> GetFamousList()
        {
            SqlConnection con = db.getConnection();
            List<GiaoVien> l_GiaoVien = new List<GiaoVien>();
            try
            {
                SqlCommand cmd = new SqlCommand("GiaoVien_timKiemTieuBieu");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    GiaoVien gv = new GiaoVien();
                    gv.ID = smartReader.GetInt16("ID");
                    gv.HoTen = smartReader.GetString("HoTen");
                    gv.SoLuoc = smartReader.GetString("SoLuoc");
                    gv.URL = smartReader.GetString("URL");
                    l_GiaoVien.Add(gv);
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
            return l_GiaoVien;
        }

        public List<GiaoVien> GetPaginationList(short pageNum, short limitPerPage)
        {
            SqlConnection con = db.getConnection();
            List<GiaoVien> l_GiaoVien = new List<GiaoVien>();
            try
            {
                SqlCommand cmd = new SqlCommand("GiaoVien_timKiemPhanTrang");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Page", pageNum));
                cmd.Parameters.Add(new SqlParameter("@Limit", limitPerPage));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    GiaoVien gv = new GiaoVien();
                    gv.ID = smartReader.GetInt16("ID");
                    gv.HoTen = smartReader.GetString("HoTen");
                    gv.SoLuoc = smartReader.GetString("SoLuoc");
                    gv.URL = smartReader.GetString("URL");
                    l_GiaoVien.Add(gv);
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
            return l_GiaoVien;
        }

        public int GetTotalPage(short limitPerPage)
        {
            int out0 = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("GiaoVien_totalPage");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Limit", limitPerPage));
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
