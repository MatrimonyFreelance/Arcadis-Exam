using BAL.Contract;
using BAL.Model;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BAL.Service
{
    public class Service : IService
    {
        private ArcadisExamContext _context;
        public Service(ArcadisExamContext context)
        {
            this._context = context;
        }

        public List<UserWorkSheet> GetUserWorkSheets()
        {
            var allWorkSheets = _context.ExampleWorkSheet.Select(x => x);
            if(allWorkSheets!=null && allWorkSheets.Count() > 0)
            {
                List<UserWorkSheet> userWorkSheets = new List<UserWorkSheet>();
                allWorkSheets.ToList().ForEach(item =>
                {
                    UserWorkSheet temp = new UserWorkSheet()
                    {
                        Cost = item.Cost,
                        Id = item.Id,
                        Quantity = item.Quantity,
                        Title = item.Title,
                        TotalCost = item.TotalCost,
                        CostInd = item.CostInd.TrimEnd().TrimStart(),
                        CostDesc = string.Concat(item.CostInd.TrimEnd().TrimStart(), item.Cost)
                    };
                    userWorkSheets.Add(temp);
                });
                return userWorkSheets;
            }
            else
            {
                return new List<UserWorkSheet>();
            }
        }

        public List<UserWorkSheet> InsertRecord(UserWorkSheet userWorkSheet)
        {
            int outputResult = 0;
            List<UserWorkSheet> returnValue = new List<UserWorkSheet>();
            var existingSheet = _context.ExampleWorkSheet.FirstOrDefault(x => x.CostInd == userWorkSheet.CostInd && x.Title == userWorkSheet.Title);
            if (existingSheet != null)
            {
                existingSheet.Quantity += userWorkSheet.Quantity;
                existingSheet.Cost = userWorkSheet.Cost;
                _context.ExampleWorkSheet.Update(existingSheet);
                outputResult = _context.SaveChanges();
                if (outputResult > 0)
                {
                    return this.GetUserWorkSheets();
                }
                else
                {
                    return new List<UserWorkSheet>();
                }
            }
            else
            {
                ExampleWorkSheet exampleWorkSheet = new ExampleWorkSheet();
                exampleWorkSheet.Cost = userWorkSheet.Cost;
                exampleWorkSheet.CostInd = userWorkSheet.CostInd;
                exampleWorkSheet.Title = userWorkSheet.Title;
                exampleWorkSheet.Quantity = userWorkSheet.Quantity;
                _context.ExampleWorkSheet.Add(exampleWorkSheet);
                outputResult = _context.SaveChanges();
                if (outputResult > 0)
                {
                    return this.GetUserWorkSheets();
                }
                else
                {
                    return new List<UserWorkSheet>();
                }
            }
        }

        private decimal getCost(string cost)
        {
            string result = Regex.Match(cost, @"\d+").Value; ;
            return decimal.Parse(result);
        }
        private string getcurrency(string cost)
        {
            string result = Regex.Match(cost, @"^[^0-9]*").Value.Trim();
            return result;
        }

        public List<UserWorkSheet> Search(string searchText)
        {
            List<UserWorkSheet> returnValue = new List<UserWorkSheet>();
            var allitems = _context.ExampleWorkSheet.ToList();
            var existingSheet = allitems.Where(x => x.Id.ToString() == searchText 
            || x.Title.ToLower().Contains(searchText.ToLower()) || x.Cost.ToString().Contains(searchText)
            || x.Quantity.ToString().Contains(searchText)
            || (string.Concat(x.CostInd.TrimEnd().TrimStart(), x.Cost)).Contains(searchText)
            || x.TotalCost.ToString().Contains(searchText)).Select(x=>x);
            if (existingSheet != null && existingSheet.Count() > 0)
            {
                List<UserWorkSheet> userWorkSheets = new List<UserWorkSheet>();
                existingSheet.ToList().ForEach(item =>
                {
                    UserWorkSheet temp = new UserWorkSheet()
                    {
                        Cost = item.Cost,
                        Id = item.Id,
                        Quantity = item.Quantity,
                        Title = item.Title,
                        TotalCost = item.TotalCost,
                        CostInd = item.CostInd.TrimEnd().TrimStart(),
                        CostDesc = string.Concat(item.CostInd.TrimEnd().TrimStart(), item.Cost)
                    };
                    userWorkSheets.Add(temp);
                });
                return userWorkSheets;
            }
            else
            {
                return new List<UserWorkSheet>();
            }
        }
        public List<UserWorkSheet> UpdateRecord(UserWorkSheet userWorkSheet)
        {
            int outputResult = 0;
            List<UserWorkSheet> returnValue = new List<UserWorkSheet>();
            var existingSheet = _context.ExampleWorkSheet.FirstOrDefault(x => x.Id == userWorkSheet.Id);
            if (existingSheet != null)
            {
                existingSheet.Quantity = userWorkSheet.Quantity;
                existingSheet.Title = userWorkSheet.Title;
                existingSheet.Cost = getCost(userWorkSheet.CostDesc);
                existingSheet.CostInd = getcurrency(userWorkSheet.CostDesc);
                _context.ExampleWorkSheet.Update(existingSheet);
                outputResult = _context.SaveChanges();
                if (outputResult > 0)
                {
                    return this.GetUserWorkSheets();
                }
                else
                {
                    return new List<UserWorkSheet>();
                }
            }
            else
            {
                return new List<UserWorkSheet>();
            }
        }

        public List<UserWorkSheet> DeleteRecord(int id)
        {
            int outputResult = 0;
            List<UserWorkSheet> returnValue = new List<UserWorkSheet>();
            var existingSheet = _context.ExampleWorkSheet.FirstOrDefault(x => x.Id == id);
            if (existingSheet != null)
            {
                _context.ExampleWorkSheet.Remove(existingSheet);
                outputResult = _context.SaveChanges();
                if (outputResult > 0)
                {
                    return this.GetUserWorkSheets();
                }
                else
                {
                    return new List<UserWorkSheet>();
                }
            }
            else
            {
                return new List<UserWorkSheet>();
            }
        }
    }
}
