﻿using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController (SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        //chamando o servico SellerService
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        //metodo para segurança abaixo
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {

            _sellerService.Insert(seller);
            return RedirectToAction("Index");
        }
    }
}
