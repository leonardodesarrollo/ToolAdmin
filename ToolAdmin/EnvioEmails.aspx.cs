using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
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
                
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnEnviaEmails_Click(object sender, EventArgs e)
        {

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