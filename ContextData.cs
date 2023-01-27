using System;

public string ContextData()
{

    string user_agent = HttpContext.Request.UserAgent;
    string url = HttpContext.Request.RawUrl;
    string ip = HttpContext.Request.UserHostAddress;
    string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
    return "<p>User-Agent: "+user_agent+"</p><p>Url запроса: "+url+
        "</p><p>Реферер: " + referrer + "</p><p>IP-адрес: "+ip+"</p>";
}
