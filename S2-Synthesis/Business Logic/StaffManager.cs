using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Interfaces;

namespace Business_Logic
{
   public class StaffManager : IStaffData
    {
        private readonly IStaffData src;

        public StaffManager(IStaffData src) => this.src = src;

        public Staff[] GetStaff() => this.src.GetStaff();

        public bool LoginStaff(Staff s)
        {
            foreach(Staff staff in this.GetStaff())
            {
                if(s.Password == staff.Password && s.Username == staff.Username)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
