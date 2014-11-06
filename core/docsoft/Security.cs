using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using docsoft.entities;
using linh.common;
namespace docsoft
{
    public class Security
    {
        private const string cookieName = "linhUser";
        private const string sessionName = "Username";
        public static bool IsAuthenticated()
        {
            var ok = false;
            if (HttpContext.Current.Session[sessionName] != null)
            {
                ok = true;
            }
            else
            {
                var c = HttpContext.Current.Request.Cookies[cookieName];
                if (c != null)
                {
                    ok = true;
                }
            }
            return ok;
        }
        public static string Username
        {
            get
            {
                if (HttpContext.Current.Session[sessionName] != null)
                {
                    var Item = (Member)(HttpContext.Current.Session[sessionName]);
                    return Item.Username;
                }
                else
                {
                    var c = HttpContext.Current.Request.Cookies[cookieName];
                    if (c != null)
                    {
                        return c.Values["Username"].ToString();
                    }
                }
                return string.Empty;
            }
        }
        public static string Ten
        {
            get
            {
                if (HttpContext.Current.Session[sessionName] != null)
                {
                    var Item = (Member)(HttpContext.Current.Session[sessionName]);
                    return Item.Ten;
                }
                else
                {
                    var c = HttpContext.Current.Request.Cookies[cookieName];
                    if (c != null)
                    {
                        return c.Values["Ten"].ToString();
                    }
                }
                return string.Empty;
            }
        }
        public static int UserId
        {
            get
            {
                if (HttpContext.Current.Session[sessionName] != null)
                {
                    var Item = (Member)(HttpContext.Current.Session[sessionName]);
                    return Item.ID;
                }
                else
                {
                    var c = HttpContext.Current.Request.Cookies[cookieName];
                    if (c != null)
                    {
                        return Convert.ToInt32(c.Values["UserId"]);
                    }
                }
                return 0;
            }
        }
        public static int CqId
        {
            get
            {
                if (HttpContext.Current.Session[sessionName] != null)
                {
                    var Item = (Member)(HttpContext.Current.Session[sessionName]);
                    return Item.CQ_ID;
                }
                else
                {
                    var c = HttpContext.Current.Request.Cookies[cookieName];
                    if (c != null)
                    {
                        return Convert.ToInt32(c.Values["CQID"]);
                    }
                }
                return 0;
            }
        }
        public static bool Login(string username, string pwd, string ReUser)
        {
            var isOke = false;
            if (username == null || pwd == null)
            {
                return isOke;
            }
            HttpContext.Current.Session[sessionName] = null;
            var Item = new Member();
            Item = MemberDal.SelectByUsername(username);
            var c = new HttpCookie(cookieName);
            Item.Username = username;
            HttpContext.Current.Session[sessionName] = null;
            var temp = maHoa.MD5Encrypt(pwd);
            if (Item.Password != null)
            {
                if ((Item.Password == maHoa.MD5Encrypt(pwd)) || (maHoa.DecryptString(Item.Password, username) == pwd))
                {
                    HttpContext.Current.Session[sessionName] = Item;
                    isOke = true;
                    switch (ReUser.ToLower())
                    {
                        case "true":
                            c.Values.Add("Username", username);
                            c.Values.Add("UserId", Item.ID.ToString());
                            c.Values.Add("Ten", Item.Ten);
                            c.Values.Add("CQID", Item.CQ_ID.ToString());
                            c.Expires = DateTime.Now.AddDays(14);
                            HttpContext.Current.Response.Cookies.Add(c);
                            break;
                        case "false":
                            c.Expires = DateTime.Now.AddDays(-1);
                            HttpContext.Current.Response.Cookies.Add(c);
                            break;
                    }
                }
                else
                {
                    c.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Add(c);
                }
            }
            else
            {
                c.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(c);
            }
            return isOke;
        }
        public static bool Login(string username, string ReUser)
        {
            bool isOke = false;
            HttpContext.Current.Session[sessionName] = null;
            Member Item = new Member();
            HttpCookie c = new HttpCookie(cookieName);
            Item.Username = username;
            HttpContext.Current.Session[sessionName] = null;
            HttpContext.Current.Session[sessionName] = Item;
            isOke = true;
            if (ReUser.ToLower() == "true")
            {
                c.Values.Add("Username", username);
                c.Values.Add("UserId", Item.ID.ToString());
                c.Values.Add("Ten", Item.Ten);
                c.Values.Add("CQID", Item.CQ_ID.ToString());
                HttpContext.Current.Response.Cookies.Add(c);
            }
            else if (ReUser.ToLower() == "false")
            {
                c.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(c);
            }
            return isOke;
        }
        public static void LogOut()
        {
            HttpContext.Current.Session[sessionName] = null;
            HttpCookie c = new HttpCookie(cookieName);
            c.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(c);
        }
        public static bool LoginApi(string username, string pwd)
        {
            bool isOke = false;
            if (username == null || pwd == null)
            {
                return isOke;
            }
            var item = MemberDal.SelectByUsername(username);
            item.Username = username;
            if (item.Password != null)
            {
                if ((item.Password == maHoa.MD5Encrypt(pwd)) || (maHoa.DecryptString(item.Password, username) == pwd))
                {
                    isOke = true;
                }

            }
            return isOke;
        }

    }


}
