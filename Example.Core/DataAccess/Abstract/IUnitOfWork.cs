using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Core.DataAccess.Abstract
{
    public interface IUnitOfWork<T>
    {
        Task Commit(); // _context.SaveChanges() 

        //order ekle metodu çağırdım
        //order det ekle metodu

        //commit

        //product ekle metodu
        //commit
    }
}
