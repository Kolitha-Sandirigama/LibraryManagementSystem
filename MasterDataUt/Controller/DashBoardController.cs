using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.Controller
{
    public interface DashBoardController
    {
        int getTotalActiveBookCount();
        int getTotalAvailableBookCount();
        int getTotalBorrowedBookCount();
        int getTotalActiveUserCount();
    }
}
