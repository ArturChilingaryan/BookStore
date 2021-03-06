using BookStore.Model;
using System;
using System.Linq;

namespace BookStore.ModelFactory
{
    public class BranchFactory
    {
        private static BranchFactory instance;
        private BranchFactory()
        {
        }

        public static BranchFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new BranchFactory();
            }
            return instance;
        }

        public BranchInfo CreateBranch(ModelContext dbcontext, string branchName)
        {

            BranchInfo branchInfo = dbcontext.BranchInfos.FirstOrDefault(a => a.Name == branchName);
            if (branchInfo == null)
            {
                branchInfo = new BranchInfo { Name = branchName };

                dbcontext.BranchInfos.Add(branchInfo);
                dbcontext.SaveChanges();
            }
            return branchInfo;

        }

        public BranchInfo GetBranchInfoByID(ModelContext dbcontext, int id)
        {

            BranchInfo bookGenre = dbcontext.BranchInfos.FirstOrDefault(a => a.ID == id);
            if (bookGenre == null)
            {
                throw new Exception("No such branch with ID: " + id);
            }
            return bookGenre;

        }
    }
}
