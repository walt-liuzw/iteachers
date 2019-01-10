using System;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iteachers.web.Controllers
{
    public class WeiXinController : Controller
    {

        #region 系统自带
        // GET: WeiXin
        public ActionResult Index()
        {
            return View();
        }

        // GET: WeiXin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WeiXin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeiXin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WeiXin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WeiXin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WeiXin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WeiXin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion 

        /// <summary>
        /// 验证微信签名
        /// </summary>
        /// * 将token、timestamp、nonce三个参数进行字典序排序
        /// * 将三个参数字符串拼接成一个字符串进行sha1加密
        /// * 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。
        /// <returns></returns>
        [HttpGet]
        public ActionResult WeChatCheck(string signature, string timestamp, string nonce, string echostr, string token)
        {
            string[] ArrTmp = { "wechat", timestamp, nonce };
            //字典排序
            Array.Sort(ArrTmp);
            string tmpStr = string.Join("", ArrTmp);
            //字符加密
            var sha1 = HmacSha1Sign(tmpStr);
            if (sha1.Equals(signature))
            {
                return Content(echostr);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// HMAC-SHA1加密算法
        /// </summary>
        /// <param name="str">加密字符串</param>
        /// <returns></returns>
        public string HmacSha1Sign(string str)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var hash = sha1.ComputeHash(Encoding.Default.GetBytes(str));
            string byte2String = null;
            for (int i = 0; i < hash.Length; i++)
            {
                byte2String += hash[i].ToString("x2");
            }
            return byte2String;
        }
    }
}