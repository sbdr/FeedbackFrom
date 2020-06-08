using FeedbackFrom.Helper;
using FeedbackFrom.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace FeedbackFrom.Modules
{
    public class FeedbackFormModules
    {
        public List<Department> GetAllDepartment()
        {
            List<Department> resultset = new List<Department>();
            resultset.Add(new Department
            {
                DepartmentName = "Select Department",
                DepartmentId = -1
            });
            try
            {
                using (SqlConnection con = new SqlConnection(Utility.DBConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("P_GET_DEPARTMENT", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                resultset.Add(new Department
                                {
                                    DepartmentId = Convert.ToInt32(row["DEPARTMENTID"]),
                                    DepartmentName = Convert.ToString(row["DEPARTMENTNAME"]),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultset;
        }

        public int SaveFeedBackFromCreation(FeedbackModels feedbackModels)
        {
            int response = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(Utility.DBConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_SAVE_FEEDBACK_FROM_CREATION", con))
                    {
                        
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FeedbackName", feedbackModels.FeedbackName);
                        cmd.Parameters.AddWithValue("@FeedbackDescription", feedbackModels.FeedbackDescription);
                        cmd.Parameters.AddWithValue("@StartDate", Convert.ToDateTime(Format.ToExact(Convert.ToString(feedbackModels.StartDate),"dd/MM/yyyy","MM/dd/yyyy")));
                        cmd.Parameters.AddWithValue("@EndDate", Convert.ToDateTime(Format.ToExact(Convert.ToString(feedbackModels.EndDate), "dd/MM/yyyy", "MM/dd/yyyy")));
                        cmd.Parameters.AddWithValue("@Departmentid", feedbackModels.Departmentid);
                        cmd.Parameters.AddWithValue("@QuestionIds", String.Join(",",feedbackModels.QuestionIds));
                        cmd.Parameters.AddWithValue("@Range", feedbackModels.Range);
                        cmd.Parameters.AddWithValue("@CheckBoxNo", feedbackModels.CheckBoxNo);
                        cmd.Parameters.AddWithValue("@Feedbackid", feedbackModels.FeedbackId);
                        con.Open();
                        response = Convert.ToInt32(cmd.ExecuteScalar());                       
                    }
                }
                

            }
            catch (Exception ex)
            {
                throw ex;
            }            
            return response;
        }

        public List<Question> GetQuestionList()
        {
            List<Question> resultset = new List<Question>();

            try
            {
                using (SqlConnection con = new SqlConnection(Utility.DBConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("P_GET_QUESTIONS", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                resultset.Add(new Question
                                {
                                    QuestionId = Convert.ToInt32(row["ID"]),
                                    QuestionText = Convert.ToString(row["QUESTION"]),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultset;
        }
    }
}