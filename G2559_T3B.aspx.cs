using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class G2559_T3B : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnHashkirjaudu_Click(object sender, EventArgs e)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath(ConfigurationManager.AppSettings["LogFilePath2"]));
        String hash = txtHashkayttaja.Text + txtHashsala.Text;
        var md5 = MD5.Create();
        byte[] hashed = md5.ComputeHash(Encoding.UTF8.GetBytes(hash));

        //create new instance of StringBuilder to save hashed data
        StringBuilder returnValue = new StringBuilder();

        //loop for each byte and add it to StringBuilder
        for (int i = 0; i < hashed.Length; i++)
        {
            returnValue.Append(hashed[i].ToString());
        }

        // return hexadecimal string
        var hashash = returnValue.ToString();
        foreach (XmlNode node in doc.SelectNodes("//Tunnukset"))
        {
            String username = node.SelectSingleNode("//kayttaja").InnerText;
            String password = node.SelectSingleNode("//sala").InnerText;


            if (username == txtHashkayttaja.Text && password == hashash)
            {
                Response.Redirect("G2559_T3B_muokkaus.aspx");
            }
            else
            {
                lblHashkirjautuminen.Text = "Invalid login details. Please try again.";
            }
        }


    }
}