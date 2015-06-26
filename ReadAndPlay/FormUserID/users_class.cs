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
        public string user_gender { get; set; }
        public diagnosedConditionsClass user_diagnosedConditions { get; set; }

    }

    public class diagnosedConditionsClass
    {
        bool strabismusExotropia { get; set; }
        bool strabismusEsotropia { get; set; }
        bool astigmatism { get; set; }
        bool nystagmus { get; set; }
        bool amblyopia { get; set; }
        bool hypermetropia { get; set; }
        bool myopia { get; set; }
        bool cranialNervePalsy { get; set; }
        bool ADHD { get; set; }
        bool dislexia { get; set; }
        bool other { get; set; }

        public diagnosedConditionsClass(
                                    bool strabismusExotropia,
                                    bool strabismusEsotropia,
                                    bool astigmatism,
                                    bool nystagmus,
                                    bool amblyopia,
                                    bool hypermetropia,
                                    bool myopia,
                                    bool cranialNervePalsy,
                                    bool ADHD,
                                    bool dislexia,
                                    bool other
                                    )
        {
            this.strabismusExotropia = strabismusExotropia;
            this.strabismusEsotropia = strabismusEsotropia;
            this.astigmatism = astigmatism;
            this.nystagmus = nystagmus;
            this.amblyopia = amblyopia;
            this.hypermetropia = hypermetropia;
            this.myopia = myopia;
            this.cranialNervePalsy = cranialNervePalsy;
            this.ADHD = ADHD;
            this.dislexia = dislexia;
            this.other = other;
        }
    }
}
