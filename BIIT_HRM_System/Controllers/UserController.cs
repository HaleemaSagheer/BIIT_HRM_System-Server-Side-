using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BIIT_HRM_System.Models;

namespace BIIT_HRM_System.Controllers
{
    
    public class UserController : ApiController
    {
        readonly HRMDB2Entities db = new HRMDB2Entities();



        [HttpPost]
        public HttpResponseMessage Login(string email, string password)
        {

            try
            {

                var login = db.users.Where(b => b.email == email && b.password == password).OrderBy(b => b.Uid).ToList();

                if (login == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Record Not Found");

                }
                // jo data match hua us k against jo role ho ga  wo save krna
                var role = login[0].role;
                var name = login[0].Fname;
                //return Request.CreateResponse(HttpStatusCode.OK, login[0].Fname+"  login Successfully");
                var responseObj = new { message = login[0].Fname + " login Successfully", role, name };
                return Request.CreateResponse(HttpStatusCode.OK, responseObj);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage Registeruser(user u)
        // ya wala function value insert karnay ka liya bnaya or httpresppnsemesseage return type ha
        {
            try
            {
                if (db.users.Any(b => b.email == u.email))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Email already exists");
                }



                //Insert Into User Table
                var users = db.users.Add(u);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, u.Fname + "  is  added");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}