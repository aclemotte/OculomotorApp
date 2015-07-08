using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LookAndPlayForm.EyeTracking
{
    class distanceDev2User
    {
        //int lastValue = 0; //valor antes de ser cero
        public double distance(Tobii.Gaze.Core.GazeData SoruceGazeData)
        {
            /* casos:
             * mul lejos
             * muy cerca
             * non value (blink)
             */
            double gazeL = SoruceGazeData.Left.EyePositionInTrackBoxNormalized.Z;
            double gazeR = SoruceGazeData.Right.EyePositionInTrackBoxNormalized.Z;
            
            eyetrackingFunctions.eyesWeigh pesoOjos = eyetrackingFunctions.trackingStatus2Weigh(SoruceGazeData.TrackingStatus);
            
            double distanceDev2User = (gazeL * pesoOjos.leftWeigh + gazeR * pesoOjos.rightWeigh) * pesoOjos.totalWeigh * 100;
            
            //int returnValue = Convert.ToInt32(distanceDev2User);

            //if (returnValue == 0 || returnValue < 0)
            //{
            //    returnValue = lastValue;
            //} 
            //else if (returnValue > 100)
            //{
            //    returnValue = 100;
            //    lastValue = returnValue;
            //}
            //else
            //{
            //    lastValue = returnValue;
            //}

            if (double.IsNaN(distanceDev2User))
                return distanceDev2User;

            if (distanceDev2User < 0)
                distanceDev2User = 0;

            if (distanceDev2User > 100)
                distanceDev2User = 100;

            //return returnValue;
            return distanceDev2User;
        }

    }
}
