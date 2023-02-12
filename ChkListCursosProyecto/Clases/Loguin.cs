using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;

public class Loguin
{

    private string correo;
    private string contraseña;
    private string rol;
    private string nombre;

    public Loguin(string correo, string contraseña)
    {
        this.correo = correo;
        this.contraseña = contraseña;
    }

    public void setCorreo(string correo)
    {
        this.correo = correo;
    }

    public string getCorreo()
    {
        return this.correo;
    }
    public void setContraseña(string contraseña)
    {
        this.contraseña = contraseña;
    }

    public string getContraseña()
    {
        return this.contraseña;
    }

    public void setRol(string rol)
    {
        this.rol = rol;
    }

    public string getRol()
    {
        return this.rol;
    }

    public void setNombre(string nombre)
    {
        this.nombre = nombre;
    }

    public string getNombre()
    {
        return this.nombre;
    }

    public bool Ingresar()
    {
        string patron = "CLCURSOSUNIDEH";

        using (SqlConnection conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("ValidarAdministrador", conectar);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 150).Value = getCorreo(); ;
            cmd.Parameters.Add("@Pass", SqlDbType.VarChar, 50).Value = getContraseña();
            cmd.Parameters.Add("@patron", SqlDbType.VarChar, 50).Value = patron;
            cmd.Connection.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                setCorreo(Convert.ToString(dr["Email"]));
                setNombre(Convert.ToString(dr["NombreAdministrador"]));
                setRol("Administrador");
                cmd.Connection.Close();
                return true;
            }
            else
            {
                cmd.Connection.Close();
                SqlCommand cmd2 = new SqlCommand("ValidarInstructor", conectar);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add("@Email", SqlDbType.VarChar, 150).Value = getCorreo(); ;
                cmd2.Parameters.Add("@Pass", SqlDbType.VarChar, 50).Value = getContraseña();
                cmd2.Parameters.Add("@patron", SqlDbType.VarChar, 50).Value = patron;
                cmd2.Connection.Open();
                SqlDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    return true;
                }
                else
                {
                    cmd2.Connection.Close();
                    SqlCommand cmd3 = new SqlCommand("ValidarUsuario", conectar);
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.Add("@Email", SqlDbType.VarChar, 150).Value = getCorreo(); ;
                    cmd3.Parameters.Add("@Pass", SqlDbType.VarChar, 50).Value = getContraseña();
                    cmd3.Parameters.Add("@patron", SqlDbType.VarChar, 50).Value = patron;
                    cmd3.Connection.Open();
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    if (dr3.Read())
                    {
                        setCorreo(Convert.ToString(dr3["Email"]));
                        setNombre(Convert.ToString(dr3["NombreEmpleado"]));
                        setRol("Trabajador");
                        cmd3.Connection.Close();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }

    public void CerrarSession()
    {
        setCorreo("");
        setContraseña("");
        setRol("");
        setNombre("");
    }

}