using BAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Contract
{
    public interface IService
    {
        List<UserWorkSheet> GetUserWorkSheets();
        List<UserWorkSheet> InsertRecord(UserWorkSheet userWorkSheet);

        List<UserWorkSheet> UpdateRecord(UserWorkSheet userWorkSheet);

        List<UserWorkSheet> DeleteRecord(int id);

        List<UserWorkSheet> Search(string searchText);
    }
}
