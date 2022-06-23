using Microsoft.AspNetCore.Mvc;
using Project.Core.Services;

namespace Project.WEBUI.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _service;

		public ProductController(IProductService service)
		{
			_service = service;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _service.GetProductsWithCategory());
		}
	}
}
