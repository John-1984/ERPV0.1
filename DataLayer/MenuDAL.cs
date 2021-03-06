﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DataLayer
{
    public class MenuDAL
    {
        /// <summary>
        /// Multiple ways of calling EF
        ///     - Simple Query:
        ///         string sql = $@"select ID from User";
        ///         rowId = dbContext.Database.SqlQuery<int>(sql).ToList();
        ///     - Connected/Disconnected Way.
        ///         DisConnected way is used in this application
        ///     - Via Stored Procedures
        ///         Demonstarted in Login Module
        /// </summary>
        private static List<BusinessModels.Menu> Menus = new List<BusinessModels.Menu>();

        public MenuDAL()
        {
        }

        public BusinessModels.Menu GetMenu(Int32 identity)
        {
            var _Menu = new BusinessModels.Menu();
            using (var dbContext = new MenuDbContext())
            {
                _Menu = dbContext.Menu                            
                            .FirstOrDefault(p => p.ID.Equals(identity));
            }
            return _Menu;
        }

        public BusinessModels.Menu GetMenuByName(String strName)
        {
            var _Menu = new BusinessModels.Menu();
            using (var dbContext = new MenuDbContext())
            {
                _Menu = dbContext.Menu
                            .FirstOrDefault(p => p.Name.Contains(strName));
            }
            return _Menu;
        }

        public IEnumerable<BusinessModels.Menu> GetMenuForModules(Int32 identity)
        {
            var _Menus = new List<BusinessModels.Menu>();
            using (var dbContext = new MenuDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Menus = dbContext.Menu.Where(p=>p.ModuleID==identity).ToList();
            }
            return _Menus;
        }

        public IEnumerable<BusinessModels.Menu> GetAll()
        {
            var _Menus = new List<BusinessModels.Menu>();
            using (var dbContext = new MenuDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Menus = dbContext.Menu
                            .Include(p=>p.Modules)
                            .ToList();
            }

            return _Menus;
        }

        public IEnumerable<BusinessModels.Menu> GetAll(int roleID)
        {
            var _Menus = new List<BusinessModels.Menu>();
            using (var dbContext = new MenuDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;

                var _menuIDs = dbContext.Role_Menu.
                                Where(p => p.RoleID.Equals(roleID))
                                .Select(p => p.MenuID).Distinct().ToArray();

                _Menus = (from menu in dbContext.Menu
                          where _menuIDs.Contains(menu.ID)
                          select menu)
                          .Include(p => p.Modules)
                          .ToList();
            }

            return _Menus;
        }

        public IEnumerable<BusinessModels.Menu> GetAllApprovalNeededItems()
        {
            var _Menus = new List<BusinessModels.Menu>();
            using (var dbContext = new MenuDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Menus = dbContext.Menu.Where(p => p.IsApprovalNeeded == true).ToList();
            }

            return _Menus;
        }

        public Boolean Update(BusinessModels.Menu Menu)
        {
            using (var dbContext = new MenuDbContext())
            {
                dbContext.Entry(Menu).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new MenuDbContext())
            {
                dbContext.Entry(new BusinessModels.Menu() { ID = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.Menu Menu)
        {
            using (var dbContext = new MenuDbContext())
            {
                dbContext.Entry(Menu).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
