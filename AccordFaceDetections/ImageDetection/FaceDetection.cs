using System.Drawing;
using Accord.Vision.Detection;
using Accord.Vision.Detection.Cascades;

namespace AccordFaceDetections
{
    class FaceDetection
    {
        private HaarObjectDetector _detector;

        private ImageDetectorParameters _parameters1 = new ImageDetectorParameters(1.1f, 5, ObjectDetectorScalingMode.GreaterToSmaller, ObjectDetectorSearchMode.Average, true, 600, 1);

        //These are other suggested parameters to use:
        //private ImageDetectorParameters _parameters2 = new ImageDetectorParameters(1.3f, 10, ObjectDetectorScalingMode.GreaterToSmaller, ObjectDetectorSearchMode.Single, true, 700, 1);
        //private ImageDetectorParameters _parameters3 = new ImageDetectorParameters(1.5f, 15, ObjectDetectorScalingMode.GreaterToSmaller, ObjectDetectorSearchMode.NoOverlap, true, 800, 1);
        //private ImageDetectorParameters _parameters4 = new ImageDetectorParameters(1.1f, 5, ObjectDetectorScalingMode.SmallerToGreater, ObjectDetectorSearchMode.Average, true, 600, 1);
        //private ImageDetectorParameters _parameters5 = new ImageDetectorParameters(1.3f, 10, ObjectDetectorScalingMode.SmallerToGreater, ObjectDetectorSearchMode.Single, true, 700, 1);
        //private ImageDetectorParameters _parameters6 = new ImageDetectorParameters(1.5f, 15, ObjectDetectorScalingMode.SmallerToGreater, ObjectDetectorSearchMode.NoOverlap, true, 800, 1);
        public FaceDetection()
        {
            _detector = new HaarObjectDetector(new FaceHaarCascade());
        }

        public bool IsContainingFace(Bitmap image)
        {
            if(image == null)
            {
                return false;
            }

            SetDetectorParameters(_parameters1);
            Rectangle[] faces1 = _detector.ProcessFrame(image);
            if( faces1.Length > 0 )
            {
                return true;
            }

//             SetDetectorParameters(_parameters2);
//             Rectangle[] faces2 = _detector.ProcessFrame(image);
//             if (faces2.Length > 0)
//             {
//                 return true;
//             }
// 
//             SetDetectorParameters(_parameters3);
//             Rectangle[] faces3 = _detector.ProcessFrame(image);
//             if (faces3.Length > 0)
//             {
//                 return true;
//             }
// 
//             SetDetectorParameters(_parameters4);
//             Rectangle[] faces4 = _detector.ProcessFrame(image);
//             if (faces4.Length > 0)
//             {
//                 return true;
//             }
// 
//             SetDetectorParameters(_parameters5);
//             Rectangle[] faces5 = _detector.ProcessFrame(image);
//             if (faces5.Length > 0)
//             {
//                 return true;
//             }
// 
//             SetDetectorParameters(_parameters6);
//             Rectangle[] faces6 = _detector.ProcessFrame(image);
//             if (faces6.Length > 0)
//             {
//                 return true;
//             }

            return false;
        }

        private void SetDetectorParameters(ImageDetectorParameters parameters)
        {
            _detector.MinSize = new Size(parameters._MinimumSize, parameters._MinimumSize);
            _detector.ScalingFactor = parameters._ScalingFactor;
            _detector.ScalingMode = parameters._ScalingMode;
            _detector.SearchMode = parameters._SearchMode;
            _detector.UseParallelProcessing = parameters._UseParallelProcessing;
            _detector.MaxSize = new Size(parameters._MaximumSize, parameters._MaximumSize);
            _detector.Suppression = parameters._Suppression;
        }
    }
}
