using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BIIT_HRM_System.Models;
namespace BIIT_HRM_System.Controllers
{
    public class ApplicantController : ApiController
    {
        readonly HRMDB2Entities2 db = new HRMDB2Entities2();
        //Uploading Personal Info 
        [HttpPost]
        public HttpResponseMessage UpdateUser()
        {
            try
            {
                var form = HttpContext.Current.Request.Form;
                int userId;
                //agr integer ko parse krny m sucess hoi tu true return kry ga nai tu false bcoz of this "!" aur agr false ho ga tab hi hum  if ki statement py jayien gy
                //"out" parameter  will contain the integer value  if the conversion is successful.
                if (!int.TryParse(form["userId"], out userId))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid userId");
                }
                string fname = form["Fname"];
                string lname = form["Lname"];
                string email = form["email"];
                string mobile = form["mobile"];
                string cnic = form["cnic"];
                string dob = form["dob"];
                //string dobStr = form["dob"];
                //if (!DateTime.TryParseExact(dobStr, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dob))
                //{
                //    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid date format for dob. Expected format: yyyy-MM-dd");
                //}

                string gender = form["gender"];
                string address = form["address"];
                var file = HttpContext.Current.Request.Files["Image"];
                DateTime dt = DateTime.Now;
                //The Server.MapPath() method is used to get the physical path of the specified virtual path ("~/Images").
                string path = HttpContext.Current.Server.MapPath("~/Images");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileData = null;
                if (file != null && file.ContentLength > 0)
                {
                    fileData = $"{dt.Year}_{dt.Month}_{dt.Day}_{dt.Hour}_{dt.Minute}_{dt.Second}_{dt.Millisecond}_{file.FileName}";
                    //uses the SaveAs method of the HttpPostedFile object file to save the uploaded file to the specified path.
                    file.SaveAs(path + "/" + fileData);
                }
                //Convert String date into date Format 
                DateTime date =DateTime.ParseExact(dob, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                // FIND  is  a builtin method  of dbSet
                user u = db.users.Find(userId);
                if (u != null)
                {
                    u.Fname = fname;
                    u.Lname = lname;
                    u.email = email;
                    u.mobile = mobile;
                    u.cnic = cnic;
                    u.dob = date;
                    u.gender = gender;
                    u.address = address;
                    u.Image = fileData ?? fileData;
                    //db.users.Update(u);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "User data updated successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "User not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error: {ex.Message}");
            }
        }
        //Uploading Educational Information using Object type Request 
        //, int applicantId
        [HttpPost]
        public HttpResponseMessage AddEducation(Education[] educationData)
        {
            try
            {
                {
                    
                    foreach (Education education in educationData)
                    {
                        Education newEducation = new Education()
                        {
                            Title = education.Title,
                            Major = education.Major,
                            Board = education.Board,
                            Year = education.Year,
                            ApplicantId = education.ApplicantId,
                        };
                        db.Educations.Add(newEducation);
                    }
                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Education data added successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error adding education data: " + ex.Message);
            }
        }



        //Uploading Experience
        [HttpPost]
        public HttpResponseMessage UpdateExperience(Experience[] expdata)
        {
            try
            {
                {
                    foreach (Experience experience in expdata)
                    {
                        Experience newExperience = new Experience()
                        {
                            JobTitle = experience.JobTitle,
                            Organization=experience.Organization,
                            StartDate=experience.StartDate,
                            EndDate=experience.EndDate,
                            CurrentlyWorking=experience.CurrentlyWorking,
                            ApplicantID = experience.ApplicantID,


                        };
                        db.Experiences.Add(newExperience);
                    }
                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Experience data added successfully");
            
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error: {ex.Message}");
            }
        }

    }
}