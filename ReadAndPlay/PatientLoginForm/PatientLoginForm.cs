using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;

namespace LookAndPlayForm
{
    public partial class PatientLoginForm : Form
    {
        /*
            busca la carpeta root, retorno en bool, sino existe lo crea
            busca y lee users.cvs, retorno en bool, sino existe lo crea
            
            espera boton ok
                
            al darle al boton ok pregunta por id usuario

            si id usuario es nuevo (mayor a id last_session)
            {
                pregunta por el resto de la info
                - name
                - institution
            }
            
            Se inicia la prueba

            Al final de la prueba actualiza users.cvs con updateCsV();
            Al final de la prueba se genera una carpeta:
            user-date
        */

        //user id del primer user es 1, no cero

        string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\";
        bool datosMigrados2NewFromClassv1 = false;
        bool datosMigrados2NewFromClassv2 = false;

        public bool newUser { get; set; }                        
        public patient_class_datav3 patientDataSelected { get; set; }
        public List<patient_class_datav3> patientsList { get; set; }
        public bool closeApp { get; set; }




        public PatientLoginForm()
        {
            InitializeComponent();
            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            closeApp = true;


            bool rootFolder = rootFolderExist();
            bool userFile = usersFileExist(rootFolder);
            patients2Form();                 
        }

        public void updateCsv()
        {
            if (patientsList != null)
            {

                //caso que se haya introducido un nuevo usuario, 
                //se almacena en la lista el nuevo usuario y 
                //se guarda la lista en un archivo csv
                if (numericUpDownUserID.Value > Convert.ToDecimal(patientsList.Last().user_id))
                {
                    patientsList.Add(patientDataSelected);

                    if (datosMigrados2NewFromClassv1 || datosMigrados2NewFromClassv2)
                        BackUpOldUserFile();

                    reWriteCsv();
                }
                else 
                {                
                    //caso que no se haya introducido un nuevo usuario, pero de que se haya migrado
                    if (datosMigrados2NewFromClassv1 || datosMigrados2NewFromClassv2)
                    {
                        BackUpOldUserFile();
                        reWriteCsv();
                    }
                }
                
            }
            else
            {
                patientsList = new List<patient_class_datav3>();
                patientsList.Add(patientDataSelected);
                reWriteCsv();
            }

        }

        private void reWriteCsv()
        {
            using (var sw = new StreamWriter(rootPath + @"users.csv"))
            {
                var writer = new CsvWriter(sw);
                //Write the entire contents of the CSV file into another
                writer.WriteRecords(patientsList);
            }
        }

