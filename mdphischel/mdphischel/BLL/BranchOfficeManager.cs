using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mdphischel.DAL;
using mdphischel.DAL.Models;

namespace mdphischel.BLL
{
    public class BranchOfficeManager
    {

        public List<BranchOffice> GetAllBranchOffices()
        {
            DBBranchOffice branchOfficeDAL = new DBBranchOffice();
            return branchOfficeDAL.GetPrescriptionByDoctor("");
        }
    }
}