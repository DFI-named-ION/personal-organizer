using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
    public class DataManager
    {
        private string _path = Directory.GetCurrentDirectory();
        public string Path
        { 
            get { return _path; }
            set { _path = value; }
        }

        public void SaveDataToFile(string fileName, string content)
        {
            try
            {
                fileName += " - " + DateTime.Now.Hour + "/" + DateTime.Now.Minute + "/" + DateTime.Now.Second + ".dat";

                if (_path[_path.Length - 1].ToString() == @"\")
                    File.WriteAllBytes(_path + fileName, Encoding.UTF8.GetBytes(content));
                else
                    File.WriteAllBytes(_path + @"\" + fileName, Encoding.UTF8.GetBytes(content));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured! Message: {ex.Message}");
            }
        }

        public void LoadDataFromFile(string fileName) 
        {
            try
            {
                byte[] data;
                if (_path[_path.Length - 1].ToString() == @"\")
                    data = File.ReadAllBytes(_path + fileName);
                else
                    data = File.ReadAllBytes(_path + @"\" + fileName);
                string content = Encoding.UTF8.GetString(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured! Message: {ex.Message}");
            }
        }

        public void DeleteDataFile(string fileName)
        {
            try
            {
                fileName += ".dat";
                if (_path[_path.Length - 1].ToString() == @"\")
                    Directory.Delete(_path + fileName);
                else
                    Directory.Delete(_path + @"\" + fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured! Message: {ex.Message}");
            }
        }
    }
}