using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tobii.Gaze.Core;

namespace LookAndPlayForm
{
    public partial class TrackStatusControlMirada : UserControl
    {
        private Point2D _leftEye;
        private Point2D _rightEye;
        private TrackingStatus _eyesValidity;
        private SolidBrush _eyeBrush;
        private SolidBrush _eyeBrushL;
        private SolidBrush _eyeBrushR;
        private Queue<GazeData> _dataHistory;

        private static int HistorySize = 30;
        private static int EyeRadius = 8;
        private sharedData datosCompartidos;

        public TrackStatusControlMirada()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            _dataHistory = new Queue<GazeData>(HistorySize);

            _eyeBrush = new SolidBrush(Color.White);
            _eyeBrushL = new SolidBrush(Color.Red);
            _eyeBrushR = new SolidBrush(Color.Blue);

            _eyesValidity = TrackingStatus.NoEyesTracked;

            this.datosCompartidos = LookAndPlayForm.Program.datosCompartidos;
        }
       
        public void OnGazeData(Tobii.Gaze.Core.GazeData gd)
        {
            // Add data to history
            _dataHistory.Enqueue(gd);

            // Remove history item if necessary
            while (_dataHistory.Count > HistorySize)
            {
                _dataHistory.Dequeue();
            }

            _eyesValidity = gd.TrackingStatus;

            _leftEye = gd.Left.GazePointOnDisplayNormalized;
            _rightEye = gd.Right.GazePointOnDisplayNormalized;

            Invalidate();
        }

        public void Clear()
        {
            _dataHistory.Clear();
            //_leftValidity = 0;
            //_rightValidity = 0;
            _eyesValidity = TrackingStatus.BothEyesTracked;
            _leftEye = new Point2D();
            _rightEye = new Point2D();

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw eyes

            if (_eyesValidity == TrackingStatus.BothEyesTracked || _eyesValidity == TrackingStatus.OneEyeTrackedProbablyLeft || _eyesValidity == TrackingStatus.OnlyLeftEyeTracked)
            {
                RectangleF r = new RectangleF((float)(_leftEye.X * Width - EyeRadius), (float)(_leftEye.Y * Height - EyeRadius), 2 * EyeRadius, 2 * EyeRadius);
                //e.Graphics.FillEllipse(_eyeBrush, r);
                try
                {
                    e.Graphics.FillEllipse(_eyeBrushL, r);
                }
                catch(Exception ex)
                {
                    ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                }
            }

            if (_eyesValidity == TrackingStatus.BothEyesTracked || _eyesValidity == TrackingStatus.OneEyeTrackedProbablyRight || _eyesValidity == TrackingStatus.OnlyRightEyeTracked)
            {
                RectangleF r = new RectangleF((float)(_rightEye.X * Width - EyeRadius), (float)(_rightEye.Y * Height - EyeRadius), 2 * EyeRadius, 2 * EyeRadius);
                try
                {
                    e.Graphics.FillEllipse(_eyeBrushR, r);
                }
                catch (Exception ex)
                {
                    ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                }
            }
        }        
    }
}
