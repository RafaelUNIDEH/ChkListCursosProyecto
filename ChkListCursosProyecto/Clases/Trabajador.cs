using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public class Trabajador
{

    private int idEmpleado;
    private string nombreEmpleado;
    private int noEmpleado;
    private int idArea;
    private string email;

    public Trabajador() { 
    }

    public Trabajador(int idEmpleado, string nombreEmpleado, int noEmpleado, int idArea, string email)
    {
        this.idEmpleado = idEmpleado;
        this.nombreEmpleado = nombreEmpleado;
        this.noEmpleado = noEmpleado;
        this.idArea = idArea;
        this.email = email;
    }

    public Trabajador(int idEmpleado, string vacio)
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            cn.Open();
            string sql = "SELECT * FROM Empleado WHERE idEmpleado =@idEmpleado";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                this.idEmpleado = int.Parse(reader["idEmpleado"].ToString());
                this.nombreEmpleado = Convert.ToString(reader["NombreEmpleado"]);
                this.noEmpleado = int.Parse(reader["NoEmpleado"].ToString());
                this.idArea = int.Parse(reader["idArea"].ToString());
                this.email = Convert.ToString(reader["Email"]);
            }

        }
    }

    public Trabajador(int numEmpleado)
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            cn.Open();
            string sql = "SELECT * FROM Empleado WHERE NoEmpleado =@numEmpleado";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@numEmpleado", numEmpleado);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                this.idEmpleado = int.Parse(reader["idEmpleado"].ToString());
                this.nombreEmpleado = Convert.ToString(reader["NombreEmpleado"]);
                this.noEmpleado = int.Parse(reader["NoEmpleado"].ToString());
                this.idArea = int.Parse(reader["idArea"].ToString());
                this.email = Convert.ToString(reader["Email"]);
            }

        }
    }

    public Trabajador(string email)
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            cn.Open();
            string sql = "SELECT idEmpleado FROM Empleado WHERE Email =@email";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@email", email);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                this.idEmpleado = int.Parse(reader["idEmpleado"].ToString());
            }

        }

    }

    public void setIdEmpleado(int idEmpleado)
    {
        this.idEmpleado = idEmpleado;
    }

    public int getIdEmpleado()
    {
        return this.idEmpleado;
    }

    public void setNombreEmpleado(string nombreEmpleado)
    {
        this.nombreEmpleado = nombreEmpleado;
    }

    public string getNombreEmpleado()
    {
        return this.nombreEmpleado;
    }

    public void setNoEmpleado(int noEmpleado)
    {
        this.noEmpleado = noEmpleado;
    }

    public int getNoEmpleado()
    {
        return this.noEmpleado;
    }

    public void setIdArea(int idArea)
    {
        this.idArea = idArea;
    }

    public int getIdArea()
    {
        return this.idArea;
    }

    public void setEmail(string email)
    {
        this.email = email;
    }

    public string getEmail()
    {
        return this.email;
    }

    public string ConsultarQR(int id) {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            cn.Open();

            string sql = "SELECT imgQR FROM Codigo WHERE idEmpleado =@id ";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

            SqlDataReader reader = cmd.ExecuteReader();


            if (reader.Read())
            {

                byte[] imageBytes = (byte[])reader["imgQR"];

                string cadena = "data: image/Jpeg;base64," + Convert.ToBase64String(imageBytes);

                cn.Close();

                return cadena;

            }
            else {
                return "error al importar QR";
            }
        }
    }
}