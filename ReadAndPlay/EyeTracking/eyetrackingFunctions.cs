using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tobii.Gaze.Core;

namespace LookAndPlayForm
{
    public static class eyetrackingFunctions
    {

        public static PointD WeighGaze(Tobii.Gaze.Core.GazeData GazeData2Weigh)
        {
            PointD GazeWeighed = new PointD();
            eyesWeigh pesoOjos;

            pesoOjos = trackingStatus2Weigh(GazeData2Weigh.TrackingStatus);

            GazeWeighed.X = ((GazeData2Weigh.Left.GazePointOnDisplayNormalized.X) * pesoOjos.leftWeigh + (GazeData2Weigh.Right.GazePointOnDisplayNormalized.X * pesoOjos.rightWeigh)) * pesoOjos.totalWeigh;
            GazeWeighed.Y = ((GazeData2Weigh.Left.GazePointOnDisplayNormalized.Y) * pesoOjos.leftWeigh + (GazeData2Weigh.Right.GazePointOnDisplayNormalized.Y * pesoOjos.rightWeigh)) * pesoOjos.totalWeigh;                    

            return GazeWeighed;
        }

        public static eyesWeigh trackingStatus2Weigh(TrackingStatus trackingStatus)
        {
            eyesWeigh pesoOjos;

            switch (trackingStatus)
            {
                //los dos ojos
                case TrackingStatus.BothEyesTracked:
                    pesoOjos.leftWeigh = 1;
                    pesoOjos.rightWeigh = 1;
                    pesoOjos.totalWeigh = 0.5;
                    break;

                //left solo
                case TrackingStatus.OneEyeTrackedProbablyLeft:
                    pesoOjos.leftWeigh = 1;
                    pesoOjos.rightWeigh = 0;
                    pesoOjos.totalWeigh = 1;
                    break;
                case TrackingStatus.OnlyLeftEyeTracked:
                    pesoOjos.leftWeigh = 1;
                    pesoOjos.rightWeigh = 0;
                    pesoOjos.totalWeigh = 1;
                    break;

                //rigth solo
                case TrackingStatus.OneEyeTrackedProbablyRight:
                    pesoOjos.leftWeigh = 0;
                    pesoOjos.rightWeigh = 1;
                    pesoOjos.totalWeigh = 1;
                    break;
                case TrackingStatus.OnlyRightEyeTracked:
                    pesoOjos.leftWeigh = 0;
                    pesoOjos.rightWeigh = 1;
                    pesoOjos.totalWeigh = 1;
                    break;

                //peores casos
                case TrackingStatus.NoEyesTracked:
                    pesoOjos.leftWeigh = Double.NaN;
                    pesoOjos.rightWeigh = Double.NaN;
                    pesoOjos.totalWeigh = Double.NaN;
                    break;
                case TrackingStatus.OneEyeTrackedUnknownWhich:
                    pesoOjos.leftWeigh = Double.NaN;
                    pesoOjos.rightWeigh = Double.NaN;
                    pesoOjos.totalWeigh = Double.NaN;
                    break;


                default: 
                    pesoOjos.leftWeigh = Double.NaN;
                    pesoOjos.rightWeigh = Double.NaN;
                    pesoOjos.totalWeigh = Double.NaN;
                    break;
            }

            return pesoOjos;
        }

        public struct eyesWeigh
        {
            public double leftWeigh;
            public double rightWeigh;
            public double totalWeigh;
        }

        
    }
}
