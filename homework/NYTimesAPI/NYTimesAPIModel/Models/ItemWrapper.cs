using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NYTimesAPIModel.Models
{
    public partial class ItemWrapper
    {
        public List<Multimedia> Multimedia
        {
            get;
            set;
        }

        public List<Result> Result
        {
            get;
            set;
        }
    }
}
