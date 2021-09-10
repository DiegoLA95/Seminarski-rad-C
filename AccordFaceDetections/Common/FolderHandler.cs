using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace AccordFaceDetections
{
    class FolderHelper
    {
        public string ChooseFolder()
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                return folderDialog.SelectedPath;
            }

            return "";
        }

        public string[] GetImagePathsFromFolder(string folderPath)
        {
            //return Directory.GetFiles(folderPath, "*.jpg");
            string[] filters = new[] { "*.jpg", "*.png", "*.jpeg" };
            return filters.SelectMany(f => Directory.GetFiles(folderPath, f)).ToArray();
        }
    }
}
