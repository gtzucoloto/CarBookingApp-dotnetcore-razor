﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarBookingApp.Data;
using Microsoft.EntityFrameworkCore;

namespace CarBookingApp.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly CarBookingApp.Data.CarBookingAppDbContext _context;

        public CreateModel(CarBookingApp.Data.CarBookingAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }

        public SelectList Makes { get; set; }
        public SelectList Colours { get; set; }
        public SelectList Models { get; set; }

        public async Task<IActionResult> OnGet()
        {
            await LoadInitialData();
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadInitialData();
                return Page();
            }

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<JsonResult> OnGetCarModels(int makeId)
        {
            var models = await _context.CarModels
                .Where(q => q.MakeId == makeId)
                .ToListAsync();

            return new JsonResult(models);
        }

        private async Task LoadInitialData()
        {
            Makes = new SelectList(await _context.Makes.ToListAsync(), "Id", "Name");
            Colours = new SelectList(await _context.Colours.ToListAsync(), "Id", "Name");
        }
    }
}
