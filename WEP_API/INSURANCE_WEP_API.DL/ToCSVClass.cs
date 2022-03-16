using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace INSURANCE_WEP_API.DL
{
    public class ToCSVClass
    {
        readonly SqlConnection con; //connection to SQL

        public ToCSVClass() //Conection string
        {
            string conStr = ConfigurationManager.ConnectionStrings["Test"].ToString();
            con = new SqlConnection(conStr);
        }




        public SqlConnection Connect() //Conect to Database
        {
            try
            {
                con.Open();

                return con;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public bool Disconnect() //Disconect to database
        {
            try
            {
                con.Close();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

        public string PlanTermsCheckFile(string filePath)
        {
            ToCSVClass con = new ToCSVClass();
            string csvFilePath = filePath;
            if (!File.Exists(csvFilePath))
            {
                List<PlanTerms> plansT = con.ListPlanTerms();
                if (plansT.Count != 0)
                {
                    string headerLine = string.Join(",", plansT[0].GetType().GetProperties().Select(x => x.Name));
                    var dataLines = from pt in plansT
                                    let dataLine = string.Join(",", pt.GetType().GetProperties().Select(p => p.GetValue(pt)))
                                    select dataLine;
                    var csvData = new List<string>();
                    csvData.Add(headerLine);
                    csvData.AddRange(dataLines);
                    
                    System.IO.File.WriteAllLines(csvFilePath, csvData);

                    return "The file was saved successfully";
                }
                else return "There is a problem retrieving the data";
            }
            else
            {
                List<string> newLines = new List<string>();
                List<string> lines = System.IO.File.ReadLines(csvFilePath).ToList();
                List<PlanTerms> plansT = con.ListPlanTerms();
                if (plansT.Count != 0)
                {
                    var dataLines = from pt in plansT
                                    let dataLine = string.Join(",", pt.GetType().GetProperties().Select(p => p.GetValue(pt)))
                                    select dataLine;
                    foreach(var dL in dataLines)
                    {
                        bool exists = lines.Contains(dL);
                        if (!exists)
                        {
                            newLines.Add(dL);
                        }
                    }
                    if (newLines.Count == 0)
                    {
                        System.IO.File.WriteAllLines(csvFilePath, lines);
                        return "The file was not updated";
                    }
                    else
                    {
                        lines.AddRange(newLines);
                        System.IO.File.WriteAllLines(csvFilePath, lines);
                        return "The file was updated";

                    }
                }
                else return "There is a problem retrieving the data";

            }
        }


        public string CreateCSV(IDataReader reader, string filePath)
        { 

            //from console app
            //string file = $@"..\..\..\CSV_files\{fileName}.csv";
            //from Web API
            var file = filePath;
            //string file = $@"CSV_files\{fileName}.csv";
            if (!File.Exists(filePath))
            {
                List<string> lines = new List<string>();
                string headerLine;
                if (reader.Read())
                {
                    string[] columns = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        columns[i] = reader.GetName(i);
                    }
                    headerLine = string.Join(",", columns);
                    lines.Add(headerLine);
                }

                //data
                while (reader.Read())
                {
                    object[] values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    lines.Add(string.Join(",", values));
                }

                //create File
                System.IO.File.WriteAllLines(file, lines);
                return file;
            }
            else
            {
                List<string> newLines = new List<string>();
                List<string> lines = System.IO.File.ReadLines(filePath).ToList();
                List<string> linesSQL = new List<string>();
                while (reader.Read())
                {
                    object[] values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    linesSQL.Add(string.Join(",", values));
                }
                foreach(string line in linesSQL)
                {
                    bool exists = lines.Contains(line);
                    if (!exists)
                    {
                        newLines.Add(line);
                    }
                    
                }
                if(newLines.Count == 0)
                {
                    System.IO.File.WriteAllLines(file, lines);
                    return file;
                }
                else
                {
                    lines.AddRange(newLines);
                    System.IO.File.WriteAllLines(file, lines);
                    return file;

                }

            }
        }
        public string GetCSV(string tableName, string filePath)
        {
            ToCSVClass con = new ToCSVClass();
            {
                return CreateCSV(new SqlCommand($"select * from {tableName}", con.Connect()).ExecuteReader(), filePath);
            }
        }

        public List<PlanTerms> ListPlanTerms()
        {

            try
            {

                ToCSVClass con = new ToCSVClass();
                SqlCommand command = new SqlCommand("sp_getPlansAndTerms", con.Connect()) //stored procedure to get a summarized table
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);//Not a selection query, just to check;
                DataTable dt = new DataTable();
                List<string> passed = new List<string>();
                //List<string> terms = new List<string>();
                List<PlanTerms> planterms = new List<PlanTerms>();
                dt.Load(dr); //Here I saved the summarized table to a DataTable
                var uniqueVals = dt.AsEnumerable().Select(x => x.Field<string>("PlanCode")).Distinct().ToList(); //UniqueValues of the planCode to filters summarized DT
                foreach(DataRow row in dt.Rows)
                {
                    PlanTerms pt = new PlanTerms();
                    if (!passed.Contains(row.Field<string>("PlanCode"))) //Check If I already create an object for a plan
                    {
                        
                        passed.Add(row.Field<string>("PlanCode"));
                        string planCode = row.Field<string>("PlanCode");
                        string planName = row.Field<string>("PlanName");
                        string fromDate = row.Field<DateTime>("EffectiveFromDate").ToString();
                        string tillDate = row.Field<DateTime>("EffectiveTillDate").ToString();
                        pt.PlanCode = planCode;
                        pt.PlanName = planName;
                        pt.EffectiveFromDate = fromDate;
                        pt.EffectiveTillDate = tillDate;

                        
                        planterms.Add(pt); //Adding the plan object to the list of PlanTerms
                        
                    }
                }
                foreach(DataRow row in dt.Rows) //Second part, check the terms of each plan
                {
                    foreach(PlanTerms pt in planterms) //For each element object in the list of PlanTerms
                    {
                        if (pt.PlanName == row.Field<string>("PlanName")) //If planName is equal to the plan name the following code will run, else nothing happens
                        {
                            foreach (var property in pt.GetType().GetProperties()) // Acceding to properties of the object pt
                            {
                                if (property.Name == row.Field<string>("TermName")) // If the field name is equal to the termName, I will change
                                                                                    // the term value from "NA" to the TermValue
                                {
                                    property.SetValue(pt, row.Field<string>("TermValue"));
                                }
                            }
                        }
                    }
                }

                con.Disconnect();
                return planterms;


            }
            catch (Exception e)
            {
                e.ToString();
                return null;
            }
        }


        public List<string> GetTableNames()
        {
            con.Open();
            con.GetSchema("Tables");
            List<string> tables = new List<string>();
            DataTable dt = con.GetSchema("Tables");
            foreach (DataRow row in dt.Rows)
            {
                string tablename = (string)row[2];
                tables.Add(tablename);
            }
            return tables;
        }

        public void GetAllCSVs()
        {
            ToCSVClass newCSV = new ToCSVClass();
            List<string> tables = newCSV.GetTableNames();
            if (tables.Count != 0)
            {
                foreach (var tb in tables)
                {
                    string file = $@"CSV_files\{tb}.csv\holamundo";
                    newCSV.GetCSV(tb, file);
                }
            }
        }
    }
}