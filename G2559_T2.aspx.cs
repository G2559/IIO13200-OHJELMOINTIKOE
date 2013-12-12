using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class G2559_T2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DataTable dt;
        //dt = new DataTable();
        ds.ReadXml(MapPath(ConfigurationManager.AppSettings["LogFilePath1"]));
        dt = ds.Tables[0];
        //kytketään kontrolliin
        //GridView1.DataSource = ds; //toimii jos yksi taulu
        gvtyontekijat.DataSource = dt;
        gvtyontekijat.DataBind();

        //dt.Columns["palkka"].DataType = Type.GetType("System.Int32");


        XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath(ConfigurationManager.AppSettings["LogFilePath1"]));



            XmlNodeList nodes = doc.SelectNodes("//tyontekija[@tyosuhde='vakituinen']");

            lbltulokset.Text = "Löydetty: " + nodes.Count.ToString() + " vakituista työntekijää";
        
    }
}

