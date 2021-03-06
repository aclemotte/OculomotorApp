﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Newtonsoft.Json;
using System.IO;
using LookAndPlayForm.Utility;
using LookAndPlayForm.DataBase;


namespace LookAndPlayForm.LogEyeTracker
{
    public class LogEyeTracker
    {

        #region esto hay que mejorar

        //Ya existe este tipo de dato en TobiiOpenDataClass, pero se creo de nuevo xq hay que hacer una conversion de Tobii.Gaze.Core.GazeData a TobiiOpenDataClass.GazeData, que son basicamente lo mismo pero uno con datos privados y el otro con datos publicos. 
        public struct TargetTraceDefinitionEyeX
        {
            public List<Tobii.Gaze.Core.GazeData> gazeDataItemL;
            public List<PointD> gazeWeigthedL;
            public List<PointD> gazeFilteredL;
            public TargetPosSize.Target targetPositionSize;
            public bool clickInsideTarget;
        }

        //Referencias que luego se agregaran a la lista TargetTraceL y que a lo largo de la app iran apuntando a lugares diferentes
        public List<Tobii.Gaze.Core.GazeData> GazeDataItemEyeXL { get; set; }
        public List<PointD> GazeWeigthedL { get; set; }
        public List<PointD> GazeFilteredL { get; set; }

        public TargetTraceDefinitionEyeX TargetTraceEyeX;//no se puede usar get;set xq es una estructura ¿?

        public struct eyetrackerDataEyeX
        {
            public List<TargetTraceDefinitionEyeX> targetTraceL;
        }

        //Referencias que luego se agregaran a la lista TargetTraceL y que a lo largo de la app iran apuntando a lugares diferentes        
        public List<TargetTraceDefinitionEyeX> TargetTraceEyeXL { get; set; }//Lista que contiene todos los datos

        public eyetrackerDataEyeX generalDataEyeX;

        #endregion


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
            GazeWeigthedL = new List<PointD>();
            GazeFilteredL = new List<PointD>();
            TargetTraceEyeXL = new List<TargetTraceDefinitionEyeX>();
            generalDataEyeX = new eyetrackerDataEyeX();
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

        public void saveData2File()
        {
            generalDataEyeX.targetTraceL = TargetTraceEyeXL;

            DataBaseWorker.SaveEyeTrackerData(JsonConvert.SerializeObject(generalDataEyeX), Program.datosCompartidos.activeUser, LookAndPlayForm.Program.datosCompartidos.startTimeTest);

            string path = DataConverter.OldTypeDirectory(Program.datosCompartidos.startTimeTest, Program.datosCompartidos.activeUser);
            DataValidation.CheckDirectoryPath(path, true, FileAttributes.Hidden);
            File.WriteAllText(path + @"\eyetrackerData.json", JsonConvert.SerializeObject(generalDataEyeX));

            ClearList();
        }

        //Esto hay que separar de saveData2File(). Ahora mismo si se guardan gatos se graban. Pero existe la posibilidad de guardar datos pero que no quieran grabarse esos datos. Debe crearse una nueva variable que sea se_quieren_guardar_los_datos
        private void ClearList()
        {
            GazeDataItemEyeXL.Clear();
            GazeWeigthedL.Clear();
            GazeFilteredL.Clear();
            TargetTraceEyeXL.Clear();
        }

    }
}
