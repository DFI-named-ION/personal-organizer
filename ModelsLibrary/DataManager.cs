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

        public void SaveDataToFile(string fileName)
        {
            try
            {
                fileName += " - " + DateTime.Now.Hour + "/" + DateTime.Now.Minute + "/" + DateTime.Now.Second;
                fileName += ".dat";

                string content = Task

                if (_path[_path.Length - 1].ToString() == @"\")
                    File.WriteAllText(_path + fileName, content);
                else
                    Directory.Delete(_path + @"\" + fileName);
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