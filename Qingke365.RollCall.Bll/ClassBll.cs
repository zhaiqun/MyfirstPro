using Qingke365.RollCall.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qingke365.RollCall.Bll
{
    public class ClassBll:IClassBll
    {
        public IClassDal dal;
        public ClassBll(IClassDal dal)
        {
            this.dal = dal;
        }

        public void SayHello()
        {
            dal.SayHello();
        }
    }
}
