using AACalc.DAL.Data;
using AACalc.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AACalc.BAL
{
    /// <summary>
    /// UserBL class
    ///  Added by YReddy on 12/10/2015
    /// </summary>
    public class UserBL : BaseBL
    {
        /// <summary>
        /// Get User by Name 
        /// <retUsers>UserViewModel</retUsers>
        public static UserViewModel GetUserByNameAndPassword(string UserName, string Password)
        {
            try
            {
                tblUser userEntity = _context.tblUsers.Where(x => x.UserName == UserName & x.Password == Password).FirstOrDefault();
                var User = GetUserViewModelFromUserEntity(userEntity);
                return User;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets User ViewModel from User Entity
        /// </summary>
        /// <param name="user">User Entity</param>
        /// <returns>User ViewModel</returns>
        protected static UserViewModel GetUserViewModelFromUserEntity(tblUser user)
        {
            UserViewModel User = new UserViewModel()
            {
                Password = user.Password,
                RoleId = user.Role,
                UserName = user.UserName,
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FullName,
                CreatedBy = user.CreatedBy
            };
            return User;
        }

        /// <summary>
        /// Getting Menus by User IDs
        /// </summary>
        /// <param name="RoleId">RoleId</param>
        /// <param name="UserId">UserId</param>
        /// <returns></returns>
        public static List<MenuViewModel> GetMenuByRoleId(int RoleId, int UserId)
        {
            try
            {
                List<MenuViewModel> menus = new List<MenuViewModel>();
                var menuEntityList = _context.UserMenus.Where(x => x.UserId == UserId && x.RoleId == RoleId).ToList();
                foreach (var menuEntity in menuEntityList)
                {
                    var menu = new MenuViewModel()
                    {
                        MenuId = menuEntity.MenuId,
                        CssClass = menuEntity.CssClass,
                        DisplayOrder = menuEntity.DisplayOrder,
                        URL = menuEntity.Url,
                        MenuName = menuEntity.Name,
                    };
                    menus.Add(menu);
                }

                //(from u in _context.tblUsers
                //    join r in _context.tblRoles on u.Role equals r.RoleId
                //    join rm in _context.tblRoleMenus on r.RoleId equals rm.RoleId
                //    join m in _context.tblMenus on rm.MenuId equals m.MenuId
                //    select new
                //    {
                //        MenuId = m.MenuId,
                //        CssClass = m.CssClass,
                //        DisplayOrder = m.DisplayOrder,
                //        URL = m.Url,
                //        MenuName = m.Name,                                                     
                //    });
                return menus;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