        private void BackUpOldUserFile()
        {
            try
            {
                if(datosMigrados2NewFromClassv1)
                    File.Copy(rootPath + @"users.csv", rootPath + @"users_classv1.csv");
                else if(datosMigrados2NewFromClassv2)
                    File.Copy(rootPath + @"users.csv", rootPath + @"users_classv2.csv");
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }
        








        private bool rootFolderExist()
        {
            if (Directory.Exists(rootPath))
            {
                return true;
            }
            else
            {
                Console.WriteLine("rootFolderExist no existe");
                Directory.CreateDirectory(rootPath);
                return false;
            }
        }

        private bool usersFileExist(bool rootFolderExist)
        {
            string fileName = rootPath + @"users.csv";

            if (File.Exists(fileName))
            {

                //leer patient_class_datav3
                using (var sr3 = new StreamReader(fileName))
                {
                    var reader3 = new CsvReader(sr3);
                    try
                    {
                        datosMigrados2NewFromClassv1 = false;
                        datosMigrados2NewFromClassv2 = false;
                        patientsList = reader3.GetRecords<patient_class_datav3>().ToList();
                        return true;
                    }
                    catch (Exception e3)
                    {
                        ErrorLog.ErrorLog.toErrorFile(e3.GetBaseException().ToString());
                        
                        //leer patient_class_datav2
                        using (var sr2 = new StreamReader(fileName))
                        {
                            var reader2 = new CsvReader(sr2);
                            try
                            {
                                patientClassv2ToClassv3(reader2);
                                datosMigrados2NewFromClassv2 = true;
                                return true;
                            }
                            catch (Exception e2)
                            {
                                ErrorLog.ErrorLog.toErrorFile(e2.GetBaseException().ToString());
                                
                                //leer patient_class_datav1
                                using (var sr1 = new StreamReader(fileName))
                                {
                                    var reader1 = new CsvReader(sr1);
                                    try
                                    {
                                        patientClassv1ToClassv3(reader1);
                                        datosMigrados2NewFromClassv1 = true;
                                        return true;
                                    }
                                    catch (Exception e1)
                                    {
                                        ErrorLog.ErrorLog.toErrorFile(e1.GetBaseException().ToString());
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                ErrorLog.ErrorLog.toErrorFile(fileName + " no existe (users file)");
                return false;
            }
        }


        private void patientClassv1ToClassv3(CsvReader reader)
        {
            patientsList = new List<patient_class_datav3>();//lista vacia
            List<patient_class_datav1> usersListOldClass = reader.GetRecords<patient_class_datav1>().ToList();//lista de la clase vieja

            //Convertidor de Lista de clase nueva
            for (int indiceLista = 0; indiceLista < usersListOldClass.Count; indiceLista++)
            {
                patient_class_datav3 one_users_NewClass = new patient_class_datav3();
                one_users_NewClass.user_id = usersListOldClass[indiceLista].user_id;
                one_users_NewClass.user_name = usersListOldClass[indiceLista].user_name;
                one_users_NewClass.user_institution = usersListOldClass[indiceLista].user_institution;
                patientsList.Add(one_users_NewClass);
            }
        }

        private void patientClassv2ToClassv3(CsvReader reader)
        {
            patientsList = new List<patient_class_datav3>();//lista vacia
            List<patient_class_datav2> usersListOldClass = reader.GetRecords<patient_class_datav2>().ToList();//lista de la clase vieja

            //Convertidor de Lista de clase nueva
            for (int indiceLista = 0; indiceLista < usersListOldClass.Count; indiceLista++)
            {
                patient_class_datav3 one_users_NewClass = new patient_class_datav3();
                one_users_NewClass.user_id = usersListOldClass[indiceLista].user_id;
                one_users_NewClass.user_name = usersListOldClass[indiceLista].user_name;
                one_users_NewClass.user_institution = usersListOldClass[indiceLista].user_institution;
                one_users_NewClass.user_age = usersListOldClass[indiceLista].user_age;//age
                one_users_NewClass.user_country = usersListOldClass[indiceLista].user_country;//country
                one_users_NewClass.user_email = usersListOldClass[indiceLista].user_email;//email
                one_users_NewClass.user_gender = usersListOldClass[indiceLista].user_gender;//gender
                one_users_NewClass.user_diagnosedConditions.strabismusExotropia = usersListOldClass[indiceLista].user_diagnosedConditions.strabismusExotropia;
                one_users_NewClass.user_diagnosedConditions.strabismusEsotropia = usersListOldClass[indiceLista].user_diagnosedConditions.strabismusEsotropia;
                one_users_NewClass.user_diagnosedConditions.astigmatism = usersListOldClass[indiceLista].user_diagnosedConditions.astigmatism;
                one_users_NewClass.user_diagnosedConditions.nystagmus = usersListOldClass[indiceLista].user_diagnosedConditions.nystagmus;
                one_users_NewClass.user_diagnosedConditions.amblyopia = usersListOldClass[indiceLista].user_diagnosedConditions.amblyopia;
                one_users_NewClass.user_diagnosedConditions.hypermetropia = usersListOldClass[indiceLista].user_diagnosedConditions.hypermetropia;
                one_users_NewClass.user_diagnosedConditions.myopia = usersListOldClass[indiceLista].user_diagnosedConditions.myopia;
                one_users_NewClass.user_diagnosedConditions.cranialNervePalsy = usersListOldClass[indiceLista].user_diagnosedConditions.cranialNervePalsy;
                one_users_NewClass.user_diagnosedConditions.ADHD = usersListOldClass[indiceLista].user_diagnosedConditions.ADHD;
                one_users_NewClass.user_diagnosedConditions.dislexia = usersListOldClass[indiceLista].user_diagnosedConditions.dislexia;
                one_users_NewClass.user_diagnosedConditions.other = usersListOldClass[indiceLista].user_diagnosedConditions.other;
                //one_users_NewClass.user_diagnosedConditions.convergenceInsufficiency = usersListOldClass[indiceLista].user_diagnosedConditions;//nuevo
                patientsList.Add(one_users_NewClass);
            }
        }

        private bool patients2Form()
        {
            if (patientsList != null)
            {
                numericUpDownUserID.Maximum = Convert.ToDecimal(patientsList.Last().user_id);
                numericUpDownUserID.Value = Convert.ToDecimal(patientsList.Last().user_id);
            }
            //sino se queda en cero que es lo que esta por defecto
            return true;
        }



        private void numericUpDownUserID_ValueChanged(object sender, EventArgs e)
        {
            if (patientsList != null)
            {
                if (numericUpDownUserID.Value <= Convert.ToDecimal(patientsList.Last().user_id))
                {
                    //2. para cuando se llega al numero de un usuario conocido se rellena con texto del usuario
                    int userIndex = Convert.ToInt32(numericUpDownUserID.Value) - 1;
                    textBoxUserName.Text = patientsList[userIndex].user_name;
                    textBoxUserName.ReadOnly = true;
                }
            }
        }
        
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (numericUpDownUserID.Value > 0 )
            {
                patientDataSelected = new patient_class_datav3();
                patientDataSelected.user_id = numericUpDownUserID.Value.ToString();
                patientDataSelected.user_name = textBoxUserName.Text;
                patientDataSelected.user_institution = Program.datosCompartidos.institutionName;
                closeApp = false;
            }
            else
            {
                MessageBox.Show("To continue, enter a new patient.", "Empty list of patients.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }

        private void buttonNewPatient_Click(object sender, EventArgs e)
        {
            decimal newUserID;

            if (patientsList != null)
            {
                newUserID = Convert.ToDecimal(patientsList.Last().user_id) + 1;
            }
            else
            {
                newUserID = 1;
            }

            FormPatientID patientNewForm = new FormPatientID(newUserID);
            patientNewForm.ShowDialog();
            newUser = patientNewForm.newUser;

            if (newUser)
            {
                patientDataSelected = patientNewForm.patientDataSelected;
                newUser2Form();//cargar datos del nuevo usuario al form
            }

            patientNewForm.Dispose();
            patientNewForm = null;
        }

        private void newUser2Form()
        {
            numericUpDownUserID.Maximum = Convert.ToDecimal(patientDataSelected.user_id);
            numericUpDownUserID.Value = Convert.ToDecimal(patientDataSelected.user_id);
            textBoxUserName.Text = patientDataSelected.user_name;
        }
    }
}
