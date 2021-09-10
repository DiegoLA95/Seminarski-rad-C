using Accord.Vision.Detection;

namespace AccordFaceDetections
{
    class ImageDetectorParameters
    {
        public float _ScalingFactor { get; set; }
        public ObjectDetectorScalingMode _ScalingMode { get; set; }
        public ObjectDetectorSearchMode _SearchMode { get; set; }
        public bool _UseParallelProcessing { get; set; }
        public int _MinimumSize { get; set; }
        public int _MaximumSize { get; set; }
        public int _Suppression { get; set; }


        public ImageDetectorParameters(float scalingFactor, int minimumSize, ObjectDetectorScalingMode objectDetectorScalingMode,
            ObjectDetectorSearchMode objectDetectorSearchMode, bool useParallelProcessing, int maximumSize, int suppression)
        {
            _ScalingFactor = scalingFactor;
            _MinimumSize = minimumSize;
            _ScalingMode = objectDetectorScalingMode;
            _SearchMode = objectDetectorSearchMode;
            _UseParallelProcessing = useParallelProcessing;
            _MaximumSize = maximumSize;
            _Suppression = suppression;
        }
    }
}
