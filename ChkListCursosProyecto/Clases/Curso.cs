
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Web.UI.WebControls;
using System.Runtime.CompilerServices;

public class Curso
{

    protected int idCurso;
    protected string nombreCurso;
    protected int idInstructor;
    private int capacidad;
    private string duracion;
    protected string fechaInicio;
    private string dirigidoA;
    private string hora;

    public Curso()
    {

    }

    public Curso(int idCurso, string nombreCurso, int idInstructor, int capacidad, string duracion, string fechaInicio, string dirigidoA, string hora){
        this.idCurso = idCurso;
        this.nombreCurso = nombreCurso;
        this.idInstructor = idInstructor;
        this.capacidad = capacidad;
        this.duracion = duracion;
        this.fechaInicio = fechaInicio;
        this.dirigidoA = dirigidoA;
        this.hora = hora;
    }

    public Curso(int id)
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            cn.Open();
            string sql = "SELECT idCurso,NombreCurso,idInstructor, Capacidad, Duracion,FORMAT(FechaInicio, 'yyyy-MM-dd') as FechaInicio, DirigidoA, Hora FROM Curso WHERE idCurso =@id";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                this.idCurso = int.Parse(reader["idCurso"].ToString());
                this.nombreCurso = Convert.ToString(reader["NombreCurso"]); ;
                this.idInstructor = int.Parse(reader["idInstructor"].ToString());
                this.capacidad = int.Parse(reader["Capacidad"].ToString());
                this.duracion = Convert.ToString(reader["Duracion"]); ;
                this.fechaInicio = Convert.ToString(reader["FechaInicio"]);;
                this.dirigidoA = Convert.ToString(reader["DirigidoA"]);
                this.hora = Convert.ToString(reader["Hora"]);
            }

        }

    }


    public void setIdCurso(int idCurso)
    {
        this.idCurso = idCurso;
    }

    public int getIdCurso()
    {
        return this.idCurso;
    }

    public void setNombreCurso(string nombreCurso)
    {
        this.nombreCurso = nombreCurso;
    }

    public string getNombreCurso()
    {
        return this.nombreCurso;
    }

    public void setIdInstructor(int idInstructor)
    {
        this.idInstructor = idInstructor;
    }

    public int getIdInstructor()
    {
        return this.idInstructor;
    }

    public void setCapacidad(int capacidad)
    {
        this.capacidad = capacidad;
    }

    public int getCapacidad()
    {
        return this.capacidad;
    }

    public void setDuracion(string duracion)
    {
        this.duracion = duracion;
    }

    public string getDuracion()
    {
        return this.duracion;
    }

    public void setFechaInicio(string fechaInicio)
    {
        this.fechaInicio = fechaInicio;
    }

    public string getFechaInicio()
    {
        return this.fechaInicio;
    }

    public void setDirigidoA(string dirigidoA)
    {
        this.dirigidoA = dirigidoA;
    }

    public string getDirigidoA()
    {
        return this.dirigidoA;
    }

    public void setHora(string hora)
    {
        this.hora = hora;
    }

    public string getHora()
    {
        return this.hora;
    }

    public DataTable CursosDisponibles()
    {
        using (SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SelectCurDiponibles";
            cmd.Connection = cone;
            cone.Open();

            DataTable lista = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(lista);

            cone.Close();

            return lista;

        }
    }

    public List<string> Autocompeltado(String palabra ) {
        List<string> lista = new List<string>();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        con.Open();

        string sql = "SELECT NombreCurso FROM Curso where NombreCurso LIKE '%' + @search +'%'";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@search", palabra);

        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            lista.Add(sdr.GetString(0));
        }
        con.Close();

        return lista;
    }

    public DataTable Busqueda(string bus) {
        using (SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "busquedaCursos";
            cmd.Parameters.AddWithValue("@search", bus);
            cmd.Connection = cone;
            cone.Open();

            DataTable lista = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(lista);

            cone.Close();

            return lista;
        }
    }

    public void DatosModal(int row) {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            cn.Open();

            string sql = "SELECT idCurso,NombreCurso, DirigidoA, idInstructor, Capacidad, FORMAT(FechaInicio, 'yyyy-MM-dd') as FechaInicio, Hora, Duracion FROM Curso WHERE idCurso =@id ";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@id", row);

            SqlDataReader reader = cmd.ExecuteReader();


            if (reader.Read())
            {

                setIdCurso(int.Parse(reader["idCurso"].ToString()));
                setNombreCurso(Convert.ToString(reader["NombreCurso"]));
                setDirigidoA(Convert.ToString(reader["DirigidoA"]));
                setIdInstructor(int.Parse(reader["idInstructor"].ToString()));
                setCapacidad(int.Parse(reader["Capacidad"].ToString()));
                setFechaInicio(Convert.ToString(reader["FechaInicio"]));
                setHora(Convert.ToString(reader["Hora"]));
                setDuracion(Convert.ToString(reader["Duracion"]));
            }

            cn.Close();

        }
    }

    public DataSet cargarDrowDownList() {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            cn.Open();

            string sql = "SELECT idCurso,NombreCurso FROM Curso";
            SqlCommand cmd = new SqlCommand(sql, cn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cn.Close();

            return ds;

        }
    }


}