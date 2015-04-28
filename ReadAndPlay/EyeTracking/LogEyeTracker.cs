using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Newtonsoft.Json;
using System.IO;


namespace LookAndPlayForm
{
    public class LogEyeTracker
    {
        //public struct test_info
        //{
        //    public int screen_Height;
        //    public int screen_Width;
        //    public int trials;
        //    public string date;
        //    public string eyetracker;
        //    public string click_type;
        //    public string pointer_type;
        //    public int blink_time_min;
        //    public int blink_time_max;
        //    public int dwell_area;
        //    public int dwell_time;
        //    public int dewll_time_latency;
        //    public int calibration_error_left_px;
        //    public int calibration_error_right_px;
        //    public string filter_type;
        //};

        
        public struct TargetTraceDefinitionEyeX
        {
            public List<Tobii.Gaze.Core.GazeData> gazeDataItemL;
            public List<PointD> gazeWeigthedL;
            public List<PointD> gazeFilteredL;
            public TargetPosSize.Target targetPositionSize;
            public bool clickInsideTarget;
        }

        //public struct TargetTraceDefinitionEyeTribe
        //{
        //    public List<TETCSharpClient.Data.GazeData> gazeDataItemL;
        //    public List<PointD> gazeWeigthedL;
        //    public List<PointD> gazeFilteredL;
        //    public TargetPosSize.Target targetPositionSize;
        //    public bool clickInsideTarget;
        //}
                
        public struct eyetrackerDataEyeX
        {
            //public test_info test_info;
            public List<TargetTraceDefinitionEyeX> targetTraceL;
        }

        //public struct eyetrackerDataEyeTribe
        //{
        //    //public test_info test_info;
        //    public List<TargetTraceDefinitionEyeTribe> targetTraceL;
        //}

        //Referencias que luego se agregaran a la lista TargetTraceL y que a lo largo de la app iran apuntando a lugares diferentes
        public List<Tobii.Gaze.Core.GazeData> GazeDataItemEyeXL;
        //public List<TETCSharpClient.Data.GazeData> GazeDataItemEyeTribeL;
        public List<PointD> GazeWeigthedL;
        public List<PointD> GazeFilteredL;
        public TargetTraceDefinitionEyeX TargetTraceEyeX;
        //public TargetTraceDefinitionEyeTribe TargetTraceEyeTribe;

        //Lista que contiene todos los datos
        public List<TargetTraceDefinitionEyeX> TargetTraceEyeXL;
        //public List<TargetTraceDefinitionEyeTribe> TargetTraceEyeTribeL;

        /// <summary>
        /// Todas las listas (1, 2, y 3) son bufferes que almacenaran datos mediantes los metodos:
        ///     - AddMoveXYT(double xpos, double ypos, long timems)
        ///     - AddGazeDataItem2List(IGazeDataItem GazeDataItemTemp)
        /// Los datos del target son almacenados cuando se crea una nueva lista (los datos del target se pasan como parametro en el metodo correspondiente)
        ///     - AddMoveLXYTarget(TargetPosSize.Target _TargetPS)
        ///     - AddTargetTrace(TargetPosSize.Target _TargetPS)
        /// </summary>
        public LogEyeTracker()
        {
            GazeDataItemEyeXL = new List<Tobii.Gaze.Core.GazeData>();
            //GazeDataItemEyeTribeL = new List<TETCSharpClient.Data.GazeData>();
            GazeWeigthedL = new List<PointD>();
            GazeFilteredL = new List<PointD>();
            TargetTraceEyeXL = new List<TargetTraceDefinitionEyeX>();
            //TargetTraceEyeTribeL = new List<TargetTraceDefinitionEyeTribe>();
        }

        public void AddGazeDataItem2List(Tobii.Gaze.Core.GazeData GazeDataItemTemp, PointD GazeWeigthed, PointD GazeFiltered)
        {
            GazeDataItemEyeXL.Add(GazeDataItemTemp);
            GazeWeigthedL.Add(GazeWeigthed);
            GazeFilteredL.Add(GazeFiltered);
        }

        /// <summary>
        /// Almacena los datos guardados (1, 2, 3) y prepara una grabacion (4)
        /// 1. Se crea una struct que contendra los datos:
        /// 2. En esta struct creada se almacenan los datos:
        /// 3. Se almacena la struct creada y rellenada en la lista global
        /// 4. Se crean dos nuevos buffer para:
        /// </summary>
        /// <param name="_TargetPS"></param>
        public void AddTargetTraceEyeX(TargetPosSize.Target _TargetPS, bool clickInsideTarget)
        {
            //1.
            TargetTraceEyeX = new TargetTraceDefinitionEyeX();

            //2.
            TargetTraceEyeX.targetPositionSize = _TargetPS;

            //#region borra todos los datos intermedios
            //GazeData GazeDataItemL0 = GazeDataItemL[0];
            //GazeData GazeDataItemLlast = GazeDataItemL[GazeDataItemL.Count - 1];
            //GazeDataItemL.Clear();
            //GazeDataItemL.Add(GazeDataItemL0);
            //GazeDataItemL.Add(GazeDataItemLlast);

            //PointD GazeWeigthedL0 = GazeWeigthedL[0];
            //PointD GazeWeigthedLlast = GazeWeigthedL[GazeWeigthedL.Count - 1];
            //GazeWeigthedL.Clear();
            //GazeWeigthedL.Add(GazeWeigthedL0);
            //GazeWeigthedL.Add(GazeWeigthedLlast);

            //PointD GazeFiltered0 = GazeFilteredL[0];
            //PointD GazeFilteredlast = GazeFilteredL[GazeFilteredL.Count - 1];
            //GazeFilteredL.Clear();
            //GazeFilteredL.Add(GazeFiltered0);
            //GazeFilteredL.Add(GazeFilteredlast);
            //#endregion

            TargetTraceEyeX.gazeDataItemL = GazeDataItemEyeXL; //list of all saved cursor points 
            TargetTraceEyeX.gazeWeigthedL = GazeWeigthedL; //list of all saved cursor points 
            TargetTraceEyeX.gazeFilteredL = GazeFilteredL; //list of all saved cursor points 
            TargetTraceEyeX.clickInsideTarget = clickInsideTarget;
            //3.
            TargetTraceEyeXL.Add(TargetTraceEyeX);

            //4.
            GazeDataItemEyeXL = new List<Tobii.Gaze.Core.GazeData>();
            GazeWeigthedL = new List<PointD>();
            GazeFilteredL = new List<PointD>();
        }
       
        public void saveData2File(eyetrackerDataEyeX generalData2Save)
        {
            generalData2Save.targetTraceL = TargetTraceEyeXL;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\" +
                            LookAndPlayForm.Program.datosCompartidos.startTime + 
                            @"-us" + Program.datosCompartidos.activeUser + @"\";

            bool exists = System.IO.Directory.Exists(path);

            if (!exists)
                System.IO.Directory.CreateDirectory(path);

            File.WriteAllText(path + @"eyetrackerData.json", JsonConvert.SerializeObject(generalData2Save));
        }
       

        public void ClearList()
        {           
            GazeDataItemEyeXL.Clear();
            //GazeDataItemEyeTribeL.Clear();
            GazeWeigthedL.Clear();
            GazeFilteredL.Clear();
            TargetTraceEyeXL.Clear();
            //TargetTraceEyeTribeL.Clear();
        }

    }
}
