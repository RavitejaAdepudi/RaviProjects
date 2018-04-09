using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UAT_TESTINGS.Models;
namespace UAT_TESTINGS.Repository
{
    public class UserRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);
        }
        //public bool AddUser(USERDETAILS obj)
        //{
        //    connection();
        //    SqlCommand com = new SqlCommand("Batch_Details1", con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    com.Parameters.AddWithValue("@BatchName", obj.BatchName);
        //    com.Parameters.AddWithValue("@BatchStartDate", obj.BatchStartDate);
        //    com.Parameters.AddWithValue("@BatchEndDate", obj.BatchEndDate);
        //    com.Parameters.AddWithValue("@PreferedAssessmentDate", obj.PreferedAssessmentDate);
        //    con.Open();
        //    int i = com.ExecuteNonQuery();
        //    con.Close();
        //    if (i >= 1)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        public List<USERDETAILS> GetAlldetails()
        {
            connection();
            List<USERDETAILS> userdet = new List<USERDETAILS>();
            SqlCommand com = new SqlCommand("SPROC_NSDC_PMKVY2_GetAllBatchDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    userdet.Add(new USERDETAILS
                    {
                        BatchName = Convert.ToString(dr["BatchName"]),
                        BatchStartDate = Convert.ToString(dr["BatchStartDate"]) != "" ? Convert.ToDateTime(dr["BatchStartDate"]) : DateTime.Now,
                        BatchEndDate = Convert.ToString(dr["BatchEndDate"]) != "" ? Convert.ToDateTime(dr["BatchEndDate"]) : DateTime.Now,
                        PreferedAssessmentDate = Convert.ToString(dr["PreferedAssessmentDate"]) != "" ? Convert.ToDateTime(dr["PreferedAssessmentDate"]) : DateTime.Now
                    }
                    );
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return userdet;
        }
        public bool UpdateUser(USERDETAILS obj)
        {

            connection();
            SqlCommand com = new SqlCommand("SPROC_NSDC_PMKVY2_EditBatchByName", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@BatchName", obj.BatchName);
            com.Parameters.AddWithValue("@BatchStartDate", obj.BatchStartDate);
            com.Parameters.AddWithValue("@BatchEndDate", obj.BatchEndDate);
            com.Parameters.AddWithValue("@PreferedAssessmentDate", obj.PreferedAssessmentDate);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {
                return false;
            }


        }
        

        //public List<USERDETAILS> search(string BatchNamefromController)
        //{
        //    List<USERDETAILS> lstSearch = new List<USERDETAILS>();
        //    connection();
        //    SqlCommand com = new SqlCommand("SearchByBatchName", con);
        //    USERDETAILS obj = new USERDETAILS();
        //    com.CommandType = CommandType.StoredProcedure;
        //    com.Parameters.AddWithValue("@BatchName", BatchNamefromController);
        //    SqlDataAdapter da = new SqlDataAdapter(com);
        //    DataTable dt = new DataTable();
        //    con.Open();
        //    //int i = com.ExecuteNonQuery();
        //    da.Fill(dt);
        //    con.Close();
        //    if (dt.Rows.Count > 0)
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            try
        //            {
        //                lstSearch.Add(new USERDETAILS
        //                {
        //                    BatchName = Convert.ToString(dr["BatchName"]),
        //                    BatchStartDate = Convert.ToString(dr["BatchStartDate"]) != "" ? Convert.ToDateTime(dr["BatchStartDate"]) : DateTime.Now,
        //                    BatchEndDate = Convert.ToString(dr["BatchEndDate"]) != "" ? Convert.ToDateTime(dr["BatchEndDate"]) : DateTime.Now,
        //                    PreferedAssessmentDate = Convert.ToString(dr["PreferedAssessmentDate"]) != "" ? Convert.ToDateTime(dr["PreferedAssessmentDate"]) : DateTime.Now
        //                }
        //                );
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //        }
        //    return lstSearch;
        //}

    }
}



