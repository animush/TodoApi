﻿namespace TodoApi.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new()
        {
            new UserModel(){ Username="admin",Password="admin",Role="Admin"}
        };
    }
}
