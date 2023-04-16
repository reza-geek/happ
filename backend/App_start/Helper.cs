using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
//using System.Web.Http.Controllers;
//using System.Web.Http.ModelBinding;
//using TCI_Callcenter118_DBService.App_Start.DbModels;
//using TCI_Callcenter118_DBService.Services.Interfaces;
using System.IO;

namespace backend.App_start
{
    public static class Helper
    {
        public static string GetSha256FromString(string strData)
        {
            var message = Encoding.UTF8.GetBytes(strData);
            SHA256Managed hashString = new SHA256Managed();
            string hex = "";

            var hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += $"{x:x2}";
            }
            return hex;
        }

        //public static bool HasPermissionToCurrentAction(this UserLogin loggedUser, IUnitOfWorkProfile uowProfile, HttpActionContext actionContext)
        //{
        //    var allRoles = loggedUser.User.UserRoles.Select(x => x.Role.Id).ToList();
        //    var allPerms = uowProfile.Set<RoleApiPermission>().Where(x => allRoles.Contains(x.RoleId)).ToList();
        //    if (!allPerms.Any()) return false;
        //    var requestController = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
        //    var requestAction = actionContext.ActionDescriptor.ActionName;
        //    //return allPerms.Any(x => (x.Controller == requestController || x.Controller == "*") && (x.Action == requestAction || x.Action == "*"));
        //    return allPerms.Any(x => x.ActionType.Description == $"{requestController}/{requestAction}");
        //}

        public static string ToTitleCase(this string str)
        {
            var textInfo = new CultureInfo("en-US").TextInfo;
            var titleCaseStr = textInfo.ToTitleCase(str);
            return titleCaseStr;
        }

        public static string ConvertToPersianDate(this DateTime date)
        {
            var cal = new PersianCalendar();
            return cal.GetYear(date) + "/" + cal.GetMonth(date).ToString("00") + "/" +
                   cal.GetDayOfMonth(date).ToString("00");
        }

        public static string ConvertToPersianDate(this DateTime? date)
        {
            if (!date.HasValue) return string.Empty;
            return date.Value.ConvertToPersianDate();
        }

        //public static string GetClientIp(this HttpRequestBase request)
        //{
        //    string ip = request.UserHostAddress;
        //    return ip;
        //}

        //public static string GetModelStateErrors(this ModelStateDictionary state)
        //{
        //    var errors = state.Values.SelectMany(e => e.Errors.Select((er, i) => !string.IsNullOrEmpty(er.ErrorMessage) ? er.ErrorMessage : er.Exception.Message));
        //    return string.Join("<br>", errors.Select((x, i) => $"{i + 1} - {x}"));
        //}

        public static string ApplyCorrectYeKe(this string data)
        {
            return string.IsNullOrWhiteSpace(data)
                ? string.Empty
                : data.Replace((char)1610, (char)1740).Replace((char)1603, (char)1705).Trim();
        }

        public static int GetWeekNumberOfMonth(DateTime date)
        {
            date = date.Date;
            DateTime firstMonthDay = new DateTime(date.Year, date.Month, 1);
            DateTime firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            if (firstMonthMonday > date)
            {
                firstMonthDay = firstMonthDay.AddMonths(-1);
                firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            }
            return (date - firstMonthMonday).Days / 7 + 1;
        }

        public static bool IsNumber(this string data)
        {
            return !string.IsNullOrWhiteSpace(data) && data.All(char.IsDigit);
        }

        //public static T DeepClone<T>(this T obj) where T : new()
        //{
        //    var newEntity = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj, new JsonSerializerSettings
        //    {
        //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //    }));
        //    return newEntity;
        //}

        public static bool IsValidIranianNationalCode(this string nationalCode)
        {
            if (string.IsNullOrWhiteSpace(nationalCode))
            {
                return false;
            }

            nationalCode = nationalCode.PadLeft(10, '0');

            const int nationalCodeLength = 10;
            if (nationalCode.Length != nationalCodeLength)
            {
                return false;
            }

            if (!nationalCode.IsNumber())
            {
                return false;
            }

            var j = nationalCodeLength;
            var sum = 0;
            for (var i = 0; i < nationalCode.Length - 1; i++)
            {
                sum += (int)char.GetNumericValue(nationalCode[i]) * j--;
            }

            var remainder = sum % 11;
            var controlNumber = (int)char.GetNumericValue(nationalCode[9]);
            return remainder < 2 && controlNumber == remainder ||
                   remainder >= 2 && controlNumber == 11 - remainder;
        }

        //public static IEnumerable<Callcenter118Region> ToCallcenterDbData(this IEnumerable<Profile118Region> obj)
        //{
        //    foreach (var item in obj)
        //    {
        //        yield return item;
        //    }
        //}

        //public static IEnumerable<Callcenter118Metadata> ToCallcenterDbData(this IEnumerable<Profile118Metadata> obj)
        //{
        //    foreach (var item in obj)
        //    {
        //        yield return item;
        //    }
        //}

        //public static IEnumerable<Callcenter118Address> ToCallcenterDbData(this IEnumerable<Profile118Address> obj)
        //{
        //    foreach (var item in obj)
        //    {
        //        yield return item;
        //    }
        //}

        public static T ToType<T>(this object obj)
        {
            return (T)obj;
        }

        public static bool ReCaptchaPassed(string gRecaptchaResponse)
        {
            HttpClient httpClient = new HttpClient();

            var res = httpClient.GetAsync(
                 string.Format("https://www.google.com/recaptcha/api/siteverify?secret=6Ld_wtwUAAAAAJ2YdoJtgBix577LwQjC47eZ6ljq&response={0}", gRecaptchaResponse))
                 .Result;
            //string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}",
            //  ConfigurationManager.AppSettings["reCaptcha_SecretKey"], gRecaptchaResponse))
            //.Result;

            if (res.StatusCode != HttpStatusCode.OK)
            {
                return false;
            }
            string JSONres = res.Content.ReadAsStringAsync().Result;
            dynamic JSONdata = JObject.Parse(JSONres);

            if (JSONdata.success != "true" || JSONdata.score <= 0.5m)
            {
                return false;
            }

            return true;
        }

        public static string getErrorMessage(Exception e)
        {
            var messages = new List<string>();
            do
            {
                messages.Add(e.Message);
                e = e.InnerException;
            }
            while (e != null);
            var message = string.Join(" *+* ", messages);

            return message;

            //if (e.InnerException != null)
            //    return getErrorMessage(e.InnerException);
            //else
            //    return e.Message;
        }

        public static string Post(Uri url, string value)
        {
            var request = HttpWebRequest.Create(url);
            var byteData = Encoding.UTF8.GetBytes(value);

            request.ContentType = "application/json";
            request.Method = "POST";

            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(byteData, 0, byteData.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return responseString;
            }
            catch (WebException e)
            {
                throw e;
            }
        }

        public static string Get(Uri url)
        {
            var request = HttpWebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "GET";

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return responseString;
            }
            catch (WebException e)
            {
                throw e;
            }
        }

    }
}
