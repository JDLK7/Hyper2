using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyper.EN;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;

namespace Hyper.CAD
{
    public class BuscarCAD
    {
        /*
         * el campo admite valores "todo", "usuario", "musica", videos, archivos
         */
        public static ArrayList buscar(string termino, string campo)
        {
            ArrayList res = new ArrayList();
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Hyper2DB"].ConnectionString);

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
            ArrayList files = new ArrayList();
            files.Add(".txt");
            files.Add(".doc");
            files.Add(".exe");

            if (campo == "Todos")
            {
                try
                {
                    db.Open();
                    string query = "SELECT [Path], [Name], [Extension] FROM [Files] WHERE name LIKE '%" + termino + "%';";
                    SqlCommand command = new SqlCommand(query, db);
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            string path = dr.GetString(0);
                            string name = dr.GetString(1);
                            string extension = dr.GetString(2);
                            BuscarEN busqueda = new BuscarEN(name, extension, path);

                            res.Add(busqueda);
                        }
                    }

                }
                catch (Exception)
                {
                    return res;
                }
                finally
                {
                    db.Close();
                   
                }
                return res;
            }
            else
            {
                if (campo == "Música")
                {
                    foreach (string ext in music)
                    {
                        try
                        {
                            db.Open();
                            string query = "SELECT [Path], [Name], [Extension] FROM [Files] WHERE name LIKE '%" + termino + "%' and extension='" + ext + "';";
                            SqlCommand command = new SqlCommand(query, db);
                            SqlDataReader dr = command.ExecuteReader();

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    string path = dr.GetString(0);
                                    string name = dr.GetString(1);
                                    string extension = dr.GetString(2);
                                    BuscarEN busqueda = new BuscarEN(name, extension, path);

                                    res.Add(busqueda);
                                }
                            }

                        }
                        catch (Exception)
                        {
                            return res;
                        }
                        finally
                        {
                            db.Close();
                        }
                    }
                }

                if (campo == "Vídeos")
                {
                    foreach (string ext in video)
                    {
                        try
                        {
                            db.Open();
                            string query = "SELECT [Path], [Name], [Extension] FROM [Files] WHERE name LIKE '%" + termino + "%' and extension='" + ext + "';";
                            SqlCommand command = new SqlCommand(query, db);
                            SqlDataReader dr = command.ExecuteReader();

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    string path = dr.GetString(0);
                                    string name = dr.GetString(1);
                                    string extension = dr.GetString(2);
                                    BuscarEN busqueda = new BuscarEN(name, extension, path);

                                    res.Add(busqueda);
                                }
                            }

                        }
                        catch (Exception)
                        {
                            return res;
                        }
                        finally
                        {
                            db.Close();
                        }
                    }

                }

                if (campo == "Archivos")
                {
                    foreach (string ext in files)
                    {
                        try
                        {
                            db.Open();
                            string query = "SELECT [Path], [Name], [Extension] FROM [Files] WHERE name LIKE '%" + termino + "%' and extension='" + ext + "';";
                            SqlCommand command = new SqlCommand(query, db);
                            SqlDataReader dr = command.ExecuteReader();

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    string path = dr.GetString(0);
                                    string name = dr.GetString(1);
                                    string extension = dr.GetString(2);
                                    BuscarEN busqueda = new BuscarEN(name, extension, path);

                                    res.Add(busqueda);
                                }
                            }

                        }
                        catch (Exception)
                        {
                            return res;
                        }
                        finally
                        {
                            db.Close();
                        }
                    }

                }

                if (campo == "Fotos")
                {
                    foreach (string ext in photos)
                    {
                        try
                        {
                            db.Open();
                            string query = "SELECT [Path], [Name], [Extension] FROM [Files] WHERE name LIKE '%" + termino + "%' and extension='" + ext + "';";
                            SqlCommand command = new SqlCommand(query, db);
                            SqlDataReader dr = command.ExecuteReader();

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    string path = dr.GetString(0);
                                    string name = dr.GetString(1);
                                    string extension = dr.GetString(2);
                                    BuscarEN busqueda = new BuscarEN(name, extension, path);

                                    res.Add(busqueda);
                                }
                            }

                        }
                        catch (Exception)
                        {
                            return res;
                        }
                        finally
                        {
                            db.Close();
                        }
                    }

                }

                if (campo == "Usuarios")
                {

                    try
                    {
                        db.Open();
                        string query = "SELECT [username] FROM [User] WHERE username LIKE '%" + termino + "%';";
                        SqlCommand command = new SqlCommand(query, db);
                        SqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                string aux = dr.GetString(0);
                                BuscarEN busqueda = new BuscarEN(aux, "Usuario");

                                res.Add(busqueda);
                            }
                        }

                    }
                    catch (Exception)
                    {
                        return res;
                    }
                    finally
                    {
                        db.Close();
                    }
                }
                    
                
            }
        return res;
        }
    }
}

