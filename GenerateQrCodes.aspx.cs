using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QRCoder;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
public partial class GenerateQrCodes : System.Web.UI.Page
{
    string strconn = System.Configuration.ConfigurationManager.ConnectionStrings["ausadha"].ToString();
    SqlConnection con;
    string PID;
    string qry1 = "";
    StringBuilder qry = new StringBuilder();  

    protected void Page_Load(object sender, EventArgs e)
    {
        PID = Request.QueryString["purcahseid"];

        if(PID!="" && PID!=null)
        {
            fillkko();
        }
        else
        {
            Response.Redirect("Default.aspx");
        }

    }

    public void fillkko()
    {
        //Created By Anil Vishwakarma MailID(anilvishwakrma125@gmail.com)
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataRow dr;
        DataColumn pName;
        DataColumn pQty;
        DataColumn BName;
        DataColumn IID;
        DataColumn ilogo;

        pName = new DataColumn("QR_Code", Type.GetType("System.String"));
        pQty = new DataColumn("Name", Type.GetType("System.String"));
        BName = new DataColumn("BName", Type.GetType("System.String"));
        IID = new DataColumn("IID", Type.GetType("System.String"));
        ilogo = new DataColumn("ilogo", Type.GetType("System.String"));

        dt.Columns.Add(pName);
        dt.Columns.Add(pQty);
        dt.Columns.Add(BName);
        dt.Columns.Add(IID);
        dt.Columns.Add(ilogo);



        SqlConnection con = new SqlConnection(strconn);
        con.Open();

        SqlCommand cmd = new SqlCommand("SPName", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Type", "getRecvstockdata");
        cmd.Parameters.AddWithValue("@PurchaseID", PID);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dts = new DataTable();
        da.Fill(dts);

        if (dts.Rows.Count > 0)
        {
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                
                dr = dt.NewRow();
                //Created By Anil Vishwakarma MailID(anilvishwakrma125@gmail.com)
                string PurchaseId = dts.Rows[i]["PurchaseID"].ToString();
                string itemname = dts.Rows[i]["ItemName"].ToString();
                string batchno = dts.Rows[i]["BatchNo"].ToString();
                string itemid = dts.Rows[i]["Item_Id"].ToString();
                string Ponumber = dts.Rows[i]["PurchaseId"].ToString();
                string quantity = dts.Rows[i]["Quantity"].ToString();
                string hsncode = dts.Rows[i]["HSN_Code"].ToString();
                string qty = dts.Rows[i]["Item_Id"].ToString();
                string SrReferenceNo = dts.Rows[i]["SrReferenceNo"].ToString();
                string Parentrefno ="";// dts.Rows[i]["parentrefno"].ToString();
                string PName = itemname + "\n" + batchno + "\n" + itemid;
                string code = "";//itemname //txtCode.Text;
                code = itemname + "," + itemid + "," + quantity + "," + batchno + "," + Ponumber + "," + SrReferenceNo;//+"," + Parentrefno;
                byte[] byteImage;
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                imgBarCode.Height = 140;
                imgBarCode.Width = 140;
                string hjhjhj = "";
                using (Bitmap bitMap = qrCode.GetGraphic(20))
                {
                    string name = "";
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        byteImage = ms.ToArray();
                        imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                        name = "Check";
                        hjhjhj = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                    }
                }
                //Created By Anil Vishwakarma MailID(anilvishwakrma125@gmail.com)
                string path = "Log/Ausadhawp.jpeg";
                dr["Name"] = itemname;//.Replace("_", "_\n" + System.Environment.NewLine);//.Replace("_", "" + System.Environment.NewLine); 
                dr["QR_COde"] = hjhjhj;
                dr["BName"] = batchno;
                dr["IID"] = itemid;
                dr["ilogo"] = path;

                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);
            Repeater1.DataSource = ds.Tables[0];
            Repeater1.DataBind();
            //Created By Anil Vishwakarma MailID(anilvishwakrma125@gmail.com)
        }


    }


}