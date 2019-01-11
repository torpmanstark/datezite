﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;


namespace datezite.Models
{
    public class GetApplicationUser
    {
        public ApplicationDbContext _context { get; set; }

        public GetApplicationUser()
        {
            _context = new ApplicationDbContext();
        }

        

        public ApplicationUser GetUserByName(string name)
        {
            var appUser = _context.Users.Single(u => u.UserName == name);
            return appUser;


        }

        public ApplicationUser GerUserById(string id)
        {
            var appUser = _context.Users.Single(u => u.Id == id);
            
            foreach(var entry in _context.Entries)
            {
                if(id == entry.RecipientId)
                {
                    appUser.Inlägg.Add(entry);
                }
            }

            return appUser;

        }

        


    }
}