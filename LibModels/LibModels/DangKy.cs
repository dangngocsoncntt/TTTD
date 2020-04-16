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
    public class DangKy
    {
        private int _ID;
        private int _HocVienID;
        private short _LopHocID;
        private string _NgayDangKy;
        private byte _TrangThaiID;
        private string _IP;
        private string _Username;               // new; 
        private string _Password;               // new

        // chức năng tìm kiếm
        private string _TenLopHoc;
        private string _HoTen;
        private byte _Tuoi;
        private string _DiaChi;
        private string _Email;
        private string _SDT;
        private string _TenTrangThai;
        private DBAccess db;

        public DangKy()
        {
            db = new DBAccess();
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public int HocVienID
        {
            get { return _HocVienID; }
            set { _HocVienID = value; }
        }

        public short LopHocID
        {
            get { return _LopHocID; }
            set { _LopHocID = value; }
        }

        public string NgayDangKy
        {
            get { return _NgayDangKy; }
            set { _NgayDangKy = value; }
        }

        public byte TrangThaiID
        {
            get { return _TrangThaiID; }
            set { _TrangThaiID = value; }
        }

        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }

        public string TenLopHoc
        {
            get { return _TenLopHoc; }
            set { _TenLopHoc = value; }
        }

        public string HoTen
        {
            get { return _HoTen; }
            set { _HoTen = value; }
        }

        public byte Tuoi
        {
            get { return _Tuoi; }
            set { _Tuoi = value; }
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

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string SDT
        {
            get { return _SDT; }
            set { _SDT = value; }
        }

        public string TenTrangThai
        {
            get { return _TenTrangThai; }
            set { _TenTrangThai = value; }
        }

        //===============================================================================

        public int Add()
        {
            int out0 = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("HocVien_dangky");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@HoTen", this.HoTen));
                cmd.Parameters.Add(new SqlParameter("@Tuoi", this.Tuoi));
                cmd.Parameters.Add(new SqlParameter("@DiaChi", this.DiaChi));
                cmd.Parameters.Add(new SqlParameter("@Email", this.Email));
                cmd.Parameters.Add(new SqlParameter("@SDT", this.SDT));
                cmd.Parameters.Add(new SqlParameter("@LopHocID", this.LopHocID));
                cmd.Parameters.Add(new SqlParameter("@IP", this.IP));
                cmd.Parameters.Add(new SqlParameter("@Username", this.Username));
                cmd.Parameters.Add(new SqlParameter("@Password", this.Password));
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
                SqlCommand cmd = new SqlCommand("HocVien_xoa");
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

        public List<DangKy> GetList(string IDsDangKy, short LopHocID, string TenHocVien, string IP)
        {
            SqlConnection con = db.getConnection();
            List<DangKy> l_DangKy = new List<DangKy>();
            try
            {
                SqlCommand cmd = new SqlCommand("DangKy_timkiem");
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IDsDangKy", IDsDangKy));
                cmd.Parameters.Add(new SqlParameter("@LopHocID", LopHocID));
                cmd.Parameters.Add(new SqlParameter("@TenHocVien", TenHocVien));
                cmd.Parameters.Add(new SqlParameter("@IP", IP));
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    DangKy dk = new DangKy();
                    dk.ID = smartReader.GetInt32("ID");
                    dk.TenLopHoc = smartReader.GetString("TenLopHoc");
                    dk.HoTen = smartReader.GetString("HoTen");
                    dk.Tuoi = smartReader.GetByte("Tuoi");
                    dk.DiaChi = smartReader.GetString("DiaChi");
                    dk.Email = smartReader.GetString("Email");
                    dk.SDT = smartReader.GetString("SDT");
                    dk.NgayDangKy = smartReader.GetString("NgayDangKy");
                    dk.IP = smartReader.GetString("IP");
                    dk.HocVienID = smartReader.GetInt32("HocVienID");
                    dk.TenTrangThai = smartReader.GetString("TenTrangThai");
                    l_DangKy.Add(dk);
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
            return l_DangKy;
        }
    }
}
