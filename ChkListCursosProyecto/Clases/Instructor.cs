

using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Data;

public class Instructor {
    private int idInstructor;
    private string nombreInstructor;
    private int noInstructor;
    private string email;

    public Instructor() { 
    }

    public Instructor(int idInstructor, string nombreInstructor, int noInstructor, string email)
    {
        this.idInstructor = idInstructor;
        this.nombreInstructor = nombreInstructor;
        this.noInstructor = noInstructor;
        this.email = email;
    }

    public Instructor(int id) {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            cn.Open();
            string sql = "SELECT * FROM Instructor WHERE idInstructor =@id";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                this.idInstructor = int.Parse(reader["idInstructor"].ToString());
                this.nombreInstructor = Convert.ToString(reader["NombreInstructor"]);
                this.noInstructor = int.Parse(reader["NoInstructor"].ToString());
                this.email = Convert.ToString(reader["Email"]);
            }

        }
    }

    public void setIdInstructor(int idInstructor)
    {
        this.idInstructor = idInstructor;
    }

    public int getIdInstructor()
    {
        return this.idInstructor;
    }

    public void setNombreInstructor(string nombreInstructor)
    {
        this.nombreInstructor = nombreInstructor;
    }

    public string getNombreInstructor()
    {
        return this.nombreInstructor;
    }

    public void setNoInstructor(int noInstructor)
    {
        this.noInstructor = noInstructor;
    }

    public int getNoInstructor()
    {
        return this.noInstructor;
    }

    public void setEmail(string email)
    {
        this.email = email;
    }

    public string getEmail()
    {
        return this.email;
    }

    public DataSet cargarDrowinstructores()
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            cn.Open();

            string sql = "SELECT idInstructor,NombreInstructor FROM Instructor";
            SqlCommand cmd = new SqlCommand(sql, cn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cn.Close();

            return ds;

        }
    }

    public DataSet CargarCursosAsigados(int idInstructor) {
        DateTime fechaActual = DateTime.Now;
        using (SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SeleccionarCursosImpartidos";
            cmd.Parameters.AddWithValue("@idInstructor", idInstructor);
            cmd.Parameters.AddWithValue("@FechaActual", fechaActual);
            cmd.Connection = cone;
            cone.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cmd.Connection.Close();

            return ds;

        }

    }

    public DataTable ParticipantesCurso(int idCurso) {
        using (SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ParticipantesCurso";
            cmd.Parameters.AddWithValue("@idCurso", idCurso);
            cmd.Connection = cone;
            cone.Open();

            DataTable lista = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(lista);

            cone.Close();

            return lista;

        }

    }

    public void AsignarCalificacion(DataTable dt) {
        for (int i = 0; i < dt.Rows.Count; i++) {
            this.fechaVencimiento = DateTime.Parse(fechas.Rows[i]["fecha"].ToString());
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("CalificarCurso", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nombreEmpleado", SqlDbType.VarChar, 250).Value = dt.Rows[i]["fecha"].ToString();
                cmd.Parameters.Add("@nombreCurso", SqlDbType.VarChar, 250).Value = dt.Rows[i]["fecha"].ToString()
                cmd.Parameters.Add("@@nombreInstructor", SqlDbType.VarChar, 250).Value = dt.Rows[i]["fecha"].ToString()
                cmd.Parameters.Add("@fechaCpacitacion", SqlDbType.Date).Value = dt.Rows[i]["fecha"].ToString()
                cmd.Parameters.Add("@fechaVencimiento", SqlDbType.Date).Value = dt.Rows[i]["fecha"].ToString()
                cmd.Parameters.Add("@estatus", SqlDbType.VarChar, 50).Value = dt.Rows[i]["fecha"].ToString()
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }

        }

    }

}