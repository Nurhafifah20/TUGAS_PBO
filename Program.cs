using Npgsql;
using System.Data;

namespace TugasPbo
{
    class getting_data
    {
        private static NpgsqlConnection koneksi()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=cantik8:);database=latihan;");
        }
        public bool ExecuteQuery(out bool info)

        {
            info = true;
            try
            {

                NpgsqlConnection con = koneksi();
                con.Open();
                string sql = "select * from pembeli";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return info;

            }
            catch (Exception)
            {
                info = false;
                return info;
            }

        }
    }
    class operasi
    {
        private static NpgsqlConnection koneksi()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=cantik8:);database=latihan;");
        }
        public bool insert(ref bool info)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("insert into pembeli(id_pembeli,nama_pembeli,no_telp,alamat_pembeli) values(7,'Yuda','08983436578','Jalan Hayam Wuruk')", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }

        }

        public bool update(ref bool info)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("update pembeli set nama_pembeli = Qiandra, where id_pembeli = 4 ", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }

        }
        public bool Delete(ref bool info)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("delete from pembeli where id_pembeli = 2 ", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }

        }
    }

    class program_utama
    {

        static void Main(string[] args)
        {
            bool info;
            bool ingfo = false;
            getting_data dat = new getting_data();
            operasi op = new operasi();
            if (dat.ExecuteQuery(out info) == true)
            {
                Console.WriteLine("sukses mengambil data");
            }
            else if (dat.ExecuteQuery(out info) == false)
            {
                Console.WriteLine("gagal mengambil data");
            }
            if (op.insert(ref ingfo) == true)
            {
                Console.WriteLine("selamat insert berhasil");
            }
            else if (op.insert(ref ingfo) == false)
            {
                Console.WriteLine("Maaf insert gagal");
            }
            if (op.update(ref ingfo) == true)
            {
                Console.WriteLine("selamat update berhasil");
            }
            else if (op.update(ref ingfo) == false)
            {
                Console.WriteLine("Maaf update gagal");
            }
            if (op.Delete(ref ingfo) == true)
            {
                Console.WriteLine("selamat delete berhasil");
            }
            else if (op.Delete(ref ingfo) == false)
            {
                Console.WriteLine("Maaf delete gagal");
            }
        }
    }
}