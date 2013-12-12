using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class G2559_T3B_muokkaus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      

            DataSet ds = new DataSet();
            DataTable dt;
            //dt = new DataTable();
            ds.ReadXml(MapPath(ConfigurationManager.AppSettings["LogFilePath3"]));
            dt = ds.Tables[0];
            //kytketään kontrolliin
            //GridView1.DataSource = ds; //toimii jos yksi taulu
            grdtunnit.DataSource = dt;
            grdtunnit.DataBind();

            Label1.Text = "Tallennettu: " + grdtunnit.Rows.Count.ToString() + " tuntia";

            

            if (!IsPostBack)
            {
                BindGrid();
                ClearScreen();

                DataTable ddt;
                ddt = dt.DefaultView.ToTable(true, "koodaaja");

                DataRow row2 = ddt.NewRow();
                row2["koodaaja"] = "Kaikki";
                ddt.Rows.InsertAt(row2, 0);
                DataRow row = ddt.NewRow();
                row["koodaaja"] = "-- Valitse --";
                ddt.Rows.InsertAt(row, 0);
                DropDownTyypit.DataSource = ddt.DefaultView;
                DropDownTyypit.DataTextField = "koodaaja";
                DropDownTyypit.DataBind();
            
        }

    }
    private void BindGrid()
    {
        TunnitDAL objTuntiDAL = new TunnitDAL();
        grdtunnit.DataSource = objTuntiDAL.GetAll();
        grdtunnit.DataBind();
    }

    protected void grdViewTunti_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[1].Attributes.Add("onclick", "return confirm('Are you sure want to delete?')");
        }
    }

    protected void grdViewTunti_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdtunnit.PageIndex = e.NewPageIndex;
        grdtunnit.SelectedIndex = -1;
        BindGrid();
    }

    protected void grdViewTunti_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        hndId.Value = grdtunnit.Rows[e.NewSelectedIndex].Cells[2].Text.Trim();
        if (hndId.Value.Length > 0)
        {
            TunnitDAL objTuntiDAL = new TunnitDAL();
            BLTunnit tunti = objTuntiDAL.Get(hndId.Value);

            txtkoodaaja.Text = tunti.koodaaja;
            txtpvm.Text = tunti.paivamaara;
            txttuntimaara.Text = tunti.tuntimaara;
            txtminuutit.Text = tunti.minuutit;

            lblMessage.Text = "";
        }
    }

    protected void grdViewTunti_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string strId = grdtunnit.Rows[e.RowIndex].Cells[2].Text.Trim();
            if (strId.Length > 0)
            {
                TunnitDAL objTuntiDAL = new TunnitDAL();
                objTuntiDAL.Delete(strId);

                ClearScreen();
                BindGrid();
                lblMessage.Text = "Record deleted successfully";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = "There is an error occured while processing the request. Please verify the code!";
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsValid) return;

            BLTunnit tunti = new BLTunnit();
            tunti.koodaaja = txtkoodaaja.Text;
            tunti.paivamaara = txtpvm.Text;
            tunti.tuntimaara = txttuntimaara.Text;
            tunti.minuutit = txtminuutit.Text;
            tunti.id = Convert.ToInt64(hndId.Value);

            TunnitDAL objTuntiDAL = new TunnitDAL();
            if ((hndId.Value.Trim().Length > 0) &&
                (Convert.ToInt64(hndId.Value) > 0))
                objTuntiDAL.Update(tunti);
            else
                objTuntiDAL.Create(tunti);

            ClearScreen();
            BindGrid();
            lblMessage.Text = "Record saved successfully";
        }
        catch (Exception ex)
        {
            lblMessage.Text = "There is an error occured while processing the request. Please verify the code!";
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearScreen();
    }

    private void ClearScreen()
    {
        txtid.Text = "tunti Generated";
        txtkoodaaja.Text = "";
        txtpvm.Text = "";
        txttuntimaara.Text = "";
        txtminuutit.Text = "";
        hndId.Value = "0";
    }


    
    protected void DropDownTyypit_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownTyypit.SelectedValue == "-- Valitse --")
        {
            return;
        }
        DataTable dt;
        DataSet ds = new DataSet();
        ds.ReadXml(MapPath(ConfigurationManager.AppSettings["LogFilePath3"]));
        dt = ds.Tables[0];
        DataView dv = dt.DefaultView;

        if (DropDownTyypit.SelectedValue != "Kaikki")
        {
            dv.RowFilter = string.Format("koodaaja like '%{0}%'", DropDownTyypit.SelectedValue);
        }
        grdtunnit.DataSource = dv;
        grdtunnit.DataBind();
    }
     
}