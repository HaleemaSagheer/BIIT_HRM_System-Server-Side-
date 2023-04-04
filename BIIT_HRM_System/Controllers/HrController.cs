using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BIIT_HRM_System.Models;

namespace BIIT_HRM_System.Controllers
{
    public class HrController : ApiController
    {
        readonly HRMDB2Entities db = new HRMDB2Entities();
        [HttpPost]
        public HttpResponseMessage JobPost(job_posts j)

        {
            try
            {
                db.job_posts.Add(j);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, j.job_title + " " + "Job Posted ");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage  AllJobs()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.job_posts);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}