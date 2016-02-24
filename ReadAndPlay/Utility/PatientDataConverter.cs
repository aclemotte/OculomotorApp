using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LookAndPlayForm.Utility
{
    public class PatientDataConverter
    {
        public static List<patient_class_datav3> GetPatients(string fileName)
        {
            List<patient_class_datav3> patientsList = null;
            if (File.Exists(fileName))
            {
                //leer patient_class_datav3
                using (var sr3 = new StreamReader(fileName))
                {
                    var reader3 = new CsvReader(sr3);
                    try
                    {
                        patientsList = reader3.GetRecords<patient_class_datav3>().ToList();
                    }
                    catch (Exception e3)
                    {
                        //ErrorLog.ErrorLog.toErrorFile(e3.GetBaseException().ToString());

                        //leer patient_class_datav2
                        using (var sr2 = new StreamReader(fileName))
                        {
                            var reader2 = new CsvReader(sr2);
                            try
                            {
                                patientsList = PatientDataConverter.patientClassv2ToClassv3(reader2);
                            }
                            catch (Exception e2)
                            {
                                //ErrorLog.ErrorLog.toErrorFile(e2.GetBaseException().ToString());

                                //leer patient_class_datav1
                                using (var sr1 = new StreamReader(fileName))
                                {
                                    var reader1 = new CsvReader(sr1);
                                    try
                                    {
                                        patientsList = PatientDataConverter.patientClassv1ToClassv3(reader1);
                                    }
                                    catch (Exception e1)
                                    {
                                        ErrorLog.ErrorLog.toErrorFile(e1.GetBaseException().ToString());
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
            }

            return patientsList;
        }



        public static List<patient_class_datav3> patientClassv1ToClassv3(CsvReader reader)
        {
            List<patient_class_datav3> patientsList = new List<patient_class_datav3>();//lista vacia
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

            return patientsList;
        }

        public static List<patient_class_datav3> patientClassv2ToClassv3(CsvReader reader)
        {
            List<patient_class_datav3>  patientsList = new List<patient_class_datav3>();//lista vacia
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

            return patientsList;
        }
    }
}
