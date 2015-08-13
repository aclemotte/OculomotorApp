using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookAndPlayForm
{
    public class patient_class_datav1
    {
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string user_institution { get; set; }
    }

    public class patient_class_datav2
    {
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string user_institution { get; set; }
        public string user_age { get; set; }
        public string user_country { get; set; }
        public string user_email { get; set; }
        public userGender user_gender { get; set; }
        public diagnosedConditionsClassv1 user_diagnosedConditions { get; set; }

    }

    public class patient_class_datav3
    {
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string user_institution { get; set; }
        public string user_age { get; set; }
        public string user_country { get; set; }
        public string user_email { get; set; }
        public userGender user_gender { get; set; }
        public diagnosedConditionsClassv2 user_diagnosedConditions { get; set; }

        public patient_class_datav3()
        {
            user_diagnosedConditions = new diagnosedConditionsClassv2();
        }

    }

    public enum userGender
    {
        male = 1, female = 2
    }

    public class diagnosedConditionsClassv1
    {
        public bool strabismusExotropia { get; set; }
        public bool strabismusEsotropia { get; set; }
        public bool astigmatism { get; set; }
        public bool nystagmus { get; set; }
        public bool amblyopia { get; set; }
        public bool hypermetropia { get; set; }
        public bool myopia { get; set; }
        public bool cranialNervePalsy { get; set; }
        public bool ADHD { get; set; }
        public bool dislexia { get; set; }
        public bool other { get; set; }

    }

    public class diagnosedConditionsClassv2
    {
        public bool strabismusExotropia { get; set; }
        public bool strabismusEsotropia { get; set; }
        public bool astigmatism { get; set; }
        public bool nystagmus { get; set; }
        public bool amblyopia { get; set; }
        public bool hypermetropia { get; set; }
        public bool myopia { get; set; }
        public bool cranialNervePalsy { get; set; }
        public bool ADHD { get; set; }
        public bool dislexia { get; set; }
        public bool other { get; set; }
        public bool convergenceInsufficiency { get; set; }
    }
}
