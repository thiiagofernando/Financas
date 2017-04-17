﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Financas.DAO;
using Financas.Entidades;
using Financas.Models;
using WebMatrix.WebData;
using System.Web.Security;

namespace Financas.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private UsuarioDAO usuarioDAO;
        public UsuarioController(UsuarioDAO usuarioDAO)
        {
            this.usuarioDAO = usuarioDAO;
        }
        // GET: Usuario
        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(UsuarioModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(model.Nome, model.Senha, 
                        new {Email = model.Email });
                    return RedirectToAction("Index");
                }
                catch(MembershipCreateUserException e)
                {
                    ModelState.AddModelError("Usuario invalido", e.Message);
                    return View("Form", model);
                }
                
            }
            else
            {
                return View("Form", model);
            }
        }

        public ActionResult Index()
        {
            IList<Usuario> usuarios = usuarioDAO.Lista();
            return View(usuarios);
        }
    }
}