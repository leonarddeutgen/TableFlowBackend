using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data.Entities;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PermissionModelController : Controller
{
    private readonly IPermissionModelService _permissionModelService;

    public PermissionModelController(IPermissionModelService permissionModelService)
    {
        _permissionModelService = permissionModelService;
    }
    // GET ALL PERMISSIONS
    [HttpGet]
    public async Task<IActionResult> GetAllPermissions()
    {
        List<PermissionModel?> allPermissions = await _permissionModelService.GetAllOrganisationsAsync();

        return Ok(allPermissions);
    }
}