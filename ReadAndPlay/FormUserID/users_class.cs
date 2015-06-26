using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookAndPlayForm
{
    public class users_class
    {
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string user_institution { get; set; }
        public string user_age { get; set; }
        public string user_country { get; set; }
        public string user_email { get; set; }
        public userGender user_gender { get; set; }
        public diagnosedConditionsClass user_diagnosedConditions { get; set; }

    }

    public enum userGender
    {
        male = 1, female = 2
    }

    public class diagnosedConditionsClass
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

        //public diagnosedConditionsClass(
        //                            bool strabismusExotropia,
        //                            bool strabismusEsotropia,
        //                            bool astigmatism,
        //                            bool nystagmus,
        //                            bool amblyopia,
        //                            bool hypermetropia,
        //                            bool myopia,
        //                            bool cranialNervePalsy,
        //                            bool ADHD,
        //                            bool dislexia,
        //                            bool other
        //                            )
        //{
        //    this.strabismusExotropia = strabismusExotropia;
        //    this.strabismusEsotropia = strabismusEsotropia;
        //    this.astigmatism = astigmatism;
        //    this.nystagmus = nystagmus;
        //    this.amblyopia = amblyopia;
        //    this.hypermetropia = hypermetropia;
        //    this.myopia = myopia;
        //    this.cranialNervePalsy = cranialNervePalsy;
        //    this.ADHD = ADHD;
        //    this.dislexia = dislexia;
        //    this.other = other;
        //}
    }
}
