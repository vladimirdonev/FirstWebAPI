using FirstWebAPI.Models;
using FirstWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstWebAPI.Controllers
{
    public class BooksController : Controller
    {
        private IBookServise bookServise { get; set; }

        public BooksController(IBookServise bookServise)
        {
            this.bookServise = bookServise;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetBooks()
        {
            return Ok(this.bookServise.AllBooks());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetBook(string id)
        {
            if (this.bookServise.GetBookById(id) != null)
            {
                return Ok(this.bookServise.GetBookById(id));
            }

            return NotFound($"Book with Id: {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]/Create")]
        public IActionResult Create(Book book)
        {
            this.bookServise.CreateBook(book);
            return Ok();
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Edit(Book book)
        {
            if (this.bookServise.GetBookById(book.Id) != null)
            {
                this.bookServise.EditBook(book);
                return Ok();
            }

            return NotFound($"Book with Id: {book.Id} was not found");
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult Delete(string id)
        {
            if (this.bookServise.GetBookById(id) != null)
            {
                this.bookServise.DeleteBook(id);
                return Ok();
            }

            return NotFound($"Book with Id: {id} was not found");
        }

    }
}
