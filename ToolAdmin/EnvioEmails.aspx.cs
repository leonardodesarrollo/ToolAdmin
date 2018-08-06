using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToolAdmin
{
    public partial class EnvioEmails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack)
                {

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (fuArchivo.HasFile)
                {
                    string tipoArchivo = fuArchivo.FileName;
                    tipoArchivo = tipoArchivo.Substring(tipoArchivo.LastIndexOf(".") + 1).ToLower();
                    if (tipoArchivo == "csv")
                    {
                        fuArchivo.SaveAs(Server.MapPath("formatosCarga/temp/" + fuArchivo.FileName));

                        DataTable dt = new DataTable();
                        List<string[]> testParse = parseCSV(Server.MapPath("formatosCarga/temp/" + fuArchivo.FileName));

                        foreach (string column in testParse[0])
                        {
                            dt.Columns.Add(column);
                        }

                        for (int n = 1; n < testParse.Count; n++)
                        {
                            string[] row = testParse[n];
                            dt.Rows.Add(row);
                        }
                        Session["dtEmails"]= dt;
                        grvEmails.DataSource = dt;
                        grvEmails.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnEnviaEmails_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Session["dtEmails"] as DataTable;

                foreach (DataRow row in dt.Rows)
                {
                    string body = txtBody.Text;
                    string subject = txtSubject.Text;
                    string emailTo = txtEmail.Text;

                    foreach (DataColumn column in dt.Columns)
                    {
                        body = body.Replace("|" + column.ColumnName + "|", row[column].ToString());
                        subject = subject.Replace("|" + column.ColumnName + "|", row[column].ToString());
                        emailTo = emailTo.Replace("|" + column.ColumnName + "|", row[column].ToString());
                    }

                    string bodyFinal = body.Replace("\r\n", "<br>");
                    string subjectFinal = subject;
                    string emailToFinal = emailTo;

                    EnviarEmail(emailToFinal, bodyFinal, subjectFinal);

                    lblResultado.Text += emailToFinal +": Enviado <br>";
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }


        public void EnviarEmail(string email, string body, string sub)
        {
            System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();

            correo.From = new MailAddress("<notificaciones@getsoft.cl>");
            string bodyEmail = body;

            String[] AMailto = email.Split(';');
            foreach (String mail in AMailto)
            {
                correo.To.Add(new MailAddress(mail));
            }

            correo.Subject = sub;
            correo.IsBodyHtml = true;
            correo.Body = bodyEmail;


            SmtpClient client = new SmtpClient();

            client.Send(correo);
        }

        public List<string[]> parseCSV(string path)
        {
            List<string[]> parsedData = new List<string[]>();

            using (StreamReader readFile = new StreamReader(path))
            {
                string line;
                string[] row;

                while ((line = readFile.ReadLine()) != null)
                {
                    row = line.Split(';');
                    parsedData.Add(row);
                }
            }
            return parsedData;
        }

        private object ReadToEnd(string filePath)
        {
            DataTable dtDataSource = new DataTable();

            //Read all lines from selected file and assign to string array variable.
            string[] fileContent = File.ReadAllLines(filePath);

            //Checks fileContent count > 0 then we have some lines in the file. If = 0 then file is empty
            if (fileContent.Count() > 0)
            {
                //In CSV file, 1st line contains column names. When you read CSV file, each delimited by ','.
                //fileContent[0] contains 1st line and splitted by ','. columns string array contains list of columns.
                string[] columns = fileContent[0].Split(',');
                for (int i = 0; i < columns.Count(); i++)
                {
                    dtDataSource.Columns.Add(columns[i]);
                }

                //Same logic for row data.
                for (int i = 1; i < fileContent.Count(); i++)
                {
                    string[] rowData = fileContent[i].Split(',');
                    dtDataSource.Rows.Add(rowData);
                }
            }
            return dtDataSource;
        }
    }
}