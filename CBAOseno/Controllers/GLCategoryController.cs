using Microsoft.AspNetCore.Mvc;
using CBAOseno.Services.Interfaces;
using CBAOseno.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CBAOseno.Core.Models;
using CBAOseno.WebApi.ViewModels;
using CBAOseno.Data;

namespace CBAOseno.WebApi.Controllers
{
    public class GLCategoryController : Controller
    {
        private readonly IGLCategoryOperation _operations;
        public GLCategoryController(IGLCategoryOperation operations)
        {
            _operations = operations;
        }


        public IActionResult Index()
        {
            var gLCategorys = _operations.GetAllGLCategorys();
            return View(gLCategorys);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddGLCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                GLCategory newGLCategory = new()
                {
                    CategoryId = model.CategoryId,
                    CategoryName = model.CategoryName,
                    Status = model.Status,
                    CategoryDescription = model.CategoryDescription,
					Categories = model.Categories,
                    //CategoryCode = _operations.CreateGlCategoryCode(gLCategory),
                    //GLCategoryAccount = model.GLCategoryAccount,
                };
                _operations.Save(newGLCategory);
                //return RedirectToAction("index", new { id = newUser.Id });
                return RedirectToAction("index", "GLCategory", new { area = "" });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var gLCategory = _operations.RetrieveById(id);
            EditGLCategoryViewModel editUserViewModel = new EditGLCategoryViewModel()
            {
                //GLCategoryId = gLCategory.GLCategoryId,
                CategoryName = gLCategory.CategoryName,
                Status = gLCategory.Status,
				CategoryCode = gLCategory.CategoryCode,
				CategoryDescription = gLCategory.CategoryDescription,
				Categories = gLCategory.Categories,
            };
            return View(editUserViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var gLCategory = _operations.RetrieveById(id);
            EditGLCategoryViewModel editUserViewModel = new EditGLCategoryViewModel()
            {
                //GLCategoryId = gLCategory.GLCategoryId,
                CategoryName = gLCategory.CategoryName,
                Status = gLCategory.Status,
				CategoryDescription = gLCategory.CategoryDescription,
            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditGLCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                GLCategory gLCategory = _operations.RetrieveById(model.Id);
                //Console.WriteLine(model.Id);
                //gLCategory.GLCategoryId = model.GLCategoryId;
                gLCategory.CategoryName = model.CategoryName;
                gLCategory.Status = model.Status;
				gLCategory.CategoryDescription = model.CategoryDescription;

                GLCategory updatedGLCategory = _operations.UpdateGLCategory(gLCategory);

                return RedirectToAction("index", "GLCategory", new { area = "" });
            }

            return View(model);
        }
    }
}