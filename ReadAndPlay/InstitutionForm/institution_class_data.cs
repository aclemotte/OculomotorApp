using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LookAndPlayForm.InstitutionID
{
    public class institution_class_data
    {
        public string institution_id { get; set; }
        public string institution_name { get; set; }

        public institution_class_data() { }

        public institution_class_data(string id, string name)
        {
            institution_id = id;
            institution_name = name;
        }
    }
}
