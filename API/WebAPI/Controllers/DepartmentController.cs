using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DepartmentController : Controller
    {
        public HttpResponseMessage Get ()
        {
            string query = @"select DepartmentId, DepartmentName from Department";
            DataTable tabela = new DataTable();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString))

            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(tabela);

            }
            return Request.CreateResponse(HttpStatusCode.OK, tabela);
        }
    }
}