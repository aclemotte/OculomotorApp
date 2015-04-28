using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LookAndPlayForm
{
    class eyesDetector
    {
        private int numberOfNoEyesTracked;
        private int maxNumberOfDataReceived;
        private sharedData datosCompartidos;


        public eyesDetector()
        {
            numberOfNoEyesTracked = 0;
            maxNumberOfDataReceived = settings.maxNumberOfDataReceived;
            this.datosCompartidos = LookAndPlayForm.Program.datosCompartidos;
        }

        public void dataReceived(Tobii.Gaze.Core.TrackingStatus dataStatus)
        {
            if (noEncontroOjos(dataStatus))
                numberOfNoEyesTrackedMasMas();
            else
                numberOfNoEyesTrackedMenosMenos();

            
            checkNumberOfNoEyesTrackedReceived();// si es valor maximo bandera true, si es valor minimo bandera false

        }

        //public void dataReceived(TETCSharpClient.Data.GazeData dataStatus)
        //{
        //    if (noEncontroOjos(dataStatus))
        //        numberOfNoEyesTrackedMasMas();
        //    else
        //        numberOfNoEyesTrackedMenosMenos();


        //    checkNumberOfNoEyesTrackedReceived();// si es valor maximo bandera true, si es valor minimo bandera false

        //}

        private void checkNumberOfNoEyesTrackedReceived()
        {
            if (numberOfNoEyesTracked == 0)
                datosCompartidos.eyeNotFound = false;

            if (numberOfNoEyesTracked == maxNumberOfDataReceived)
                datosCompartidos.eyeNotFound = true;            
        }

        private void numberOfNoEyesTrackedMasMas()
        {
            if (numberOfNoEyesTracked < maxNumberOfDataReceived)
                numberOfNoEyesTracked++;
        }

        private void numberOfNoEyesTrackedMenosMenos()
        {
            numberOfNoEyesTracked = 0;           
        }

        private bool noEncontroOjos(Tobii.Gaze.Core.TrackingStatus dataStatus)
        {
            if (dataStatus == Tobii.Gaze.Core.TrackingStatus.NoEyesTracked)
                return true;
            else
                return false;
        }

        //private bool noEncontroOjos(TETCSharpClient.Data.GazeData dataStatus)
        //{
        //    if (
        //        ((dataStatus.State & TETCSharpClient.Data.GazeData.STATE_TRACKING_GAZE) !=0) ||
        //        ((dataStatus.State & TETCSharpClient.Data.GazeData.STATE_TRACKING_EYES) !=0)
        //        )
        //        return false;
        //    else
        //        return true;
        //}
    }
}
