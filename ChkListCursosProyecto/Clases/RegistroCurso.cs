
using ChkListCursosProyecto.Secciones_trabajador;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class RegistroCurso : Curso {

    private int idEmpleado;

    public RegistroCurso()
    {
        
    }

    public RegistroCurso(int idCurso) : base(idCurso)
    {
        this.idCurso = idCurso;
    }

    public bool RealizarRgistro(int idEmpleado, int idCurso, int idInstructor) {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Registrar_empleado_a_curso";
            cmd.Parameters.Add("@idEmpleado", SqlDbType.Int).Value = idEmpleado;
            cmd.Parameters.Add("@idCurso", SqlDbType.Int).Value = idCurso;
            cmd.Parameters.Add("@idInstructor", SqlDbType.Int).Value = idInstructor;
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return true;
        }
    }

    public bool ComprobarNoRegistro(int idEmpleado, int idCurso) {

        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Comprobar_no_registro", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            cmd.Parameters.Add("@idEmpleado", SqlDbType.Int).Value = idEmpleado;
            cmd.Parameters.Add("@idCurso", SqlDbType.Int).Value = idCurso;
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                cn.Close();
                return true;
            }
            else {
                cn.Close();
                return false;
            }
        }
           
    }

    public bool RestarLugar(int idCurso)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Actualizar_lugares_disponibles_curso";
            cmd.Parameters.Add("@idCurso", SqlDbType.Int).Value = idCurso;
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return true;
        }
    }

}