using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.ViewModels;
using WebApplication1.Models.EFModels;

namespace WebApplication1.Controllers
{
    public class AccountsController : Controller
    {
        private AppDbContext _context;

        public AccountsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var viewModelList = _context.Accounts
                                        .AsNoTracking()
                                        .Include(x=>x.Owner)
                                        .Where(a => a.Owner.NationalId == "K188888886")
                                        .Select(a => new AccountViewModel
                                        {
                                            NationalId = a.Owner.NationalId,
                                            BranchId = a.BranchId,
                                            AcctSerialId = a.AcctSerialId
                                        })
                                        .ToList();

            return View(viewModelList);
        }
    }
}
