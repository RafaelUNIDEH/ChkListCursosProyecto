
using Microsoft.SqlServer.Server;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using ChkListCursosProyecto.Secciones_trabajador;
using System.Security.Policy;

public class StatusCurso : Curso {
    private int idCursoRegistrado;
    private string nombreEmpleado;
    private string nombreInstructor;
    private DateTime fechaVencimiento;
    private string vencimientoSting;
    private string status;

    public StatusCurso() {
    }

    public StatusCurso(int idCursoRegistrado, string nombreEmpleado, string nombreCurso, string nombreInstructor, string fechaCapacitacion, DateTime fechaVencimiento, string status) {
        this.idCursoRegistrado = idCursoRegistrado;
        this.nombreEmpleado = nombreEmpleado;
        base.nombreCurso = nombreCurso;
        this.nombreInstructor = nombreInstructor;
        base.idInstructor = idInstructor;
        base.fechaInicio = fechaInicio;
        this.fechaVencimiento = fechaVencimiento;
        this.status = status;
    }

    public StatusCurso(string nombreEmpleado){
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            cn.Open();
            string sql = "SELECT * FROM StatusCursos WHERE nombreEmpleado =@nombre";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@nombre", nombreEmpleado);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                this.idCursoRegistrado = int.Parse(reader["idEmpleado"].ToString());
                this.nombreEmpleado = Convert.ToString(reader["nombreEmpleado"]);
                this.nombreCurso = Convert.ToString(reader["nombreCurso"]);
                this.nombreInstructor = Convert.ToString(reader["nombreInstructor"]);
                this.fechaInicio = Convert.ToString(reader["fechaCpacitacion"]);
                this.fechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                this.status = Convert.ToString(reader["Estatus"]);
            }

        }

    }

    public void setIdCursoRegistrado(int idCursoRegistrado)
    {
        this.idCursoRegistrado = idCursoRegistrado;
    }

    public int getIdCursoRegistrado()
    {
        return this.idCursoRegistrado;
    }

    public void setNombreEmpleado(string nombreEmpleado)
    {
        this.nombreEmpleado = nombreEmpleado;
    }

    public string getNombreEmpleado()
    {
        return this.nombreEmpleado;
    }

    public void setNombreInstructor(string nombreInstructor)
    {
        this.nombreInstructor = nombreInstructor;
    }

    public string getNombreInstructor()
    {
        return this.nombreInstructor;
    }

    public void setFechaVencimiento(DateTime fechaVencimiento)
    {
        this.fechaVencimiento = fechaVencimiento;
    }

    public DateTime getFechaVencimiento()
    {
        return this.fechaVencimiento;
    }

    public void setVencimientoSting(string vencimientoSting)
    {
        this.vencimientoSting = vencimientoSting;
    }

    public string getVencimientoSting()
    {
        return this.vencimientoSting;
    }

    public void setStatus(string status)
    {
        this.status = status;
    }

    public string getStatus()
    {
        return this.status;
    }

    public DataTable MisCursos(string nombreTrabajador)
    {

        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            cn.Open();

            string sql = "SELECT IdCursoRegistrado 'ID',nombreCurso 'Curso', Estatus 'Estatus' FROM StatusCursos WHERE nombreEmpleado =@name ";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@name", nombreTrabajador);

            DataTable miscursos = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(miscursos);

            cn.Close();

            return miscursos;

        }
    }

    public void ModalMisCursos(int row)
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            cn.Open();

            string sql = "SELECT IdCursoRegistrado,nombreEmpleado, nombreCurso, nombreInstructor,  FORMAT(fechaCpacitacion, 'yyyy-MM-dd') as fechaCpacitacion,  FORMAT(fechaVencimiento, 'yyyy-MM-dd') as fechaVencimiento, Estatus FROM StatusCursos WHERE IdCursoRegistrado =@id ";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@id", row);

            SqlDataReader reader = cmd.ExecuteReader();


            if (reader.Read())
            {
                setIdCursoRegistrado(int.Parse(reader["IdCursoRegistrado"].ToString()));
                setNombreEmpleado(Convert.ToString(reader["nombreEmpleado"]));
                setNombreCurso(Convert.ToString(reader["nombreCurso"]));
                setNombreInstructor(Convert.ToString(reader["nombreInstructor"]));
                setFechaInicio(Convert.ToString(reader["fechaCpacitacion"]));
                setFechaVencimiento(DateTime.Parse(reader["fechaVencimiento"].ToString()));
                setVencimientoSting(Convert.ToString(reader["fechaVencimiento"]));
                setStatus(Convert.ToString(reader["Estatus"]));
            }

            cn.Close();

        }
    }

    public void VerificarStatus(string nombreUsuario) {

        DataTable fechas = new DataTable();

        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            cn.Open();

            string sql = "SELECT IdCursoRegistrado 'ID',fechaVencimiento 'fecha' FROM StatusCursos WHERE nombreEmpleado =@name ";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@name", nombreUsuario);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(fechas);

            cn.Close();
        }

        DateTime fechaActual = DateTime.Now;
        DateTime fechaprevia;
        for (int i = 0; i < fechas.Rows.Count; i++)
        {
            this.fechaVencimiento = DateTime.Parse(fechas.Rows[i]["fecha"].ToString());


            fechaprevia = fechaVencimiento.AddDays(-15);

            if (DateTime.Compare(fechaActual, fechaprevia) != -1)
            {
                Console.WriteLine((DateTime.Compare(fechaActual, this.fechaVencimiento)).ToString());
                if (DateTime.Compare(fechaActual,this.fechaVencimiento) == -1)
                {
                    //Atualizo por vencer
                    using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
                    {
                        cn.Open();

                        string sql = "UPDATE StatusCursos SET Estatus = 'Por vencer' WHERE IdCursoRegistrado = @id";
                        SqlCommand cmd = new SqlCommand(sql, cn);
                        cmd.Parameters.AddWithValue("@id",int.Parse(fechas.Rows[i]["ID"].ToString()) );

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            cn.Close();
                            continue;
                        }
                    }
                }
                if ((DateTime.Compare(fechaActual, this.fechaVencimiento) == 0) || (DateTime.Compare(fechaActual, this.fechaVencimiento) == 1)) {
                    //Acualizo vencido
                    using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
                    {
                        cn.Open();

                        string sql = "UPDATE StatusCursos SET Estatus = 'Vencido' WHERE IdCursoRegistrado =@id";
                        SqlCommand cmd = new SqlCommand(sql, cn);
                        cmd.Parameters.AddWithValue("@id", int.Parse(fechas.Rows[i]["ID"].ToString()));

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            cn.Close();
                            continue;
                        }
                    }
                }
            }
            else {
                continue;
            }


        }



     }

}