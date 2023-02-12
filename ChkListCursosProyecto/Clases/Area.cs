

using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public class Area {
    private int idArea;
    private string nombreArea;

    public Area() { 
    }

    public void setIdArea(int idArea)
    {
        this.idArea = idArea;
    }

    public int getIdArea()
    {
        return this.idArea;
    }

    public void setNombreArea(string nombreArea)
    {
        this.nombreArea = nombreArea;
    }

    public string getNombreArea()
    {
        return this.nombreArea;
    }

    public DataSet cargarDrowAreas()
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        {
            cn.Open();

            string sql = "SELECT idArea,NombreArea FROM Area";
            SqlCommand cmd = new SqlCommand(sql, cn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cn.Close();

            return ds;

        }
    }

}