using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace AccordFaceDetections
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FolderHelper _FolderHelper = new FolderHelper();
        FaceDetection _FaceDetection = new FaceDetection();
        private string _SelectedFolderPath;

        // Images on screen details
        Thickness _FirstImageMargin = new Thickness(24, 270, 0, 0);
        double _ImageWidth = 150;
        double _ImageHeight = 150;
        VerticalAlignment _ImageVerticalAlignment = VerticalAlignment.Top;
        System.Windows.HorizontalAlignment _ImageHorizontalAlignment = System.Windows.HorizontalAlignment.Left;
        double _ImageHorizontalOffset = 20;
        double _ImageVerticalOffset = 20;
        int _MaxNumberOfImages = 25;

        //We need to store them, so we can delete them when choosing another folder 
        System.Windows.Controls.Image[] _CurrentlyShownImages = new System.Windows.Controls.Image[25];

        public MainWindow()
        {
        }

        private void PickFolderClick(object sender, RoutedEventArgs e)
        {
            if(_CurrentlyShownImages.Length > 0)
            {
                ResetWindow();
            }

            // Ask the user about desired folder
            string _SelectedFolderPath = _FolderHelper.ChooseFolder();
            // Fill the text box for selected folder
            SelectedPath.Text = _SelectedFolderPath;

            if(_SelectedFolderPath.Length > 0)
            {
                ProcessAndShowImages(_SelectedFolderPath);
            }
        }

        private void ProcessAndShowImages(string folderPath)
        {
            string[] imagesPaths = _FolderHelper.GetImagePathsFromFolder(folderPath);
            if(imagesPaths.Length > 0)
            {
                int currentImagesShownCount = 0;

                foreach(string path in imagesPaths)
                {
                    Bitmap bitmapImage = new Bitmap(path);
                    if(_FaceDetection.IsContainingFace(bitmapImage))
                    {
                        AddImageToWindow(path, currentImagesShownCount);
                        currentImagesShownCount++;
                        if(currentImagesShownCount > _MaxNumberOfImages)
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void AddImageToWindow(string path, int currentImageCount)
        {
            // first we need to replace "\" with "/" in path because making BitmapImage reads paths differently
            string replacedFolderPath = path.Replace(@"\", @"/");

            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
            image.Width = _ImageWidth;
            image.Height = _ImageHeight;
            double top = _FirstImageMargin.Top + (currentImageCount / 5) *( _ImageVerticalOffset + _ImageHeight);
            double left = _FirstImageMargin.Left + (currentImageCount % 5) * (_ImageHorizontalOffset + _ImageWidth);
            Thickness imageMargin = new Thickness(left, top, 0, 0);
            image.Margin = imageMargin;
            image.VerticalAlignment = _ImageVerticalAlignment;
            image.HorizontalAlignment = _ImageHorizontalAlignment;
            image.Source = new BitmapImage(new Uri(replacedFolderPath, UriKind.RelativeOrAbsolute));

            MainGrid.Children.Add(image);
            _CurrentlyShownImages[currentImageCount] = image;
        }

        private void ResetWindow()
        {
            SelectedPath.Text = "";

            foreach (System.Windows.Controls.Image image in _CurrentlyShownImages)
            {
                if(image != null)
                {
                    MainGrid.Children.Remove(image);
                }
            }

            Array.Clear(_CurrentlyShownImages, 0, _CurrentlyShownImages.Length);
        }
    }
}
