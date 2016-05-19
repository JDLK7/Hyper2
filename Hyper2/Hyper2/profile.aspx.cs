using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hyper.CAD;
using System.Collections;
using System.IO;

namespace Hyper2
{
    public partial class profile : System.Web.UI.Page
    {

        private static string path = @"c:\HyperDataFiles\";

        protected void Page_Load(object sender, EventArgs e)
        {
            profilePic.ImageUrl = "IMG/" + Session["username"].ToString() + ".jpg";
            LabelNombre.Text = "<b>Nombre de usuario:</b> xd";
            LabelEmail.Text = "<b>Email: </b>" + UserCAD.getField(Session["username"].ToString(), "email");
            LabelPlan.Text = "<b>Plan: </b>" + UserCAD.getField(Session["username"].ToString(), "plan");

            PieChart1.ChartHeight = "500em";
            PieChart1.ChartWidth = "500em";
            PieChart1.CssClass = "graficoSVG";

            ArrayList music = new ArrayList();
            music.Add(".mp3");
            music.Add(".ogg");
            ArrayList video = new ArrayList();
            video.Add(".avi");
            video.Add(".mp4");
            video.Add(".mpeg");
            video.Add(".flv");
            ArrayList photos = new ArrayList();
            photos.Add(".bmp");
            photos.Add(".gif");
            photos.Add(".png");
            photos.Add(".jpg");


            AjaxControlToolkit.PieChartValue musicPie = new AjaxControlToolkit.PieChartValue();
            musicPie.Category = "Music";
            musicPie.Data = calcular(path + Session["username"].ToString(), music);
            
            PieChart1.PieChartValues.Add(musicPie);


            AjaxControlToolkit.PieChartValue videoPie = new AjaxControlToolkit.PieChartValue();
            videoPie.Category = "Videos";
            videoPie.Data = calcular(path + Session["username"].ToString(), video);

            PieChart1.PieChartValues.Add(videoPie);


            AjaxControlToolkit.PieChartValue photosPie = new AjaxControlToolkit.PieChartValue();
            photosPie.Category = "Photos";
            photosPie.Data = calcular(path + Session["username"].ToString(), photos);

            PieChart1.PieChartValues.Add(photosPie);

            
            AjaxControlToolkit.PieChartValue totalPie = new AjaxControlToolkit.PieChartValue();
            totalPie.Category = "Files";
            decimal aux = musicPie.Data + photosPie.Data + videoPie.Data;
            totalPie.Data = total(path + Session["username"].ToString()) - aux ;

            PieChart1.PieChartValues.Add(totalPie);
            
        }


        static long calcular(string path, ArrayList extensiones)
        {
            long tam = 0;

            DirectoryInfo dir = new DirectoryInfo(path);

            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                tam += calcular(d.FullName, extensiones);
            }

            foreach (FileInfo f in dir.GetFiles())
            {
                if (extensiones.Contains(f.Extension))
                {
                    tam += f.Length;
                }
            }

            return tam/1024;
        }

        static long total(string path)
        {
            long tam = 0;

            DirectoryInfo dir = new DirectoryInfo(path);

            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                tam += total(d.FullName);
            }

            foreach (FileInfo f in dir.GetFiles())
            {
           
               tam += f.Length;
                
            }

            return tam/1024;
        }
    }
}