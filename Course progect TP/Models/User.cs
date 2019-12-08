using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Course_progect_TP.Models
{
    public class User
    {
        [Key]
        public int Id_User { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Date_of_birth { get; set; }
        public int Experience { get; set; }
        public int Id_Role { get; set; }
        public string Login { get; set; }
        public string GetRole
        {
            get
            {
                String RoleString;
                if (Id_Role == 1)
                {
                    RoleString = "Администратор";
                }
                else
                {
                    if (Id_Role == 2)
                    {
                        RoleString = "Водитель";
                    }
                    else
                    {
                        if (Id_Role == 3)
                        {
                            RoleString = "Кондуктор";
                        }
                        else
                        {
                            if (Id_Role == 4)
                            {
                                RoleString = "Диспетчер";
                            }
                            else
                            {
                                RoleString = "Не назначена";
                            }
                        }
                    }
                }
                return RoleString;
            }
            set { }
        }
    }
}