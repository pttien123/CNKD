﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace Chiecnonkidieu
{
    public class Import
    {
        public static ArrayList arrQuestion { get; set; }
        public static  ArrayList arrAnswer1 { get; set; }
        public static ArrayList arrAnswer2 { get; set; }
        private Random rand;
        public void ImportQA(SqlConnection cn,string str)
        {
            rand = new Random();

            arrQuestion = new ArrayList();
            arrAnswer1 = new ArrayList();
            arrAnswer2 = new ArrayList();
            SqlDataAdapter da = new SqlDataAdapter(str, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                int r = rand.Next(0, dt.Rows.Count);

                arrQuestion.Add(dt.Rows[r][1]);
                arrAnswer1.Add(dt.Rows[r][2]);
                arrAnswer2.Add(dt.Rows[r][3]);
            }
;        }
        public void ImportPoint(SqlConnection cn, string name, int point)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ImportPoint", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@point", point));
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
    }
}
