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
    public class LopHoc
    {
        private short _ID;
        private string _TenLopHoc;
        private short _SoLuong;
        private string _NgayNhan;
        private string _HanChot;
        private string _NgayNhapHoc;
        private string _MoTa;
        private byte _MonHocID;
        private string _TenMonHoc;
        private decimal _HocPhi;
        private string _LichHoc;
        private bool _NhanHocVien;
        private byte _LoaiHocPhiID;
        private byte _Khoi;
        private bool _DangKy;
        private DBAccess db;

        public LopHoc()
        {
            db = new DBAccess();
        }

        public short ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string TenLopHoc
        {
            get { return _TenLopHoc; }
            set { _TenLopHoc = value; }
        }

        public short SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }

        public string NgayNhan
        {
            get { return _NgayNhan; }
            set { _NgayNhan = value; }
        }

        public string HanChot
        {
            get { return _HanChot; }
            set { _HanChot = value; }
        }

        public string NgayNhapHoc
        {
            get { return _NgayNhapHoc; }
            set { _NgayNhapHoc = value; }
        }

        public byte MonHocID
        {
            get { return _MonHocID; }
            set { _MonHocID = value; }
        }

        public string MoTa
        {
            get { return _MoTa; }
            set { _MoTa = value; }
        }

        public string TenMonHoc
        {
            get { return _TenMonHoc; }
            set { _TenMonHoc = value; }
        }

        public string LichHoc
        {
            get { return _LichHoc; }
            set { _LichHoc = value; }
        }

        public decimal HocPhi
        {
            get { return _HocPhi; }
            set { _HocPhi = value; }
        }

        public byte LoaiHocPhiID
        {
            get { return _LoaiHocPhiID; }
            set { _LoaiHocPhiID = value; }
        }

        public bool NhanHocVien
        {
            get { return _NhanHocVien; }
            set { _NhanHocVien = value; }
        }

        public byte Khoi
        {
            get { return _Khoi; }
            set { _Khoi = value; }
        }

        public bool DangKy
        {
            get { return _DangKy; }
            set { _DangKy = value; }
        }

        //===============================================================================

        public int Add()
        {
            int out0 = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("LopHoc_tao");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TenLopHoc", this.TenLopHoc));
                cmd.Parameters.Add(new SqlParameter("@NgayNhan", this.NgayNhan));
                cmd.Parameters.Add(new SqlParameter("@HanChot", this.HanChot));
                cmd.Parameters.Add(new SqlParameter("@NgayNhapHoc", this.NgayNhapHoc));
                cmd.Parameters.Add(new SqlParameter("@MoTa", this.MoTa));
                cmd.Parameters.Add(new SqlParameter("@MonHocID", this.MonHocID));
                cmd.Parameters.Add(new SqlParameter("@HocPhi", this.HocPhi));
                cmd.Parameters.Add(new SqlParameter("@LichHoc", this.LichHoc));
                cmd.Parameters.Add(new SqlParameter("@NhanHocVien", this.NhanHocVien));
                cmd.Parameters.Add(new SqlParameter("@LoaiHocPhiID", this.LoaiHocPhiID));
                cmd.Parameters.Add(new SqlParameter("@Khoi", this.Khoi));
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
                SqlCommand cmd = new SqlCommand("LopHoc_sua");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", this.ID));
                cmd.Parameters.Add(new SqlParameter("@TenLopHoc", this.TenLopHoc));
                cmd.Parameters.Add(new SqlParameter("@SoLuong", this.SoLuong));
                cmd.Parameters.Add(new SqlParameter("@NgayNhan", this.NgayNhan));
                cmd.Parameters.Add(new SqlParameter("@HanChot", this.HanChot));
                cmd.Parameters.Add(new SqlParameter("@NgayNhapHoc", this.NgayNhapHoc));
                cmd.Parameters.Add(new SqlParameter("@MoTa", this.MoTa));
                cmd.Parameters.Add(new SqlParameter("@MonHocID", this.MonHocID));
                cmd.Parameters.Add(new SqlParameter("@HocPhi", this.HocPhi));
                cmd.Parameters.Add(new SqlParameter("@LichHoc", this.LichHoc));
                cmd.Parameters.Add(new SqlParameter("@NhanHocVien", this.NhanHocVien));
                cmd.Parameters.Add(new SqlParameter("@LoaiHocPhiID", this.LoaiHocPhiID));
                cmd.Parameters.Add(new SqlParameter("@Khoi", this.Khoi));
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
                SqlCommand cmd = new SqlCommand("DangKy_xoa");
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

        public int Activate(string list)
        {
            int out0 = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("DangKy_kichhoat");
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

        public LopHoc FindByID(short ID)
        {
            LopHoc lh = new LopHoc();
            SqlConnection con = db.getConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("LopHoc_chitiet");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", ID));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    lh.ID = smartReader.GetInt16("ID");
                    lh.TenLopHoc = smartReader.GetString("TenLopHoc");
                    lh.SoLuong = smartReader.GetInt16("SoLuong");
                    lh.NgayNhan = smartReader.GetString("NgayNhan");
                    lh.HanChot = smartReader.GetString("HanChot");
                    lh.NgayNhapHoc = smartReader.GetString("NgayNhapHoc");
                    lh.MonHocID = smartReader.GetByte("MonHocID");
                    lh.HocPhi = smartReader.GetDecimal("HocPhi");
                    lh.LichHoc = smartReader.GetString("LichHoc");
                    lh.MoTa = smartReader.GetString("MoTa");
                    lh.NhanHocVien = smartReader.GetBoolean("NhanHocVien");
                    lh.LoaiHocPhiID = smartReader.GetByte("LoaiHocPhiID");
                    lh.Khoi = smartReader.GetByte("Khoi");
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
            return lh;
        }

        public List<LopHoc> GetList(string TenLopHoc, byte MonHocID, string NhanHocVien, byte Khoi, string username)
        {
            SqlConnection con = db.getConnection();
            List<LopHoc> l_LopHoc = new List<LopHoc>();
            try
            {
                SqlCommand cmd = new SqlCommand("LopHoc_timkiem");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TenLopHoc", TenLopHoc));
                cmd.Parameters.Add(new SqlParameter("@MonHocID", MonHocID));
                cmd.Parameters.Add(new SqlParameter("@NhanHocVien", NhanHocVien));
                cmd.Parameters.Add(new SqlParameter("@Khoi", Khoi));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    LopHoc lh = new LopHoc();
                    lh.ID = smartReader.GetInt16("ID");
                    lh.TenLopHoc = smartReader.GetString("TenLopHoc");
                    lh.SoLuong = smartReader.GetInt16("SoLuong");
                    lh.NgayNhan = smartReader.GetString("NgayNhan");
                    lh.HanChot = smartReader.GetString("HanChot");
                    lh.NgayNhapHoc = smartReader.GetString("NgayNhapHoc");
                    lh.TenMonHoc = smartReader.GetString("TenMonHoc");
                    lh.HocPhi = smartReader.GetDecimal("HocPhi");
                    lh.LichHoc = smartReader.GetString("LichHoc");
                    lh.NhanHocVien = smartReader.GetBoolean("NhanHocVien");
                    lh.LoaiHocPhiID = smartReader.GetByte("LoaiHocPhiID");
                    lh.Khoi = smartReader.GetByte("Khoi");
                    lh.DangKy = CheckDangKy(username, lh.ID);
                    l_LopHoc.Add(lh);
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
            return l_LopHoc;
        }

        public bool CheckDangKy(string username, int lophocid)
        {
            if (username == "") return false;
            else
            {
                int out0 = 0;
                try
                {
                    SqlCommand cmd = new SqlCommand("Hocvien_checkdangky");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@username", username));
                    cmd.Parameters.Add(new SqlParameter("@lophocid", lophocid));
                    cmd.Parameters.Add("@out", SqlDbType.Int).Direction = ParameterDirection.Output;
                    db.ExecuteSQL(cmd);
                    out0 = Convert.ToInt32(cmd.Parameters["@out"].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return out0 == 0 ? true : false;
            }
            
        }
    }
}
