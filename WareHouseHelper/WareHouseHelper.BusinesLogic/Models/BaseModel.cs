using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouseHelper.BusinesLogic.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual bool IsValid()
        {
            return true;
        }
    }
}