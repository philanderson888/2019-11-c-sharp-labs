# Day 31 - Http

# Http

Using .NET we can read and write to the web.

`WebClient` can be used to trivially download data

Let's begin by just downloading some complete files then we can move onto streaming

We can do this via SYNCHRONOUS or ASYNCHRONOUS methods

SYNCHRONOUS : WAIT
ASYNCH : DON'T WAIT BUT JUST LET DATA ARRIVE BUT IT DOES NOT 'HANG' OUR CODE

Web Terms (Networking!)

IP Address	1.2.3.4 0<n<255
Port	Channel for data to flow down to IP
2^16 ports = 65536
Client	machine making the request
Server	machine responding to the request
URL	https:// link Uniform Resource Locator
URI	Uniform Resource Identifier (more specific)
Absolute path	full path [https://mydomain/mypage.html](https://mydomain/mypage.html)
Relative path end part ie mypage.html
Host / Hostname name of server/machine MYCOMPUTER
Common Ports	80	http UNENCRYPTED WEB
443 https ENCRYPTED WEB TRAFFIC (PADLOCK)
22 ssh LINUX SERVER
25 smtp EMAIL OUT
110 pop EMAIL IN
Proxy	agent ie don't go directly

    Client  ======================== Internet (normal)
    
    	Client ==> Proxy =============== Internet

    using System;
    using System.Net;
    using System.Diagnostics;
    
    namespace Lab_19_Http
    {
        class Program
        {
            static void Main(string[] args)
            {
                var uri = new Uri("https://www.bbc.co.uk/weather");
    
                Console.WriteLine($"Host is {uri.Host}, Port is {uri.Port}, Path is {uri.AbsolutePath}");
    
                // get page
    
                var webclient = new WebClient { Proxy = null };
                webclient.DownloadFile(uri, "localpage.html");
                // run the webpage locally
                //Process.Start("notepad.exe");
                //Process.Start("WinWord.exe");
                System.Threading.Thread.Sleep(3000);
                Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe",
                    "localpage.html");
    
            }
        }
    }