using System.Collections.Generic;
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