using CVeditor.Helpers;
using CVeditor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CVeditor
{
    
    public partial class _Default : Page
    {
        CVmodel model = new CVmodel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

            }
        }


        protected void btnImport_Click(object sender, EventArgs e)
        {
            var contentType = FileUpload.PostedFile.ContentType;
            if (contentType == "application/xml" || contentType == "text/xml")
            {
                try
                {
                    string fileName = Path.Combine(Server.MapPath("UploadDocuments"), Guid.NewGuid().ToString() + ".xml");
                    FileUpload.PostedFile.SaveAs(fileName);
                    XDocument Xdoc = XDocument.Load(fileName);

                    model.Details = XDocumentHelper.DescendantElement(Xdoc, "me");
                    model.Education = XDocumentHelper.DescendantElement(Xdoc, "education");
                    model.Employment = XDocumentHelper.DescendantElement(Xdoc, "employment");
     
                    DetailsTextBox.Text = model.Details;
                    EducationTextBox.Text = model.Education;
                    EmploymentTextBox.Text = model.Employment;

                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                lblMessage.Text = "Please upload a CV in xlm format. The type should be application/xml or text/xml ";
            }
        }

        protected void DetailsTextBox_TextChanged(object sender, EventArgs e)
        {
            model.Details = DetailsTextBox.Text;
        }
        protected void EducationTextBox_TextChanged(object sender, EventArgs e)
        {
            model.Education = EducationTextBox.Text;
        }

        protected void EmploymentTextBox_TextChanged(object sender, EventArgs e)
        {
            model.Employment = EmploymentTextBox.Text;
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
                if (model!=null)
                {
                    var xEle = new XElement("CV",                      
                        new XElement("Details", model.Details),
                        new XElement("Education", model.Education),
                        new XElement("Employment", model.Employment)                       
                       );
                    HttpContext context = HttpContext.Current;
                    context.Response.Write(xEle);
                    context.Response.ContentType = "application/xml";
                    context.Response.AppendHeader("Content-Disposition", "attachment; filename=MyCV.xml");
                    context.Response.End();
                }
            
        }

    }
}