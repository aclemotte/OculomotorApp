using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixDet;

namespace LookAndPlayForm.FixDetector
{
    public class fixationDataPoint
    {
        public SFDFixation fixationData;
        public stateFixationData fixationState;//fixation start or end
    }

    public class fixationData
    {
        public List<fixationDataPoint> fixationDataPointLandR;
        public List<fixationDataPoint> fixationDataPointLeft;
        public List<fixationDataPoint> fixationDataPointRight;

        public fixationData()
        {
            this.fixationDataPointLandR = new List<fixationDataPoint>();
            this.fixationDataPointLeft = new List<fixationDataPoint>();
            this.fixationDataPointRight = new List<fixationDataPoint>();
        }

        public void clearAllList()
        {
            this.fixationDataPointLandR.Clear();
            this.fixationDataPointLeft.Clear();
            this.fixationDataPointRight.Clear();
        }
    }

    public enum stateFixationData
    {
        start = 0,  //fixation start
        end = 1     //fixation end
    }
}
