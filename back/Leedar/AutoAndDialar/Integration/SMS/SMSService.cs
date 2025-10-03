using Microsoft.Exchange.WebServices.Data;

using Shared.DTOs.SMS;
using Shared.Extensions;
using Shared.Interfaces.Services;
using Shared.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Integration.SMS
{
    public class SMSService : ISMSService
    {
       
        public SMSService()
        {
            
        }
        public async Task<string> SendSMS(SMSSendViewModel model)
        {
            try
            {
               // https://api.goinfinito.me/unified/v2/send?clientid=Smartlinkxptd43xiumzjzmm&clientpassword=kf0a7u8gg1etwgrzmig8jo6hk4lzf6q0&to=966583154674&from=SmartLink&text=Testing
                var requstUrl = "https://api.goinfinito.me/unified/v2/send?clientid=Smartlinkxptd43xiumzjzmm&clientpassword=kf0a7u8gg1etwgrzmig8jo6hk4lzf6q0" + "&to=" +
                                model.To + "&from=" + "SmartLink" + "&text=" + model.Message;

                using (HttpClient httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(requstUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return "message sent Successfully";
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        //List<string> errors = new List<string>();
                        //errors.Add(error);
                        return error;
                    }
                }
            }
            catch (Exception ex)
            {
                {
                    var error = ex.Message;
                    //List<string> errors = new List<string>();
                    //errors.Add(error);
                    return error;
                }

            }
        }

    }
}
