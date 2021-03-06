﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Web.Security;
using Projeto.Entidades;
using Projeto.Entidades.Tipos;
using Projeto.Aplicacao.Contratos;
using Projeto.Util;
using Projeto.Aplicacao.Servicos;
using Projeto.Infra.Repositorio.Repositorios;

namespace Projeto.Apresentacao.Areas.AreaRestrita.Security
{
    public class PermissaoProvider : RoleProvider
    {

       

        public override string[] GetRolesForUser(string idUsuario)
        {

            UsuarioRepositorio rep = new UsuarioRepositorio();

            Usuario u = rep.ObterPorId(Int32.Parse(idUsuario));

            if(u == null)
            {
                return new string[] { };
            }

            List<string> lista = new List<string>();

            lista.Add(EnumHelper.GetDescription(u.Perfil));

            return lista.ToArray();

        }






        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

       
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}