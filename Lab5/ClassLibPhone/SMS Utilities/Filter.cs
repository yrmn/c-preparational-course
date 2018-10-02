using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibPhone.Utilities;

namespace ClassLibPhone.SMS_Utilities {

    public static class Filter {

        public static string[] GetUniqueUsers(List<Message> msgList) {
            string[] uniqueUsers = msgList.GroupBy(m => m.User)
                .Select(grp => grp.First().User).ToArray();
            return uniqueUsers;
        }

        public static List<Message> FilterByUser(List<Message> msgList, string userName) {
            var res = msgList.Where(x => x.User.Equals(userName)).ToList();
            return res;
        }

        public static List<Message> FilterByText(List<Message> msgList, string text) {
            var res = msgList.Where(x => x.Text.Contains(text)).ToList();
            return res;
        }

        public static List<Message> FilterByDate(List<Message> msgList, DateTime dtFrom, DateTime dtTo) {
            var res = msgList.Where(x => x.ReceivingTime.TimeOfDay >= dtFrom.TimeOfDay && x.ReceivingTime.TimeOfDay <= dtTo.TimeOfDay).ToList();
            return res;
        }
        
        public static List<Message> FilterAND(List<Message> msgList, bool isUser, bool isText, bool isDate, string name,
            string text, DateTime dtFrom, DateTime dtTo) {
            var res = msgList;
            if (!String.IsNullOrEmpty(name) && isUser) {
                res = Filter.FilterByUser(msgList, name);
            }
            if (isText) {
                res = Filter.FilterByText(res, text);
            }
            if (isDate) {
                res = Filter.FilterByDate(res, dtFrom, dtTo);
            }
            return res;
        }
        
        public static List<Message> FilterOR(List<Message> msgList, bool isUser, bool isText, bool isDate, string name, 
            string text, DateTime dtFrom, DateTime dtTo) {
            var filteredByUser = new List<Message>();
            var filteredByText = new List<Message>();
            var filteredByDate = new List<Message>();
            if (!String.IsNullOrEmpty(name) && isUser) {
                filteredByUser = FilterByUser(msgList, name);
            }
            if (isText) {
                filteredByText = FilterByText(msgList, text);
            }
            if (isDate) {
                filteredByDate = FilterByDate(msgList, dtFrom, dtTo);
            }
            filteredByUser.AddRange(filteredByText);
            filteredByUser.AddRange(filteredByDate);
            var res = filteredByUser.Distinct().ToList();
            return res;
        }
        
    }

}
