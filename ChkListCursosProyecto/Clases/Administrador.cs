
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.IO;
using System.Drawing;
using MessagingToolkit.QRCode.Codec;
using System.Web;
using System.Drawing.Imaging;
using static System.Net.WebRequestMethods;
using System.Security.Permissions;
using Microsoft.SqlServer.Server;
using static System.Windows.Forms.MonthCalendar;

public class Administrador {
    private int idAdministrador;
    private string nombreAdministrador;
    private int noEmpleado;
    private int idArea;
    private string email;

    public Administrador()
    {
    }

    public Administrador(int id)
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            cn.Open();
            string sql = "SELECT * FROM Administrador WHERE idAdministrador =@id";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                this.idAdministrador = int.Parse(reader["idAdministrador"].ToString());
                this.nombreAdministrador = Convert.ToString(reader["NombreAdministrador"]);
                this.noEmpleado = int.Parse(reader["NoEmpleado"].ToString());
                this.idArea = int.Parse(reader["idArea"].ToString());
                this.email = Convert.ToString(reader["Email"]);
                cmd.Connection.Close();
            }

        }
    }

    public void setIdAdministrador(int idAdministrador)
    {
        this.idAdministrador = idAdministrador;
    }

    public int getIdAdministrador()
    {
        return this.idAdministrador;
    }

    public void setNombreAdministrador(string nombreAdministrador)
    {
        this.nombreAdministrador = nombreAdministrador;
    }

    public string getNombreAdministrador()
    {
        return this.nombreAdministrador;
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

    public string InsertarArea(string nombre) {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            string sql = "Select * FROM Area WHERE NombreArea = @area";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@area", SqlDbType.VarChar).Value = nombre;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                cmd.Connection.Close();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "insertArea";
                cmd2.Parameters.Add("@NombreArea", SqlDbType.VarChar).Value = nombre;
                cmd2.Connection = conn;
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
                return "correcto";
            }
            else
            {
                cmd.Connection.Close();
                return "Ya existe un departamento con este nombre";
            }

        }
    }

    public string modificarArea(int id, string nombre, string nombreactual) {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {

            if (nombre == nombreactual)
            {
                return "El nombre de area es el mismo que tiene actualmente";
            }
            else
            {
                string sql = "Select * FROM Area WHERE NombreArea = @area";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = email;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    cmd.Connection.Close();
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.CommandText = "updateArea";
                    cmd2.Parameters.Add("@idArea", SqlDbType.Int).Value = id;
                    cmd2.Parameters.Add("@NombreArea", SqlDbType.VarChar).Value = nombre;
                    cmd2.Connection.Open();
                    cmd2.ExecuteNonQuery();
                    cmd2.Connection.Close();

                    return "correcto";

                }
                else
                {
                    cmd.Connection.Close();
                    return "Ya existe un departamento con este nombre";
                }
            }
        }
    }

    public void eliminarArea(int id) {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            string sql = "Delete FROM Registro_a_curso WHERE idArea = @id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read()) {
                cmd.Connection.Close();
                DataTable usuarios = new DataTable();

                string sql2 = "SELECT  FROM idEmpleado WHERE idArea = @id";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                cmd2.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(usuarios);
                cmd2.Connection.Close();

                for (int i = 0; i < usuarios.Rows.Count; i++) {
                    int idUser = int.Parse(usuarios.Rows[i]["idEmpleado"].ToString());

                    string sql3 = "Delete FROM Codigo WHERE idEmpleado = @id";
                    SqlCommand cmd3 = new SqlCommand(sql3, conn);
                    cmd3.Parameters.AddWithValue("@id", SqlDbType.Int).Value = idUser;
                    cmd3.Connection.Open();
                    SqlDataReader reader3 = cmd3.ExecuteReader();

                    if (!reader3.Read()) {
                        cmd3.Connection.Close();
                        continue;
                    }

                }

                string sql4 = "Delete FROM Empleado WHERE idArea = @id";
                SqlCommand cmd4 = new SqlCommand(sql4, conn);
                cmd4.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                cmd4.Connection.Open();
                SqlDataReader reader4 = cmd4.ExecuteReader();
                if (!reader4.Read()) {
                    cmd4.Connection.Close();
                    string sql5 = "Delete FROM Administrador WHERE idArea = @id";
                    SqlCommand cmd5 = new SqlCommand(sql5, conn);
                    cmd5.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                    cmd5.Connection.Open();
                    SqlDataReader reader5 = cmd5.ExecuteReader();
                    if (!reader5.Read()) {
                        cmd5.Connection.Close();
                        SqlCommand cmd6 = new SqlCommand();
                        cmd6.CommandType = CommandType.StoredProcedure;
                        cmd6.CommandText = "deleteArea";
                        cmd6.Parameters.Add("@idArea", SqlDbType.Int).Value = id;
                        cmd6.Connection = conn;
                        conn.Open();
                        cmd6.ExecuteNonQuery();
                        cmd6.Connection.Close();
                    }
                }
            }
        }
    }
    

    public string InsertarEmpleado(string nombre, int numEmpelado, int idArea, string email, string pass)
    {

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            string sql = "Select * FROM Empleado WHERE NoEmpleado = @id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = numEmpelado;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                cmd.Connection.Close();
                string sql2 = "Select * FROM Empleado WHERE Email = @email";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = email;
                cmd2.Connection.Open();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (!reader2.Read())
                {
                    cmd2.Connection.Close();
                    string patron = "CLCURSOSUNIDEH";

                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.CommandText = "insertEmpleado";
                    cmd3.Parameters.Add("@NombreEmpleado", SqlDbType.VarChar).Value = nombre;
                    cmd3.Parameters.Add("@NoEmpleado", SqlDbType.Int).Value = numEmpelado;
                    cmd3.Parameters.Add("@idArea", SqlDbType.Int).Value = idArea;
                    cmd3.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                    cmd3.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
                    cmd3.Parameters.Add("@patron", SqlDbType.VarChar).Value = patron;
                    cmd3.Connection = conn;
                    conn.Open();
                    cmd3.ExecuteNonQuery();
                    conn.Close();

                    Trabajador id = new Trabajador(email);

                    GenetareQR(id.getIdEmpleado());

                    return "correcto";
                }
                else
                {
                    cmd2.Connection.Close();
                    return "El correo ingresado, pertenece a otro empleado";
                }

            }
            else
            {
                cmd.Connection.Close();
                return "El numero de trabajador ya pertenece a otro empleado";
            }

        }

    }

    public void GenetareQR(int id)
    {
        //Generar QR
        QRCodeEncoder encoder = new QRCodeEncoder();
        Bitmap img = encoder.Encode(id.ToString());
        System.Drawing.Image QR = (System.Drawing.Image)resizeImage(img, new Size(300, 300)); ;

        using (MemoryStream ms = new MemoryStream())
        {
            QR.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imageBytes = ms.ToArray();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string sql = "INSERT INTO Codigo(idEmpleado,imgQR) VALUES(@id,@img)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.AddWithValue("@img", SqlDbType.Image).Value = imageBytes;
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }

        }

    }

    public static Image resizeImage(Image imgToResize, Size size)
    {
        return (Image)(new Bitmap(imgToResize, size));
    }

    public string ModificarEmpleado(string nombre, int numEmpelado, int idArea, string email, string pass, string correoActual)
    {
        string patron = "CLCURSOSUNIDEH";

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {

            if (email == correoActual)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "updateEmpleado";
                cmd.Parameters.Add("@NombreEmpleado", SqlDbType.VarChar).Value = nombre;
                cmd.Parameters.Add("@NoEmpleado", SqlDbType.Int).Value = numEmpelado;
                cmd.Parameters.Add("@idArea", SqlDbType.Int).Value = idArea;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
                cmd.Parameters.Add("@patron", SqlDbType.VarChar).Value = patron;
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return "correcto";
            }
            else
            {
                string sql = "Select * FROM Empleado WHERE Email = @email";
                SqlCommand cmd2 = new SqlCommand(sql, conn);
                cmd2.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = email;
                cmd2.Connection.Open();
                SqlDataReader reader = cmd2.ExecuteReader();
                if (!reader.Read())
                {
                    cmd2.Connection.Close();
                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.CommandText = "updateEmpleado";
                    cmd3.Parameters.Add("@NombreEmpleado", SqlDbType.VarChar).Value = nombre;
                    cmd3.Parameters.Add("@NoEmpleado", SqlDbType.Int).Value = numEmpelado;
                    cmd3.Parameters.Add("@idArea", SqlDbType.Int).Value = idArea;
                    cmd3.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                    cmd3.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
                    cmd3.Parameters.Add("@patron", SqlDbType.VarChar).Value = patron;
                    cmd3.Connection.Open();
                    cmd3.ExecuteNonQuery();
                    cmd3.Connection.Close();

                    return "correcto";

                }
                else
                {
                    cmd2.Connection.Close();
                    return "El correo ingresado, pertenece a otro empleado";
                }
            }
        }
    }

    public void EliminarEmpleado(int id)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            string sql = "Delete FROM Registro_a_curso WHERE idEmpleado = @id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                cmd.Connection.Close();
                string sql2 = "Delete FROM Codigo WHERE idEmpleado = @id";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                cmd2.Connection.Open();
                SqlDataReader reader2 = cmd2.ExecuteReader();

                if (!reader2.Read())
                {
                    cmd2.Connection.Close();
                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.CommandText = "deleteEmpleado";
                    cmd3.Parameters.Add("@idEmpleado", SqlDbType.Int).Value = id;
                    cmd3.Connection = conn;
                    conn.Open();
                    cmd3.ExecuteNonQuery();
                    cmd3.Connection.Close();
                }
            }
        }
    }

    public string InsertarInstructor(string nombre, int noInstructor, string email, string pass)
    {

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            string sql = "Select * FROM Instructor WHERE NoInstructor = @num";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@num", SqlDbType.Int).Value = noInstructor;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                cmd.Connection.Close();
                string sql2 = "Select * FROM Instructor WHERE Email = @email";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = email;
                cmd2.Connection.Open();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (!reader2.Read())
                {
                    cmd2.Connection.Close();
                    string patron = "CLCURSOSUNIDEH";

                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.CommandText = "insertInstructor";
                    cmd3.Parameters.Add("@NombreInstructor", SqlDbType.VarChar).Value = nombre;
                    cmd3.Parameters.Add("@NoInstructor", SqlDbType.Int).Value = noInstructor;
                    cmd3.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                    cmd3.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
                    cmd3.Parameters.Add("@patron", SqlDbType.VarChar).Value = patron;
                    cmd3.Connection = conn;
                    conn.Open();
                    cmd3.ExecuteNonQuery();
                    conn.Close();

                    return "correcto";
                }
                else
                {
                    cmd2.Connection.Close();
                    return "El correo ingresado, pertenece a otro empleado";
                }

            }
            else
            {
                cmd.Connection.Close();
                return "El numero de trabajador ya pertenece a otro empleado";
            }

        }
    }

    public string ModificarInstructor(int id, string nombre, int noInstructor, string email, string pass, string correoActual)
    {

        string patron = "CLCURSOSUNIDEH";

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {

            if (email == correoActual)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "updateInstructor";
                cmd.Parameters.Add("@idInstructor", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@NombreInstructor", SqlDbType.VarChar).Value = nombre;
                cmd.Parameters.Add("@NoInstructor", SqlDbType.Int).Value = noInstructor;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
                cmd.Parameters.Add("@patron", SqlDbType.VarChar).Value = patron;
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return "correcto";
            }
            else
            {
                string sql = "Select * FROM Instructor WHERE Email = @email";
                SqlCommand cmd2 = new SqlCommand(sql, conn);
                cmd2.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = email;
                cmd2.Connection.Open();
                SqlDataReader reader = cmd2.ExecuteReader();
                if (!reader.Read())
                {
                    cmd2.Connection.Close();
                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.CommandText = "updateInstructor";
                    cmd3.Parameters.Add("@idInstructor", SqlDbType.Int).Value = id;
                    cmd3.Parameters.Add("@NombreInstructor", SqlDbType.VarChar).Value = nombre;
                    cmd3.Parameters.Add("@NoInstructor", SqlDbType.Int).Value = noInstructor;
                    cmd3.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                    cmd3.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
                    cmd3.Parameters.Add("@patron", SqlDbType.VarChar).Value = patron;
                    cmd3.Connection = conn;
                    conn.Open();
                    cmd3.ExecuteNonQuery();
                    cmd3.Connection.Close();

                    return "correcto";

                }
                else
                {
                    cmd2.Connection.Close();
                    return "El correo ingresado, pertenece a otro empleado";
                }
            }
        }

    }

    public void EliminarInstructor(int id)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            string sql = "Delete FROM Registro_a_curso WHERE idInstructor = @id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                cmd.Connection.Close();
                string sql2 = "Delete FROM Curso WHERE idInstructor = @id";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                cmd2.Connection.Open();
                SqlDataReader reader2 = cmd2.ExecuteReader();

                if (!reader2.Read())
                {
                    cmd2.Connection.Close();
                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.CommandText = "deleteInstructor";
                    cmd3.Parameters.Add("@idInstructor", SqlDbType.Int).Value = id;
                    cmd3.Connection = conn;
                    conn.Open();
                    cmd3.ExecuteNonQuery();
                    cmd3.Connection.Close();
                }
            }
        }
    }

    public string InsertarAdministrador(string nombre, int NoEmpleado, int idAreaAdmin, string email, string pass)
    {

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            string sql = "Select * FROM Administrador WHERE NoEmpleado = @num";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@num", SqlDbType.Int).Value = NoEmpleado;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                cmd.Connection.Close();
                string sql2 = "Select * FROM Administrador WHERE Email = @email";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = email;
                cmd2.Connection.Open();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (!reader2.Read())
                {
                    cmd2.Connection.Close();
                    string patron = "CLCURSOSUNIDEH";

                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.CommandText = "insertAdministrador";
                    cmd3.Parameters.Add("@NombreAdministrador", SqlDbType.VarChar).Value = nombre;
                    cmd3.Parameters.Add("@NoEmpleado", SqlDbType.Int).Value = NoEmpleado;
                    cmd3.Parameters.Add("@idArea", SqlDbType.Int).Value = idAreaAdmin;
                    cmd3.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                    cmd3.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
                    cmd3.Parameters.Add("@patron", SqlDbType.VarChar).Value = patron;
                    cmd3.Connection = conn;
                    conn.Open();
                    cmd3.ExecuteNonQuery();
                    conn.Close();

                    return "correcto";
                }
                else
                {
                    cmd2.Connection.Close();
                    return "El correo ingresado, pertenece a otro empleado";
                }

            }
            else
            {
                cmd.Connection.Close();
                return "El numero de trabajador ya pertenece a otro empleado";
            }

        }

    }

    public string ModificarAdministrador(int id, string nombre, int NoEmpleado, int idAreaAdmin, string email, string pass, string correoActual)
    {

        string patron = "CLCURSOSUNIDEH";

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {

            if (email == correoActual)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "updateAdministrador";
                cmd.Parameters.Add("@idAdministrador", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@NombreAdministrador", SqlDbType.VarChar).Value = nombre;
                cmd.Parameters.Add("@NoEmpleado", SqlDbType.Int).Value = NoEmpleado;
                cmd.Parameters.Add("@idArea", SqlDbType.Int).Value = idAreaAdmin;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
                cmd.Parameters.Add("@patron", SqlDbType.VarChar).Value = patron;
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return "correcto";
            }
            else
            {
                string sql = "Select * FROM Administrador WHERE Email = @email";
                SqlCommand cmd2 = new SqlCommand(sql, conn);
                cmd2.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = email;
                cmd2.Connection.Open();
                SqlDataReader reader = cmd2.ExecuteReader();
                if (!reader.Read())
                {
                    cmd2.Connection.Close();
                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.CommandText = "updateInstructor";
                    cmd3.CommandText = "updateAdministrador";
                    cmd3.Parameters.Add("@idAdministrador", SqlDbType.Int).Value = id;
                    cmd3.Parameters.Add("@NombreAdministrador", SqlDbType.VarChar).Value = nombre;
                    cmd3.Parameters.Add("@NoEmpleado", SqlDbType.Int).Value = NoEmpleado;
                    cmd3.Parameters.Add("@idArea", SqlDbType.Int).Value = idAreaAdmin;
                    cmd3.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                    cmd3.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
                    cmd3.Parameters.Add("@patron", SqlDbType.VarChar).Value = patron;
                    cmd3.Connection = conn;
                    conn.Open();
                    cmd3.ExecuteNonQuery();
                    cmd3.Connection.Close();

                    return "correcto";

                }
                else
                {
                    cmd2.Connection.Close();
                    return "El correo ingresado, pertenece a otro empleado";
                }
            }
        }
    }

    public void EliminarAdministrador(int id)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "deleteAdministrador";
            cmd.Parameters.Add("@idAdministrador", SqlDbType.Int).Value = id;
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }

    public void InsertarCurso(string nombre, int idInstructor, int capacidad, string duracion, DateTime fecha, string dirigidoA, string hora)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insertCurso";
            cmd.Parameters.Add("@NombreCurso", SqlDbType.VarChar).Value = nombre;
            cmd.Parameters.Add("@idInstructor", SqlDbType.Int).Value = idInstructor;
            cmd.Parameters.Add("@Capacidad", SqlDbType.Int).Value = capacidad;
            cmd.Parameters.Add("@Duracion", SqlDbType.VarChar).Value = duracion;
            cmd.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = fecha;
            cmd.Parameters.Add("@DirigidoA", SqlDbType.VarChar).Value = dirigidoA;
            cmd.Parameters.Add("@Hora", SqlDbType.Time).Value = hora;
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }

    public void ModificarCurso(int id, string nombre, int idInstructor, int capacidad, string duracion, DateTime fecha, string dirigidoA, string hora)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "updateCurso";
            cmd.Parameters.Add("@idCurso", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@NombreCurso", SqlDbType.VarChar).Value = nombre;
            cmd.Parameters.Add("@idInstructor", SqlDbType.Int).Value = idInstructor;
            cmd.Parameters.Add("@Capacidad", SqlDbType.Int).Value = capacidad;
            cmd.Parameters.Add("@Duracion", SqlDbType.VarChar).Value = duracion;
            cmd.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = fecha;
            cmd.Parameters.Add("@DirigidoA", SqlDbType.VarChar).Value = dirigidoA;
            cmd.Parameters.Add("@Hora", SqlDbType.Time).Value = hora;
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }

    public void EliminarCurso(int id)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            string sql = "Delete FROM Registro_a_curso WHERE idCurso = @id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                cmd.Connection.Close();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "deleteCurso";
                cmd2.Parameters.Add("@idCurso", SqlDbType.Int).Value = id;
                cmd2.Connection = conn;
                conn.Open();
                cmd2.ExecuteNonQuery();
                cmd2.Connection.Close();
            }
        }
    }

    public DataTable VisualizarInstructores()
    {

        using (SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GridInstructores";
            cmd.Connection = cone;
            cone.Open();

            DataTable lista = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(lista);

            cone.Close();

            return lista;

        }

    }

    public DataTable VisualizarAdministradores()
    {

        using (SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GridAdministradores";
            cmd.Connection = cone;
            cone.Open();

            DataTable lista = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(lista);

            cone.Close();

            return lista;

        }

    }

    public DataTable VisualizarCursos()
    {
        DataTable lista = new DataTable();

        using (SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GridCursos";
            cmd.Connection = cone;
            cone.Open();



            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(lista);

            cone.Close();

        }

        for (int i = 0; i < lista.Rows.Count; i++)
        {
            string idInstructor = lista.Rows[i]["Instructor"].ToString();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string sql = "Select NombreInstructor FROM Instructor WHERE idInstructor = @id";
                SqlCommand cmd2 = new SqlCommand(sql, conn);
                cmd2.Parameters.AddWithValue("@id", SqlDbType.Int).Value = idInstructor;
                cmd2.Connection.Open();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    lista.Rows[i]["Instructor"] = Convert.ToString(reader2["NombreInstructor"]);
                    cmd2.Connection.Close();
                }

            }

        }

        return lista;
    }

}