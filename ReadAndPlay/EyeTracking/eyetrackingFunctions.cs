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
            double leftWeigh;
            double rightWeigh;
            double totalWeigh;

            switch (GazeData2Weigh.TrackingStatus)
            {
                //los dos ojos
                case TrackingStatus.BothEyesTracked:
                    leftWeigh = 1;
                    rightWeigh = 1;
                    totalWeigh = 0.5;
                    break;
                
                //left solo
                case TrackingStatus.OneEyeTrackedProbablyLeft:
                    leftWeigh = 1;
                    rightWeigh = 0;
                    totalWeigh = 1;
                    break;
                case TrackingStatus.OnlyLeftEyeTracked:
                    leftWeigh = 1;
                    rightWeigh = 0;
                    totalWeigh = 1;
                    break;

                //rigth solo
                case TrackingStatus.OneEyeTrackedProbablyRight:
                    leftWeigh = 0;
                    rightWeigh = 1;
                    totalWeigh = 1;
                    break;
                case TrackingStatus.OnlyRightEyeTracked:
                    leftWeigh = 0;
                    rightWeigh = 1;
                    totalWeigh = 1;
                    break;
                
                //peores casos
                case TrackingStatus.NoEyesTracked:
                    leftWeigh = Double.NaN;
                    rightWeigh = Double.NaN;
                    totalWeigh = Double.NaN;
                    break;
                case TrackingStatus.OneEyeTrackedUnknownWhich:
                    leftWeigh = Double.NaN;
                    rightWeigh = Double.NaN;
                    totalWeigh = Double.NaN;
                    break;

                default:
                    leftWeigh = Double.NaN;
                    rightWeigh = Double.NaN;
                    totalWeigh = Double.NaN;
                    break;
            }

            GazeWeighed.X = ((GazeData2Weigh.Left.GazePointOnDisplayNormalized.X) * leftWeigh + (GazeData2Weigh.Right.GazePointOnDisplayNormalized.X * rightWeigh)) * totalWeigh;
            GazeWeighed.Y = ((GazeData2Weigh.Left.GazePointOnDisplayNormalized.Y) * leftWeigh + (GazeData2Weigh.Right.GazePointOnDisplayNormalized.Y * rightWeigh)) * totalWeigh;                    

            return GazeWeighed;
        }

        //public static PointD WeighGaze(TETCSharpClient.Data.GazeData GazeData2Weigh)
        //{
        //    PointD GazeWeighed = new PointD();
        //    double leftWeigh;
        //    double rightWeigh;
        //    double totalWeigh;

        //    //Source de los estados: http://dev.theeyetribe.com/api/#cat_tracker

        //    if ((GazeData2Weigh.State & TETCSharpClient.Data.GazeData.STATE_TRACKING_GAZE) != 0) 
        //    {   
        //        leftWeigh = 1;
        //        rightWeigh = 1;
        //        totalWeigh = 0.5;
        //    }
        //    else if ((GazeData2Weigh.State & TETCSharpClient.Data.GazeData.STATE_TRACKING_EYES) != 0)
        //    {
        //        leftWeigh = 1;
        //        rightWeigh = 1;
        //        totalWeigh = 0.5;
        //    }
        //    else
        //    {
        //        leftWeigh = Double.NaN;
        //        rightWeigh = Double.NaN;
        //        totalWeigh = Double.NaN;
        //    }

        //    //GazeWeighed.X = ((GazeData2Weigh.LeftEye.RawCoordinates.X) * leftWeigh + (GazeData2Weigh.RightEye.RawCoordinates.X* rightWeigh)) * totalWeigh;
        //    //GazeWeighed.Y = ((GazeData2Weigh.LeftEye.RawCoordinates.Y) * leftWeigh + (GazeData2Weigh.RightEye.RawCoordinates.Y * rightWeigh)) * totalWeigh;

        //    GazeWeighed.X = ((GazeData2Weigh.LeftEye.SmoothedCoordinates.X) * leftWeigh + (GazeData2Weigh.RightEye.SmoothedCoordinates.X * rightWeigh)) * totalWeigh;
        //    GazeWeighed.Y = ((GazeData2Weigh.LeftEye.SmoothedCoordinates.Y) * leftWeigh + (GazeData2Weigh.RightEye.SmoothedCoordinates.Y * rightWeigh)) * totalWeigh;

        //    return GazeWeighed;
        //}

        public static int distanceBetweenDev2User(Tobii.Gaze.Core.GazeData SoruceGazeData)
        {
            double distanceDev2User = (SoruceGazeData.Left.EyePositionInTrackBoxNormalized.Z + SoruceGazeData.Right.EyePositionInTrackBoxNormalized.Z) * 0.5 * 100;
            int returnValue = Convert.ToInt32(distanceDev2User);

            if (returnValue > 100)
            {
                returnValue = 100;
            }
            else if (returnValue < 0)
            {
                returnValue = 0;
            }

            return returnValue;
        }

        #region calculo de distancia entre eyetribe a usuario 

        //Version de internet:
        //http://theeyetribe.com/forum/viewtopic.php?f=11&t=35&p=139&hilit=distance&sid=e781cb533c65aa1bad6ac01df52e11c1#p139



        /// <summary>
        /// Minimum distance from sensor is about 1 foot
        /// </summary>
        public const double PUPIL_DISTANCE_MAX = 0.35d;

        /// <summary>
        /// Max distance is about 3-4 feet
        /// </summary>
        public const double PUPIL_DISTANCE_MIN = 0.10d;

        /// <summary>
        /// Returned when no pupil distance is not accurate enough to compute
        /// </summary>
        //public const double PUPIL_DISTANCE_NOTACCURATE = -100d;
        public const double PUPIL_DISTANCE_NOTACCURATE = 0;

        /// <summary>
        /// Computed using pupil distance to return a value between 0 and 1 for z distance from sensor within 1-4 foot range.
        /// </summary>
        //public static double HeadDistance(TETCSharpClient.Data.GazeData data)
        //{
        //    if ((data.State & TETCSharpClient.Data.GazeData.STATE_TRACKING_GAZE) == 0) return PUPIL_DISTANCE_NOTACCURATE;
        //    if ((data.State & TETCSharpClient.Data.GazeData.STATE_TRACKING_PRESENCE) == 0) return PUPIL_DISTANCE_NOTACCURATE;
        //    if ((data.State & TETCSharpClient.Data.GazeData.STATE_TRACKING_FAIL) != 0) return PUPIL_DISTANCE_NOTACCURATE;
        //    if ((data.State & TETCSharpClient.Data.GazeData.STATE_TRACKING_LOST) != 0) return PUPIL_DISTANCE_NOTACCURATE;


        //    if (data.LeftEye == null || data.RightEye == null) return PUPIL_DISTANCE_NOTACCURATE;

        //    var leftCenter = data.LeftEye.PupilCenterCoordinates;
        //    var rightCenter = data.RightEye.PupilCenterCoordinates;
        //    if (leftCenter == null || rightCenter == null) return PUPIL_DISTANCE_NOTACCURATE;

        //    var xDist = (rightCenter.X - leftCenter.X);
        //    var yDist = (rightCenter.Y - leftCenter.Y);

        //    if (xDist == 0 && yDist == 0) return PUPIL_DISTANCE_NOTACCURATE; //Sensor returning wonky values

        //    var dist = Math.Sqrt(xDist * xDist + yDist * yDist);
        //    if (dist > PUPIL_DISTANCE_MAX) return PUPIL_DISTANCE_NOTACCURATE; //Sensor returning wonky values

        //    dist -= PUPIL_DISTANCE_MIN;            
        //    if (dist < 0) return PUPIL_DISTANCE_NOTACCURATE;

        //    return dist / (PUPIL_DISTANCE_MAX - PUPIL_DISTANCE_MIN);
        //}

        #endregion

        //public static string RatingCalibrationFunction(TETCSharpClient.Data.CalibrationResult result)
        //{
        //    if (result == null)
        //        return "";

        //    double accuracy = result.AverageErrorDegree;

        //    if (accuracy < 0.5)
        //        return "Calibration Quality: PERFECT";

        //    if (accuracy < 0.7)
        //        return "Calibration Quality: GOOD";

        //    if (accuracy < 1)
        //        return "Calibration Quality: MODERATE";

        //    if (accuracy < 1.5)
        //        return "Calibration Quality: POOR";

        //    return "Calibration Quality: REDO";
        //}

        //public static Tobii.Gaze.Core.Point2D Point2DEyeTribe2Point2DEyeX(TETCSharpClient.Data.Point2D calibrationPointPositionEyeTribe)
        //{
        //    Tobii.Gaze.Core.Point2D calibrationPointPositionEyeX = new Tobii.Gaze.Core.Point2D(
        //        calibrationPointPositionEyeTribe.X,
        //        calibrationPointPositionEyeTribe.Y);
        //    return calibrationPointPositionEyeX;
        //}
    }
}
