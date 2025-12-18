using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

/// <summary>
/// Summary description for RegistrionTblService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class RegistrionTblService : System.Web.Services.WebService {

    SqlCommand cmd;
    SqlDataAdapter da;
    SqlConnection con;
    DataSet ds;

    void mycon()
{
    con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TestDbDataBasemdf.mdf;Integrated Security=True");
    con.Open();
}
    public RegistrionTblService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string Insert(string Name,string Email,string Gender)
    {
        try
        {
            mycon();
            cmd = new SqlCommand("Insert Into RegistrionTbl values (@nm,@em,@gen,GETDATE())",con);
            cmd.Parameters.AddWithValue("@nm", Name);
            cmd.Parameters.AddWithValue("@em", Email);
            cmd.Parameters.AddWithValue("@gen", Gender);
            cmd.ExecuteNonQuery();
            return "successfully Store a Data";
        }
        catch (Exception ex)
        {

            return ex.ToString();
        }
        finally
        {
            if (con.State==ConnectionState.Open)
            {
                con.Close();
   
            }
            con.Dispose();
            cmd.Dispose();
            //ds.Dispose();
            //da.Dispose();
        }

    }
    [WebMethod]
    public string Update( string RegID, string Name, string Email, string Gender)
    {
        try
        {
            mycon();
            cmd = new SqlCommand("Update  RegistrionTbl set  Name=@nm,Email=@em,Gender=@gen where RegID=@Rid", con);
            cmd.Parameters.AddWithValue("@nm", Name);
            cmd.Parameters.AddWithValue("@em", Email);
            cmd.Parameters.AddWithValue("@gen", Gender);
            cmd.Parameters.AddWithValue("@Rid", RegID);
            cmd.ExecuteNonQuery();
            return "successfully Update Data";
        }
        catch (Exception ex)
        {

            return ex.ToString();
        }
        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();

            }
            con.Dispose();
            cmd.Dispose();
         
        }

    }
    [WebMethod]
    public string Edit(string RegID)
    {
        try
        {
            mycon();
            cmd = new SqlCommand("select  * from RegistrionTbl where RegID=@Rid", con);
            cmd.Parameters.AddWithValue("@Rid", RegID);
            cmd.ExecuteNonQuery();
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds.Tables[0]);
        }
        catch (Exception ex)
        {

            return ex.ToString();
        }
        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();

            }
            con.Dispose();
            cmd.Dispose();
            ds.Dispose();
            da.Dispose();
        }

    }
    [WebMethod]
    public string list()
    {
        try
        {
            mycon();
            cmd = new SqlCommand("Select *  From RegistrionTbl", con);
            cmd.ExecuteNonQuery();
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds.Tables[0]);
        }
        catch (Exception ex)
        {

            return ex.ToString();
        }
        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();

            }
            con.Dispose();
            cmd.Dispose();
            ds.Dispose();
            da.Dispose();
        }

    }
    [WebMethod]
    public string Delete(string RegID)
    {
        try
        {
            mycon();
            cmd = new SqlCommand("Delete from RegistrionTbl where RegID=@Rid", con);
            cmd.Parameters.AddWithValue("@Rid", RegID);
            cmd.ExecuteNonQuery();
        
            return "Your Data SuccessFully Delete";
        }
        catch (Exception ex)
        {

            return ex.ToString();
        }
        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();

            }
            con.Dispose();
            cmd.Dispose();
          
        }

    }
}
