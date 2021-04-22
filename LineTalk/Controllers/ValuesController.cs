using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LineTalk.Controllers
{
    public class ValuesController : ApiController
    {
        /// <summary>
        /// Line機器人回覆API
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Post()
        {
            string MyLineChannelAccessToken = "i8eIyvfI2ON7bE37AoRsiMeKyHau7PKeZsKwGWiHnu5/WsKXbSrPs0AO2uECfYoKupclRTRsrW3nhzsXFXkqw5yIFDKrZlGahkLBu1bKuWMVthu44FGdQY5JnGbU3XcxZP6tSn7EacfZTitKj9ZMxgdB04t89/1O/w1cDnyilFU=";

            try
            {
                //取得 http Post RawData(should be JSON)
                string postData = Request.Content.ReadAsStringAsync().Result;
                //剖析JSON
                var ReceivedMessage = isRock.LineBot.Utility.Parsing(postData);
                //回覆訊息
                string Message;
                Message = string.Format("現在時間:{0}  您說了:{1}", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"), ReceivedMessage.events[0].message.text);
                //回覆用戶
                isRock.LineBot.Utility.ReplyMessage(ReceivedMessage.events[0].replyToken, Message, MyLineChannelAccessToken);
                //回覆API OK
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }
    }
}
